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
            this.chatToCallsheetButton = new System.Windows.Forms.Button();
            this.chatToCallsheetHotkeyButton = new System.Windows.Forms.Button();
            this.convertChatToCallHotkeyButton = new System.Windows.Forms.Button();
            this.convertChatToCallButton = new System.Windows.Forms.Button();
            this.setupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatToCallsheetButton
            // 
            this.chatToCallsheetButton.Location = new System.Drawing.Point(11, 13);
            this.chatToCallsheetButton.Name = "chatToCallsheetButton";
            this.chatToCallsheetButton.Size = new System.Drawing.Size(161, 44);
            this.chatToCallsheetButton.TabIndex = 0;
            this.chatToCallsheetButton.Text = "Chat To Callsheet";
            this.chatToCallsheetButton.UseVisualStyleBackColor = true;
            // 
            // chatToCallsheetHotkeyButton
            // 
            this.chatToCallsheetHotkeyButton.Location = new System.Drawing.Point(178, 13);
            this.chatToCallsheetHotkeyButton.Name = "chatToCallsheetHotkeyButton";
            this.chatToCallsheetHotkeyButton.Size = new System.Drawing.Size(88, 44);
            this.chatToCallsheetHotkeyButton.TabIndex = 1;
            this.chatToCallsheetHotkeyButton.Text = "Set Hotkey";
            this.chatToCallsheetHotkeyButton.UseVisualStyleBackColor = true;
            // 
            // convertChatToCallHotkeyButton
            // 
            this.convertChatToCallHotkeyButton.Location = new System.Drawing.Point(177, 63);
            this.convertChatToCallHotkeyButton.Name = "convertChatToCallHotkeyButton";
            this.convertChatToCallHotkeyButton.Size = new System.Drawing.Size(88, 44);
            this.convertChatToCallHotkeyButton.TabIndex = 3;
            this.convertChatToCallHotkeyButton.Text = "Set Hotkey";
            this.convertChatToCallHotkeyButton.UseVisualStyleBackColor = true;
            // 
            // convertChatToCallButton
            // 
            this.convertChatToCallButton.Location = new System.Drawing.Point(10, 63);
            this.convertChatToCallButton.Name = "convertChatToCallButton";
            this.convertChatToCallButton.Size = new System.Drawing.Size(161, 44);
            this.convertChatToCallButton.TabIndex = 2;
            this.convertChatToCallButton.Text = "Convert Chat to Call";
            this.convertChatToCallButton.UseVisualStyleBackColor = true;
            // 
            // setupButton
            // 
            this.setupButton.Location = new System.Drawing.Point(86, 131);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(105, 42);
            this.setupButton.TabIndex = 4;
            this.setupButton.Text = "Setup";
            this.setupButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 190);
            this.Controls.Add(this.setupButton);
            this.Controls.Add(this.convertChatToCallHotkeyButton);
            this.Controls.Add(this.convertChatToCallButton);
            this.Controls.Add(this.chatToCallsheetHotkeyButton);
            this.Controls.Add(this.chatToCallsheetButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button chatToCallsheetButton;
        private System.Windows.Forms.Button chatToCallsheetHotkeyButton;
        private System.Windows.Forms.Button convertChatToCallHotkeyButton;
        private System.Windows.Forms.Button convertChatToCallButton;
        private System.Windows.Forms.Button setupButton;
    }
}

