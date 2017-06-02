namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    public class CefWebFocusHandler : CefFocusHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebFocusHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override void OnGotFocus(CefBrowser browser)
        {
            base.OnGotFocus(browser);
        }

        protected override bool OnSetFocus(CefBrowser browser, CefFocusSource source)
        {
            return base.OnSetFocus(browser, source);
        }

        protected override void OnTakeFocus(CefBrowser browser, bool next)
        {
            base.OnTakeFocus(browser, next);
        }
    }
    /* END: erinus */
}
