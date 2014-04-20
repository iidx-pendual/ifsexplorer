using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IFSExplorer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = @"C:\LDJ\data\graphic";
            openFileDialog.DefaultExt = "ifs";
            var dialogResult = openFileDialog.ShowDialog();
            listboxImages.Items.Clear();

            if (dialogResult != DialogResult.OK) {
                return;
            }

            var stream = openFileDialog.OpenFile();
            var mappings = IFSUtils.ParseIFS(stream);

            foreach (var mapping in mappings) {
                listboxImages.Items.Add(new ImageItem(mapping));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updownIndexSelect.Minimum = 0;
            updownIndexSelect.Value = 0;
            updownIndexSelect.Maximum = 0;
            updownIndexSelect.Visible = true;
            pictureboxPreview.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var imageItem = (ImageItem) listboxImages.SelectedItem;

            if (imageItem != null) {
                imageItem.Draw(updownIndexSelect, labelStatus, e.Graphics);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pictureboxPreview.Refresh();
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

            internal void Draw(NumericUpDown numericUpDown, Label label, Graphics graphics)
            {
                var rawBytes = IFSUtils.DecompressLSZZ(_fileIndex.Read());
                DecodedRaw raw;

                try {
                    raw = IFSUtils.DecodeRaw(rawBytes);
                } catch (Exception e) {
                    label.Text = string.Format("Couldn't decode raw #{0}: {1}", _fileIndex.EntryNumber, e);
                    return;
                }

                if (numericUpDown.Maximum == 0) {
                    numericUpDown.Maximum = raw.IndexSize - 1;
                    numericUpDown.Value = (int) (((decimal) raw.IndexSize)/2);
                }
                var index = (int) numericUpDown.Value;
                var size = raw.GetSize(index);

                label.Text = string.Format("#{0}: {1} bytes decompresses to {2} bytes (index {3} = {4}x{5})",
                                           _fileIndex.EntryNumber,
                                           _fileIndex.Size, rawBytes.Length, index, size.Item1, size.Item2);

                var colors = new Dictionary<int, SolidBrush>();

                try {
                    for (var y = 0; y < size.Item2; ++y) {
                        for (var x = 0; x < size.Item1; ++x) {
                            var argb = raw.GetARGB(index, x, y);
                            var color = Color.FromArgb(argb);

                            SolidBrush brush;
                            if (!colors.TryGetValue(argb, out brush)) {
                                brush = new SolidBrush(color);
                                colors[argb] = brush;
                            }
                            graphics.FillRectangle(brush, x, y, 1, 1);
                        }
                    }
                } finally {
                    foreach (var pair in colors) {
                        pair.Value.Dispose();
                    }
                }
            }
        }
    }
}