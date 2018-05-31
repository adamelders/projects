using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Chat_to_Callsheet_Tool.Properties;

namespace Chat_to_Callsheet_Tool {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        // Starting mouse position, so we can restore after the macro.
        private int mouseStartPosX = 0;
        private int mouseStartPosY = 0;

        // Create variables for storing chat data.
        private string customerId, customerName, question;

        // Mouse actions.
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        // Mouse event from user32.dll to handle clicks.
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        // Move the mouse to specified X, Y coordinates (set in Setup form).
        private void MoveMouse(int xPos, int yPos) => Cursor.Position = new System.Drawing.Point(xPos, yPos);

        // Perform a left click on the mouse at current position.
        private void PerformLeftClick() => mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

        // Perform a right click on the mouse at current position.
        private void PerformRightClick() => mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);

        // Send Copy command (Ctrl + C) keystroke.
        private void SendCopy() {
            SendKeys.Send("^C");
        }

        // Send Paste command (Ctrl + P) keystroke.
        private void SendPaste() {
            SendKeys.Send("^V");
        }

        // We have to assume that "Copy current cell" option is below and slightly to the right.
        // Otherwise, the user will have to enter coordinates for each drop-down. This should
        // suffice in most situations.
        private void CompensateForCopyCell(int xPos, int yPos, out int newXPos, out int newYPos) {

            // Add/subtract to xPos
            newXPos = xPos < 0 ? xPos + 38 : xPos - 38;
            // Add/subtract to yPos
            newYPos = yPos > 0 ? yPos + 11 : yPos - 11;
        }

        // Tries to parse the X, Y coordinates from Settings as Int32.
        private bool TryParseSettingCoords(string settingName, out int xPos, out int yPos) {

            bool successfulX = false;
            bool successfulY = false;

            // Try parsing setting values.
            if (Int32.TryParse(Settings.Default[settingName + "X"].ToString(), out xPos))
                successfulX = true;
            if (Int32.TryParse(Settings.Default[settingName + "Y"].ToString(), out yPos))
                successfulY = true;

            if (successfulX && successfulY)
                return true;
            else
                return false;
        }

        // When we can't parse the setting (i.e. they haven't been set), exit and show message to user.
        private void ShowSettingError() {

            MessageBox.Show(this, "Cannot read a coordinate setting. " +
                "Please make sure you have set all coordinates in the Setup menu.", "Failure",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Reset the mouse positions and clear chat data when we finish a macro.
        private void Reset() {
            mouseStartPosX = 0;
            mouseStartPosY = 0;
            customerId = null;
            customerName = null;
            question = null;
        }

        // Chat to Callsheet button handler
        private void chatToCallsheetButton_Click(object sender, EventArgs e) {

            try {

                // Get current mouse position, so we can restore it later.
                mouseStartPosX = Cursor.Position.X;
                mouseStartPosY = Cursor.Position.Y;

                // Customer ID
                if (TryParseSettingCoords("ChatCustId", out int chatCustIdX, out int chatCustIdY)) {

                    // Move to Customer box.
                    MoveMouse(chatCustIdX, chatCustIdY);
                    PerformLeftClick();
                    Thread.Sleep(300);

                    // Right click, move, and copy current cell.
                    CompensateForCopyCell(chatCustIdX, chatCustIdY, out int copyXPos, out int copyYPos);
                    PerformRightClick();
                    Thread.Sleep(300);
                    MoveMouse(copyXPos, copyYPos);
                    PerformLeftClick();
                    Thread.Sleep(300);

                    // Save clipboard text as customer ID.
                    //customerId = Clipboard.GetText();
                    //DEBUG
                    customerId = "914492";
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Customer Name
                if (TryParseSettingCoords("ChatCustName", out int chatCustNameX, out int chatCustNameY)) {

                    // Move to Name box.
                    MoveMouse(chatCustNameX, chatCustNameY);
                    PerformLeftClick();
                    Thread.Sleep(300);

                    // Right click, move, and copy current cell.
                    CompensateForCopyCell(chatCustNameX, chatCustNameY, out int copyXPos, out int copyYPos);
                    PerformRightClick();
                    Thread.Sleep(300);
                    MoveMouse(copyXPos, copyYPos);
                    PerformLeftClick();
                    Thread.Sleep(300);

                    // Save clipboard text as customer name.
                    customerName = Clipboard.GetText();
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Query (Problem)
                if (TryParseSettingCoords("ChatProblem", out int chatProblemX, out int chatProblemY)) {

                    // Move to Query box.
                    MoveMouse(chatProblemX, chatProblemY);
                    PerformLeftClick();
                    Thread.Sleep(300);

                    // Right click, move, and copy current cell.
                    CompensateForCopyCell(chatProblemX, chatProblemY, out int copyXPos, out int copyYPos);
                    PerformRightClick();
                    Thread.Sleep(300);
                    MoveMouse(copyXPos, copyYPos);
                    PerformLeftClick();
                    Thread.Sleep(300);

                    // Save clipboard text as customer problem/question.
                    question = Clipboard.GetText();
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Now we have the chat data, we need to move it to the callsheet.

                // First, click "New" or "Reset Form" so we have an empty form.
                if (TryParseSettingCoords("CallsheetNew", out int callNewX, out int callNewY)) {

                    // Move to New and click.
                    MoveMouse(callNewX, callNewY);
                    PerformLeftClick();
                    Thread.Sleep(1500); // Wait for callsheet to refresh with new call form.
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Customer ID
                if (TryParseSettingCoords("CallsheetCustId", out int callCustIdX, out int callCustIdY)) {

                    // Move to Cust ID box.
                    MoveMouse(callCustIdX, callCustIdY);
                    PerformLeftClick();

                    // Set Clipboard data.
                    Clipboard.Clear();
                    Clipboard.SetText(customerId);
                    Thread.Sleep(300); // Make sure we don't paste before clipboard data is set.

                    // Paste customer ID.
                    SendPaste();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Customer Name
                if (TryParseSettingCoords("CallsheetCustName", out int callCustNameX, out int callCustNameY)) {

                    // Move to Customer box.
                    MoveMouse(callCustNameX, callCustNameY);
                    PerformLeftClick();

                    // Set Clipboard data.
                    Clipboard.Clear();
                    Clipboard.SetText(customerName);
                    Thread.Sleep(300); // Make sure we don't paste before clipboard data is set.

                    // Paste customer name.
                    SendPaste();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Query/Question/Problem
                if (TryParseSettingCoords("CallsheetProblem", out int callProblemX, out int callProblemY)) {

                    // Move to Problem box.
                    MoveMouse(callProblemX, callProblemY);
                    PerformLeftClick();

                    // Set Clipboard data.
                    Clipboard.Clear();
                    Clipboard.SetText(question);
                    Thread.Sleep(300); // Make sure we don't paste before clipboard data is set.

                    // Paste customer problem.
                    SendPaste();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Finally, we need to change Result to "chat", set In Progress, and Save.

                // Change Result to "chat".
                if (TryParseSettingCoords("CallsheetResult", out int callResultX, out int callResultY)) {

                    // Move to Result box.
                    MoveMouse(callResultX, callResultY);

                    // Click, select chat with keystrokes.
                    PerformLeftClick();
                    Thread.Sleep(300);
                    SendKeys.Send("C");
                    SendKeys.Send("C");
                    Thread.Sleep(300);
                    SendKeys.Send("{ENTER}");
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Change to In Progress.
                if (TryParseSettingCoords("CallsheetInProgress", out int callProgressX, out int callProgressY)) {

                    // Move to In Progress and click.
                    MoveMouse(callProgressX, callProgressY);
                    PerformLeftClick();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Finally, click Save.
                if (TryParseSettingCoords("CallsheetSave", out int callSaveX, out int callSaveY)) {

                    // Move to Save and click.
                    MoveMouse(callSaveX, callSaveY);
                    PerformLeftClick();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Move the mouse back to initial position.
                Cursor.Position = new System.Drawing.Point(mouseStartPosX, mouseStartPosY);

                // Reset chat data.
                Reset();
            }
            
            // This is only for debugging purposes and will be removed once testing is complete.
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
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
