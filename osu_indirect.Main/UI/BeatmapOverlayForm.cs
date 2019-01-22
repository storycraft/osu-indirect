using osu_indirect.Main.OsuApi;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osu_indirect.Main.UI
{
    public partial class BeatmapOverlayForm : Form
    {

        public delegate void ClickListener(BeatmapOverlayForm form, int beatmapId, string mapName, string rawURL);

        public BeatmapInfo MapInfo { get; }

        private string rawURL;

        private ClickListener onDownloadClick;
        private ClickListener onBrowserClick;
        private ClickListener onCloseClick;

        public BeatmapOverlayForm(BeatmapInfo mapInfo, string rawURL, ClickListener onDownloadClick, ClickListener onBrowserClick, ClickListener onCloseClick)
        {
            InitializeComponent();
            
            MapInfo = mapInfo;
            this.rawURL = rawURL;

            titleText.Text = MapInfo.Artist + " - " + MapInfo.Name;
            idText.Text = MapInfo.SetId + "";

            this.onDownloadClick = onDownloadClick;
            this.onBrowserClick = onBrowserClick;
            this.onCloseClick = onCloseClick;
        }

        [DllImport("user32.dll")]
        static extern bool OpenIcon(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private void cancelButton_Click(object sender, EventArgs e)
        {
            onCloseClick?.Invoke(this, MapInfo.SetId, MapInfo.Name, rawURL);
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private const int WS_EX_TOPMOST = 0x00000008;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_TOPMOST;
                return createParams;
            }
        }

        private void OverlayForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Bounds = Screen.PrimaryScreen.Bounds;
            TopMost = true;

            WebClient infoClient = new WebClient();

            infoClient.Headers.Add(HttpRequestHeader.UserAgent, "osu-indirect");

            infoClient.OpenReadTaskAsync(new Uri("https://bloodcat.com/osu/i/" + MapInfo.Id)).ContinueWith((Task<Stream> task) =>
            {
                if (task.IsCompleted)
                {
                    this.BackgroundImage = Image.FromStream(task.Result);
                }
            });

            OpenIcon(Handle);
            SetForegroundWindow(Handle);
        }

        private void browserButton_Click(object sender, EventArgs e)
        {
            onBrowserClick?.Invoke(this, MapInfo.SetId, MapInfo.Name, rawURL);
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            onDownloadClick?.Invoke(this, MapInfo.SetId, MapInfo.Name, rawURL);
        }

        private void titleText_Click(object sender, EventArgs e)
        {

        }
    }
}
