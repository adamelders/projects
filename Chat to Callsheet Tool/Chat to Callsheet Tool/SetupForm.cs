using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace Chat_to_Callsheet_Tool {
    public partial class SetupForm : Form {

        private IKeyboardMouseEvents globalHook;

        public SetupForm() {
            InitializeComponent();
        }

        private void chatCustIdSelectButton_Click(object sender, EventArgs e) {
            Subscribe("chatCustIdSelectButton");
        }

        private void chatCustNameSelectButton_Click(object sender, EventArgs e) {
            Subscribe("chatCustNameSelectButton");
        }

        private void Subscribe(string control) {

            // Make sure we aren't using the hook somewhere else
            Unsubscribe();

            // Create a new global hook
            globalHook = Hook.GlobalEvents();

            // Register events
            switch (control) {
                case "chatCustIdSelectButton":
                    globalHook.KeyPress += HookManager_Escape;
                    globalHook.MouseMove += ChatCustId_MouseMove;
                    break;
                case "chatCustNameSelectButton":
                    globalHook.KeyPress += HookManager_Escape;
                    globalHook.MouseMove += ChatCustName_MouseMove;
                    break;
                default:
                    globalHook.KeyPress += HookManager_Escape;
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
                    case "chatCustIdSelectButton":
                        globalHook.MouseMove -= ChatCustId_MouseMove;
                        break;
                    case "chatCustNameSelectButton":
                        globalHook.MouseMove -= ChatCustName_MouseMove;
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
    }
}
