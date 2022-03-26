using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Interface_
{
    public partial class pnlSuperior : Form
    {
        public pnlSuperior()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        { 
            Application.Exit();
        }

        private void btnfullscrem_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Maximized;
            btnfullscrem.Visible= false;
            btnrestaurar.Visible = true;
        }

        private void btnrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnrestaurar.Visible= false;
            btnfullscrem.Visible = true;
        }

        private void btnminimaize_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void callpanel(object callpanel)
        {
            if (this.pnlcontainer.Controls.Count > 0)
                this.pnlcontainer.Controls.RemoveAt(0);
            Form cp = callpanel as Form;
            cp.TopLevel = false;
            cp.Dock= DockStyle.Fill;    
            this.pnlcontainer.Controls.Add(cp);
            this.pnlcontainer.Tag = cp;
            cp.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            callpanel(new pos());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            callpanel(new Product());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            callpanel(new FormCliente());
        }
    }
}
