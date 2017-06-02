namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    public class CefWebFindHandler : CefFindHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebFindHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override void OnFindResult(CefBrowser browser, int identifier, int count, CefRectangle selectionRect, int activeMatchOrdinal, bool finalUpdate)
        {
            //throw new NotImplementedException();
        }
    }
    /* END: erinus */
}
