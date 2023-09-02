using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeConverter;
using AngleSharp;
using System.Runtime.CompilerServices;
using System.IO;
using YoutubeExplode.Videos.Streams;

namespace YoutubeConverter
{
    public partial class Form1 : Form
    {
        public string desktopPath { get; set; }
        public YoutubeClient YoutubeClient { get; set; }
        public string inputValue { get; set; }


        DirectoryInfo dirInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

        public Form1()
        {
            InitializeComponent();

            YoutubeClient = new YoutubeClient();

            progressBar1.Hide();

            desktopPath = Path.Combine(dirInfo.FullName,"Youtube Downloads");
        }

        private async void button1_Click(object sender, EventArgs e)

        {
        }

      
        private async void button2_Click(object sender, EventArgs e)
        {

           bool existance =  Directory.Exists(Path.Combine(dirInfo.FullName,"Youtube Downloads"));

           dirInfo.CreateSubdirectory("Youtube Downloads");


            var videoManifest = await YoutubeClient.Videos.Streams.GetManifestAsync(inputValue);

            var video = videoManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            var videoInfo = await YoutubeClient.Videos.GetAsync(inputValue);

            //await YoutubeClient.Videos.Streams.DownloadAsync(targetVideo, desktopPath + $"\\{video.Title}.{targetVideo.Container}");

            string newVideo = $"{videoInfo.Title}.{video.Container}";

            label2.AutoSize = true;
            string desktopTarget = desktopPath + $"\\{newVideo}";

            label2.Text = desktopTarget;

            //FileStream fs = new FileStream(desktopTarget,FileMode.Open);

            var stream = YoutubeClient.Videos.Streams.GetAsync(video);

            // var res  = await stream.AsTask();

            //byte[] videoBytes = new byte[1000000];

            //res.Write(videoBytes, 0, videoBytes.Length);

            //res.Close();

            char[] invalidChars = Path.GetInvalidPathChars();

            var filteredTarget = desktopTarget.ToCharArray().Where<char>((s) => {

               if (invalidChars.Contains(s))
                {
                    return false;
                }
               else
                {
                    return true;
                }
            });




            string newww = new string(filteredTarget.ToArray());

            await YoutubeClient.Videos.Streams.DownloadAsync(video,newww);

          

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            inputValue = richTextBox1.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private async void button1_Click_2(object sender, EventArgs e)
        {

            bool existance = Directory.Exists(Path.Combine(dirInfo.FullName, "Youtube Downloads"));

            dirInfo.CreateSubdirectory("Youtube Downloads");


            var videoManifest = await YoutubeClient.Videos.Streams.GetManifestAsync(inputValue);

            var video = videoManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            var videoInfo = await YoutubeClient.Videos.GetAsync(inputValue);

            //await YoutubeClient.Videos.Streams.DownloadAsync(targetVideo, desktopPath + $"\\{video.Title}.{targetVideo.Container}");

            string newVideo = $"{videoInfo.Title}.{video.Container}";

            label2.AutoSize = true;
            string desktopTarget = desktopPath + $"\\{newVideo}";

            label2.Text = desktopTarget;

            //FileStream fs = new FileStream(desktopTarget,FileMode.Open);

            var stream = YoutubeClient.Videos.Streams.GetAsync(video);

            
            // var res  = await stream.AsTask();

            //byte[] videoBytes = new byte[1000000];

            //res.Write(videoBytes, 0, videoBytes.Length);

            //res.Close();

            char[] invalidChars = Path.GetInvalidPathChars();

            var filteredTarget = desktopTarget.ToCharArray().Where<char>((s) => {

                if (invalidChars.Contains(s))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });




            string newww = new string(filteredTarget.ToArray());

            await YoutubeClient.Videos.Streams.DownloadAsync(video, newww);

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
