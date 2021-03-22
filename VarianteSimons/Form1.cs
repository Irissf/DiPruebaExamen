using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarianteSimons
{
    public partial class Form1 : Form
    {
        public int x = 10;
        public int y = 10;
        public int height = 30;
        public Form1()
        {
            InitializeComponent();
            CrearComponentesPanel();
        }

        private void CrearComponentesPanel()
        {
            for (int i = 0; i < 5; i++)
            {
                x = 10;
                y += 10;
                
                for (int j = 0; j < 8; j++)
                {
                    FormasColor.UserControl1 user = new FormasColor.UserControl1();
                    user.Formas = FormasColor.EForma.ELIPSE;
                    user.Width = 40;
                    user.Height = height;
                    user.Textlabel = "Acierto";
                    user.ForeColor = Color.CadetBlue;
                    user.Location = new Point(x+=(10 + user.Width),y);
                    user.Enabled = false;
                    this.panel1.Controls.Add(user);

                }
                y += (10 + height);


            }
        }

        private void userControl11_Click_1(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
