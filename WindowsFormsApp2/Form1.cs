using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog dlAbrir = new OpenFileDialog();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        string from,cc, subject, body,route;

        private void txtadd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            var folder = txtruta.Text;
            fbd.SelectedPath = folder;
            fbd.Description = "Select path of destiny";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                lblruta.Text = fbd.SelectedPath;
                route = txtruta.Text;
            }
            else
            {
                MessageBox.Show("Porfavor de seleccionar una ruta");
            }
        }

        mail obj = new mail();

        private void txtsend_Click(object sender, EventArgs e)
        {
            from = txtdest.Text;
            cc = txtcc.Text;
            subject = txtasunt.Text;
            body = txtmensaje.Text;
            route = txtruta.Text;
            try
            {
                obj.SMTP(from,subject, body, cc, route);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            MessageBox.Show("Mensaje Envidoa correctamente");

        }
    }
}
