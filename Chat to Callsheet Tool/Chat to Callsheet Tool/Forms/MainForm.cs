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

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            using (HelpForm helpForm = new HelpForm()) {
                helpForm.ShowDialog(this);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            using (AboutForm aboutForm = new AboutForm()) {
                aboutForm.ShowDialog(this);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
