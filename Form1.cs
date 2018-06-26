using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        //notitie: windows rekenmachine doet dit als je al een som hebt gemaakt: 
        //als je op = drukt overschrijft hij de quest
        //als je op een getal drukt en dan op = overschrijft hij de result en rekent verder met de oude quest
        bool Validator_pressed = false;
        bool Equal_pressed = false;
        bool M_pressed = false;
        string operation = "";
        double Rtext;
        double Qtext;
        double MResult;


        public Form1()
        {
            InitializeComponent();
        }


        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            //de 0 op het startscherm gaat weg en je begint te typen op een leeg scherm
            if (Result.Text == "0" || (Validator_pressed == true) || (Equal_pressed == true) || (M_pressed == true))
            {
                Result.Text = "";
                Result.Text += b.Text;
            }
            else
            {
                // niet meerdere komma's
                if (Result.Text.Contains(",") && (b.Text == ","))
                {
                    //er gebeurt niks
                }
                else
                {
                    Result.Text += b.Text;
                }
            }
            Validator_pressed = false;
            Equal_pressed = false;
            M_pressed = false;

            if (Result.Text == ",")
            {
                Result.Text = "0,";
            }
        }

        private void CE_Click(object sender, EventArgs e)
        {
            Qtext = 0;
            Rtext = 0;
            Equal_pressed = false;
            Result.Text = "0";
            Quest.Text = "";
        }

        private void C_Click(object sender, EventArgs e)
        {
            Equal_pressed = false;
            Result.Text = "0";
        }

        private void B_Click(object sender, EventArgs e)
        {
            Equal_pressed = false;
            //als er niet al een 0 op een scherm staat....
            if (Result.Text != "0")
            {
                //haal je het laatste getal weg
                Result.Text = Result.Text.Remove(Result.Text.Length - 1, 1);
            }
            //je wilt geen leeg scherm dus voer je de 0 weer in
            if (Result.Text == "")
            {
                Result.Text = "0";
            }
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (Result.Text.StartsWith("-"))
            {
                Result.Text = Result.Text.Remove(0, 1);
            }
            else
            {
                Result.Text = "-" + Result.Text;
            }
        }

        private void Validator_Click(object sender, EventArgs e)
        {
            Equal_pressed = false;
            Qtext = double.Parse(Result.Text);
            Button b = (Button)sender;
            operation = b.Text;
            Validator_pressed = true;

            if (Result.Text.EndsWith(","))
            {
                Quest.Text = Result.Text.Remove(Result.Text.Length - 1, 1) + b.Text;
            }
            else
            {
                Quest.Text = Result.Text + b.Text;
            }
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            switch (Equal_pressed)
            {
                //als eerder op = is gedrukt reken je verder met het getal dat je zelf hebt getypt in result
                case true:
                    Qtext = double.Parse(Result.Text);
                    break;
                //zo niet reken je met het getal dat er nog staat
                case false:
                    Rtext = double.Parse(Result.Text);
                    if (Qtext != 0)
                    {
                        Qtext = double.Parse(Quest.Text.Remove(Quest.Text.Length - 1, 1));
                    }
                    break;
                default:
                    break;
            }
            //history en Answer_history vullen met de geschiedenis
            History2.Text = History.Text;
            RHistory2.Text = RHistory.Text;
            if (Equal_pressed == true)
            {
                History.Text = Result.Text + operation;
            }
            else
            {
                History.Text = Quest.Text;
            }
            //History.Text = Quest.Text;
            RHistory.Text = Rtext.ToString();

            switch (operation)
            {
                case "+":
                    Result.Text = (Qtext + Rtext).ToString();                    
                    break;
                case "-":
                    Result.Text = (Qtext - Rtext).ToString();
                    break;
                case "/":
                    Result.Text = (Qtext / Rtext).ToString();
                    break;
                case "*":
                    Result.Text = (Qtext * Rtext).ToString();
                    break;
                default:
                    break;
            }

            //Answer_history komt pas na de berekening
            Answer_History2.Text = Answer_History.Text;
            Answer_History.Text = Result.Text;

            Equal_pressed = true;
        }

        private void Result_TextChanged(object sender, EventArgs e)
        {

        }

        private void History_TextChanged(object sender, EventArgs e)
        {

        }

        private void History_click(object sender, EventArgs e)
        {
            if (History.Text != "")
            {
                Equal_pressed = false;
                Result.Text = RHistory.Text;
                Quest.Text = History.Text;
                operation = History.Text.Substring(History.Text.Length - 1, 1);
            }
            else
            {
                
            }
        }

        private void History2_TextChanged(object sender, EventArgs e)
        {
        }

        private void History2_click(object sender, EventArgs e)
        {
            if (History.Text != "")
            {
                Equal_pressed = false;
                Result.Text = RHistory2.Text;
                Quest.Text = History2.Text;
                operation = History2.Text.Substring(History2.Text.Length - 1, 1);
            }            
        }

        private void MPlus_Click(object sender, EventArgs e)
        {
            if (Result.Text != ",")
            {
                MResult = MResult += double.Parse(Result.Text);
                M_pressed = true;
            }
        }

        private void MMin_Click(object sender, EventArgs e)
        {
            if (Result.Text != ",")
            {
                MResult = MResult -= double.Parse(Result.Text);
                M_pressed = true;
            }
        }

        private void MR_Click(object sender, EventArgs e)
        {
            Result.Text = MResult.ToString();
            M_pressed = true;
        }

        private void MC_Click(object sender, EventArgs e)
        {
            MResult = 0;
            M_pressed = true;
        }
    }
}
