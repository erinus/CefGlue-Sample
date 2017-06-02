namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    public class CefWebDownloadHandler : CefDownloadHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebDownloadHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override void OnBeforeDownload(CefBrowser browser, CefDownloadItem downloadItem, string suggestedName, CefBeforeDownloadCallback callback)
        {
            base.OnBeforeDownload(browser, downloadItem, suggestedName, callback);

            CefWebBrowser.CefWebBeforeDownloadEventArgs args = new CefWebBrowser.CefWebBeforeDownloadEventArgs(browser, downloadItem, suggestedName, callback);
            _core.OnBeforeDownload(args);
        }

        protected override void OnDownloadUpdated(CefBrowser browser, CefDownloadItem downloadItem, CefDownloadItemCallback callback)
        {
            base.OnDownloadUpdated(browser, downloadItem, callback);
        }
    }
    /* END: erinus */
}
