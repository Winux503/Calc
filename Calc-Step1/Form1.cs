using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_Step1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// A simple calculator application, made in C#
        /// made by Samuel Tamplin as part of my computer security course
        /// </summary>
        public Form1()
        {
            //starts the form
            InitializeComponent();
            //sets the diplay text to 0
            txtDisplay.Text = "0";
            
        }
        /// <summary>
        /// Global variable declarations
        /// </summary>
        string secTxt;
        bool Isclicked = true;
        double memoryValue = 0.0;
        bool clearDisplay = true;
        bool isFirstValue = true;
        bool isAfterEqual = false;
        double currentAnswer;
        double lastValueEntered;
        char lastOp;

        private void Form1_Load(object sender, EventArgs e)
        {
            //don't know why this is here
            //I'm guessing it loads the form
        }

        private void btnDP_Click(object sender, EventArgs e)
        {
            if (clearDisplay)
            {
                txtDisplay.Text = "0.";
                clearDisplay = false;
            }
            else
            {
                txtDisplay.AppendText(".");
            }
            if (isAfterEqual)
            {
                currentAnswer = 0.0;
                lastOp = ' ';
            }
            isAfterEqual = false;
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            OpHandler();
            lastOp = '*';
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
           if(isAfterEqual == false)
            {
                lastValueEntered = double.Parse(txtDisplay.Text);

            }
            isAfterEqual = true;
            switch (lastOp)
            {
                case '+':
                    currentAnswer += lastValueEntered;
                    break;
                case '-':
                    currentAnswer -= lastValueEntered;
                    break;
                case '/':
                    currentAnswer /= lastValueEntered;
                    break;
                case '*':
                    currentAnswer *= lastValueEntered;
                    break;
            }
            txtDisplay.Text = currentAnswer.ToString();
            isFirstValue = true;
        }

        private void btnBksp_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length > 1)
            {
                
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }else
            {
                txtDisplay.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            clearDisplay = true;
            btnDP.Enabled = true;
            isFirstValue = true;
            isAfterEqual = false;
            lastOp = ' ';
            currentAnswer = 0.0;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            
            string newTxt = "";
            string oldTxt = txtDisplay.Text;
            
            if (Isclicked == true)
            {
                char sep = ' ';

                txtDisplay.Text = "-" + sep + oldTxt;
                string[] splitTxt = txtDisplay.Text.Split(sep);
                newTxt = splitTxt[0] + splitTxt[1];
                secTxt = splitTxt[1];
                txtDisplay.Text = "-" + oldTxt;
                Isclicked = false;
            } else if (Isclicked == false)
            {
                txtDisplay.Text = secTxt;
                Isclicked = true;
            }
        }

        private void btnMclr_Click(object sender, EventArgs e)
        {
            memoryValue = 0.0;
        }

        private void btnMrec_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = Convert.ToString(memoryValue);
        }

        private void btnMsub_Click(object sender, EventArgs e)
        {
            memoryValue -= Convert.ToDouble(txtDisplay.Text);
        }

        private void btnMadd_Click(object sender, EventArgs e)
        {
            memoryValue += Convert.ToDouble(txtDisplay.Text); 
        }

        private void OpHandler()
        {
            clearDisplay = true;
            btnDP.Enabled = true;
            if (isFirstValue)
            {
                currentAnswer = double.Parse(txtDisplay.Text);
                isFirstValue = false;

            }
            else
            {
                lastValueEntered = double.Parse(txtDisplay.Text);
                switch (lastOp)
                {
                    case '+':
                        currentAnswer += lastValueEntered;
                        break;
                    case '-':
                        currentAnswer -= lastValueEntered;
                        break;
                    case '/':
                        currentAnswer /= lastValueEntered;
                        break;
                    case '*':
                        currentAnswer *= lastValueEntered;
                        break;
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string digit = button.Text;
            if(clearDisplay)
            {
                txtDisplay.Text = digit;
                clearDisplay = false;
            }else
            {
                txtDisplay.AppendText(digit);
            }
            if (isAfterEqual)
            {
                currentAnswer = 0.0;
                lastOp = ' ';
            }
            isAfterEqual = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpHandler();   
            lastOp = '+';
            //isAfterEqual = false;
            //txtDisplay.Text = currentAnswer.ToString();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            OpHandler();
            lastOp = '-';
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            OpHandler();
            lastOp = '/';
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            btnDP.Enabled = !txtDisplay.Text.Contains(".");
        }

        private void btnOpt_Click(object sender, EventArgs e)
        {
            this.Size = new Size(635, 435);
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightPink;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkSeaGreen;
        }

        private void btnGrey_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightSlateGray;
        }

        private void btnColRes_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(240,240,240);
        }

        private void btnOpt2_Click(object sender, EventArgs e)
        {
            this.Size = new Size(413, 435);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDisplay.ForeColor = Color.Blue;
        }

        private void btnTxtWhite_Click(object sender, EventArgs e)
        {
            txtDisplay.ForeColor = Color.White;
        }

        private void btnTxtYellow_Click(object sender, EventArgs e)
        {
            txtDisplay.ForeColor = Color.Yellow;
        }

        private void btnTxtRes_Click(object sender, EventArgs e)
        {
            txtDisplay.ForeColor = Color.Aquamarine;
        }

        private void About_Click(object sender, EventArgs e)
        {
            Form2 Second = new Form2();
            Second.Show();
        }
    }
}
