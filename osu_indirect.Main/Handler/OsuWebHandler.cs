using osu_indirect.Hook.Pinvoke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static osu_indirect.Hook.Pinvoke.Win32Helper;

namespace osu_indirect.Main.Handler
{
    public abstract class OsuWebHandler : UriHandler
    {
        public const string SERVER_URL = "osu.ppy.sh";

        public override bool CanHandle(SHELLEXECUTEINFO info)
        {
            return base.CanHandle(info) && CreateUri(info.lpFile).Host == SERVER_URL;
        }

        public abstract override bool Execute(ref SHELLEXECUTEINFO info);
    }
}
