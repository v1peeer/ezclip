using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace ezclip.Forms {
    public partial class Downloader : Form {
        public WebClient webClient;
        public string linkToFile;
        public string fileName;

        public Downloader(string fileName, string linkToFile) {
            InitializeComponent();
            this.linkToFile = linkToFile;
            this.fileName = fileName;
        }

        public void DownloaderForm_Load(object sender, EventArgs e) {
            webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

            try {
                webClient.DownloadFileAsync(new Uri(linkToFile), Application.StartupPath + "\\resources\\" + fileName);
            } catch(Exception ex) {
                Main.logger.Error("Couldn't delete the dependency!", ex.Message);
                Close();
            }
        }

        public void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            progressBar1.Value = e.ProgressPercentage;
        }

        public void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) {
            Close();
        }
    }
}