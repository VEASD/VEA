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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[] cifri;
        Button[] ynar;
        Button[] binar;
        Button ravno;
        string[] binarText = { "/", "*", "+", "-","a^b" };
        string[] ynarText = { "√", "C", "±", ",", "sin", "ctg", "cos", "tg" };
        public static float peremennaya=0;
        public static string funksia;
        Graphics g;
        public static Form2 form2;
        public static Form1 form1 = new Form1();
        private void Form1_Load(object sender, EventArgs e)
        {
            // Создание массива цифр
            cifri = new Button[10];
            for(int i=0;i<cifri.Length;i++)
            {
                cifri[i]=new Button();

                if (i == 0)
                {
                    cifri[i].Size = new Size(131, 40);
                    cifri[i].Location = new Point(13, 266);
                    cifri[i].Text = i.ToString();
                    cifri[i].Parent = this;
                    cifri[i].Click += new EventHandler(CifriClick);
                }
                else
                {
                    cifri[i].Location = new Point(13+(46*((i-1)%3)), 220-(46*((i-1)/3)));
                    cifri[i].Size = new Size(40, 40);
                    cifri[i].Text = i.ToString();
                    cifri[i].Parent = this;
                    cifri[i].Click += new EventHandler(CifriClick);
                }

            }
            // Создание массива бинарных функций
            binar = new Button[5];
            for(int i=0;i<binar.Length;i++)
            {
                binar[i] = new Button();    
                binar[i].Size = new Size(40, 40);
                binar[i].Location = new Point(13+46*i, 82);
                binar[i].Text = binarText[i];
                binar[i].Parent = this;
                binar[i].Click += new EventHandler(BinarClick);
            }
            // Создание массива унарных функций
            ynar = new Button[8];
            for(int i=0;i<ynar.Length;i++)
            {
                ynar[i] = new Button();
                ynar[i].Size = new Size(40, 40);
                ynar[i].Location = new Point(151+46*(i%2), 266-46*(i/2));
                ynar[i].Text = ynarText[i];
                ynar[i].Parent = this;
                ynar[i].Click += new EventHandler(YnarClick);
            }
            ravno = new Button();
            ravno.Size = new Size(224, 20);
            ravno.Location = new Point(13, 56);
            ravno.Text = "=";
            ravno.Parent = this;
            ravno.Click += new EventHandler(RavnoClick);
        }
        public void CifriClick(object sender, EventArgs e)
        {
            Button a = sender as Button;
            switch(a.Text)
            {
                case "0":
                    if (label1.Text == "ОШИБКА") label1.Text="0"; else if (label1.Text != "0") label1.Text += "0"; else { label1.Text = "0,0"; ynar[3].Enabled = false; }
                    break;
                case "1":
                    if (label1.Text == "ОШИБКА") label1.Text = "1"; else if (label1.Text != "0") label1.Text += "1"; else { label1.Text = "0,1"; ynar[3].Enabled = false; }
                    break;
                case "2":
                    if (label1.Text == "ОШИБКА") label1.Text = "2"; else if (label1.Text != "0") label1.Text += "2"; else { label1.Text = "0,2"; ynar[3].Enabled = false; }
                    break;
                case "3":
                    if (label1.Text == "ОШИБКА") label1.Text = "3"; else if (label1.Text != "0") label1.Text += "3"; else { label1.Text = "0,3"; ynar[3].Enabled = false; }
                    break;
                case "4":
                    if (label1.Text == "ОШИБКА") label1.Text = "4"; else if (label1.Text != "0") label1.Text += "4"; else { label1.Text = "0,4"; ynar[3].Enabled = false; }
                    break;
                case "5":
                    if (label1.Text == "ОШИБКА") label1.Text = "5"; else if (label1.Text != "0") label1.Text += "5"; else { label1.Text = "0,5"; ynar[3].Enabled = false; }
                    break;
                case "6":
                    if (label1.Text == "ОШИБКА") label1.Text="6"; else if (label1.Text != "0") label1.Text += "6"; else { label1.Text = "0,6"; ynar[3].Enabled = false; }
                    break;
                case "7":
                    if (label1.Text == "ОШИБКА") label1.Text = "7"; else if (label1.Text != "0") label1.Text += "7"; else { label1.Text = "0,7"; ynar[3].Enabled = false; }
                    break;
                case "8":
                    if (label1.Text == "ОШИБКА") label1.Text = "8"; else if (label1.Text != "0") label1.Text += "8"; else { label1.Text = "0,8"; ynar[3].Enabled = false; }
                    break;
                case "9":
                    if (label1.Text == "ОШИБКА") label1.Text = "9"; else if (label1.Text != "0") label1.Text += "9"; else { label1.Text = "0,9"; ynar[3].Enabled = false; }
                    break;
            }
        }
        public void YnarClick(object sender, EventArgs e)
        {
            Button a = sender as Button;
            switch(a.Text)
            {
                case "√":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        if (Convert.ToSingle(label1.Text) >= 0)
                        {
                            label1.Text = (Convert.ToSingle(Math.Pow(Convert.ToSingle(label1.Text), 1.0 / 2))).ToString();
                            ynar[3].Enabled = true;
                        }
                        else label1.Text = "ОШИБКА";
                    }
                    break;
                case "C":
                    if (label1.Text != "")
                    {
                        peremennaya = 0;
                        label1.Text = "";
                        ynar[3].Enabled = true;
                    }
                    break;
                case "±":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        label1.Text = (-Convert.ToSingle(label1.Text)).ToString();
                    }
                    break;
                case ",":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        label1.Text += ",";
                        a.Enabled = false;
                    }
                    break;
                case "sin":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        peremennaya = Convert.ToSingle(label1.Text);
                        label1.Text = Math.Sin(peremennaya).ToString();
                        funksia = "sin";
                        form2 = new Form2();
                        form2.ShowDialog();
                    }
                    break;
                case "ctg":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        peremennaya = Convert.ToSingle(label1.Text);
                        label1.Text = (1.0/Math.Tan(peremennaya)).ToString();
                        funksia = "ctg";
                        form2 = new Form2();
                        form2.ShowDialog();
                    }
                    break;
                case "cos":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        peremennaya = Convert.ToSingle(label1.Text);
                        label1.Text = Math.Cos(peremennaya).ToString();
                        funksia = "cos";
                        form2 = new Form2();
                        form2.ShowDialog();                        
                    }
                    break;
                case "tg":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        peremennaya = Convert.ToSingle(label1.Text);
                        label1.Text = Math.Tan(peremennaya).ToString();
                        funksia = "tg";
                        form2 = new Form2();
                        form2.ShowDialog();                        
                    }
                    break;
            }
        }
        int index;
        public void BinarClick(object sender, EventArgs e)
        {
            Button a = sender as Button;
            switch (a.Text)
            {
                case "/":
                    if(label1.Text!="" && label1.Text!="ОШИБКА")
                    {
                        if (Convert.ToSingle(label1.Text) != 0)
                        {
                            if (peremennaya == 0) peremennaya = Convert.ToSingle(label1.Text);
                            else if (Convert.ToSingle(label1.Text) != 0) peremennaya /= Convert.ToSingle(label1.Text);
                            else label1.Text = "ОШИБКА";
                        }
                        label1.Text = "";
                        index = 1;
                        ynar[3].Enabled = true;
                    }
                    break;
                case "*":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        if(peremennaya==0) peremennaya = (float)1;
                        peremennaya *= Convert.ToSingle(label1.Text);
                        label1.Text = "";
                        index = 2;
                        ynar[3].Enabled = true;
                    }
                    break;
                case "+":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        peremennaya += Convert.ToSingle(label1.Text);
                        label1.Text = "";
                        index = 3;
                        ynar[3].Enabled = true;
                    }
                    break;
                case "-":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        if (peremennaya == 0) peremennaya += Convert.ToSingle(label1.Text);
                        else peremennaya -= Convert.ToSingle(label1.Text);
                        label1.Text = "";
                        index = 4;
                        ynar[3].Enabled = true;
                    }
                    break;
                case "a^b":
                    if (label1.Text != "" && label1.Text != "ОШИБКА")
                    {
                        peremennaya = Convert.ToSingle(label1.Text);
                        label1.Text = "";
                        index = 5;
                        ynar[3].Enabled = true;
                    }
                    break;
            }
        }
        public void RavnoClick(object sender, EventArgs e)
        {
            Button a = sender as Button;
            switch(index)
            {
                case 1:
                    if (Convert.ToSingle(label1.Text) != 0) 
                    {
                        peremennaya /= Convert.ToSingle(label1.Text);
                        label1.Text = peremennaya.ToString();
                    }
                    else label1.Text = "ОШИБКА";
                    
                    peremennaya = 0;
                    break;
                case 2:
                    peremennaya *= Convert.ToSingle(label1.Text);
                    label1.Text = peremennaya.ToString();
                    peremennaya = 0;
                    break;
                case 3:
                    peremennaya += Convert.ToSingle(label1.Text);
                    label1.Text = peremennaya.ToString();
                    peremennaya = 0;
                    break;
                case 4:
                    peremennaya -= Convert.ToSingle(label1.Text);
                    label1.Text = peremennaya.ToString();
                    peremennaya = 0;
                    break;
                case 5:
                    if (peremennaya <= 0 && Convert.ToSingle(label1.Text)!=(int)Convert.ToSingle(label1.Text)) label1.Text="ОШИБКА";
                    else label1.Text = (Math.Pow(peremennaya, Convert.ToDouble(label1.Text))).ToString();
                    break;
            }
        }

    }
}
