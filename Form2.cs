using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace калькулятор
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Graphics g;
        float x, y, h, kx, ky, xs, ys, x_, y_, yper;
        bool flag;

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            switch (Form1.funksia) 
            {
                case "cos":
                    g = risuem.CreateGraphics();
                    g.DrawLine(new Pen(Color.Black), 0, 0, 0, risuem.Height);
                    g.DrawLine(new Pen(Color.Black),0,(risuem.Height-10)/2, 420,(risuem.Height-10)/2);
                    x = 0;
                    h = 2 * (float)Math.PI / 200;
                    kx = (risuem.Size.Width / (2 * (float)Math.PI));
                    ky = (risuem.Size.Height - 10) / (2);
                    x_=0;
                    y_=(risuem.Size.Height-10)/2;
                    for (int i = 0; i < 200; i++)
                    {
                        y = (float)Math.Cos(x);
                        yper = (float)Math.Cos(Form1.peremennaya % (2 * Math.PI));
                        yper = (risuem.Size.Height - 10) / 2 - yper * ky;
                        xs = x * kx;
                        ys = (risuem.Size.Height - 10) / 2 - y * ky;
                        g.DrawLine(new Pen(Color.Green), x_, y_, xs, ys);
                        if (flag) 
                        { 
                            g.FillEllipse(new SolidBrush(Color.Red), (int)(Form1.peremennaya % (2 * Math.PI) * kx - 4), (int)(yper - 4), 8, 8);
                            g.DrawString("[" + (Form1.peremennaya % (2 * Math.PI)).ToString() + " ; " + ((float)Math.Cos(Form1.peremennaya)).ToString() + "]", new Font("Arial", 8), new SolidBrush(Color.Black), risuem.Width/2-40, 40);
                            flag = false; 
                        }
                        x += h;
                        x_ = xs; 
                        y_ = ys;
                    }
                    break;
                case "sin":
                    g = risuem.CreateGraphics();
                    g.DrawLine(new Pen(Color.Black), 0,0,0,risuem.Height-10);
                    g.DrawLine(new Pen(Color.Black),0,(risuem.Height-10)/2, 420,(risuem.Height-10)/2);
                    x = 0;
                    h = 2 * (float)Math.PI / 200;
                    kx = (risuem.Size.Width / (2 * (float)Math.PI));
                    ky = (risuem.Size.Height - 10) / (2);
                    x_=0;
                    y_=(risuem.Size.Height-10)/2;
                    for (int i = 0; i < 200; i++)
                    {
                        y = (float)Math.Sin(x);
                        yper = (float)Math.Sin(Form1.peremennaya % (2 * Math.PI));
                        yper = (risuem.Size.Height - 10) / 2 - yper * ky;
                        xs = x * kx;
                        ys = (risuem.Size.Height - 10) / 2 - y * ky;
                        g.DrawLine(new Pen(Color.Green), x_, y_, xs, ys);
                        if (flag) 
                        { 
                            g.FillEllipse(new SolidBrush(Color.Red), (int) (Form1.peremennaya % (2 * Math.PI)*kx-4), (int) (yper-4), 8, 8);
                            g.DrawString("[" + (Form1.peremennaya % (2 * Math.PI)).ToString() + " ; " + ((float)Math.Sin(Form1.peremennaya)).ToString() + "]", new Font("Arial", 8), new SolidBrush(Color.Black), risuem.Width / 2 - 40, 40);
                            flag = false; 
                        }
                        x += h;
                        x_ = xs; 
                        y_ = ys;
                    }
                    break;
                case "tg":
                    g = risuem.CreateGraphics();
                    g.DrawLine(new Pen(Color.Black), risuem.Width / 2, 0, risuem.Width / 2, risuem.Height);
                    g.DrawLine(new Pen(Color.Black),0,(risuem.Height-10)/2, 420,(risuem.Height-10)/2);
                    x = 0;
                    h = 2 * (float)Math.PI / 200;
                    kx = (risuem.Size.Width / (2 * (float)Math.PI-0));
                    ky = (risuem.Size.Height - 10) / (40);
                    x_=0;
                    y_=(risuem.Size.Height-10)/2;
                    for (int i = 0; i < 200; i++)
                    {
                        y = (float)Math.Tan(x);
                        yper = (float)Math.Tan(Form1.peremennaya % (2 * Math.PI));
                        yper = (risuem.Size.Height - 10) / 2 - yper * ky;
                        xs = x * kx;
                        ys = (risuem.Size.Height - 10) / 2 - y * ky;
                        g.DrawLine(new Pen(Color.Green), x_, y_, xs, ys);
                        if (flag)
                        {
                            g.FillEllipse(new SolidBrush(Color.Red), (int)(Form1.peremennaya % (2 * Math.PI) * kx - 4+risuem.Width/2), (int)(yper - 4), 8, 8);
                            g.DrawString("[" + (Form1.peremennaya % (2 * Math.PI)).ToString() + " ; " + ((float)Math.Tan(Form1.peremennaya)).ToString() + "]", new Font("Arial", 8), new SolidBrush(Color.Black), risuem.Width / 2 - 40, 40);
                            flag = false;
                        } 
                        x += h;
                        x_ = xs; 
                        y_ = ys;
                    }
                    break;
                case "ctg":
                    g = risuem.CreateGraphics();
                    g.DrawLine(new Pen(Color.Black), risuem.Width / 2, 0, risuem.Width / 2, risuem.Height);
                    g.DrawLine(new Pen(Color.Black),0,(risuem.Height-10)/2, 420,(risuem.Height-10)/2);
                    x = (float)0.01;
                    h = 2 * (float)Math.PI / 200;
                    kx = (risuem.Size.Width / (2 * (float)Math.PI-0));
                    ky = (risuem.Size.Height - 10) / (40);
                    x_=0;
                    y_=(risuem.Size.Height-10)/2;
                    for (int i = 0; i < 200; i++)
                    {
                        y = (float)(1.0/Math.Tan(x));
                        yper = (float)(1.0/Math.Tan(Form1.peremennaya % (2 * Math.PI)));
                        yper = (risuem.Size.Height - 10) / 2 - yper * ky;
                        xs = x * kx;
                        ys = (risuem.Size.Height - 10) / 2 - y * ky;
                        g.DrawLine(new Pen(Color.Green), x_, y_, xs, ys);
                        if (flag) 
                        {
                            g.FillEllipse(new SolidBrush(Color.Red), (int)(Form1.peremennaya % (2 * Math.PI) * kx - 4 + risuem.Width / 2), (int)(yper - 4), 8, 8);
                            g.DrawString("[" + (Form1.peremennaya % (2 * Math.PI)).ToString() + " ; " + ((float)Math.Tan(Form1.peremennaya)).ToString() + "]", new Font("Arial", 8), new SolidBrush(Color.Black), risuem.Width / 2 - 40, 40);
                            flag = false;
                        }
                        x += h;
                        x_ = xs; 
                        y_ = ys;
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.form2.Close();
            
        }
    }
}
