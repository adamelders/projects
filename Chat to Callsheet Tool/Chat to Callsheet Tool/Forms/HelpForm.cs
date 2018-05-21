using System;
using System.Windows.Forms;

namespace Chat_to_Callsheet_Tool {
    public partial class HelpForm : Form {
        public HelpForm() {
            InitializeComponent();
        }

        private void closeHelpFormButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void HelpForm_Load(object sender, EventArgs e) {
            helpRichTextBox.LoadFile(@"../Debug/Resources/HelpText.rtf");
        }
    }
}
