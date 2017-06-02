namespace Xilium.CefGlue.WindowsForms
{
    using System;

    /* BEG: erinus */
    public class CefWebRenderHandler : CefRenderHandler
    {
        private readonly CefWebBrowser _core;

        public CefWebRenderHandler(CefWebBrowser core)
        {
            _core = core;
        }

        protected override bool GetRootScreenRect(CefBrowser browser, ref CefRectangle rect)
        {
            return base.GetRootScreenRect(browser, ref rect);
        }

        protected override bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
        {
            //throw new NotImplementedException();
            return true;
        }

        protected override bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX, ref int screenY)
        {
            return base.GetScreenPoint(browser, viewX, viewY, ref screenX, ref screenY);
        }

        protected override bool GetViewRect(CefBrowser browser, ref CefRectangle rect)
        {
            return base.GetViewRect(browser, ref rect);
        }

        protected override void OnCursorChange(CefBrowser browser, IntPtr cursorHandle, CefCursorType type, CefCursorInfo customCursorInfo)
        {
            //throw new NotImplementedException();
        }

        protected override void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange, CefRectangle[] characterBounds)
        {
            //throw new NotImplementedException();
        }

        protected override void OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects, IntPtr buffer, int width, int height)
        {
            //throw new NotImplementedException();
        }

        protected override void OnPopupShow(CefBrowser browser, bool show)
        {
            base.OnPopupShow(browser, show);
        }

        protected override void OnPopupSize(CefBrowser browser, CefRectangle rect)
        {
            //throw new NotImplementedException();
        }

        protected override void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
        {
            //throw new NotImplementedException();
        }

        protected override bool StartDragging(CefBrowser browser, CefDragData dragData, CefDragOperationsMask allowedOps, int x, int y)
        {
            return base.StartDragging(browser, dragData, allowedOps, x, y);
        }

        protected override void UpdateDragCursor(CefBrowser browser, CefDragOperationsMask operation)
        {
            base.UpdateDragCursor(browser, operation);
        }
    }
    /* END: erinus */
}
