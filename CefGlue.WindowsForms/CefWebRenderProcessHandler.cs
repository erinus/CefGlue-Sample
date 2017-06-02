namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    internal sealed class CefWebRenderProcessHandler : CefRenderProcessHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebRenderProcessHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override CefLoadHandler GetLoadHandler()
        {
            return base.GetLoadHandler();
        }

        protected override bool OnBeforeNavigation(CefBrowser browser, CefFrame frame, CefRequest request, CefNavigationType navigation_type, bool isRedirect)
        {
            return base.OnBeforeNavigation(browser, frame, request, navigation_type, isRedirect);
        }

        protected override void OnBrowserCreated(CefBrowser browser)
        {
            base.OnBrowserCreated(browser);
        }

        protected override void OnBrowserDestroyed(CefBrowser browser)
        {
            base.OnBrowserDestroyed(browser);
        }

        protected override void OnContextCreated(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            base.OnContextCreated(browser, frame, context);

            context.Enter();

            CefWebBrowser.CefWebCreateJSObjectEventArgs args = new CefWebBrowser.CefWebCreateJSObjectEventArgs(browser, frame, context);
            _core.OnCreateJSObject(args);

            context.Exit();
        }

        protected override void OnContextReleased(CefBrowser browser, CefFrame frame, CefV8Context context)
        {
            base.OnContextReleased(browser, frame, context);
        }

        protected override void OnFocusedNodeChanged(CefBrowser browser, CefFrame frame, CefDomNode node)
        {
            base.OnFocusedNodeChanged(browser, frame, node);
        }

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
        {
            return base.OnProcessMessageReceived(browser, sourceProcess, message);
        }

        protected override void OnRenderThreadCreated(CefListValue extraInfo)
        {
            base.OnRenderThreadCreated(extraInfo);
        }

        protected override void OnUncaughtException(CefBrowser browser, CefFrame frame, CefV8Context context, CefV8Exception exception, CefV8StackTrace stackTrace)
        {
            base.OnUncaughtException(browser, frame, context, exception, stackTrace);

            System.Collections.Generic.List<string> data = new System.Collections.Generic.List<string>();
            data.Add(string.Format("Url: {0}", frame.Url));
            data.Add(string.Format("ScriptResourceName: {0}", exception.ScriptResourceName));
            data.Add(string.Format("Message: {0}", exception.Message));
            data.Add(string.Format("LineNumber: {0}", exception.LineNumber));
            data.Add(string.Format("SourceLine: {0}", exception.SourceLine));
            data.Add(string.Format("StartColumn: {0}", exception.StartColumn));
            data.Add(string.Format("EndColumn: {0}", exception.EndColumn));
            System.Windows.Forms.MessageBox.Show(string.Join(Environment.NewLine, data));
        }

        protected override void OnWebKitInitialized()
        {
            base.OnWebKitInitialized();
        }

        private void CreateFunction(CefV8Value parent, CefV8Handler method, String name)
        {
            // Create the {name} function.
            CefV8Value value = CefV8Value.CreateFunction(name, method);

            // Add the {name} function to the {parent} object.
            parent.SetValue(name, value, CefV8PropertyAttribute.None);
        }
    }
    /* END: erinus */
}
