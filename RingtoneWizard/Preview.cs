using NAudio.Wave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RingtoneWizard
{
    public partial class Preview : Form
    {
        private List<float[]> arrayList;
        private String inputFile;
        private CustomTrackbar customTrackbar1;
        private String directory;
        private System.Timers.Timer playbackTimer = new System.Timers.Timer();
        private System.Threading.Thread dismissThread;

        public Preview()
        {
            InitializeComponent();
            dismissThread = new System.Threading.Thread(new System.Threading.ThreadStart(deleteFile));
        }

        private void dismiss_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.close();
            this.Hide();
            dismissThread.Start();
        }

        private void deleteFile()
        {
            System.IO.File.Delete(directory + "\\preview.mp3");
        }

        private void closeForm()
        {
            this.Close();
        }

        internal void play(List<float[]> arrayList, String inputFile, CustomTrackbar customTrackbar1)
        {
            this.arrayList = arrayList;
            this.inputFile = inputFile;
            this.customTrackbar1 = customTrackbar1;
            directory = System.IO.Path.GetDirectoryName(inputFile);
            axWindowsMediaPlayer2.URL = inputFile;
            this.Show();
            createTempFile();
        }

        private void loadTempFile()
        {
            String newFile = directory + "/preview.mp3";
            axWindowsMediaPlayer2.URL = newFile;
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }

        private void createTempFile()
        {
            axWindowsMediaPlayer2.Ctlcontrols.play();
            playbackTimer.Elapsed += new System.Timers.ElapsedEventHandler(onTimedEvent);
            playbackTimer.Interval = 500;
            playbackTimer.Enabled = true;
        }

        private void onTimedEvent(object source, EventArgs e)
        {
            startCreation();
        }

        delegate void SetTimerCallback();

        private void startCreation()
        {
            try
            {
                if (this.axWindowsMediaPlayer2.InvokeRequired)
                {
                    SetTimerCallback t = new SetTimerCallback(startCreation);
                    this.Invoke(t);
                }
                else
                {
                    if(axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    {
                        createFile();
                    }
                }
            }
            catch (Exception e)
            {
                //only ever throws an exception when closing the program
                //and it happens to land in the middle of the timer
                //I don't know how to properly handle this
            }
        }

        private void createFile()
        {
            playbackTimer.Stop();
            axWindowsMediaPlayer2.Ctlcontrols.pause();
            using (System.IO.FileStream fs = new System.IO.FileStream(directory + "/preview.mp3", System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                float section1 = 0;
                float section2 = 0;


                foreach (float[] item in arrayList)
                {
                    //for each item, it contains two floats: start and end of each section
                    using (Mp3FileReader reader = new Mp3FileReader(inputFile))
                    {
                        Mp3Frame frame = reader.ReadNextFrame();
                        float rate = ((float)frame.SampleRate / (float)frame.SampleCount);
                        float percent1 = item[0] / customTrackbar1.Width;
                        float percent2 = item[1] / customTrackbar1.Width;

                        float seconds1 = (percent1 * (float)axWindowsMediaPlayer2.currentMedia.duration);
                        float seconds2 = (percent2 * (float)axWindowsMediaPlayer2.currentMedia.duration);

                        Console.WriteLine("Seconds (first): " + seconds1);
                        Console.WriteLine("Seconds (second): " + seconds2);

                        section1 = (percent1 * (float)axWindowsMediaPlayer2.currentMedia.duration) * rate;
                        section2 = (percent2 * (float)axWindowsMediaPlayer2.currentMedia.duration) * rate;

                        Console.WriteLine("Section1: " + section1);
                        Console.WriteLine("Section2: " + section2);
                        int count = 1;

                        while (frame != null)
                        {
                            if (count > section2)
                            {
                                break;
                            }

                            if (count > section1)
                            {
                                fs.Write(frame.RawData, 0, frame.RawData.Length);
                            }
                            count = count + 1;
                            frame = reader.ReadNextFrame();
                        }
                    }
                }
                Console.WriteLine("Finished Creating File");
                fs.Close();
            }

            loadTempFile();
        }
    }
}
