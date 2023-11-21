namespace ezclip.Classes {
    public class Logger {
        public string textFile;

        public Logger(string textFile) {
            this.textFile = textFile;

            if(!File.Exists(textFile)) {
                File.Create(textFile);
                MessageBox.Show("Created Log File!\nYou have to restart ezclip!");
                Environment.Exit(0);
            }

            using(StreamWriter writer = new StreamWriter(textFile, true)) {
                string currentDateAndTime = DateTime.Now.ToString("dd/MM/yy - HH:mm:ss");
                writer.WriteLine($"[{currentDateAndTime}] [START] ~ Started Logger!");
                writer.Close();
            }
        }

        public void Info(string message) {
            using(StreamWriter writer = new StreamWriter(textFile, true)) {
                string currentDateAndTime = DateTime.Now.ToString("dd/MM/yy - HH:mm:ss");
                writer.WriteLine($"[{currentDateAndTime}] [INFO] ~ " + message);
                writer.Close();
            }
        }

        public void Error(string message, string exception) {
            MessageBox.Show(message + "\n" + exception, "An error occured");
            using(StreamWriter writer = new StreamWriter(textFile, true)) {
                string currentDateAndTime = DateTime.Now.ToString("dd/MM/yy - HH:mm:ss");
                writer.WriteLine($"[{currentDateAndTime}] [ERROR] ~ " + message);
                writer.WriteLine(exception);
                writer.Close();
            }
        }

        public void EndMessage() {
            using(StreamWriter writer = new StreamWriter(textFile, true)) {
                string currentDateAndTime = DateTime.Now.ToString("dd/MM/yy - HH:mm:ss");
                writer.WriteLine($"[{currentDateAndTime}] [STOP] ~ Stopped Logger!");
                writer.WriteLine("-----");
                writer.Close();
            }
        }
    }
}