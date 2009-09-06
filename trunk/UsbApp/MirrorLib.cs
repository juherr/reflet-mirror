using System;
using System.Collections.Generic;
using System.Text;

namespace UsbApp
{
    public static class MirrorLib
    {
        private static string ZTAMP_LIST_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\reflet\\" + "ztampList.xml";
        private static string ZTAMP_LIST_FOLDER_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\reflet";

        public static string GetZtampListPath()
        {
            return ZTAMP_LIST_PATH;
        }

        public static string GetZtampListFolderPath()
        {
            return ZTAMP_LIST_FOLDER_PATH;
        }
    }
}
