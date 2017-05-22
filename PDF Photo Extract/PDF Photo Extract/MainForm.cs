/* ------------------------------------------------------------------------------
  PDF Photo Extract
  This tool will extract any images found in a single PDF file,
  and export them to a folder of the user's choosing.
 
  Copyright (C) 2016, 2017 Adam Elders
  Contact - Email: aelders@sfrep.com
  Full AGPL License can be found here: \<Installation Folder>\AGPL.txt
  For example: C:\Users\Adam\Desktop\PDF Photo Extract\AGPL.txt
  ------------------------------------------------------------------------------
  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU Affero General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.
 
  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
  GNU Affero General Public License for more details.

  You should have received a copy of the GNU Affero General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
  ------------------------------------------------------------------------------ */

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PDF_Photo_Extract {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private string fileToExtract;

        private void openFileButton_Click(object sender, EventArgs e) {
            if (openFile.ShowDialog() == DialogResult.OK) {
                fileToExtract = openFile.FileName;
                openFileTextBox.Text = fileToExtract;
            }
        }

        private void saveFileButton_Click(object sender, EventArgs e) {
            if (saveFile.ShowDialog() == DialogResult.OK) {
                saveFileTextBox.Text = saveFile.SelectedPath;
            }
        }

        private void extractButton_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(openFileTextBox.Text)) {
                if (!string.IsNullOrWhiteSpace(saveFileTextBox.Text)) {
                    try {
                        PdfImage.Helpers.ImageExtractor.ExtractImagesFromFile(fileToExtract, "ExtractedImage", saveFileTextBox.Text, true);

                        MessageBox.Show("All images have been extracted sucessfully.", "Images Extracted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Process p = Process.Start(saveFileTextBox.Text);
                        p?.Dispose();
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
    }
}
