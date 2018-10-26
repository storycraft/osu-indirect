using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu_indirect.Hook;
using osu_indirect.Hook.Pinvoke;
using osu_indirect.Main.Mirror;
using osu_indirect.Main.OsuApi;
using osu_indirect.Main.Util;
using static osu_indirect.Hook.Pinvoke.Win32Helper;

namespace osu_indirect.Main.Handler
{
    public class BeatmapListHandler : OsuWebHandler
    {
        public const string BEATMAP_PATH = "b";

        private static IMirror mirror = new RippleMirror();

        public override bool CanHandle(SHELLEXECUTEINFO info)
        {
            return base.CanHandle(info) && CreateUri(info.lpFile).LocalPath.StartsWith("/" + BEATMAP_PATH);
        }

        public override bool Execute(ref SHELLEXECUTEINFO info)
        {
            string rawUrl = info.lpFile;
            Uri uri = CreateUri(rawUrl);
            try
            {
                int beatmapId = int.Parse(uri.LocalPath.Remove(0, ("/" + BEATMAP_PATH + "/").Length));
                Console.WriteLine("Beatmap Id: " + beatmapId);

                new Task(() =>
                {
                    BeatmapInfo beatmapInfo = OsuApi.OsuApi.GetBeatmapInfo(beatmapId);

                    if (beatmapInfo == null
                        || (beatmapInfo.Rank != BeatmapRank.RANKED && beatmapInfo.Rank != BeatmapRank.APPROVED && beatmapInfo.Rank != BeatmapRank.LOVED && beatmapInfo.Rank != BeatmapRank.QUALIFIED))
                    {
                        Console.WriteLine("Cannot find beatmap " + beatmapId + " opening browser instead");
                        Process.Start(new ProcessStartInfo()
                        {
                            UseShellExecute = true,
                            FileName = rawUrl
                        });
                        return;
                    }

                    Console.WriteLine("Beatmap SetId: " + beatmapInfo.SetId);
                    Console.WriteLine("Beatmap Name: " + beatmapInfo.Name);

                    string fileName = beatmapInfo.SetId + " " + string.Join("_", beatmapInfo.Name.Split(Path.GetInvalidFileNameChars()));
                    Console.WriteLine("Starting downloading " + fileName);

                    try
                    {
                        string tempFile = Path.Combine(Path.GetTempPath(), fileName + ".osz");
                        FileUtil.WriteStream(mirror.DownloadMapset(beatmapInfo.SetId), tempFile, FileMode.CreateNew);
                        Console.WriteLine(fileName + " download complete");

                        Process.Start(IpcShellExecuteInterface.ClientProcess.MainModule.FileName, tempFile);
                    } catch (Exception e) {
                        Console.WriteLine("Error on beatmap downloading: " + e.Message);
                        Console.WriteLine("Maybe not cached in ripple. Opening browser instead");
                        Process.Start(new ProcessStartInfo()
                        {
                            UseShellExecute = true,
                            FileName = rawUrl
                        });
                    }
                }).Start();

            } catch (Exception e)
            {
                Console.WriteLine("Error on beatmap handling: " + e.Message);
                return false;
            }

            return true;
        }
    }
}
