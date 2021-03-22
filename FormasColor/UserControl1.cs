using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormasColor
{
    public enum EForma
    {
        ELIPSE, RECTANGULO, TEXTO
    }

    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        //********************** PROPIEDADES *********************************


        //acceso a la propiedad text
        [Category("aa")]
        [Description("acceso al texto del label del componente")]
        public string Textlabel
        {
            set
            {
                this.label1.Text = value;
                Refresh();
            }
            get
            {
                return this.label1.Text;
            }
        }


        private EForma formas;
        [Category("aa")]
        [Description("cambia forma a elipse, rectángulo o texto")]
        public EForma Formas
        {
            set
            {
                if (value == EForma.TEXTO)
                {
                    if (this.label1.Text == null)
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        formas = value;
                        Refresh();
                        CambiaForma?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    formas = value;
                    Refresh();
                }

            }
            get
            {
                return formas;
            }
        }


        //********************** EVENTOS *********************************

        [Category("aa")]
        [Description("evento que se lanza al cambiar la forma")]
        public event System.EventHandler CambiaForma;



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(this.ForeColor);
            Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);

            switch (formas)
            {
                case EForma.ELIPSE:
                    this.label1.Visible = false;
                    g.FillEllipse(brush, rectangle);
                    break;
                case EForma.RECTANGULO:
                    this.label1.Visible = false;
                    g.FillRectangle(brush, new RectangleF(0, 0, this.Width, this.Height));
                    break;
                case EForma.TEXTO:
                    this.label1.Visible = true;
                    this.label1.Location = new Point(0, 0);
                    this.Width = label1.Width;
                    this.Height = label1.Height;
                    break;
                default:
                    break;
            }

            brush.Dispose();
        }


        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (formas == EForma.ELIPSE)
            {

                formas = EForma.RECTANGULO;
                Refresh();
                Thread.Sleep(1000);
                formas = EForma.ELIPSE;
                Refresh();

            }
        }
    }


}
