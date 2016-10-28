using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Calc_Step1
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Color[] colours =
            {
                Color.Blue,
                Color.Red,
                Color.Yellow,
                Color.Green,
                Color.Orange
            };
            while (true)
            {
                BackColor = colours[new Random().Next(0,4)];
                Thread.Sleep(500);
            }
        }
    }
}
