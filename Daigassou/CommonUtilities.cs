using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Daigassou.Utils;
using Newtonsoft.Json;

namespace Daigassou
{
    internal class CommonUtilities
    {
        public class versionObject
        {
            public bool isForceUpdate { get; set; }
            public bool isRefuseToUse { get; set; }
            public string Version { get; set; }
            public string Description { get; set; }
            public uint countDownPacket { get; set; }
            public uint ensembleStopPacket { get; set; }
            public uint partyStopPacket { get; set; }
            public uint ensembleStartPacket { get; set; }
            public uint ensemblePacket { get; set; }
            //public bool isBeta { get; set; }
        }
        public static void WriteLog(string msg)
        {
            Console.WriteLine($"{DateTime.Now.ToString("O")}\t\t\t" + $"{msg}");
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMiliseconds;
        }

        public class SetSystemDateTime
        {
            [DllImport("Kernel32.dll")]
            public static extern bool SetLocalTime(ref SystemTime sysTime);

            public static bool SetLocalTimeByStr(DateTime dt)
            {
                bool flag = false;
                SystemTime sysTime = new SystemTime();
                sysTime.wYear = Convert.ToUInt16(dt.Year);
                sysTime.wMonth = Convert.ToUInt16(dt.Month);
                sysTime.wDay = Convert.ToUInt16(dt.Day);
                sysTime.wHour = Convert.ToUInt16(dt.Hour);
                sysTime.wMinute = Convert.ToUInt16(dt.Minute);
                sysTime.wSecond = Convert.ToUInt16(dt.Second);
                sysTime.wMiliseconds = Convert.ToUInt16(dt.Millisecond);
                try
                {
                    flag = SetSystemDateTime.SetLocalTime(ref sysTime);
                }
                catch (Exception e)
                {
                    WriteLog("Failed to set system date time with exception "+e.Message);
                }

                return flag;
            }
        }
    }
}