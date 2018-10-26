using EasyHook;
using osu_indirect.Hook;
using osu_indirect.Main.Handler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels.Ipc;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osu_indirect.Main
{
    public class Program
    {
        public const string HOOK_ASSEMBLY = "osu_indirect.Hook.dll";
        public const string PROCESS_NAME = "osu!";

        private static ExecutionHandler executionHandler;

        public static string InjectionLibrary {
            get => Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), HOOK_ASSEMBLY);
        }

        static void Main(string[] args)
        {
            string channelName = null;

            Console.WriteLine("osu!indirect v0.1\n\n");

            if (args.Length > 0 && OsuApi.OsuApi.IsKeyValid(args[0]))
            {
                OsuApi.OsuApi.ApiKey = args[0];
            }
            else
            {
                while (!AskApiKey());
            }

            IpcServerChannel channel = RemoteHooking.IpcCreateServer<IpcShellExecuteInterface>(ref channelName, System.Runtime.Remoting.WellKnownObjectMode.Singleton);
            executionHandler = new ExecutionHandler();
            IpcShellExecuteInterface.IsServerInstalled(executionHandler);

            int found = InjectToProcess(PROCESS_NAME, channelName, InjectionLibrary);

            if (found < 1)
            {
                Console.WriteLine("Cannot find any osu! process.");
                Console.ReadKey();
            }
            else
            {
                Application.Run();
            }
        }

        internal static bool AskApiKey()
        {
            Console.WriteLine("Please paste osu! api key here");
            string apiKey = Console.ReadLine();

            if (OsuApi.OsuApi.IsKeyValid(apiKey))
            {
                OsuApi.OsuApi.ApiKey = apiKey;
                Console.WriteLine("");
                return true;
            }

            Console.WriteLine(apiKey + " is not valid.");
            return false;
        }

        public static int InjectToProcess(string processName, string channelName, string injectionLibrary)
        {
            Process[] processList = Process.GetProcessesByName(processName);

            foreach (Process proc in processList)
            {
                Console.WriteLine("Found " + processName + " process"/* + " with pid " + proc.Id*/);
                RemoteHooking.Inject(proc.Id, injectionLibrary, injectionLibrary, channelName);
            }

            return processList.Length;
        }
    }
}
