using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static osu_indirect.Hook.Pinvoke.Win32Helper;

namespace osu_indirect.Main.Handler
{
    public interface IAppHandler
    {
        bool CanHandle(SHELLEXECUTEINFO info);

        bool Execute(ref SHELLEXECUTEINFO info);
    }
}
