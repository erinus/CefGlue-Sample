namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    public class CefWebKeyboardHandler : CefKeyboardHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebKeyboardHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override bool OnKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, IntPtr osEvent)
        {
            return base.OnKeyEvent(browser, keyEvent, osEvent);
        }

        protected override bool OnPreKeyEvent(CefBrowser browser, CefKeyEvent keyEvent, IntPtr os_event, out bool isKeyboardShortcut)
        {
            return base.OnPreKeyEvent(browser, keyEvent, os_event, out isKeyboardShortcut);
        }
    }
    /* END: erinus */
}
