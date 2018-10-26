using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu_indirect.Hook.Pinvoke;

namespace osu_indirect.Main.Handler
{
    public abstract class UriHandler : IAppHandler
    {
        public virtual bool CanHandle(Win32Helper.SHELLEXECUTEINFO info)
        {
            return Uri.IsWellFormedUriString(info.lpFile, UriKind.RelativeOrAbsolute);
        }

        internal Uri CreateUri(string rawUri)
        {
            return new Uri(rawUri);
        }

        public abstract bool Execute(ref Win32Helper.SHELLEXECUTEINFO info);
    }
}
