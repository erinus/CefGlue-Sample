namespace Xilium.CefGlue.WindowsForms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    /* BEG: erinus */
    internal sealed class CefWebJSDialogHandler : CefJSDialogHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebJSDialogHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override bool OnBeforeUnloadDialog(CefBrowser browser, string messageText, bool isReload, CefJSDialogCallback callback)
        {
            //throw new NotImplementedException();
            return true;
        }

        protected override void OnDialogClosed(CefBrowser browser)
        {
            //throw new NotImplementedException();
        }

        protected override bool OnJSDialog(CefBrowser browser, string originUrl, CefJSDialogType dialogType, string message_text, string default_prompt_text, CefJSDialogCallback callback, out bool suppress_message)
        {
            bool result = false;
            suppress_message = true;
            switch (dialogType)
            {
                case CefJSDialogType.Alert:
                    MessageBox.Show(message_text, "POS1");
                    break;
                case CefJSDialogType.Confirm:
                    MessageBox.Show(message_text, "POS1", MessageBoxButtons.OKCancel);
                    break;
            }
            return result;
        }

        protected override void OnResetDialogState(CefBrowser browser)
        {
            //throw new NotImplementedException();
        }
    }
    /* END: erinus */
}
