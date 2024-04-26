using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_11_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int n = trackBar1.Value;
            label1.Text = "n = " + n.ToString();

            // Вычисление с помощью цикла
            long sumLoop = 0;
            for (int i = 1; i <= n; i++)
            {
                sumLoop += (long)Math.Pow(i, 4);
            }
            label2.Text = "Сумма (цикл): " + sumLoop.ToString();

            // Вычисление по формуле
            long sumFormula = n * (n + 1) * (2 * n + 1) * (3 * n * n + 3 * n - 1) / 30;
            label3.Text = "Сумма (формула): " + sumFormula.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
