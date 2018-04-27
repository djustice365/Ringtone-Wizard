using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NAudio.Wave;

namespace RingtoneWizard
{
    public partial class RingtoneWizard : Form
    {
        System.Timers.Timer playbackTimer = new System.Timers.Timer();
        private Preview pre;

        String inputFile = "";

        public RingtoneWizard()
        {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {
            //idk, just don't give it a bad file
        }

        private void open(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                axWindowsMediaPlayer1.URL = @dlg.FileName;
                inputFile = @dlg.FileName;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                playbackTimer.Elapsed += new System.Timers.ElapsedEventHandler(onTimedEvent);
                playbackTimer.Interval = 500;
                playbackTimer.Enabled = true;
            }
        }

        private void onTimedEvent(object source, EventArgs e)
        {
            Console.WriteLine("Position: " + axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
            setTrackbar();
        }

        delegate void SetTimerCallback();

        private void setTrackbar()
        {
            try
            {
                if (this.customTrackbar1.InvokeRequired)
                {
                    SetTimerCallback t = new SetTimerCallback(setTrackbar);
                    this.Invoke(t);
                }
                else
                {
                    customTrackbar1.setPosition(((float)axWindowsMediaPlayer1.Ctlcontrols.currentPosition / (float)axWindowsMediaPlayer1.currentMedia.duration));
                    if (customTrackbar1.getSets().Count > 0 && !customTrackbar1.waitingForNext)
                    {
                        createRingtone.Enabled = true;
                        preview.Enabled = true;
                    }
                    else
                    {
                        createRingtone.Enabled = false;
                        preview.Enabled = false;
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

        private void customTrackBarDown(object sender, MouseEventArgs e)
        {
            float percentage = ((float)e.X) / customTrackbar1.Width;

            if (e.Button == MouseButtons.Left)
            {
                //allow media player to be controlled by clicking track bar
                try
                {
                    this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition = percentage * axWindowsMediaPlayer1.currentMedia.duration;
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("No Media in player: " + ex);
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                customTrackbar1.rightClick(percentage);
            }
        }

        private void customTrackBarUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
                customTrackbar1.finish();
        }

        private void customTrackBarMove(object sender, MouseEventArgs e)
        {
            float percentage = ((float)e.X) / customTrackbar1.Width;

            if (e.Button == MouseButtons.Left)
            {
                customTrackbar1.setPosition(percentage);

                //allow media player to be controlled by clicking track bar
                try
                {
                    this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition = percentage * axWindowsMediaPlayer1.currentMedia.duration;
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("No Media in player: " + ex);
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                customTrackbar1.rightClick(percentage);
            }
        }
        
        //create the ringtone
        private void createRingtone_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            String outputFile = System.IO.Path.GetDirectoryName(inputFile);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = outputFile;
            dlg.Filter = "music files (*.mp3)|*.mp3";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                NewMessage newMessage = new NewMessage();
                newMessage.hideButtons();
                newMessage.Show("Saving...");
                customTrackbar1.orderPoints();

                using (System.IO.FileStream fs = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    List<float[]> list = customTrackbar1.getSets();

                    float section1 = 0;
                    float section2 = 0;


                    foreach (float[] item in list)
                    {
                        using (Mp3FileReader reader = new Mp3FileReader(inputFile))
                        {
                            Mp3Frame frame = reader.ReadNextFrame();
                            float rate = ((float)frame.SampleRate / (float)frame.SampleCount); float percent1 = item[0] / customTrackbar1.Width;
                            float percent2 = item[1] / customTrackbar1.Width;

                            float seconds1 = (percent1 * (float)axWindowsMediaPlayer1.currentMedia.duration);
                            float seconds2 = (percent2 * (float)axWindowsMediaPlayer1.currentMedia.duration);

                            section1 = (percent1 * (float)axWindowsMediaPlayer1.currentMedia.duration) * rate;
                            section2 = (percent2 * (float)axWindowsMediaPlayer1.currentMedia.duration) * rate;


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
                    fs.Close();
                    newMessage.Close();
                }
            }
            DialogResult result = MessageBox.Show("Saved", "Saving", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
            }
        }

        //preview the current setup
        private void preview_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            customTrackbar1.orderPoints();
            pre = new Preview();
            foreach(float[] point in customTrackbar1.getSets())
            {
                Console.WriteLine("Preview points: " + point[0]);
            }
            pre.play(customTrackbar1.getSets(), inputFile, customTrackbar1);
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                customTrackbar1.KeyDown();
            }
        }

        private void RingtoneWizard_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        //Allows the command line to be seen during normal execution
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]

        static extern bool AllocConsole();
    }
}
