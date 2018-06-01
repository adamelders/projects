using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Chat_to_Callsheet_Tool {
    static class ClipboardHelper {
        [DllImport("user32.dll")]
        static extern IntPtr GetOpenClipboardWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();

        public static bool SetText(string text) {
            IntPtr hWnd = GetOpenClipboardWindow(); // Gets the HWND of the window that currently owns the clipboard

            // If no window currently owns the clipboard, just go ahead and set the text.
            if (hWnd == null || hWnd == IntPtr.Zero)
                Clipboard.SetText(text);
            else {
                OpenClipboard(IntPtr.Zero);
                Clipboard.SetText(text);
                CloseClipboard();
            }
            return true;
        }

        public static string GetText() {
            IntPtr hwnd = GetOpenClipboardWindow();

            if (hwnd == null || hwnd == IntPtr.Zero)
                return Clipboard.GetText();
            else {
                OpenClipboard(IntPtr.Zero);
                string data = Clipboard.GetText();
                CloseClipboard();
                return data;
            }
        }

        public static void Clear() {
            IntPtr hWnd = GetOpenClipboardWindow();

            if (hWnd == null || hWnd == IntPtr.Zero)
                Clipboard.Clear();
            else {
                OpenClipboard(IntPtr.Zero);
                Clipboard.Clear();
                CloseClipboard();
            }
        }
    }
}
