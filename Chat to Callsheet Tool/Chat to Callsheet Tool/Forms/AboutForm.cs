using System.Windows.Forms;

namespace Chat_to_Callsheet_Tool {
    public partial class AboutForm : Form {
        public AboutForm() {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, System.EventArgs e) {
            this.Close();
        }
    }
}
