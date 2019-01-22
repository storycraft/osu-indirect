using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu_indirect.Hook.Pinvoke;

namespace osu_indirect.Main.Handler
{
    public class ScreenshotHandler : IAppHandler
    {
        public bool CanHandle(Win32Helper.SHELLEXECUTEINFO info)
        {
            return false;
        }

        public bool Execute(ref Win32Helper.SHELLEXECUTEINFO info)
        {
            return false;
        }
    }
}
