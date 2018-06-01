using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlarmandCountdownTimer
{
    public partial class AlarmandCountdownTimer : Form
    {
        int hours;
        int minutes;
        int seconds;
        System.Timers.Timer timer;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
       
        public AlarmandCountdownTimer()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (hoursBox.Text == "")
            {
                hoursBox.Text = "0";
            }
            if (minuteBox.Text == "")
            {
                minuteBox.Text = "0";
            }
            if (secondBox.Text == "")
            {
                secondBox.Text = "0";
            }
            hours = Convert.ToInt32(hoursBox.Text);
            minutes = Convert.ToInt32(minuteBox.Text);
            seconds = Convert.ToInt32(secondBox.Text);

            countdowntimer.Start();

        }

        delegate void UpdateLabel(Label lbl, string value);

        void UpdateDataLabel(Label lb, string value)
        {
            alarmst.Text = value;
        }
        
        private void countdowntimer_Tick(object sender, EventArgs e)
        {
            seconds = seconds - 1;
            if (seconds == -1)
            {
                minutes = minutes - 1;
                seconds = 59;

            }
            if (minutes == -1)
            {
                hours = hours - 1;
                minutes = 59;
            }
            if (hours == 0 && minutes == 0 && seconds == 0)
            {
                countdowntimer.Stop();
                MessageBox.Show("Times Up!", "Time");
            }

            string hourslabel = Convert.ToString(hours);
            string minutelabel = Convert.ToString(minutes);
            string secondslabel = Convert.ToString(seconds);

            label1.Text = hourslabel;
            label3.Text = minutelabel;
            label5.Text = secondslabel;
        }

        private void End_Click(object sender, EventArgs e)
        {
            countdowntimer.Stop();
        }

        private void AlarmandCountdownTimer_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTimer = dateTimePicker.Value;
            if (currentTime.Hour == userTimer.Hour && currentTime.Minute == userTimer.Minute &&
                currentTime.Second == userTimer.Second)
            {
                timer.Stop();

                try
                {
                    UpdateLabel updateDataLabel = UpdateDataLabel;
                    if(alarmst.InvokeRequired)
                        Invoke(updateDataLabel,alarmst,"Stop");
                    
                   player.SoundLocation = @"C:\Windows\media\Alarm01.wav";
                   player.PlayLooping();
                }   
                catch(Exception message)
                {
                    MessageBox.Show(message.Message,"Message", MessageBoxButtons.OK , MessageBoxIcon.Error);
                }
            }
        }

        private void alarmstart_Click(object sender, EventArgs e)
        {
            timer.Start();
            alarmst.Text = "Running..";
        }

        private void alarmStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            alarmst.Text = "Stop";
            player.Stop();
        }

        private void About_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

              
    }
}
