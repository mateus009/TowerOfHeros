using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    class Class1 : IMessageFilter
    {
        Rectangle BoundRect;
        Rectangle OldRect = Rectangle.Empty;

        public void EnableMouse()
        {
            Cursor.Clip = OldRect;
            Cursor.Show();
            Application.RemoveMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x201 || m.Msg == 0x202 || m.Msg == 0x203) return true;
            if (m.Msg == 0x204 || m.Msg == 0x205 || m.Msg == 0x206) return true;
            return false;
        }
        public void DisableMouse()
        {
            OldRect = Cursor.Clip;
            // Arbitrary location.
            BoundRect = new Rectangle(50, 50, 1, 1);
            Cursor.Clip = BoundRect;
            Cursor.Hide();
            Application.AddMessageFilter(this);
        }

        public Class1()
        {
        }

        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
             if (m.Msg >= 513 && m.Msg <= 515)
        {
            Console.WriteLine("Processing the messages : " + m.Msg);
            return true;
        }
        return false;
        }
    }
}
