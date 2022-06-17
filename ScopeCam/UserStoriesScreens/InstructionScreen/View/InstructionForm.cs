using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScopeCam
{
    public partial class InstructionForm : Form
    {
        public InstructionForm()
        {
            InitializeComponent();
        }

        Point lastLocation;
        bool mouseDown = false;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseDown == false && e.Button == MouseButtons.Left)
            {
                mouseDown    = true;
                lastLocation = e.Location;
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(this.DesktopLocation.X - lastLocation.X + e.X, 
                                        this.DesktopLocation.Y - lastLocation.Y + e.Y);
                this.Update();
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void MinimizeWindowButton_Click(object sender, EventArgs e)
        {
            minimizeWindowButton.ForeColor = Color.DarkTurquoise;

            this.WindowState  = FormWindowState.Minimized;
        }

        private void MinimizeWindowButton_MouseHover(object sender, EventArgs e)
        {
            minimizeWindowButton.ForeColor = Color.Aqua;
        }

        private void MinimizeWindowButton_MouseLeave(object sender, EventArgs e)
        {
            minimizeWindowButton.ForeColor = Color.White;
        }

        private void CloseWindowButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseWindowButton_MouseDown(object sender, MouseEventArgs e)
        {
            closeWindowButton.ForeColor = Color.IndianRed;
        }

        private void CloseWindowButton_MouseHover(object sender, EventArgs e)
        {
            closeWindowButton.ForeColor = Color.Red;
        }

        private void CloseWindowButton_MouseLeave(object sender, EventArgs e)
        {
            closeWindowButton.ForeColor = Color.White;
        }
    }
}
