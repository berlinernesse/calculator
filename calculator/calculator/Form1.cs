using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace calculator
{
    public partial class Form1 : Form
    {
        //declarations 
        double firstNum;
        double secondNum;
        String operations;

        //Color declaration
        private readonly Color lightBackground = ColorTranslator.FromHtml("#FFDBE5");
        private readonly Color darkBackground = ColorTranslator.FromHtml("#393646");
        private readonly Color lightTextColor = ColorTranslator.FromHtml("#CC313D");
        private readonly Color darkTextColor = ColorTranslator.FromHtml("#F4EEE0");

        public Form1()
        {
            InitializeComponent();

            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //default colors
            tabPage1.BackColor = lightBackground;
            tabPage2.BackColor = lightBackground;
            textBox1.BackColor = lightBackground;
            textBox1.ForeColor = lightTextColor;
            boxDarkMode.ForeColor = ColorTranslator.FromHtml("#E27396");
        }


        //numbers 
        private void enterNumbers(object sender, EventArgs e)
        {
            System.Windows.Forms.Button num = (System.Windows.Forms.Button)sender;  

            if(textResult.Text == "0")
                textResult.Text = "";
            {
                if(num.Text == ".")
                {
                    if(!textResult.Text.Contains("."))
                        textResult.Text = textResult.Text + num.Text;
                } else
                {
                    textResult.Text = textResult.Text + num.Text;
                }
            }
        }


        //"dark mode"
        private void boxDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (boxDarkMode.Checked)
            {
                tabPage1.BackColor = darkBackground;
                tabPage2.BackColor = darkBackground;
                textBox1.BackColor = darkBackground;
                textBox1.ForeColor = darkTextColor;
                boxDarkMode.ForeColor = darkTextColor;
            }
            else
            {
                tabPage1.BackColor = lightBackground;
                tabPage2.BackColor = lightBackground;
                textBox1.BackColor = lightBackground;
                textBox1.ForeColor = lightTextColor;
                boxDarkMode.ForeColor = ColorTranslator.FromHtml("#E27396");
            }
        }

        //equations etc 

        private void numberOperations(object sender, EventArgs e)
        {
            System.Windows.Forms.Button num = (System.Windows.Forms.Button)sender;

            firstNum = Convert.ToDouble(textResult.Text);
            operations = num.Text;

            //taking care of the exponent button 
            if (operations == "x^y")
            {
                operations = "^";
                textResult.Text = ""; 
            }
            else
            {
                textResult.Text = ""; 
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            secondNum = Convert.ToDouble(textResult.Text);

            switch(operations)
            {
                case "+": 
                    textResult.Text = (firstNum + secondNum).ToString();
                    break;
                case "-":
                    textResult.Text = (firstNum - secondNum).ToString();
                    break;
                case "÷":
                    if(secondNum == 0)
                    {
                        textResult.Text = "Error: Dividing by Zero";
                    }
                    else
                    {
                        textResult.Text = (firstNum / secondNum).ToString();
                    }
                    break;
                case "x":
                    textResult.Text = (firstNum * secondNum).ToString();
                    break;
                case "^":
                    textResult.Text = (Math.Pow(firstNum, secondNum)).ToString();
                    break;
                default:
                    break;
            }
        }

        //clear equations, clear, and delete
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            textResult.Text = "";
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(textResult.Text.Length > 0)
            {
                textResult.Text = textResult.Text.Remove(textResult.Text.Length - 1, 1);
            }

            if(textResult.Text == "")
            {
                textResult.Text = "";
            }
        }

        private void btnOneOverX_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(textResult.Text);

            if(firstNum != 0)
            {
                textResult.Text = (1.0 / firstNum).ToString();
            } else
            {
                textResult.Text = "Error: Dividing by Zero";
            }
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(textResult.Text);
            textResult.Text = (firstNum * firstNum).ToString();
        }

        private void btnCube_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(textResult.Text);
            textResult.Text = (firstNum * firstNum * firstNum).ToString();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(textResult.Text);

            textResult.Text = (firstNum / 100).ToString();  
        }

        private void btnPosNeg_Click(object sender, EventArgs e)
        {
            firstNum = Convert.ToDouble(textResult.Text);
            textResult.Text = Convert.ToString(-1 * firstNum);
        }

    }
}
