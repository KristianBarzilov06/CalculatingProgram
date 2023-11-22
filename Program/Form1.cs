using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> list = textBox1.Text.Split(' ').Select(l => double.Parse(l)).ToList();
            var avg = list.Average();

            list.Sort();
            double median = 0;
            if (list.Count % 2 == 1)
            {
                median = list[(list.Count - 1) / 2];
            }
            if (list.Count % 2 == 0)
            {
                var index = list.Count / 2;
                median = (list[index] + list[index - 1]) / 2.0;
            }

            var mode = list.GroupBy(x => x)
                .OrderByDescending(x => x.Count()).ThenBy(x => x.Key)
                .ThenBy(x => (int)x.Key)
                .FirstOrDefault();
            

            chart1.Series.Clear();
            chart1.Series.Add("Results");
            chart1.Series["Results"].Points.AddXY("Average", avg);
            chart1.Series["Results"].Points.AddXY("Median", median);
            chart1.Series["Results"].Points.AddXY("Mode", mode.Key);

            MessageBox.Show($"Average: {avg}\nMedian: {median}\nMode: {mode.Key}", "Results");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
