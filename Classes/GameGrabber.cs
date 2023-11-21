using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ezclip.Classes {
    public class GameGrabber {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetCurrentGame(bool hide) {
            if(hide)
                return "something";
            IntPtr hWnd = GetForegroundWindow();
            StringBuilder title = new StringBuilder(256);
            if(GetWindowText(hWnd, title, 256) > 0)
                return title.ToString().ToLower();
            return "nothing";
        }
    }
}