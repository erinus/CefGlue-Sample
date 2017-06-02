namespace Xilium.CefGlue.WindowsForms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(CefWebBrowser))]
    public class CefWebBrowser : Control
    {
        private bool _handleCreated;

        private CefBrowser _browser;
        private IntPtr _browserWindowHandle;

        public CefWebBrowser()
        {
            /* BEG: erinus */
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                CefRuntime.Load();

                CefSettings settings = new CefSettings();
                settings.MultiThreadedMessageLoop = false;
                settings.SingleProcess = true;
                //settings.LogSeverity = CefLogSeverity.Error;
                //settings.LogFile = "cef.log";
                //settings.ResourcesDirPath = System.IO.Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetEntryAssembly().CodeBase).LocalPath);
                //settings.RemoteDebuggingPort = 20480;
                settings.NoSandbox = true;

                CefMainArgs mainArgs = new CefMainArgs(Environment.GetCommandLineArgs());
                CefWebApp app = new CefWebApp(this);

                if (CefRuntime.ExecuteProcess(mainArgs, app, IntPtr.Zero) != -1)
                {
                    MessageBox.Show("ExecuteProcess failed");
                }

                CefRuntime.Initialize(mainArgs, settings, app, IntPtr.Zero);

                Application.Idle += (s, e) => CefRuntime.DoMessageLoopWork();
            }
            /* END: erinus */

            SetStyle(
                ControlStyles.ContainerControl
                | ControlStyles.ResizeRedraw
                | ControlStyles.FixedWidth
                | ControlStyles.FixedHeight
                | ControlStyles.StandardClick
                | ControlStyles.UserMouse
                | ControlStyles.SupportsTransparentBackColor
                | ControlStyles.StandardDoubleClick
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.CacheText
                | ControlStyles.EnableNotifyMessage
                | ControlStyles.DoubleBuffer
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UseTextForAccessibility
                | ControlStyles.Opaque,
                false);

            SetStyle(
                ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.Selectable,
                true);

            StartUrl = "about:blank";
        }


        [DefaultValue("about:blank")]
        public string StartUrl { get; set; }

        [Browsable(false)]
        public CefBrowserSettings BrowserSettings { get; set; }

        internal void InvokeIfRequired(Action a)
        {
            if (InvokeRequired)
                Invoke(a);
            else
                a();
        }

        protected virtual CefWebClient CreateWebClient()
        {
            return new CefWebClient(this);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (DesignMode)
            {
                if (!_handleCreated) Paint += PaintInDesignMode;
            }
            else
            {
                var windowInfo = CefWindowInfo.Create();
                windowInfo.SetAsChild(Handle, new CefRectangle { X = 0, Y = 0, Width = Width, Height = Height });

                var client = CreateWebClient();

                var settings = BrowserSettings;
                /* BEG: erinus */
                if (settings == null)
                {
                    settings = new CefBrowserSettings
                    {
                        FileAccessFromFileUrls = CefState.Enabled,
                        JavaScript = CefState.Enabled,
                        JavaScriptCloseWindows = CefState.Disabled,
                        JavaScriptOpenWindows = CefState.Disabled,
                        LocalStorage = CefState.Enabled,
                        UniversalAccessFromFileUrls = CefState.Enabled,
                        WebGL = CefState.Enabled,
                        WebSecurity = CefState.Disabled
                    };
                }
                /* END: erinus */

                CefBrowserHost.CreateBrowser(windowInfo, client, settings, StartUrl);
            }

            _handleCreated = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (_browser != null && disposing) // TODO: ugly hack to avoid crashes when CefWebBrowser are Finalized and underlying objects already finalized
            {
                var host = _browser.GetHost();
                if (host != null)
                {
                    host.CloseBrowser();
                    host.Dispose();
                }
                _browser.Dispose();
                _browser = null;
                _browserWindowHandle = IntPtr.Zero;
            }

            base.Dispose(disposing);

            /* BEG: erinus */
            CefRuntime.Shutdown();
            /* END: erinus */
        }

        public event EventHandler BrowserCreated;

        internal protected virtual void OnBrowserAfterCreated(CefBrowser browser)
        {
            _browser = browser;
            _browserWindowHandle = _browser.GetHost().GetWindowHandle();
            ResizeWindow(_browserWindowHandle, Width, Height);

            if (BrowserCreated != null)
                BrowserCreated(this, EventArgs.Empty);
        }

        internal protected virtual void OnTitleChanged(TitleChangedEventArgs e)
        {
            Title = e.Title;

            var handler = TitleChanged;
            if (handler != null) handler(this, e);
        }

        public string Title { get; private set; }

        public event EventHandler<TitleChangedEventArgs> TitleChanged;

        internal protected virtual void OnAddressChanged(AddressChangedEventArgs e)
        {
            Address = e.Address;

            var handler = AddressChanged;
            if (handler != null) handler(this, e);
        }

        public string Address { get; private set; }

        public event EventHandler<AddressChangedEventArgs> AddressChanged;

        internal protected virtual void OnStatusMessage(StatusMessageEventArgs e)
        {
            var handler = StatusMessage;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<StatusMessageEventArgs> StatusMessage;

        /* BEG: erinus */
        public class CefWebBeforeDownloadEventArgs : CancelEventArgs
        {
            public CefBrowser Browser = null;
            public CefDownloadItem DownloadItem = null;
            public string SuggestedName = null;
            public CefBeforeDownloadCallback Callback = null;

            public CefWebBeforeDownloadEventArgs(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
            {
                Cancel = false;
                Browser = browser;
                DownloadItem = downloadItem;
                SuggestedName = suggestedName;
                Callback = callback;
            }
        }

        internal void OnBeforeDownload(CefWebBeforeDownloadEventArgs args)
        {
            var handler = BeforeDownload;
            if (handler == null)
            {
                args.Callback.Continue(string.Empty, true);
            }
            else
            {
                handler(this, args);
                if (!args.Cancel)
                {
                    args.Callback.Continue(string.Empty, true);
                }
            }
        }

        public event EventHandler<CefWebBeforeDownloadEventArgs> BeforeDownload;
        /* END: erinus */

        /* BEG: erinus */
        public class CefWebDownloadUpdatedEventArgs : CancelEventArgs
        {
            public CefBrowser Browser = null;
            public CefDownloadItem DownloadItem = null;
            public CefDownloadItemCallback Callback = null;

            public CefWebDownloadUpdatedEventArgs(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
            {
                Cancel = false;
                Browser = browser;
                DownloadItem = downloadItem;
                Callback = callback;
            }
        }

        internal void OnDownloadUpdated(CefWebDownloadUpdatedEventArgs args)
        {
            var handler = DownloadUpdated;
            handler(this, args);
        }

        public event EventHandler<CefWebDownloadUpdatedEventArgs> DownloadUpdated;
        /* END: erinus */

        /* BEG: erinus */
        public class CefWebCreateJSObjectEventArgs : EventArgs
        {
            public CefBrowser Browser = null;
            public CefFrame Frame = null;
            public CefV8Context Context = null;

            public CefWebCreateJSObjectEventArgs(CefBrowser browser, CefFrame frame, CefV8Context context)
            {
                Browser = browser;
                Frame = frame;
                Context = context;
            }
        }

        internal void OnCreateJSObject(CefWebCreateJSObjectEventArgs args)
        {
            var handler = CreateJSObject;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public event EventHandler<CefWebCreateJSObjectEventArgs> CreateJSObject;
        /* END: erinus */

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_browserWindowHandle != IntPtr.Zero)
            {
                // Ignore size changes when form are minimized.
                var form = TopLevelControl as Form;
                if (form != null && form.WindowState == FormWindowState.Minimized)
                {
                    return;
                }

                ResizeWindow(_browserWindowHandle, Width, Height);
            }
        }

        private void PaintInDesignMode(object sender, PaintEventArgs e)
        {
            var width = this.Width;
            var height = this.Height;
            if (width > 1 && height > 1)
            {
                var brush = new SolidBrush(this.ForeColor);
                var pen = new Pen(this.ForeColor);
                pen.DashStyle = DashStyle.Dash;

                e.Graphics.DrawRectangle(pen, 0, 0, width - 1, height - 1);

                var fontHeight = (int)(this.Font.GetHeight(e.Graphics) * 1.25);

                var x = 3;
                var y = 3;

                e.Graphics.DrawString("CefWebBrowser", Font, brush, x, y + (0 * fontHeight));
                e.Graphics.DrawString(string.Format("StartUrl: {0}", StartUrl), Font, brush, x, y + (1 * fontHeight));

                brush.Dispose();
                pen.Dispose();
            }
        }

        public void InvalidateSize()
        {
            ResizeWindow(_browserWindowHandle, Width, Height);
        }

        private static void ResizeWindow(IntPtr handle, int width, int height)
        {
            if (handle != IntPtr.Zero)
            {
                NativeMethods.SetWindowPos(handle, IntPtr.Zero,
                    0, 0, width, height,
                    SetWindowPosFlags.NoMove | SetWindowPosFlags.NoZOrder
                    );
            }
        }

        public CefBrowser Browser { get { return _browser; } }

        public event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;

        internal protected virtual void OnConsoleMessage(ConsoleMessageEventArgs e)
        {
            if (ConsoleMessage != null)
                ConsoleMessage(this, e);
            else
                e.Handled = false;
        }

        public event EventHandler<LoadingStateChangeEventArgs> LoadingStateChange;

        internal protected virtual void OnLoadingStateChange(LoadingStateChangeEventArgs e)
        {
            if (LoadingStateChange != null)
                LoadingStateChange(this, e);
        }

        public event EventHandler<TooltipEventArgs> Tooltip;

        internal protected virtual void OnTooltip(TooltipEventArgs e)
        {
            if (Tooltip != null)
                Tooltip(this, e);
            else
                e.Handled = false;
        }

        public event EventHandler BeforeClose;

        internal protected virtual void OnBeforeClose()
        {
            _browserWindowHandle = IntPtr.Zero;
            if (BeforeClose != null)
                BeforeClose(this, EventArgs.Empty);
        }

        public event EventHandler<BeforePopupEventArgs> BeforePopup;

        internal protected virtual void OnBeforePopup(BeforePopupEventArgs e)
        {
            if (BeforePopup != null)
                BeforePopup(this, e);
            else
                e.Handled = false;
        }

        public event EventHandler<LoadEndEventArgs> LoadEnd;

        internal protected virtual void OnLoadEnd(LoadEndEventArgs e)
        {
            if (LoadEnd != null)
                LoadEnd(this, e);
        }

        public event EventHandler<LoadErrorEventArgs> LoadError;

        internal protected virtual void OnLoadError(LoadErrorEventArgs e)
        {
            if (LoadError != null)
                LoadError(this, e);
        }

        public event EventHandler<LoadStartEventArgs> LoadStarted;

        internal protected virtual void OnLoadStart(LoadStartEventArgs e)
        {
            if (LoadStarted != null)
                LoadStarted(this, e);
        }

        public event EventHandler<PluginCrashedEventArgs> PluginCrashed;

        internal protected virtual void OnPluginCrashed(PluginCrashedEventArgs e)
        {
            if (PluginCrashed != null)
                PluginCrashed(this, e);
        }

        public event EventHandler<RenderProcessTerminatedEventArgs> RenderProcessTerminated;

        internal protected virtual void OnRenderProcessTerminated(RenderProcessTerminatedEventArgs e)
        {
            if (RenderProcessTerminated != null)
                RenderProcessTerminated(this, e);
        }

        /* BEG: erinus */
        private class GDI32
        {
            public const int SRCCOPY = 0x00CC0020;
            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }

        private class CefWebStringVisitor : CefStringVisitor
        {
            private string _path;

            public CefWebStringVisitor(string path)
            {
                this._path = path;
            }

            protected override void Visit(string value)
            {
                File.WriteAllText(this._path, value, Encoding.UTF8);
            }
        }

        public Image CaptureWindow(IntPtr handle)
        {
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            GDI32.SelectObject(hdcDest, hOld);
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            Image img = Image.FromHbitmap(hBitmap);
            GDI32.DeleteObject(hBitmap);
            return img;
        }

        public void Save(string path)
        {
            switch (Path.GetExtension(path))
            {
                case ".bmp":
                    CaptureWindow(this.Handle).Save(path, ImageFormat.Bmp);
                    break;
                case ".png":
                    CaptureWindow(this.Handle).Save(path, ImageFormat.Png);
                    break;
                case ".jpg":
                    CaptureWindow(this.Handle).Save(path, ImageFormat.Jpeg);
                    break;
                case ".htm":
                    this.Browser.GetMainFrame().GetSource(new CefWebStringVisitor(path));
                    break;
            }
        }
        /* END: erinus */
    }
}
