using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainApp
{
    public partial class Form1 : Form
    {
        List<Train> trains = new List<Train>();

        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            trains.Clear();
            Random random = new Random();
            string[] destinations = { "Томск", "Москва", "Саратов", "Санкт-Петербург", "Новосибирск", "Омск", "Киров", "Екатеринбург", "Ростов", "Казань", "Красноярск", "Краснодар", "Уфа", "Пермь" };

            for (int i = 0; i < 10; i++)
            {
                Train train = new Train
                {
                    Destination = destinations[random.Next(destinations.Length)],
                    TrainNumber = random.Next(100, 1000),
                    DepartureTime = DateTime.Now.AddHours(random.Next(1, 24))
                };
                trains.Add(train);
            }
            SaveDataToFile();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            ReadDataFromFile();
            DisplayTrainsInListBox1();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            trains.Sort((x, y) => x.TrainNumber.CompareTo(y.TrainNumber));
            DisplayTrainsInListBox2();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var train in trains)
                    {
                        writer.WriteLine(train.ToString());
                    }
                }
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            int trainNumberToFilter = Convert.ToInt32(textBox1.Text);
            Train filteredTrain = trains.Find(t => t.TrainNumber == trainNumberToFilter);
            if (filteredTrain != null)
            {
                MessageBox.Show(filteredTrain.ToString(), "Filtered Train Information");
            }
            else
            {
                MessageBox.Show("Train not found", "Filtered Train Information");
            }
        }

        private void SaveDataToFile()
        {
            using (StreamWriter writer = new StreamWriter("trains.txt"))
            {
                foreach (var train in trains)
                {
                    writer.WriteLine(train.ToString());
                }
            }
        }

        private void ReadDataFromFile()
        {
            trains.Clear();
            using (StreamReader reader = new StreamReader("trains.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Train train = new Train
                    {
                        Destination = parts[0],
                        TrainNumber = int.Parse(parts[1]),
                        DepartureTime = DateTime.Parse(parts[2])
                    };
                    trains.Add(train);
                }
            }
        }

        private void DisplayTrainsInListBox1()
        {
            listBox1.Items.Clear();
            foreach (var train in trains)
            {
                listBox1.Items.Add(train.ToString());
            }
        }

        private void DisplayTrainsInListBox2()
        {
            listBox2.Items.Clear();
            foreach (var train in trains)
            {
                listBox2.Items.Add(train.ToString());
            }
        }
    }

    public class Train
    {
        public string Destination { get; set; }
        public int TrainNumber { get; set; }
        public DateTime DepartureTime { get; set; }

        public override string ToString()
        {
            return $"{Destination}, {TrainNumber}, {DepartureTime}";
        }
    }
}