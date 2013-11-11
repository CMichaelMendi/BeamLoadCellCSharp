using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeamLoadCellCSharp
{
    public partial class Form1 : Form
    {
        public float getNum(TextBox t) {//This is a function that you put a textbox into which returns the number in the textbox.
            float f;
            if (!float.TryParse(t.Text, out f)) {
                //If there's something other than a number in the textbox, then this will run.
                f = float.NaN;
            }
            return f;//Otherwise the function just returns f.
        }

        bool updating;
        public void update() {
            if (updating)
            {
                return;
            }
            else {
                updating = true;
            }

            float width = getNum(widthTB);
            float height = getNum(heightTB);
                areaTB.Text = (width * height).ToString();
                AreaMomInertTB.Text = ((width * Math.Pow(height, 3))/12).ToString();
            float areamominert = getNum(AreaMomInertTB);
            float length = getNum(lengthTB);
            float force = getNum(forceTB);
                momentTB.Text = (force * length).ToString();
            float moment = getNum(momentTB);
                stressTB2.Text = (moment * height / 2 / areamominert).ToString();
            float stress = getNum(stressTB2);
            float elasticmod = getNum(elasticmodTB);
            float yieldstress = getNum(yieldstressTB); 
                ///yieldstressTB.Text = "" + yieldstressSlideBar.Value;
                ///yieldstressSlideBar.Value = int.Parse(yieldstressTB.Text);
                if (yieldstress >= 30000 && yieldstress <=150000){
                    yieldstressSlideBar.Value = int.Parse(yieldstressTB.Text);
                    yieldrangemeterTB.BackColor = Color.WhiteSmoke;
                    yieldrangemeterTB.Text = "";
                }
                else if (yieldstress < 30000)
                {
                    yieldstressSlideBar.Value = 30000;
                    yieldrangemeterTB.Text = "Below Range";
                    yieldrangemeterTB.BackColor = Color.Aqua;
                }
                else
                {
                    yieldstressSlideBar.Value = 150000;
                    yieldrangemeterTB.Text = "Above Range";
                    yieldrangemeterTB.BackColor = Color.Red;
                }
                strainTB.Text = (stress / elasticmod * 1000000).ToString();
            float strain = getNum(strainTB);
            float SF = getNum(safetyfatorTB);
            float gain = getNum(gainTB);
            float gagefactor = getNum(gagefactorTB);
            float inputvoltage = getNum(inputvoltageTB);
                outputvoltageTB.Text = (strain / 1000000 * gagefactor * inputvoltage * gain).ToString();
            float outputvoltage = getNum(outputvoltageTB);
                calibrationfactorTB.Text = (outputvoltage / force).ToString();
            

            // THE SECTION BELOW IS FOR THE OUTPUT STATUS
            if (outputvoltage.Equals(float.NaN) || inputvoltage.Equals(float.NaN) || outputvoltage.Equals(0) || inputvoltage.Equals(0))
            {
                System.Diagnostics.Debug.WriteLine("A");
                failurestatusTB.Text = "N/A";
            }
            else if (outputvoltage > inputvoltage)
            {
                System.Diagnostics.Debug.WriteLine("B");
                outputstatusTB.Text = ("SATURATED");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("C");
                outputstatusTB.Text = ("OK");
            }
            // THE SECTION ABOVE IS FOR THE OUTPUT STATUS

            
            // THE SECTION BELOW IS FOR THE FAILURE STATUS FIELD
            if (stress.Equals(float.NaN) || yieldstress.Equals(float.NaN) || SF.Equals(float.NaN) || SF == 0)
            {
                System.Diagnostics.Debug.WriteLine("A");
                failurestatusTB.Text = "N/A";
            }
            else if (stress > (yieldstress / SF))
            {
                System.Diagnostics.Debug.WriteLine("B");
                failurestatusTB.Text = ("Fail");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("C");
                failurestatusTB.Text = ("Pass");
            }
            // THE SECTION ABOVE IS FOR THE FAILURE STATUS FIELD



            updating = false;
            
        }

        public Form1()//ignore me
        {
            InitializeComponent();
            widthTB.Text = 1.5.ToString();
            heightTB.Text = .125.ToString();
            lengthTB.Text = 20.ToString();
            forceTB.Text = 2.ToString();
            elasticmodTB.Text = 10700000.ToString();
            safetyfatorTB.Text = 2.ToString();
            yieldstressTB.Text = 42000.ToString();
            gainTB.Text = 200.ToString();
            gagefactorTB.Text = 2.11.ToString();
            inputvoltageTB.Text = 10.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void widthTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void heightTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void lengthTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }
        
        private void forceTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void momentTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void stressTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void elasticmodTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void yieldstressTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void strainTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void safetyfatorTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void failurestatusTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void gainTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void gagefactorTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void inputvoltageTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void outputvoltageTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void outputstatusTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void calibrationfactorTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void yieldstressSlideBar_Scroll(object sender, EventArgs e)
        {
            yieldstressTB.Text = "" + yieldstressSlideBar.Value;
            update();
        }

        private void stressTB2_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void yieldrangemeterTB_TextChanged(object sender, EventArgs e)
        {
            update();
        }

        private void steelBUT_Click(object sender, EventArgs e)
        {
            yieldstressTB.Text = 36000.ToString();
            elasticmodTB.Text = 29000000.ToString();
            update();
        }

        private void titaniumBUT_Click(object sender, EventArgs e)
        {
            yieldstressTB.Text = 128000.ToString();
            elasticmodTB.Text = 16500000.ToString();
            update();
        }

        private void alumBUT_Click(object sender, EventArgs e)
        {
            yieldstressTB.Text = 40000.ToString();
            elasticmodTB.Text = 10000000.ToString();
            update();
        }
                                                            
    }
}
