using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
        }
      
        int pocetznamek;
        int i = 0;
        string s = "";
        int pocet = 0;
        int soucet = 0;
        int znamka = 0;
        int vaha = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            pocetznamek = (int)numericUpDown1.Value;
            i = 0;
            s = pocetznamek.ToString() + " ";
            button2.Visible = true;
            pocet = 0;
            soucet = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i++;
           
            if (i <= pocetznamek*2)
            {
                
                if (i % 2 == 0)
                {
                    znamka = (int)numericUpDown3.Value;
                    s += znamka.ToString()+ " ";
                   
                    soucet += znamka * vaha;
                    pocet += vaha;
                }
                else
                {
                    vaha = (int)numericUpDown2.Value;
                    s += vaha.ToString() + " ";
                }
                
                
            }
            else
            {
                listBox1.Items.Add(s);
                double prumer = (double)(soucet) / (double)(pocet);
                if (prumer == 5)
                {
                    textBox3.Text += "John Doe" + Environment.NewLine;
                }
                else textBox3.Text += textBox1.Text + " " + textBox2.Text + Environment.NewLine;

                button2.Visible = false;

                if (prumer < 1.5) MessageBox.Show("Gratulace!! Vycházi ti jednicka");
                if (prumer > 3.5 && prumer < 4.5) MessageBox.Show("Pozor!! Vychazi ti 4");

            }                        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("seznam.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
            BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
            int i = 0;
            foreach(string s in listBox1.Items)
            {
                bw.Write(s + textBox3.Lines[i]);
                i++;
            }

            br.BaseStream.Position = 0;
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                listBox2.Items.Add(br.ReadString());
            }



        }
    }
}
