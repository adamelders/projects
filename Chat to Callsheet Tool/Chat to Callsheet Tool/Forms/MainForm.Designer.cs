namespace Chat_to_Callsheet_Tool {
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
            this.chatToCallsheetButton = new System.Windows.Forms.Button();
            this.chatToCallsheetHotkeyButton = new System.Windows.Forms.Button();
            this.convertChatToCallHotkeyButton = new System.Windows.Forms.Button();
            this.convertChatToCallButton = new System.Windows.Forms.Button();
            this.setupButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatToCallsheetButton
            // 
            this.chatToCallsheetButton.Location = new System.Drawing.Point(11, 30);
            this.chatToCallsheetButton.Name = "chatToCallsheetButton";
            this.chatToCallsheetButton.Size = new System.Drawing.Size(161, 44);
            this.chatToCallsheetButton.TabIndex = 0;
            this.chatToCallsheetButton.Text = "Chat To Callsheet";
            this.chatToCallsheetButton.UseVisualStyleBackColor = true;
            // 
            // chatToCallsheetHotkeyButton
            // 
            this.chatToCallsheetHotkeyButton.Location = new System.Drawing.Point(178, 30);
            this.chatToCallsheetHotkeyButton.Name = "chatToCallsheetHotkeyButton";
            this.chatToCallsheetHotkeyButton.Size = new System.Drawing.Size(88, 44);
            this.chatToCallsheetHotkeyButton.TabIndex = 1;
            this.chatToCallsheetHotkeyButton.Text = "Set Hotkey";
            this.chatToCallsheetHotkeyButton.UseVisualStyleBackColor = true;
            // 
            // convertChatToCallHotkeyButton
            // 
            this.convertChatToCallHotkeyButton.Location = new System.Drawing.Point(177, 80);
            this.convertChatToCallHotkeyButton.Name = "convertChatToCallHotkeyButton";
            this.convertChatToCallHotkeyButton.Size = new System.Drawing.Size(88, 44);
            this.convertChatToCallHotkeyButton.TabIndex = 3;
            this.convertChatToCallHotkeyButton.Text = "Set Hotkey";
            this.convertChatToCallHotkeyButton.UseVisualStyleBackColor = true;
            // 
            // convertChatToCallButton
            // 
            this.convertChatToCallButton.Location = new System.Drawing.Point(10, 80);
            this.convertChatToCallButton.Name = "convertChatToCallButton";
            this.convertChatToCallButton.Size = new System.Drawing.Size(161, 44);
            this.convertChatToCallButton.TabIndex = 2;
            this.convertChatToCallButton.Text = "Convert Chat to Call";
            this.convertChatToCallButton.UseVisualStyleBackColor = true;
            // 
            // setupButton
            // 
            this.setupButton.Location = new System.Drawing.Point(86, 148);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(105, 42);
            this.setupButton.TabIndex = 4;
            this.setupButton.Text = "Setup";
            this.setupButton.UseVisualStyleBackColor = true;
            this.setupButton.Click += new System.EventHandler(this.setupButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(276, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 200);
            this.Controls.Add(this.setupButton);
            this.Controls.Add(this.convertChatToCallHotkeyButton);
            this.Controls.Add(this.convertChatToCallButton);
            this.Controls.Add(this.chatToCallsheetHotkeyButton);
            this.Controls.Add(this.chatToCallsheetButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat to Callsheet Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chatToCallsheetButton;
        private System.Windows.Forms.Button chatToCallsheetHotkeyButton;
        private System.Windows.Forms.Button convertChatToCallHotkeyButton;
        private System.Windows.Forms.Button convertChatToCallButton;
        private System.Windows.Forms.Button setupButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

