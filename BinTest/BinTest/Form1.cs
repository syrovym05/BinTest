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
            this.Text = "TestBinarniSoubory";
            this.ShowIcon = false;
            this.CenterToScreen();
            button2.Visible = false;
            panel1.Visible = false;
            //FileStream fs = new FileStream("seznam.dat", FileMode.Truncate, FileAccess.Write);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("seznam.dat")) 
            {                
                File.Delete("seznam.dat");
            }
        }

        int pocetznamek;
        int i = 0;
        string s = "";
        string znamky = "";
        int pocet = 0;
        int soucet = 0;
        int znamka = 0;
        int vaha = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            pocetznamek = (int)numericUpDown1.Value;
            i = 0;                        
            s = pocetznamek.ToString() + " ";
            pocet = 0;
            soucet = 0;

            button2.Visible = true;
            panel1.Visible = true;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            i++;           
            if (i <= pocetznamek)
            {                
                vaha = (int)numericUpDown2.Value;
                s += vaha.ToString() + " ";

                znamka = (int)numericUpDown3.Value;
                s += znamka.ToString() + " ";
                znamky += znamka.ToString() + " ";

                soucet += znamka * vaha;
                pocet += vaha;
            }
            
            if(i == pocetznamek)
            {                
                listBox4.Items.Add(znamky);              
                   
                double prumer = Math.Round( (double)(soucet) / (double)(pocet),2);                
                listBox3.Items.Add(prumer);
                string jmeno = textBox1.Text + " " + textBox2.Text;

                if (prumer >= 4.5)
                {
                    textBox3.Text += "John Doe" + Environment.NewLine;
                    jmeno = "John Doe";
                    MessageBox.Show("Pozor!! Propadáš, vychází ti 5!!", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else textBox3.Text += textBox1.Text + " " + textBox2.Text + Environment.NewLine;

                if (prumer < 1.5) MessageBox.Show("Gratulace!! Vycházi ti jednicka", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (prumer > 3.5 && prumer < 4.5) MessageBox.Show("Pozor!! Vychazi ti 4", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Zapis(s +jmeno);
                button2.Visible = false;
                znamky = "";
            }                        
        }

        void Zapis(string s)
        {
            FileStream fs = new FileStream("seznam.dat", FileMode.Append, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
            bw.Write(s);            
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("seznam.dat", FileMode.Open, FileAccess.Read);            
            BinaryReader br = new BinaryReader(fs, Encoding.UTF8);
            listBox2.Items.Clear();
           
            br.BaseStream.Position = 0;
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                listBox2.Items.Add(br.ReadString());
            }

            fs.Close();
        }

       
    }
}
