using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Chat_to_Callsheet_Tool.Properties;
using Gma.System.MouseKeyHook;

namespace Chat_to_Callsheet_Tool {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        // Hotkey for Chat to Callsheet button
        private string chatToCallsheetHotkey;

        // Hotkey for Convert Chat to Call button
        private string convertChatToCallHotkey;

        // Actions and definitions for pressing buttons.
        private Action chatToCallsheet_Action;
        private Action convertChatToCall_Action;

        private void chatToCallsheet_Execute() {
            chatToCallsheetButton.PerformClick();
        }

        private void convertChatToCall_Execute() {
            convertChatToCallButton.PerformClick();
        }

        // Start listening for mouse/key events globally.
        private void Subscribe() {

            // Make sure nothing else is listening for hotkeys.
            Unsubscribe();

            // Create new key combinations and assign the Actions to click the buttons.
            Combination chatToCallsheet_KeyCombo = Combination.FromString(chatToCallsheetHotkey);
            Combination convertChatToCall_KeyCombo = Combination.FromString(convertChatToCallHotkey);
            chatToCallsheet_Action = chatToCallsheet_Execute;
            convertChatToCall_Action = convertChatToCall_Execute;

            // Assign actions to key combinations.
            Dictionary<Combination, Action> assignment = new Dictionary<Combination, Action> {
                { chatToCallsheet_KeyCombo, chatToCallsheet_Action },
                { convertChatToCall_KeyCombo, convertChatToCall_Action }
            };

            // Install listener.
            Hook.GlobalEvents().OnCombination(assignment);
        }

        // Stop listening for mouse/key events globally.
        private void Unsubscribe() {

            Hook.GlobalEvents().Dispose();
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

        // Import mouse event from user32.dll to handle clicks.
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        // Move the mouse to specified X, Y coordinates (set in Setup form).
        private void MoveMouse(int xPos, int yPos) => Cursor.Position = new System.Drawing.Point(xPos, yPos);

        // Perform a left click on the mouse at current position.
        private void PerformLeftClick() => mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

        // Perform a right click on the mouse at current position.
        private void PerformRightClick() => mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);

        // Send Copy command (Ctrl + C) keystroke.
        private void SendCopy() {
            SendKeys.Send("^a"); // Select all
            Thread.Sleep(100);
            SendKeys.Send("^c"); // Copy
        }

        // Send Paste command (Ctrl + P) keystroke.
        private void SendPaste() {
            SendKeys.Send("^v"); // Paste
        }

        // We have to assume that "Copy current cell" option is below and slightly to the right.
        // Otherwise, the user will have to enter coordinates for each drop-down. This should
        // suffice in most situations.
        private void CompensateForCopyCell(int xPos, int yPos, out int newXPos, out int newYPos) {

            // Add/subtract to xPos
            newXPos = xPos + 38;
            // Add/subtract to yPos
            newYPos = yPos + 11;
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

                    // Wait a bit before we start, to make sure the user isn't still holding a modifier key.
                    Thread.Sleep(500);

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
                    customerId = ClipboardHelper.GetText();
                    Thread.Sleep(300);
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
                    customerName = ClipboardHelper.GetText();
                    Thread.Sleep(300);
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
                    question = ClipboardHelper.GetText();
                    Thread.Sleep(300);
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
                    Thread.Sleep(300);

                    // If empty or null text is selected, clear the clipboard first.
                    if (string.IsNullOrEmpty(customerId))
                        ClipboardHelper.Clear();
                    else
                        ClipboardHelper.SetText(customerId);

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
                    Thread.Sleep(300);

                    // If empty or null text is selected, clear the clipboard first.
                    if (string.IsNullOrEmpty(customerName))
                        ClipboardHelper.Clear();
                    else
                        ClipboardHelper.SetText(customerName);

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
                    Thread.Sleep(300);

                    // If empty or null text is selected, clear the clipboard first.
                    if (string.IsNullOrEmpty(question))
                        ClipboardHelper.Clear();
                    else
                        ClipboardHelper.SetText(question);

                    // Paste question/problem.
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

                // Play a beep to signal completion.
                SystemSounds.Beep.Play();

                // Reset chat data.
                Reset();
            }
            catch (ExternalException ex) {
                if (ex.Message.Contains("Requested Clipboard operation did not succeed"))
                    MessageBox.Show("A clipboard operation has failed (thanks, Chrome)." +
                        Environment.NewLine + Environment.NewLine +
                        "Please try again.");
            }
            
            // This is only for debugging purposes and will be removed once testing is complete.
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        // Convert Chat to Call button handler

        private void convertChatToCallButton_Click(object sender, EventArgs e) {

            try {
                // Get current mouse position, so we can restore it later.
                mouseStartPosX = Cursor.Position.X;
                mouseStartPosY = Cursor.Position.Y;

                // First, we need to get the chat info from the callsheet. This ensures we always have up-to-date information,
                // rather than using the chat data we get from the Chat to Callsheet button.
                if (TryParseSettingCoords("CallsheetCustId", out int callCustIdX, out int callCustIdY)) {

                    // Wait a bit before we start, to make sure the user isn't still holding a modifier key.
                    Thread.Sleep(1000);

                    // Move to Cust ID and copy data.
                    MoveMouse(callCustIdX, callCustIdY);
                    PerformLeftClick();
                    Thread.Sleep(300);
                    SendCopy();
                    Thread.Sleep(300);
                    customerId = ClipboardHelper.GetText();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Customer Name
                if (TryParseSettingCoords("CallsheetCustName", out int callCustNameX, out int callCustNameY)) {

                    // Move to Customer and copy data.
                    MoveMouse(callCustNameX, callCustNameY);
                    PerformLeftClick();
                    Thread.Sleep(300);
                    SendCopy();
                    Thread.Sleep(300);
                    customerName = ClipboardHelper.GetText();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Problem/Query
                if (TryParseSettingCoords("CallsheetProblem", out int callProblemX, out int callProblemY)) {

                    // Move to Problem and copy data.
                    MoveMouse(callProblemX, callProblemY);
                    PerformLeftClick();
                    Thread.Sleep(300);
                    SendCopy();
                    Thread.Sleep(300);
                    question = ClipboardHelper.GetText();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Next, click "New" or "Reset Form" so we have an empty form.
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

                // Paste in the chat data.

                // Customer ID
                if (TryParseSettingCoords("CallsheetCustId", out callCustIdX, out callCustIdY)) {

                    // Move to Cust ID and paste.
                    MoveMouse(callCustIdX, callCustIdY);
                    PerformLeftClick();
                    Thread.Sleep(300);

                    // If empty or null text is selected, clear the clipboard first.
                    if (string.IsNullOrEmpty(customerId))
                        ClipboardHelper.Clear();
                    else
                        ClipboardHelper.SetText(customerId);

                    // Paste customer ID.
                    SendPaste();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Customer Name
                if (TryParseSettingCoords("CallsheetCustName", out callCustNameX, out callCustNameY)) {

                    // Move to Customer and paste.
                    //MoveMouse(callCustNameX, callCustNameY);
                    SendKeys.Send("{TAB}");
                    Thread.Sleep(300);

                    // If empty or null text is selected, clear the clipboard first.
                    if (string.IsNullOrEmpty(customerName))
                        ClipboardHelper.Clear();
                    else
                        ClipboardHelper.SetText(customerName);

                    // Paste customer name.
                    SendPaste();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Problem
                if (TryParseSettingCoords("CallsheetProblem", out callProblemX, out callProblemY)) {

                    // Add text to problem.
                    question = "From chat - " + question;

                    // Move to Problem and paste.
                    MoveMouse(callProblemX, callProblemY);
                    PerformLeftClick();

                    // If empty or null text is selected, clear the clipboard first.
                    if (string.IsNullOrEmpty(question))
                        ClipboardHelper.Clear();
                    else
                        ClipboardHelper.SetText(question);

                    // Paste customer ID.
                    SendPaste();
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Now change result to "call", and Save. In Progress is automatically set.
                if (TryParseSettingCoords("CallsheetResult", out int callResultX, out int callResultY)) {

                    // Move to Result, click, choose "call".
                    MoveMouse(callResultX, callResultY);
                    PerformLeftClick();
                    Thread.Sleep(150);
                    SendKeys.Send("C");
                    Thread.Sleep(150);
                    SendKeys.Send("{ENTER}");
                    Thread.Sleep(300);
                }
                else {
                    ShowSettingError();
                    return;
                }

                // Save call.
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

                // Play a beep to signal completion.
                SystemSounds.Beep.Play();

                // Reset chat data.
                Reset();
            }
            catch (ExternalException ex) {
                if (ex.Message.Contains("Requested Clipboard operation did not succeed"))
                    MessageBox.Show("A clipboard operation has failed (thanks, Chrome)." +
                        Environment.NewLine + Environment.NewLine +
                        "Please try again.");
            }

            // This is only for debugging purposes and will be removed once testing is complete.
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e) {

            // If the form is minimized, we need to minize it to the system tray.
            //if (this.WindowState == FormWindowState.Minimized) {
            //    this.Hide();
            //    notifyIcon.Visible = true;
            //}
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {

            // Show the form if it is minimized to the tray.
            //this.Show();
            //this.WindowState = FormWindowState.Normal;
            //notifyIcon.Visible = false;
        }

        private void setupButton_Click(object sender, EventArgs e) {

            using (SetupForm setupForm = new SetupForm()) {
                setupForm.ShowDialog(this);
            }

            // Make sure the hotkeys get registered again. When the global hook is
            // unregistered from the Setup menu, the hotkeys also get unregistered.
            this.Subscribe();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            using (HelpForm helpForm = new HelpForm()) {
                helpForm.ShowDialog(this);
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {

            // Load hotkeys from settings.
            this.chatToCallsheetHotkey = Settings.Default.ChatToCallsheetHotkey;
            this.convertChatToCallHotkey = Settings.Default.ConvertChatToCallHotkey;

            // DEBUG: Manually set hotkeys.
            if (this.chatToCallsheetHotkey.Length == 0)
                chatToCallsheetHotkey = "Control+Alt+F1";
            if (this.convertChatToCallHotkey.Length == 0)
                convertChatToCallHotkey = "Control+Alt+F2";

            // Clear the clipboard before starting, so we don't paste previous data.
            ClipboardHelper.Clear();

            // Register global hook listener.
            this.Subscribe();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {

            // Stop listening for keys.
            this.Unsubscribe();

            // Save hotkey settings on exit.
            Settings.Default.ChatToCallsheetHotkey = this.chatToCallsheetHotkey;
            Settings.Default.ConvertChatToCallHotkey = this.convertChatToCallHotkey;
            Settings.Default.Save();
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
