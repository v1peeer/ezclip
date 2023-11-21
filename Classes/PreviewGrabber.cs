using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ezclip.Classes {
    public class PreviewGrabber {
        public static Image GetThumbnail(string videoPath, int targetWidth, int targetHeight) {
            string outputImagePath = Application.StartupPath + "\\temp\\" + Path.GetRandomFileName().Replace(".", "").Substring(0, 8) + ".png";

            // Calculate the cropping values to center the 16:9 video in the 21:9 frame
            int xOffset = (targetWidth - targetHeight * 16 / 9) / 2;
            string arguments = $"-i \"{videoPath}\" -vf \"crop={targetHeight * 16 / 9}:{targetHeight}:{xOffset}:0\" -vframes 1 {outputImagePath}";

            Process process = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = Application.StartupPath + "\\resources\\ffmpeg.exe",
                    Arguments = arguments,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();

            if(File.Exists(outputImagePath))
                return Image.FromFile(outputImagePath);

            return null;
        }

    }
}