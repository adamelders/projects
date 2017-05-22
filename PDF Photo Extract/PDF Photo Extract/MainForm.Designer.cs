namespace PDF_Photo_Extract {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.openFileTextBox = new System.Windows.Forms.TextBox();
            this.saveFileTextBox = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.FolderBrowserDialog();
            this.extractButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(313, 37);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(104, 23);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Open PDF";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(313, 87);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(104, 23);
            this.saveFileButton.TabIndex = 1;
            this.saveFileButton.Text = "Save In Folder...";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // openFileTextBox
            // 
            this.openFileTextBox.Location = new System.Drawing.Point(13, 39);
            this.openFileTextBox.Name = "openFileTextBox";
            this.openFileTextBox.Size = new System.Drawing.Size(294, 20);
            this.openFileTextBox.TabIndex = 2;
            // 
            // saveFileTextBox
            // 
            this.saveFileTextBox.Location = new System.Drawing.Point(13, 89);
            this.saveFileTextBox.Name = "saveFileTextBox";
            this.saveFileTextBox.Size = new System.Drawing.Size(294, 20);
            this.saveFileTextBox.TabIndex = 3;
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            this.openFile.Filter = "PDF Files (.pdf)|*.pdf";
            this.openFile.Title = "Open PDF file...";
            // 
            // saveFile
            // 
            this.saveFile.Description = "Choose a folder to be used for the extracted images.";
            // 
            // extractButton
            // 
            this.extractButton.Location = new System.Drawing.Point(112, 145);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(188, 23);
            this.extractButton.TabIndex = 4;
            this.extractButton.Text = "Extract Images From PDF";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.extractButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.extractButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 176);
            this.Controls.Add(this.extractButton);
            this.Controls.Add(this.saveFileTextBox);
            this.Controls.Add(this.openFileTextBox);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.openFileButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PDF Photo Extract";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.TextBox openFileTextBox;
        private System.Windows.Forms.TextBox saveFileTextBox;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.FolderBrowserDialog saveFile;
        private System.Windows.Forms.Button extractButton;
    }
}

