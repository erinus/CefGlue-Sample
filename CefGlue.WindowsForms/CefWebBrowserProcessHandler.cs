namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    internal sealed class CefWebBrowserProcessHandler : CefBrowserProcessHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebBrowserProcessHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override CefPrintHandler GetPrintHandler()
        {
            return base.GetPrintHandler();
        }

        protected override void OnBeforeChildProcessLaunch(CefCommandLine commandLine)
        {
            base.OnBeforeChildProcessLaunch(commandLine);
        }

        protected override void OnContextInitialized()
        {
            base.OnContextInitialized();
        }

        protected override void OnRenderProcessThreadCreated(CefListValue extraInfo)
        {
            base.OnRenderProcessThreadCreated(extraInfo);
        }

        protected override void OnScheduleMessagePumpWork(long delayMs)
        {
            base.OnScheduleMessagePumpWork(delayMs);
        }
    }
    /* END: erinus */
}
