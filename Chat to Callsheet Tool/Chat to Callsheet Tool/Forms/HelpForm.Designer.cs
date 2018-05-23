namespace Chat_to_Callsheet_Tool {
    partial class HelpForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.helpRichTextBox = new System.Windows.Forms.RichTextBox();
            this.closeHelpFormButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // helpRichTextBox
            // 
            this.helpRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.helpRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpRichTextBox.Location = new System.Drawing.Point(20, 20);
            this.helpRichTextBox.Name = "helpRichTextBox";
            this.helpRichTextBox.ReadOnly = true;
            this.helpRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.helpRichTextBox.Size = new System.Drawing.Size(658, 451);
            this.helpRichTextBox.TabIndex = 0;
            this.helpRichTextBox.Text = "";
            // 
            // closeHelpFormButton
            // 
            this.closeHelpFormButton.Location = new System.Drawing.Point(321, 489);
            this.closeHelpFormButton.Name = "closeHelpFormButton";
            this.closeHelpFormButton.Size = new System.Drawing.Size(75, 23);
            this.closeHelpFormButton.TabIndex = 1;
            this.closeHelpFormButton.Text = "OK";
            this.closeHelpFormButton.UseVisualStyleBackColor = true;
            this.closeHelpFormButton.Click += new System.EventHandler(this.closeHelpFormButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.helpRichTextBox);
            this.panel1.Location = new System.Drawing.Point(6, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.panel1.Size = new System.Drawing.Size(698, 481);
            this.panel1.TabIndex = 2;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 519);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.closeHelpFormButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox helpRichTextBox;
        private System.Windows.Forms.Button closeHelpFormButton;
        private System.Windows.Forms.Panel panel1;
    }
}