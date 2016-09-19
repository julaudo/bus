using System;
using System.Net;

namespace Bus.Util
{
    class DownloadUtils
    {
        public static byte[] Download(String url)
        {
            using (var client = new WebClient())
            {
                byte[] data = client.DownloadData(url);
                return data;
            }
        }
    }
}
