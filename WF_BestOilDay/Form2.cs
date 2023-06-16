using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WF_BestOilDay
{
    public partial class Form2 : Form
    {
        string[] type = { "A 95plus", "A 95", "ДТ*", "Газ" };
        double[] price = { 53.99, 51.49, 55.49, 28.79 };
        double[] pr_food = { 29.50, 69.79, 35.5, 25.99 };
        double[] res = new double[4] {0,0,0,0};       // результат по чек боксам -- ціна * кількість
        List<double> dayProfit = new List<double>();  // результати торгівлі за день
        public Form2()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { type[0], type[1], type[2], type[3] });            
            comboBox1.Text = type[0];
            textBox1.Text = price[0].ToString();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) textBox1.Text = price[0].ToString();
            if (comboBox1.SelectedIndex == 1) textBox1.Text = price[1].ToString();
            if (comboBox1.SelectedIndex == 2) textBox1.Text = price[2].ToString();
            if (comboBox1.SelectedIndex == 3) textBox1.Text = price[3].ToString();
            textBox1.Enabled = false;                      
            textBox2.Text = textBox3.Text = "";

        }        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (button1.CanFocus == false)
            {
                textBox2.Text = "";
                textBox3.Text = "";
            }
                textBox2.BackColor = Color.White;
                textBox2.Enabled = true;
                textBox3.BackColor = Color.SeaShell;
                textBox3.Enabled = false;                                
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (button1.CanFocus == false)
            {
                textBox2.Text = "";
                textBox3.Text = "";
            }
                textBox3.BackColor = Color.White;
                textBox3.Enabled = true;
                textBox2.BackColor = Color.SeaShell;
                textBox2.Enabled = false;            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        { 
            if (radioButton1.Checked == true)
            {
                if (textBox2.Text.Length != 0)
                {
                    textBox3.Enabled = true;
                    double temp = Math.Round((double.Parse(textBox1.Text) * double.Parse(textBox2.Text)),2);
                    textBox3.Text = temp.ToString();
                    label10.Text = temp.ToString();
                }
                else
                {
                    if (button1.CanFocus == false)
                    {
                        textBox3.Text = "";
                        textBox3.BackColor = Color.SeaShell;
                        label10.Text = "00,00";                       
                    }
                }
                if (textBox2.Text == "")
                {
                    textBox3.Text = "";
                    label10.Text = "00,00";
                    label11.Text = "00,00";
                }
                textBox3.Enabled = false;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                if (textBox3.Text.Length != 0 )
                {
                    textBox2.Enabled = true;
                    double temp = (double.Parse(textBox3.Text) / double.Parse(textBox1.Text));
                    textBox2.Text = (Math.Round(temp,2)).ToString();
                    label10.Text = textBox3.Text;                  
                }
                else
                {
                    if (button1.CanFocus == false)
                    {
                        textBox2.Text = "";
                        textBox2.BackColor = Color.SeaShell;
                        label10.Text = "00,00";
                    }
                }
                if (textBox3.Text == "")
                {
                    textBox2.Text = "";
                    label10.Text = "00,00";
                    label11.Text = "00,00";
                }
                textBox2.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double temp = Math.Round(double.Parse(label10.Text) + double.Parse(label9.Text),2);
            string str = temp.ToString();
            label11.Text = temp.ToString();           
        }
        // +-------------- Міні кафе -------------------
        //
        // +--------------- хот-дог --------------------
        private void checkBox1_CheckedChanged(object sender, EventArgs e)  // хот-дог
        {           
            if (checkBox1.Checked == true)
            {
                textBox8.Text = "0";
                textBox8.BackColor = Color.White;
                textBox8.Enabled = true;
                textBox4.Text = pr_food[0].ToString();              
            }
            else
            {
                textBox8.BackColor = Color.SeaShell;
                textBox8.Enabled = false;
                textBox8.Text = "";
                textBox4.Text = "";                
            }            
        }
        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {           
            if (textBox8.Text != "0" && textBox8.Text != "")
            {
                res[0] = double.Parse(textBox8.Text) * double.Parse(textBox4.Text);               
                label9.Text = CheckSum().ToString();
            }
            else
            {
                res[0] = 0;
                if (CheckSum() == 0)               
                    label9.Text = "00,00";
                else label9.Text = CheckSum().ToString();
            }
            label11.Text = "00,00";
        }
        //+------------------- гамбургер ----------------------
        private void checkBox2_CheckedChanged(object sender, EventArgs e)  // гамбургер
        {
            if (checkBox2.Checked == true)
            {
                textBox9.Text = "0";
                textBox9.BackColor = Color.White;
                textBox9.Enabled = true;
                textBox5.Text = pr_food[1].ToString();
            }
            else
            {
                textBox9.BackColor = Color.SeaShell;
                textBox9.Enabled = false;
                textBox9.Text = "";
                textBox5.Text = "";
            }
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {          
            if (textBox9.Text != "0" && textBox9.Text != "")
            {
                res[1] = double.Parse(textBox9.Text) * double.Parse(textBox5.Text);               
                label9.Text = CheckSum().ToString();
            }
            else
            {
                res[1] = 0;
                if (CheckSum() == 0)
                    label9.Text = "00,00";
                else label9.Text = CheckSum().ToString();
            }
            label11.Text = "00,00";
        }
        //+------------------- картопля фрі ----------------------
        private void checkBox3_CheckedChanged(object sender, EventArgs e)  // картопля фрі
        {
            if (checkBox3.Checked == true)
            {
                textBox10.Text = "0";
                textBox10.BackColor = Color.White;
                textBox10.Enabled = true;
                textBox6.Text = pr_food[2].ToString();
            }
            else
            {
                textBox10.BackColor = Color.SeaShell;
                textBox10.Enabled = false;
                textBox10.Text = "";
                textBox6.Text = "";
            }
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text != "0" && textBox10.Text != "")
            {
                res[2] = double.Parse(textBox10.Text) * double.Parse(textBox6.Text);
                label9.Text = CheckSum().ToString();
            }
            else
            {
                res[2] = 0;
                if (CheckSum() == 0)
                    label9.Text = "00,00";
                else label9.Text = CheckSum().ToString();
            }
            label11.Text = "00,00";
        }
        //+------------------- кока-кола ----------------------
        private void checkBox4_CheckedChanged(object sender, EventArgs e)  // кока-кола
        {
            if (checkBox4.Checked == true)
            {
                textBox11.Text = "0";
                textBox11.BackColor = Color.White;
                textBox11.Enabled = true;
                textBox7.Text = pr_food[3].ToString();
            }
            else
            {
                textBox11.BackColor = Color.SeaShell;
                textBox11.Enabled = false;
                textBox11.Text = "";
                textBox7.Text = "";
            }
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text != "0" && textBox11.Text != "")
            {
                res[3] = double.Parse(textBox11.Text) * double.Parse(textBox7.Text);
                label9.Text = CheckSum().ToString();
            }
            else
            {
                res[3] = 0;
                if (CheckSum() == 0)
                    label9.Text = "00,00";
                else label9.Text = CheckSum().ToString();
            }
            label11.Text = "00,00";
        }

        public double CheckSum()
        {
            double temp = 0;
            for (int i = 0; i < res.Length; i++) temp = Math.Round(temp + res[i], 2);
            return temp;
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            label11.Text = "00,00";
        }

        private void button2_Click(object sender, EventArgs e)  // новий клієнт
        {
            if (label9.Text != "00,00" || label10.Text != "00,00")
            {
                ChangePicture();
                double temp = double.Parse(label11.Text);
                label9.Text = label10.Text = label11.Text = "00,00";
                radioButton1.Checked = radioButton2.Checked = false;
                checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = checkBox4.Checked = false;
                textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text =
                    textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text =
                        textBox10.Text = textBox11.Text = "";
                textBox3.BackColor = textBox2.BackColor = Color.SeaShell;
                textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled =
                    textBox6.Enabled = textBox7.Enabled = textBox8.Enabled = textBox9.Enabled =
                        textBox10.Enabled = textBox11.Enabled = false;
                dayProfit.Add(temp);
            }
        }

        private void button3_Click(object sender, EventArgs e)  // денний результат
        {
            label9.Text = label10.Text = "00,00";
            radioButton1.Checked = radioButton2.Checked = false;
            checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = checkBox4.Checked = false;
            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text =
                textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text =
                    textBox10.Text = textBox11.Text = "";
            textBox3.BackColor = textBox2.BackColor = Color.SeaShell;
            textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled =
                textBox6.Enabled = textBox7.Enabled = textBox8.Enabled = textBox9.Enabled =
                    textBox10.Enabled = textBox11.Enabled = false;           
                double temp = 0;
            
                for (int i = 0; i < dayProfit.Count; i++)
                {
                    temp += dayProfit[i];
                }
                label11.Text = Math.Round(temp, 2).ToString();
            
            pictureBox2.Width = 0;
            pictureBox2.Height = 0;
        }
        async public void ChangePicture()
        {
            pictureBox2.Width = 0;
            pictureBox2.Height = 0;
            if (label11.Text != "00,00")
            {               
                for (byte x = 0, y = 0; x < 91 && y < 84; x++, y++)
                {
                    await Task.Delay(70);
                    pictureBox2.Width = x;
                    pictureBox2.Height = y;
                }
                pictureBox2.Width = 91;
                pictureBox2.Height = 84;
            }
        }       
    }
}
