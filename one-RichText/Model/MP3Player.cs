using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace origin.Model
{
    public class MP3Player
    {

        public String filepath = "";
        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand,
        string lpstrReturnString, uint uReturnLength, uint hWndCallback);
        public void Play()
        {
            string aa = "open \"" + filepath + "\" alias temp_alias";
            mciSendString(@"close temp_alias", null, 0, 0);
            mciSendString(aa, null, 0, 0);
            mciSendString("play temp_alias repeat", null, 0, 0);

        }

        public void Stop()
        {
            mciSendString(@"stop temp_alias", null, 0, 0);
        }


    }
}
