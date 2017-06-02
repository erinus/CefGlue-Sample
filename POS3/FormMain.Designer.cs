namespace LifePlus.POS
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.PanelMain = new System.Windows.Forms.Panel();
            this.CefWebBrowserMainView = new Xilium.CefGlue.WindowsForms.CefWebBrowser();
            this.PanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMain.Controls.Add(this.CefWebBrowserMainView);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(1026, 770);
            this.PanelMain.TabIndex = 0;
            // 
            // CefWebBrowserMainView
            // 
            this.CefWebBrowserMainView.BrowserSettings = null;
            this.CefWebBrowserMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CefWebBrowserMainView.Location = new System.Drawing.Point(0, 0);
            this.CefWebBrowserMainView.Name = "CefWebBrowserMainView";
            this.CefWebBrowserMainView.Size = new System.Drawing.Size(1024, 768);
            this.CefWebBrowserMainView.TabIndex = 0;
            this.CefWebBrowserMainView.BrowserCreated += new System.EventHandler(this.CefWebBrowserMainView_BrowserCreated);
            this.CefWebBrowserMainView.CreateJSObject += new System.EventHandler<Xilium.CefGlue.WindowsForms.CefWebBrowser.CefWebCreateJSObjectEventArgs>(this.CefWebBrowserMainView_CreateJSObject);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 770);
            this.Controls.Add(this.PanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS3";
            this.PanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMain;
        private Xilium.CefGlue.WindowsForms.CefWebBrowser CefWebBrowserMainView;
    }
}

