using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ezclip.Forms {
    public partial class Upload : Form {
        public string filePath;
        public string videoLink;

        public Upload(string filePath) {
            InitializeComponent();
            this.filePath = filePath;
            label1.Text = label1.Text.Replace("%69%", Path.GetFileName(filePath));
        }

        private void button2_Click(object sender, EventArgs e) {
            Close();
        }

        private async void button1_Click(object sender, EventArgs e) {
            textBox1.Text = "Uploading... Might look like it's stuck but just wait!";
            string response = await UploadVideo(filePath);
            var videoData = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            if(videoData.ContainsKey("shortcode")) {
                textBox1.Text = "https://streamable.com/" + videoData["shortcode"];
            }
        }

        public async Task<string> UploadVideo(string filePath) {
            HttpClient _httpClient = new HttpClient();
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"streamable-email:streamable-password"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            using(var content = new MultipartFormDataContent())
            using(var fileStream = new StreamContent(File.OpenRead(filePath))) {
                content.Add(fileStream, "file", Path.GetFileName(filePath));
                var response = await _httpClient.PostAsync("https://api.streamable.com/upload", content);
                if(response.IsSuccessStatusCode) {
                    var videoData = await response.Content.ReadAsStringAsync();
                    return videoData;
                } else
                    throw new Exception("Error uploading video: " + response.ReasonPhrase);
            }
        }

        private void textBox1_Click(object sender, EventArgs e) {
            textBox1.SelectAll();
            Clipboard.SetText(textBox1.Text);
        }
    }
}
