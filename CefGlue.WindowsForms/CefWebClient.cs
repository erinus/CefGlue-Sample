namespace Xilium.CefGlue.WindowsForms
{
    using System;
    using System.Collections.Generic;
    using Xilium.CefGlue;

    public class CefWebClient : CefClient
    {
        private readonly CefWebBrowser _core;
        private readonly CefWebContextMenuHandler _contextMenuHandler;
        private readonly CefWebDialogHandler _dialogHandler;
        private readonly CefWebDisplayHandler _displayHandler;
        private readonly CefWebDownloadHandler _downloadHandler;
        private readonly CefWebDragHandler _dragHandler;
        private readonly CefWebFindHandler _findHandler;
        private readonly CefWebFocusHandler _focusHandler;
        private readonly CefWebGeolocationHandler _geolocationHandler;
        private readonly CefWebJSDialogHandler _jsDialogHandler;
        private readonly CefWebKeyboardHandler _keyboardHandler;
        private readonly CefWebLifeSpanHandler _lifeSpanHandler;
        private readonly CefWebLoadHandler _loadHandler;
        private readonly CefWebRenderHandler _renderHandler;
        private readonly CefWebRequestHandler _requestHandler;

        public CefWebClient(CefWebBrowser core)
        {
            _core = core;
            _contextMenuHandler = new CefWebContextMenuHandler(_core);
            _dialogHandler = new CefWebDialogHandler(_core);
            _displayHandler = new CefWebDisplayHandler(_core);
            _downloadHandler = new CefWebDownloadHandler(_core);
            _dragHandler = new CefWebDragHandler(_core);
            _findHandler = new CefWebFindHandler(_core);
            _focusHandler = new CefWebFocusHandler(_core);
            _geolocationHandler = new CefWebGeolocationHandler(_core);
            _jsDialogHandler = new CefWebJSDialogHandler(_core);
            _keyboardHandler = new CefWebKeyboardHandler(_core);
            _lifeSpanHandler = new CefWebLifeSpanHandler(_core);
            _loadHandler = new CefWebLoadHandler(_core);
            _renderHandler = new CefWebRenderHandler(_core);
            _requestHandler = new CefWebRequestHandler(_core);
        }

        protected CefWebBrowser Core
        {
            get
            {
                return _core;
            }
        }

        protected override CefContextMenuHandler GetContextMenuHandler()
        {
            return _contextMenuHandler;
        }

        protected override CefDialogHandler GetDialogHandler()
        {
            return _dialogHandler;
        }

        protected override CefDisplayHandler GetDisplayHandler()
        {
            return _displayHandler;
        }

        protected override CefDownloadHandler GetDownloadHandler()
        {
            return _downloadHandler;
        }

        protected override CefDragHandler GetDragHandler()
        {
            return _dragHandler;
        }

        protected override CefFindHandler GetFindHandler()
        {
            return _findHandler;
        }

        protected override CefFocusHandler GetFocusHandler()
        {
            return _focusHandler;
        }

        protected override CefGeolocationHandler GetGeolocationHandler()
        {
            return _geolocationHandler;
        }

        protected override CefJSDialogHandler GetJSDialogHandler()
        {
            return _jsDialogHandler;
        }

        protected override CefKeyboardHandler GetKeyboardHandler()
        {
            return _keyboardHandler;
        }

        protected override CefLifeSpanHandler GetLifeSpanHandler()
        {
            return _lifeSpanHandler;
        }

        protected override CefLoadHandler GetLoadHandler()
        {
            return _loadHandler;
        }

        protected override CefRenderHandler GetRenderHandler()
        {
            return _renderHandler;
        }

        protected override CefRequestHandler GetRequestHandler()
        {
            return _requestHandler;
        }

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess, CefProcessMessage message)
        {
            return base.OnProcessMessageReceived(browser, sourceProcess, message);
        }
    }
}
