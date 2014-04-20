using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFSExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = @"C:\LDJ\data\graphic";
            openFileDialog.DefaultExt = "ifs";
            var dialogResult = openFileDialog.ShowDialog();
            listBox1.Items.Clear();

            if (dialogResult != DialogResult.OK) {
                return;
            }

            var stream = openFileDialog.OpenFile();
            var mappings = ParseIFS(stream);

            foreach (var mapping in mappings) {
                listBox1.Items.Add(new ImageItem(mapping));
            }
        }

        private class ImageItem
        {
            private readonly FileIndex _fileIndex;

            internal ImageItem(FileIndex fileIndex)
            {
                _fileIndex = fileIndex;
            }

            public override string ToString()
            {
                return string.Format("#{0} ({1})", _fileIndex.EntryNumber, _fileIndex.Size);
            }

            internal void Draw(Label label, Graphics graphics)
            {
                var rawBytes = DecompressLSZZ(_fileIndex.Read());
                DecodedRaw raw;

                try {
                    raw = DecodeRaw(rawBytes);
                } catch (Exception e) {
                    label.Text = string.Format("Couldn't decode raw #{0}: {1}", _fileIndex.EntryNumber, e);
                    return;
                }

                label.Text = string.Format("#{0}: {1} bytes decompresses to {2} bytes", _fileIndex.EntryNumber,
                                           _fileIndex.Size, rawBytes.Length);

                var index = raw.IndexSize / 2;
                var size = raw.GetSize(index);

                for (var y = 0; y < size.Item2; ++y) {
                    
                for (var x = 0; x < size.Item1; ++x) {
                    int argb = raw.GetARGB(index, x, y);
                    var color = Color.FromArgb(argb);
                    var solidBrush = new SolidBrush(color);
                    graphics.FillRectangle(solidBrush, x, y, 1, 1);
                }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var imageItem = (ImageItem) listBox1.SelectedItem;

            if (imageItem != null) {
                imageItem.Draw(label1, e.Graphics);
            }
        }

        private static IEnumerable<FileIndex> ParseIFS(Stream stream)
        {
            stream.Seek(16, SeekOrigin.Begin);
            var fIndex = ReadInt(stream);
            stream.Seek(40, SeekOrigin.Begin);
            var fHeader = ReadInt(stream);

            if (fHeader%4 != 0) {
                throw new ArgumentException("fHeader%4 != 0");
            }

            stream.Seek(fHeader + 72, SeekOrigin.Begin);

            var packet = new byte[4];
            var zeroPadArray = new byte[] {0, 0, 0, 0};
            var separator = new byte[] {0, 0, 0, 0};
            var sepInit = false;
            var zeroPad = false;
            var entryNumber = 0;

            var fileMappings = new List<FileIndex>();

            while (stream.Position < fIndex) {
                stream.Read(packet, 0, 4);

                if (stream.Position >= fIndex) {
                    break;
                }

                if (!sepInit || ByteArrayEqual(separator, zeroPadArray)) {
                    if (!ByteArrayEqual(packet, zeroPadArray)) {
                        packet.CopyTo(separator, 0);
                        sepInit = true;
                        continue;
                    }
                } else {
                    if (separator[0] == packet[0]) {
                        continue;
                    }

                    if (ByteArrayEqual(packet, zeroPadArray)) {
                        if (zeroPad) {
                            continue;
                        }
                        zeroPad = true;
                    }
                }

                var index = ReadInt(packet);

                if (stream.Position >= fIndex) {
                    break;
                }

                var size = ReadInt(stream);
                if (size > 0) {
                    fileMappings.Add(new FileIndex(stream, fIndex + index, size, entryNumber++));
                }
            }

            return fileMappings;
        }

        private static byte[] DecompressLSZZ(byte[] bytes)
        {
            using (MemoryStream inStream = new MemoryStream(bytes),
                                outStream = new MemoryStream(bytes.Length*2)) {
                inStream.Seek(8, SeekOrigin.Begin);

                var ctrlLen = 0;
                var ctrl = 0;
                var dect = new List<int>();

                int data;
                while ((data = inStream.ReadByte()) != -1) {
                    if (ctrlLen == 0) {
                        ctrl = data;
                        ctrlLen = 8;
                        continue;
                    }

                    if ((ctrl & 0x01) == 0x01) {
                        outStream.WriteByte((byte) data);
                        dect.Add(data);
                        ctrl = ctrl >> 1;
                        --ctrlLen;
                        continue;
                    }

                    var cmd0 = data;
                    var cmd1 = inStream.ReadByte();

                    if (cmd1 == -1) {
                        break;
                    }

                    var chLen = (cmd1 & 0x0f) + 3;
                    var chOff = ((cmd0 & 0xff) << 4) | ((cmd1 & 0xf0) >> 4);
                    var index = dect.Count - chOff;

                    var dest = new List<int>();
                    for (var i = 0; i < chLen; ++i, ++index) {
                        if (index >= dect.Count) {
                            if (chOff == 0) {
                                break;
                            }
                            index = dect.Count - chOff;
                        }
                        if (index < 0) {
                            outStream.WriteByte(0x00);
                            dest.Add(0);
                        } else {
                            var decVal = dect[index];
                            outStream.WriteByte((byte) decVal);
                            dest.Add(decVal);
                        }
                    }

                    dect.AddRange(dest);
                    dest.Clear();

                    const int decSize = 0x1000;
                    if (dect.Count >= decSize) {
                        dect.RemoveRange(0, dect.Count - decSize + 1);
                    }

                    ctrl = ctrl >> 1;
                    --ctrlLen;
                }

                return outStream.ToArray();
            }
        }

        private static DecodedRaw DecodeRaw(byte[] raw)
        {
            var fileSize = raw.Length;

            if (fileSize == 0 || (fileSize%4) != 0) {
                throw new ArgumentException("raw");
            }

            var argbSize = fileSize >> 2;
            var argbArr = new int[argbSize];

            using (var stream = new MemoryStream(raw)) {
                var data = new byte[4];
                var index = 0;
                while (stream.Read(data, 0, 4) == 4) {
                    argbArr[index++] = (data[3] << 24) | (data[2] << 16) | (data[1] << 8) | data[0];
                }

                var offset = 0;
                if (argbArr[0] == 0x54584454) {
                    // XXX: or 0x54445854?
                    offset = 16;
                }

                var set = new SortedSet<int>();
                for (var i = 1; i <= (int) Math.Sqrt(argbSize); ++i) {
                    if (argbSize%i != 0) {
                        continue;
                    }
                    set.Add(i);
                    set.Add(argbSize/i);
                }

                var indexSize = set.Count;
                var widths = new int[indexSize];
                var heights = new int[indexSize];
                var k = 0;

                foreach (var i in set) {
                    widths[k] = i;
                    heights[indexSize - k - 1] = i;
                    ++k;
                }

                return new DecodedRaw(offset, argbArr, widths, heights);
            }
        }

        private static int ReadInt(Stream stream)
        {
            var bytes = new byte[4];
            stream.Read(bytes, 0, 4);
            return ReadInt(bytes);
        }

        private static int ReadInt(byte[] bytes)
        {
            var r = 0;
            for (var i = 0; i < 4; ++i) {
                r = (r << 8) + bytes[i];
            }

            return r;
        }

        private static bool ByteArrayEqual(byte[] a, byte[] b)
        {
            var aLen = a.Length;
            if (aLen != b.Length) {
                return false;
            }
            for (var i = 0; i < aLen; ++i) {
                if (a[i] != b[i]) {
                    return false;
                }
            }
            return true;
        }
    }

    internal class DecodedRaw
    {
        private readonly int _offset;
        private readonly int[] _argbArr;
        private readonly int[] _widths;
        private readonly int[] _heights;

        internal int IndexSize { get { return _widths.Length; } }

        internal DecodedRaw(int offset, int[] argbArr, int[] widths, int[] heights)
        {
            _heights = heights;
            _widths = widths;
            _argbArr = argbArr;
            _offset = offset;
        }

        internal Tuple<int, int> GetSize(int index)
        {
            return new Tuple<int, int>(_widths[index], _heights[index]);
        }

        internal int GetARGB(int index, int x, int y)
        {
            return _argbArr[(y*_widths[index]) + x + _offset];
        }
    }

    internal class FileIndex {
        private readonly Stream _stream;

        private readonly int _index;
        internal readonly int Size;
        internal readonly int EntryNumber;

        internal FileIndex(Stream stream, int index, int size, int entryNumber)
        {
            _stream = stream;
            EntryNumber = entryNumber;
            Size = size;
            _index = index;
        }

        internal byte[] Read()
        {
            _stream.Seek(_index, SeekOrigin.Begin);
            var r = new byte[Size];
            _stream.Read(r, 0, Size);
            return r;
        }
    }
}
