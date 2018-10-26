using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static osu_indirect.Hook.Pinvoke.Win32Helper;

namespace osu_indirect.Hook.Handler
{
    public interface IShellExecutionHandler
    {
        bool OnShellExecution(ref SHELLEXECUTEINFO info);
    }
}
