namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    public class CefWebGeolocationHandler : CefGeolocationHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebGeolocationHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override void OnCancelGeolocationPermission(CefBrowser browser, int requestId)
        {
            //throw new NotImplementedException();
        }

        protected override bool OnRequestGeolocationPermission(CefBrowser browser, string requestingUrl, int requestId, CefGeolocationCallback callback)
        {
            //throw new NotImplementedException();
            return true;
        }
    }
    /* END: erinus */
}
