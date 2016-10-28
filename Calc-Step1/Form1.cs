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
                case 'S':
                    currentAnswer = Math.Sqrt(lastValueEntered);
                    break;
                case 'L':
                    currentAnswer = Math.Log(lastValueEntered);
                    break;
                case 'E':
                    currentAnswer = Math.Sin(lastValueEntered);
                    break;
                case 'C':
                    currentAnswer = Math.Cos(lastValueEntered);
                    break;
                case 'T':
                    currentAnswer = Math.Tan(lastValueEntered);
                    break;
                case 'P':
                    currentAnswer = Math.Pow(currentAnswer, lastValueEntered);
                    break;
                case 'A':
                    currentAnswer = Math.Abs(lastValueEntered);
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
                    case 'S':
                        currentAnswer = Math.Sqrt(lastValueEntered);
                        break;
                    case 'L':
                        currentAnswer = Math.Log(lastValueEntered);
                        break;
                    case 'E':
                        currentAnswer = Math.Sin(lastValueEntered);
                        break;
                    case 'C':
                        currentAnswer = Math.Cos(lastValueEntered);
                        break;
                    case 'T':
                        currentAnswer = Math.Tan(lastValueEntered);
                        break;
                    case 'P':
                        currentAnswer = Math.Pow(currentAnswer, lastValueEntered);
                        break;
                    case 'A':
                        currentAnswer = Math.Abs(lastValueEntered);
                        break;
                }
            }
        }
        
        private void btn_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            string digit = button.Text;

            if (clearDisplay)
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

        /// <summary>
        /// Below is all of the calculator options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnOpt_Click(object sender, EventArgs e)
        {
            for (int i = 413; i <= 635; i++)
            {
                i++;
                i++;
                this.Size = new Size(i , 477);
                Thread.Sleep(1);
                //this.Size = new Size(635, 435);
            }
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
            for (int i = 635; i >= 413; --i)
            {
               --i;
               this.Size = new Size(i, 477);
               Thread.Sleep(1);
            }
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

        private void btnLog_Click(object sender, EventArgs e)
        {
            OpHandler();
            lastOp = 'L';
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            OpHandler();
            lastOp = 'S';
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            OpHandler();
            lastOp = 'E';
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            OpHandler();
            lastOp = 'C';
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            OpHandler();
            lastOp = 'T';
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            OpHandler();
            lastOp = 'P';
        }

        private void btnAbs_Click(object sender, EventArgs e)
        {
            OpHandler();
            lastOp = 'A';
        }
    }
}
