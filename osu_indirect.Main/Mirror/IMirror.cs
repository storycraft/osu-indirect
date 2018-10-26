using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_indirect.Main.Mirror
{
    public interface IMirror
    {
        Stream DownloadMapset(int setId);

        Task<Stream> DownloadMapsetAsync(int setId);
    }
}
