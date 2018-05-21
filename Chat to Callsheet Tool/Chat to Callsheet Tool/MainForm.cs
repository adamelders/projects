using System;
using System.Windows.Forms;

namespace Chat_to_Callsheet_Tool {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void setupButton_Click(object sender, EventArgs e) {

            using (SetupForm setupForm = new SetupForm()) {
                setupForm.ShowDialog(this);
            }
        }
    }
}
