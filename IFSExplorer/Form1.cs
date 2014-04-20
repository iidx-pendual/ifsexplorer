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

            if (dialogResult != DialogResult.OK) {
                return;
            }

            using (var stream = openFileDialog.OpenFile()) {
                var mappings = ParseIFS(stream);

                foreach (var mapping in mappings) {
                    var bytes = mapping.Read();
                    var raw = DecompressLSZZ(bytes);
                    Debug.WriteLine("{0} bytes decompressed to {1}", bytes.Length, raw.Length);
                }
            }
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

        private static IEnumerable<FileIndex> ParseIFS(Stream stream)
        {
            stream.Seek(16, SeekOrigin.Begin);
            var fIndex = ReadInt(stream);
            stream.Seek(40, SeekOrigin.Begin);
            var fHeader = ReadInt(stream);

            stream.Seek(fHeader + 72, SeekOrigin.Begin);

            var packet = new byte[4];
            var zeroPadArray = new byte[] {0, 0, 0, 0};
            var separator = new byte[4];
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

                var index = ReadInt(stream);

                stream.Read(packet, 0, 4);

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

        private static int ReadInt(Stream stream)
        {
            var bytes = new byte[4];
            stream.Read(bytes, 0, 4);

            var r = 0;
            for (var i = 0; i < 4; ++i) {
                r = (r << 8) | bytes[i];
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

    internal class FileIndex {
        private readonly Stream _stream;

        private readonly int _index;
        private readonly int _size;
        internal readonly int EntryNumber;

        internal FileIndex(Stream stream, int index, int size, int entryNumber)
        {
            _stream = stream;
            EntryNumber = entryNumber;
            _size = size;
            _index = index;
        }

        internal byte[] Read(Stream stream = null)
        {
            stream = stream ?? _stream;

            stream.Seek(_index, SeekOrigin.Begin);
            var r = new byte[_size];
            stream.Read(r, 0, _size);
            return r;
        }
    }
}
