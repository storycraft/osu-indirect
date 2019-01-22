using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace osu_indirect.Main.Mirror
{
    public class BloodcatMirror : IMirror
    {
        public Stream DownloadMapset(int setId)
        {
            WebClient infoClient = new WebClient();

            infoClient.Headers.Add(HttpRequestHeader.UserAgent, "osu-indirect");
            
            return infoClient.OpenRead(new Uri("https://bloodcat.com/osu/s/" + setId));
        }

        public Task<Stream> DownloadMapsetAsync(int setId)
        {
            return new Task<Stream>(() =>
            {
                return DownloadMapset(setId);
            });
        }
    }
}
