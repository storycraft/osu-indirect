using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace osu_indirect.Main.Mirror
{
    public class RippleMirror : IMirror
    {
        public Stream DownloadMapset(int setId)
        {
            WebClient infoClient = new WebClient();
            return infoClient.OpenRead(new Uri("http://storage.ripple.moe/d/" + setId));
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
