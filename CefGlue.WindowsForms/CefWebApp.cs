namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    public class CefWebApp : CefApp
    {
        private readonly CefWebBrowserProcessHandler _browserProcessHandler;
        private readonly CefWebRenderProcessHandler _renderProcessHandler;

        public CefWebApp(CefWebBrowser browser)
        {
            _browserProcessHandler = new CefWebBrowserProcessHandler(browser);
            _renderProcessHandler = new CefWebRenderProcessHandler(browser);
        }

        protected override CefBrowserProcessHandler GetBrowserProcessHandler()
        {
            return _browserProcessHandler;
        }

        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
            return _renderProcessHandler;
        }

        protected override CefResourceBundleHandler GetResourceBundleHandler()
        {
            return base.GetResourceBundleHandler();
        }

        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
            base.OnBeforeCommandLineProcessing(processType, commandLine);
        }

        protected override void OnRegisterCustomSchemes(CefSchemeRegistrar registrar)
        {
            base.OnRegisterCustomSchemes(registrar);
        }
    }
    /* END: erinus */
}
