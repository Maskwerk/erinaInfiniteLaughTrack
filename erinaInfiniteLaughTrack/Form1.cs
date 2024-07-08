using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace erinaInfiniteLaughTrack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowsMediaPlayers = new List<WMPLib.WindowsMediaPlayer>();
            for (int i = 0; i < concurrentSounds; i++)
            {
                WindowsMediaPlayers.Add(new WMPLib.WindowsMediaPlayer());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            soundPlayer1 newsounds = new soundPlayer1();    
            Task.Run(() => newsounds.playSound(concurrentSounds, WindowsMediaPlayers));
        }
        

        private int concurrentSounds = 3;
        List<WMPLib.WindowsMediaPlayer> WindowsMediaPlayers;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class soundPlayer1 {
        public void playSound(int concurrentSounds, List<WMPLib.WindowsMediaPlayer> WindowsMediaPlayers)
        {
            while (true)
            {

                string path = Directory.GetCurrentDirectory();
                string folderpath = path + "\\common";

                List<string> soundFiles = Directory.GetFiles(folderpath, "*.wav").ToList();
                soundFiles = soundFiles.OrderBy(i => Guid.NewGuid()).ToList();
                for (int i = 0; i < concurrentSounds; i++)
                {
                    WindowsMediaPlayers[i].URL = soundFiles[i];
                    Console.WriteLine(soundFiles[i]);
                }
                Thread.Sleep(2000);
            }
        }
    }
}
