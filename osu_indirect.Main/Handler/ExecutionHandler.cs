using osu_indirect.Hook.Handler;
using osu_indirect.Hook.Pinvoke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_indirect.Main.Handler
{
    public class ExecutionHandler : IShellExecutionHandler
    {
        private List<IAppHandler> appHandlerList;

        public ExecutionHandler()
        {
            appHandlerList = new List<IAppHandler>();
            InitAppHandlers();
        }

        internal void InitAppHandlers()
        {
            RegisterAppHandler(new BeatmapListHandler());
        }

        public void RegisterAppHandler(IAppHandler handler)
        {
            appHandlerList.Add(handler);
        }

        public bool RemoveAppHandler(IAppHandler handler)
        {
            return appHandlerList.Remove(handler);
        }

        public bool OnShellExecution(ref Win32Helper.SHELLEXECUTEINFO info)
        {
            bool canHandle = false;
            foreach (IAppHandler handler in appHandlerList)
            {
                if (handler.CanHandle(info)) {
                    canHandle = true;
                    handler.Execute(ref info);
                }
            }

            return canHandle;
        }
    }
}
