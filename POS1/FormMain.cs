using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace LifePlus.POS
{
    public partial class FormMain : Form
    {
        public FormMain(string[] args)
        {
            InitializeComponent();

            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "--without-borders":
                        this.Width = 1024;
                        this.Height = 768;
                        this.PanelMain.BorderStyle = BorderStyle.None;
                        break;
                }
            }

            this.CefWebBrowserMainView.StartUrl = Path.GetFullPath(@"apps\POS1\POS1.html");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MessageFilter filter = new MessageFilter();
        }

        private void CefWebBrowserMainView_BrowserCreated(object sender, EventArgs e)
        {

        }

        private void CefWebBrowserMainView_CreateJSObject(object sender, Xilium.CefGlue.WindowsForms.CefWebBrowser.CefWebCreateJSObjectEventArgs e)
        {
            // Retrieve the context's window object.
            CefV8Value window = e.Context.GetGlobal();

            // window.pos
            CefV8Value pos = CefV8Value.CreateObject(null);

            window.SetValue("pos", pos, CefV8PropertyAttribute.DontDelete | CefV8PropertyAttribute.ReadOnly);

            // window.pos.Message
            CefV8Value pos_Message = CefV8Value.CreateString("Hello Vue.js 讀書會");

            pos.SetValue("Message", pos_Message, CefV8PropertyAttribute.DontDelete | CefV8PropertyAttribute.ReadOnly);
        }
    }
}
