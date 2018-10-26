using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using osu_indirect.Hook.Handler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static osu_indirect.Hook.Pinvoke.Win32Helper;

namespace osu_indirect.Hook
{
    public class IpcShellExecuteInterface : MarshalByRefObject
    {
        private static IShellExecutionHandler handler;

        public static Process ClientProcess { get; private set; }

        public static void IsServerInstalled(IShellExecutionHandler handler)
        {
            IpcShellExecuteInterface.handler = handler;
            //Console.WriteLine("IShellExecutionHandler registered");
        }

        public void IsClientInstalled(int clientPID)
        {
            ClientProcess = Process.GetProcessById(clientPID);
            //Console.WriteLine("osu!indirect has injected BrowserHook into process {0}.\r\n", clientPID);
        }

        public void ReportMessages(string[] messages)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                Console.WriteLine(messages[i]);
            }
        }

        public bool OnShellExecution(ref SHELLEXECUTEINFO info)
        {
            if (handler == null)
                return true;

            return handler.OnShellExecution(ref info);
        }

        public void ReportMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Report exception
        /// </summary>
        /// <param name="e"></param>
        public void ReportException(Exception e)
        {
            Console.WriteLine("The target process has reported an error:\r\n" + e.ToString());
        }

        /// <summary>
        /// Called to confirm that the IPC channel is still open / host application has not closed
        /// </summary>
        public void Ping()
        {

        }
    }
}
