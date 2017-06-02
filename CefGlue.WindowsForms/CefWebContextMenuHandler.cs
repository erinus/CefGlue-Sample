namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    public class CefWebContextMenuHandler : CefContextMenuHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebContextMenuHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
        {
            base.OnBeforeContextMenu(browser, frame, state, model);
        }

        protected override bool OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
        {
            return base.OnContextMenuCommand(browser, frame, state, commandId, eventFlags);
        }

        protected override void OnContextMenuDismissed(CefBrowser browser, CefFrame frame)
        {
            base.OnContextMenuDismissed(browser, frame);
        }

        protected override bool RunContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams parameters, CefMenuModel model, CefRunContextMenuCallback callback)
        {
            return base.RunContextMenu(browser, frame, parameters, model, callback);
        }
    }
    /* END: erinus */
}
