using DiscordRPC;
using Button = DiscordRPC.Button;

namespace ezclip.Classes {
    public class Discord {
        public DateTime startTime = DateTime.UtcNow;
        public DiscordRpcClient client;

        public Discord() {
            client = new DiscordRpcClient("1153782977482985553");
            client.Initialize();
        }

        public async Task UpdateDRPC() {
            while(true) {
                client.SetPresence(new RichPresence() {
                    Details = "clipping " + (GameGrabber.GetCurrentGame(Main.hideDiscordRPC)),
                    State = "still in beta",
                    Assets = new Assets() {
                        LargeImageKey = "nobg_x512",
                        LargeImageText = $"version v{Main.version}",
                        SmallImageKey = "kyouko",
                        SmallImageText = "coded by @vvviperrr"
                    },
                    Buttons = new Button[] {
                        new Button() {
                            Label = "Website", Url = "https://ezclip.weebly.com/"
                        }
                    },
                    Timestamps = new Timestamps() {
                        Start = startTime
                    }
                });
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}