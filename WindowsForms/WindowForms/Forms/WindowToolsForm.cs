using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using Core;
using Tools;

namespace WindowForms
{
    public partial class WindowToolsForm : Form
    {
        private bool Dragging { get; set; }

        private IntPtr HwndCurrent { get; set; }

        private ArrayList Innerintptr { get; set; }

        public WindowToolsForm()
        {
            InitializeComponent();
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Resources.Drag;
            Innerintptr = new ArrayList { pictureBox1.Handle };
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Dragging = true;
            Cursor = new Cursor(new MemoryStream(Resources.Eye));
            ((PictureBox)sender).Image = Resources.Drag2;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Dragging) return;
            var intPtr = WindowsApi.WindowFromPoint(MousePosition);
            if (Innerintptr.Contains(intPtr))
            {
                intPtr = IntPtr.Zero;
            }
            if (intPtr == HwndCurrent) return;
            ApiTools.DrawRectFrame(HwndCurrent);
            ApiTools.DrawRectFrame(intPtr);
            HwndCurrent = intPtr;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            var pictureBox = ((PictureBox)sender);
            if (!Dragging) return;
            Dragging = false;
            Cursor = Cursors.Default;
            if (HwndCurrent == IntPtr.Zero) return;
            ApiTools.DrawRectFrame(HwndCurrent);
            HwndCurrent = IntPtr.Zero;
            pictureBox.Image = Resources.Drag;
            WindowsApi.SendMessage(Handle, 514u, 0, 0);
        }
    }
}
