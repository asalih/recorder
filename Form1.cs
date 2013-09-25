using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;
namespace MicrophoneRecorder
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string command, string returnString, int uReturnLength, int hwndCallback);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
            mciSendString("record recsound", "", 0, 0);

            lblStatus.Text = "recording...";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mciSendString("save recsound c:\\kayit.wav", "", 0, 0);
            mciSendString("close recsound", "", 0, 0);
            Computer c = new Computer();
            c.Audio.Stop();

            lblStatus.Text = "stoped!";
        }
    }
}
