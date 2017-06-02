using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifePlus.POS
{
    class MessageFilter : IMessageFilter
    {
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;

        public MessageFilter()
        {
            Application.AddMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN)
            {
                int x = (m.LParam.ToInt32() >> 0x00) & 0xFFFF;
                int y = (m.LParam.ToInt32() >> 0x10) & 0xFFFF;


            }

            if (m.Msg == WM_LBUTTONUP)
            {
                int x = (m.LParam.ToInt32() >> 0x00) & 0xFFFF;
                int y = (m.LParam.ToInt32() >> 0x10) & 0xFFFF;


            }

            return false;
        }
    }
}
