using EasyHook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static osu_indirect.Hook.Pinvoke.Win32Helper;

namespace osu_indirect.Hook
{
    public class BrowserHook : IEntryPoint
    {

        public string channelName;

        private IpcShellExecuteInterface server = null;

        public BrowserHook(RemoteHooking.IContext context, string channelName)
        {
            this.channelName = channelName;
            this.server = RemoteHooking.IpcConnectClient<IpcShellExecuteInterface>(channelName);
        }

        public void Run(RemoteHooking.IContext context, string channelName)
        {
            server.IsClientInstalled(RemoteHooking.GetCurrentProcessId());

            var shellExecuteHook = LocalHook.Create(
                    LocalHook.GetProcAddress("shell32.dll", "ShellExecuteExW"),
                    new ShellExecuteExDelegate(ShellExecuteExHook),
                    this);

            shellExecuteHook.ThreadACL.SetExclusiveACL(new int[] { 0 });

            RemoteHooking.WakeUpProcess();

            server.ReportMessage("Injected to osu! process");

            try
            {
                // Loop until closes (i.e. IPC fails)
                while (true)
                {
                    System.Threading.Thread.Sleep(500);

                    server.Ping();
                }
            }
            catch
            {
                // Ping() or ReportMessages() will raise an exception if host is unreachable
            }

            shellExecuteHook.Dispose();

            LocalHook.Release();
        }

        public delegate bool ShellExecuteExDelegate(ref SHELLEXECUTEINFO lpExecInfo);

        public bool ShellExecuteExHook(ref SHELLEXECUTEINFO lpExecInfo)
        {
            //server.ReportMessage("ShellExecuteExW: " + lpExecInfo.lpFile);

            if (!server.OnShellExecution(ref lpExecInfo))
            {
                return ShellExecuteEx(ref lpExecInfo);
            }

            return true;
        }
    }
}
