using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_10_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double callDuration = Convert.ToDouble(textBox1.Text);
            double callCostPerMinute = 2.0; // Стоимость разговора в будний день
            double totalCost;

            if (radioButton1.Checked) // Если выбран рабочий день
            {
                totalCost = callDuration * callCostPerMinute;
            }
            else // Если выбран выходной день
            {
                totalCost = callDuration * callCostPerMinute * 0.8; // Применяем скидку 20%
            }

            MessageBox.Show("Стоимость разговора: " + totalCost.ToString()); // Выводим стоимость в виде денежного формата
        }
    }
}
