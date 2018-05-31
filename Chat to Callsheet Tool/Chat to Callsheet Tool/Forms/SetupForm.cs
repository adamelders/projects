using System;
using System.Windows.Forms;
using Chat_to_Callsheet_Tool.Properties;
using Gma.System.MouseKeyHook;

namespace Chat_to_Callsheet_Tool {
    public partial class SetupForm : Form {

        private IKeyboardMouseEvents globalHook;

        public SetupForm() {
            InitializeComponent();
        }

        /* +++++++++++++++    Chat window section    +++++++++++++++ */

        private void chatCustIdSelectButton_Click(object sender, EventArgs e) {
            Subscribe("chatCustIdSelectButton");
        }

        private void chatCustNameSelectButton_Click(object sender, EventArgs e) {
            Subscribe("chatCustNameSelectButton");
        }

        private void chatProblemSelectButton_Click(object sender, EventArgs e) {
            Subscribe("chatProblemSelectButton");
        }

        private void chatResetButton_Click(object sender, EventArgs e) {

            // Make sure we un-hook and un-register.
            Unsubscribe();

            // Clear all coordinates.
            chatCustIdXTextBox.Text = "";
            chatCustIdYTextBox.Text = "";

            chatCustNameXTextBox.Text = "";
            chatCustNameYTextBox.Text = "";

            chatProblemXTextBox.Text = "";
            chatProblemYTextBox.Text = "";

        }

        /* +++++++++++++++    Callsheet  window section    +++++++++++++++ */

        private void callsheetCustIdSelectButton_Click(object sender, EventArgs e) {
            Subscribe("callsheetCustIdSelectButton");
        }

        private void callsheetCustNameSelectButton_Click(object sender, EventArgs e) {
            Subscribe("callsheetCustNameSelectButton");
        }

        private void callsheetProblemSelectButton_Click(object sender, EventArgs e) {
            Subscribe("callsheetProblemSelectButton");
        }

        private void callsheetInProgressSelectButton_Click(object sender, EventArgs e) {
            Subscribe("callsheetInProgressSelectButton");
        }

        private void callsheetSaveSelectButton_Click(object sender, EventArgs e) {
            Subscribe("callsheetSaveSelectButton");
        }

        private void callsheetNewSelectButton_Click(object sender, EventArgs e) {
            Subscribe("callsheetNewSelectButton");
        }

        private void callsheetResultSelectButton_Click(object sender, EventArgs e) {
            Subscribe("callsheetResultSelectButton");
        }

        private void callsheetResetButton_Click(object sender, EventArgs e) {

            // Make sure we un-hook and un-register.
            Unsubscribe();

            // Clear all coordinates.
            callsheetCustIdXTextBox.Text = "";
            callsheetCustIdYTextBox.Text = "";

            callsheetCustNameXTextBox.Text = "";
            callsheetCustNameYTextBox.Text = "";

            callsheetProblemXTextBox.Text = "";
            callsheetProblemYTextBox.Text = "";

            callsheetInProgressXTextBox.Text = "";
            callsheetInProgressYTextBox.Text = "";

            callsheetSaveXTextBox.Text = "";
            callsheetSaveYTextBox.Text = "";

            callsheetNewXTextBox.Text = "";
            callsheetNewYTextBox.Text = "";

            callsheetResultXTextBox.Text = "";
            callsheetResultYTextBox.Text = "";
        }

        private void Subscribe(string control) {

            // Make sure we aren't using the hook somewhere else
            Unsubscribe();

            // Create a new global hook
            globalHook = Hook.GlobalEvents();

            // Register events
            globalHook.KeyPress += HookManager_Escape;

            switch (control) {
                // Chat window section
                case "chatCustIdSelectButton":
                    globalHook.MouseMove += ChatCustId_MouseMove;
                    break;
                case "chatCustNameSelectButton":
                    globalHook.MouseMove += ChatCustName_MouseMove;
                    break;
                case "chatProblemSelectButton":
                    globalHook.MouseMove += ChatProblem_MouseMove;
                    break;
                // Callsheet section
                case "callsheetCustIdSelectButton":
                    globalHook.MouseMove += CallsheetCustId_MouseMove;
                    break;
                case "callsheetCustNameSelectButton":
                    globalHook.MouseMove += CallsheetCustName_MouseMove;
                    break;
                case "callsheetProblemSelectButton":
                    globalHook.MouseMove += CallsheetProblem_MouseMove;
                    break;
                case "callsheetInProgressSelectButton":
                    globalHook.MouseMove += CallsheetInProgress_MouseMove;
                    break;
                case "callsheetSaveSelectButton":
                    globalHook.MouseMove += CallsheetSave_MouseMove;
                    break;
                case "callsheetNewSelectButton":
                    globalHook.MouseMove += CallsheetNew_MouseMove;
                    break;
                case "callsheetResultSelectButton":
                    globalHook.MouseMove += CallsheetResult_MouseMove;
                    break;
                default:
                    break;
            }
        }

        private void Unsubscribe(string control = "") {

            // Validation
            if (globalHook == null)
                return;

            // Unregister events
            globalHook.KeyPress -= HookManager_Escape;

            if (control.Length > 0) {
                switch (control) {
                    // Chat window section
                    case "chatCustIdSelectButton":
                        globalHook.MouseMove -= ChatCustId_MouseMove;
                        break;
                    case "chatCustNameSelectButton":
                        globalHook.MouseMove -= ChatCustName_MouseMove;
                        break;
                    case "chatProblemSelectButton":
                        globalHook.MouseMove -= ChatProblem_MouseMove;
                        break;
                    // Callsheet section
                    case "callsheetCustIdSelectButton":
                        globalHook.MouseMove -= CallsheetCustId_MouseMove;
                        break;
                    case "callsheetCustNameSelectButton":
                        globalHook.MouseMove -= CallsheetCustName_MouseMove;
                        break;
                    case "callsheetProblemSelectButton":
                        globalHook.MouseMove -= CallsheetProblem_MouseMove;
                        break;
                    case "callsheetInProgressSelectButton":
                        globalHook.MouseMove -= CallsheetInProgress_MouseMove;
                        break;
                    case "callsheetSaveSelectButton":
                        globalHook.MouseMove -= CallsheetSave_MouseMove;
                        break;
                    case "callsheetNewSelectButton":
                        globalHook.MouseMove -= CallsheetNew_MouseMove;
                        break;
                    case "callsheetResetSelectButton":
                        globalHook.MouseMove -= CallsheetResult_MouseMove;
                        break;
                    default:
                        break;
                }
            }

            // Dispose of hook
            globalHook.Dispose();
            globalHook = null;
        }

        private void HookManager_Escape(object sender, KeyPressEventArgs e) {

            // If the user presses escape, stop looking for mouse position.
            if (e.KeyChar == 27)
                Unsubscribe();
        }

        private void ChatCustId_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            chatCustIdXTextBox.Text = e.X.ToString();
            chatCustIdYTextBox.Text = e.Y.ToString();
        }

        private void ChatCustName_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            chatCustNameXTextBox.Text = e.X.ToString();
            chatCustNameYTextBox.Text = e.Y.ToString();
        }

        private void ChatProblem_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            chatProblemXTextBox.Text = e.X.ToString();
            chatProblemYTextBox.Text = e.Y.ToString();
        }

        private void CallsheetCustId_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            callsheetCustIdXTextBox.Text = e.X.ToString();
            callsheetCustIdYTextBox.Text = e.Y.ToString();
        }

        private void CallsheetCustName_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            callsheetCustNameXTextBox.Text = e.X.ToString();
            callsheetCustNameYTextBox.Text = e.Y.ToString();
        }

        private void CallsheetProblem_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            callsheetProblemXTextBox.Text = e.X.ToString();
            callsheetProblemYTextBox.Text = e.Y.ToString();
        }

        private void CallsheetInProgress_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            callsheetInProgressXTextBox.Text = e.X.ToString();
            callsheetInProgressYTextBox.Text = e.Y.ToString();
        }

        private void CallsheetSave_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            callsheetSaveXTextBox.Text = e.X.ToString();
            callsheetSaveYTextBox.Text = e.Y.ToString();
        }

        private void CallsheetNew_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            callsheetNewXTextBox.Text = e.X.ToString();
            callsheetNewYTextBox.Text = e.Y.ToString();
        }

        private void CallsheetResult_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            callsheetResultXTextBox.Text = e.X.ToString();
            callsheetResultYTextBox.Text = e.Y.ToString();
        }

        private void SaveSettings() {

            // Set all coordinates to Settings.
            Settings.Default.ChatCustIdX = chatCustIdXTextBox.Text;
            Settings.Default.ChatCustIdY = chatCustIdYTextBox.Text;

            Settings.Default.ChatCustNameX = chatCustNameXTextBox.Text;
            Settings.Default.ChatCustNameY = chatCustNameYTextBox.Text;

            Settings.Default.ChatProblemX = chatProblemXTextBox.Text;
            Settings.Default.ChatProblemY = chatProblemYTextBox.Text;

            Settings.Default.CallsheetCustIdX = callsheetCustIdXTextBox.Text;
            Settings.Default.CallsheetCustIdY = callsheetCustIdYTextBox.Text;

            Settings.Default.CallsheetCustNameX = callsheetCustNameXTextBox.Text;
            Settings.Default.CallsheetCustNameY = callsheetCustNameYTextBox.Text;

            Settings.Default.CallsheetInProgressX = callsheetInProgressXTextBox.Text;
            Settings.Default.CallsheetInProgressY = callsheetInProgressYTextBox.Text;

            Settings.Default.CallsheetNewX = callsheetNewXTextBox.Text;
            Settings.Default.CallsheetNewY = callsheetNewYTextBox.Text;

            Settings.Default.CallsheetProblemX = callsheetProblemXTextBox.Text;
            Settings.Default.CallsheetProblemY = callsheetProblemYTextBox.Text;

            Settings.Default.CallsheetResultX = callsheetResultXTextBox.Text;
            Settings.Default.CallsheetResultY = callsheetResultYTextBox.Text;

            Settings.Default.CallsheetSaveX = callsheetSaveXTextBox.Text;
            Settings.Default.CallsheetSaveY = callsheetSaveYTextBox.Text;

            // Save settings.
            Settings.Default.Save();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveSettings();
        }

        private void SetupForm_Load(object sender, EventArgs e) {

            // Load coordinates from Settings.
            chatCustIdXTextBox.Text = Settings.Default.ChatCustIdX;
            chatCustIdYTextBox.Text = Settings.Default.ChatCustIdY;

            chatCustNameXTextBox.Text = Settings.Default.ChatCustNameX;
            chatCustNameYTextBox.Text = Settings.Default.ChatCustNameY;

            chatProblemXTextBox.Text = Settings.Default.ChatProblemX;
            chatProblemYTextBox.Text = Settings.Default.ChatProblemY;

            callsheetCustIdXTextBox.Text = Settings.Default.CallsheetCustIdX;
            callsheetCustIdYTextBox.Text = Settings.Default.CallsheetCustIdY;

            callsheetCustNameXTextBox.Text = Settings.Default.CallsheetCustNameX;
            callsheetCustNameYTextBox.Text = Settings.Default.CallsheetCustNameY;

            callsheetInProgressXTextBox.Text = Settings.Default.CallsheetInProgressX;
            callsheetInProgressYTextBox.Text = Settings.Default.CallsheetInProgressY;

            callsheetNewXTextBox.Text = Settings.Default.CallsheetNewX;
            callsheetNewYTextBox.Text = Settings.Default.CallsheetNewY;

            callsheetProblemXTextBox.Text = Settings.Default.CallsheetProblemX;
            callsheetProblemYTextBox.Text = Settings.Default.CallsheetProblemY;

            callsheetResultXTextBox.Text = Settings.Default.CallsheetResultX;
            callsheetResultYTextBox.Text = Settings.Default.CallsheetResultY;

            callsheetSaveXTextBox.Text = Settings.Default.CallsheetSaveX;
            callsheetSaveYTextBox.Text = Settings.Default.CallsheetSaveY;
        }

        // Save settings when the Setup form closes.
        private void SetupForm_FormClosing(object sender, FormClosingEventArgs e) {
            SaveSettings();
        }

        // Show the About form.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            using (AboutForm aboutForm = new AboutForm()) {
                aboutForm.ShowDialog(this);
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            using (HelpForm helpForm = new HelpForm()) {
                helpForm.ShowDialog(this);
            }
        }
    }
}
