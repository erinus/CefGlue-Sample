namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    public class CefWebDragHandler : CefDragHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebDragHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override bool OnDragEnter(CefBrowser browser, CefDragData dragData, CefDragOperationsMask mask)
        {
            //throw new NotImplementedException();
            return true;
        }

        protected override void OnDraggableRegionsChanged(CefBrowser browser, CefDraggableRegion[] regions)
        {
            //throw new NotImplementedException();
        }
    }
    /* END: erinus */
}
