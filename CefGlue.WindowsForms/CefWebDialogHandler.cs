namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    public class CefWebDialogHandler : CefDialogHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebDialogHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override bool OnFileDialog(CefBrowser browser, CefFileDialogMode mode, string title, string defaultFilePath, string[] acceptFilters, int selectedAcceptFilter, CefFileDialogCallback callback)
        {
            return base.OnFileDialog(browser, mode, title, defaultFilePath, acceptFilters, selectedAcceptFilter, callback);
        }
    }
    /* END: erinus */
}
