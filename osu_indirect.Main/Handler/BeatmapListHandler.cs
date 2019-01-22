using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using osu_indirect.Hook;
using osu_indirect.Hook.Pinvoke;
using osu_indirect.Main.Mirror;
using osu_indirect.Main.OsuApi;
using osu_indirect.Main.UI;
using osu_indirect.Main.Util;
using static osu_indirect.Hook.Pinvoke.Win32Helper;

namespace osu_indirect.Main.Handler
{
    public class BeatmapListHandler : OsuWebHandler
    {
        public const string BEATMAP_PATH = "b";

        private static IMirror mirror = new BloodcatMirror();

        public BeatmapListHandler()
        {
            Application.EnableVisualStyles();
        }

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

                ShowDownloadForm(rawUrl, beatmapId);

            } catch (Exception e)
            {
                Console.WriteLine("Error on beatmap handling: " + e.Message);
                return false;
            }

            return true;
        }

        public void ShowDownloadForm(string rawURL, int beatmapId)
        {
            BeatmapInfo beatmapInfo = OsuApi.OsuApi.GetBeatmapInfo(beatmapId);

            BeatmapOverlayForm form = new BeatmapOverlayForm(beatmapInfo, rawURL, OnDownloadClick, OnBrowserClick, OnCloseClick);

            form.Deactivate += new EventHandler(Deactivated);

            form.ShowDialog();

            Application.Run();
        }

        protected void OnDownloadClick(BeatmapOverlayForm form, int mapId, string mapName, string rawURL)
        {

            new Task(() =>
            {
                Console.WriteLine("Beatmap Name: " + mapName);
                Console.WriteLine("Beatmap SetId: " + mapId);

                string fileName = mapId + " " + string.Join("_", mapName.Split(Path.GetInvalidFileNameChars()));
                Console.WriteLine("Starting downloading " + fileName);

                try
                {
                    string tempFile = Path.Combine(Path.GetTempPath(), fileName + ".osz");
                    FileUtil.WriteStream(mirror.DownloadMapset(mapId), tempFile, FileMode.Create);
                    Console.WriteLine(fileName + " download complete");

                    Process.Start(IpcShellExecuteInterface.ClientProcess.MainModule.FileName, tempFile);
                }
                catch (Exception e)
                {
                    MessageBox.Show("비트맵이 미러에 존재하지 않거나 다운로드가 실패했습니다. 웹브라우저를 엽니다");
                    Console.WriteLine("Error on beatmap downloading: " + e.Message);
                    Console.WriteLine("Opening browser instead");

                    Process.Start(new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        FileName = rawURL
                    });
                }
            }).Start();
            
            OnCloseClick(form, mapId, mapName, rawURL);
        }

        protected void OnBrowserClick(BeatmapOverlayForm form, int mapId, string mapName, string rawURL)
        {
            Process.Start(new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = rawURL
            });

            OnCloseClick(form, mapId, mapName, rawURL);
        }

        protected void OnCloseClick(BeatmapOverlayForm form, int mapId, string mapName, string rawURL)
        {
            form.Close();
            Application.Exit();
        }

        protected void Deactivated(object obj, EventArgs args)
        {
            Application.Exit();
        }
    }
}
