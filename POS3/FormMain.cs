using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlus.POS
{
    public partial class FormMain : Form
    {
        public FormMain(string[] args)
        {
            InitializeComponent();

            foreach (string arg in args)
            {
                if ("--without-borders".Equals(arg))
                {
                    this.Width = 1024;
                    this.Height = 768;
                    this.PanelMain.BorderStyle = BorderStyle.None;
                }
            }
        }

        private void CefWebBrowserMainView_BrowserCreated(object sender, EventArgs e)
        {

        }

        private void CefWebBrowserMainView_CreateJSObject(object sender, Xilium.CefGlue.WindowsForms.CefWebBrowser.CefWebCreateJSObjectEventArgs e)
        {

        }
    }
}
