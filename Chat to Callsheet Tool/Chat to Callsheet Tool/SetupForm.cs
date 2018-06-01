using System;
using System.Windows.Forms;
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

        private void callsheetResetSelectButton_Click(object sender, EventArgs e) {
            Subscribe("callsheetResetSelectButton");
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

            callsheetResetXTextBox.Text = "";
            callsheetResetYTextBox.Text = "";
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
                case "callsheetResetSelectButton":
                    globalHook.MouseMove += CallsheetReset_MouseMove;
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
                        globalHook.MouseMove -= CallsheetReset_MouseMove;
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

        private void CallsheetReset_MouseMove(object sender, MouseEventArgs e) {

            // Set X and Y coordinates as the mouse moves.
            callsheetResetXTextBox.Text = e.X.ToString();
            callsheetResetYTextBox.Text = e.Y.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
