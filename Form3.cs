using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog7312_task1
{
    ///-------------------------------------------------------------------------------------------------------------------///
    /// <summary>
    /// REFERENCES
    /// </summary>
    /// https://www.tutorialsteacher.com/csharp/csharp-dictionary
    /// https://www.library.illinois.edu/infosci/research/guides/dewey/
    /// http://csharp.net-informations.com/collection/dictionary.htm
    /// https://www.csharp-code.com/2013/11/c-example-dictionary-index-of-key.html
    /// https://stackoverflow.com/questions/30014901/generating-random-numbers-without-repeating-c
    /// https://stackoverflow.com/questions/4648781/how-to-get-character-for-a-given-ascii-value
    /// https://www.youtube.com/watch?v=ocD7wuF8PTg
    ///-------------------------------------------------------------------------------------------------------------------///

    public partial class answer1Txbox : Form
    {
        ///--------------------------------------------------------- START OF CODE --------------------------------------------///
        /// <summary>
        /// Creating my Dictionary
        /// </summary>
        IDictionary<int, string> numberName = new Dictionary<int, string>();
        IDictionary<int, string> NumberDescript = new Dictionary<int, string>();
        IDictionary<string, string> NameDescript = new Dictionary<string, string>();
       // List<int> random7Numbers = Enumerable.Range(0, 7).ToList();

        List<int> randNum7List = new List<int>();
        List<int> randNum4List = new List<int>();
        Random rand = new Random();

        private int secondsTotal;
        ///-------------------------------------------------------------------------------------------------------------------///
        public answer1Txbox()
        {
            InitializeComponent();

            KeyValueDictionary();

        }
        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// A method to add my key/value using the Add() method
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        public void KeyValueDictionary()
        {
            numberName.Add(000, "Generalities");
            numberName.Add(100, "Philosophy & psychology");
            numberName.Add(200, "Religion");
            numberName.Add(300, "Social sciences");
            numberName.Add(400, "Language");
            numberName.Add(500, "Natural sciences");
            numberName.Add(600, "Technology");
            numberName.Add(700, "The arts");
            numberName.Add(800, "Literature");
            numberName.Add(900, "Geography & history");

            NumberDescript.Add(000, "Knowledge of a broad range of facts about various subjects");
            NumberDescript.Add(100, "A general vision of being human");
            NumberDescript.Add(200, "A type of belief where people worship");
            NumberDescript.Add(300, "An acedemic study");
            NumberDescript.Add(400, "System of communication");
            NumberDescript.Add(500, "Physics, chemistry, or biology");
            NumberDescript.Add(600, "Knowledge to invent new devices or tools");
            NumberDescript.Add(700, "Expression of human creative skill and imagination");
            NumberDescript.Add(800, "Books and writings published based on a particular subject");
            NumberDescript.Add(900, "Events and places that has affected each other across time");

            NameDescript.Add("Generalities", "Knowledge of a broad range of facts about various subjects");
            NameDescript.Add("Philosophy & psychology", "A general vision of being human");
            NameDescript.Add("Religion", "A type of belief where people worship");
            NameDescript.Add("Social sciences", "An acedemic study");
            NameDescript.Add("Language", "System of communication");
            NameDescript.Add("Natural sciences", "Physics, chemistry, or biology");
            NameDescript.Add("Technology (Applied sciences)", "Knowledge to invent new devices or tools");
            NameDescript.Add("The arts", "Expression of human creative skill and imagination");
            NameDescript.Add("Literature", "Books and writings published based on a particular subject");
            NameDescript.Add("Geography & history", "Events and places that has affected each other across time");
        }
        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// The methods below adds my random generator to the dicitonary and allowing it to display for the user
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        public void OutputNameDescript()
        {
            RandomNumberGenerator();

            left1Txbox.Text = NameDescript.ElementAt(randNum4List[0]).Key.ToString();
            left2Txbox.Text = NameDescript.ElementAt(randNum4List[1]).Key.ToString();
            left3Txbox.Text = NameDescript.ElementAt(randNum4List[2]).Key.ToString();
            left4Txbox.Text = NameDescript.ElementAt(randNum4List[3]).Key.ToString();

            String emptyString = " ";


            for (int i = 0; i < 7; i++)
            {
                string asciichar = Char.ConvertFromUtf32(65+i);
                string dict = NameDescript.ElementAt(randNum7List[i]).Value.ToString() + "\r\n";
                emptyString += asciichar + ") " + dict;
            }
            questionBox.Text = emptyString;
        }
        ///-------------------------------------------------------------------------------------------------------------------///
        public void OutputNumberDescript()
        {
            RandomNumberGenerator();

            left1Txbox.Text = NumberDescript.ElementAt(randNum4List[0]).Key.ToString();
            left2Txbox.Text = NumberDescript.ElementAt(randNum4List[1]).Key.ToString();
            left3Txbox.Text = NumberDescript.ElementAt(randNum4List[2]).Key.ToString();
            left4Txbox.Text = NumberDescript.ElementAt(randNum4List[3]).Key.ToString();

            String emptyString = " ";
            

            for (int i = 0; i < 7; i++)
            {
                string asciichar = Char.ConvertFromUtf32(65 + i);
                string dict = NumberDescript.ElementAt(randNum7List[i]).Value.ToString() + "\r\n";
                emptyString += asciichar + ") "+ dict;
            }
            questionBox.Text = emptyString;
        }
        ///-------------------------------------------------------------------------------------------------------------------///
        public void OutputNumberName()
        {
            RandomNumberGenerator();

            left1Txbox.Text = numberName.ElementAt(randNum4List[0]).Key.ToString();
            left2Txbox.Text = numberName.ElementAt(randNum4List[1]).Key.ToString();
            left3Txbox.Text = numberName.ElementAt(randNum4List[2]).Key.ToString();
            left4Txbox.Text = numberName.ElementAt(randNum4List[3]).Key.ToString();

            String emptyString = " ";
            

            for (int i = 0; i < 7; i++)
            {
                string asciichar = Char.ConvertFromUtf32(65 + i);
                string dict = numberName.ElementAt(randNum7List[i]).Value.ToString() + "\r\n";
                emptyString += asciichar + ") "+ dict;
            }
            questionBox.Text = emptyString;
        }
        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// The code below is the start button, if the user starts up the game then they will get the methods i have made above
        /// displayed to them randomly. An if statment is used in here as a random number generator has also been made, this is to
        /// ensure that if the random number lands on a number ranged 1 -3 they will get different dictionairies to match.
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        private void startGameButton_Click(object sender, EventArgs e)
        {
            Random callingMethods = new Random();
            int method = callingMethods.Next(0, 3);

            this.startGameButton.Enabled = false;
            this.finishButton.Enabled = true;

            int minutes = int.Parse(this.comboBox2.SelectedItem.ToString());
            int seconds = int.Parse(this.comboBox1.SelectedItem.ToString());

            secondsTotal = (minutes *60 ) +seconds;

            this.timer1.Enabled = true;
            if (method == 1)
            {
                OutputNumberName();

            }else if (method ==2)
            {
                OutputNumberDescript();
            }
            else
            {
                OutputNameDescript();
            }
        }
        ///-------------------------------------------------------------------------------------------------------------------///
        public void RandomNumberGenerator()
        {
            int generating7Num;
            int generating4Num;

            for (int i = 0; i < 7; i++)
            {
                do
                {
                    generating7Num = rand.Next(0, 9);
                } while (randNum7List.Contains(generating7Num));
                randNum7List.Add(generating7Num);
            }

            for (int i = 0; i < 4; i++)
            {
                do
                {
                    generating4Num = rand.Next(0, 7);
                } while (randNum4List.Contains(randNum7List[generating4Num]));
                randNum4List.Add(randNum7List[generating4Num]);
            }
        }
        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// This case statment is to see if the user inputs the correct letter depending how the index populates in the random generator
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        private bool GettingUserInput(string userAnswer, int userRounds)
        {
            int test;
            

            switch (userAnswer)
            {
                case "A":
                    test = randNum7List[0];
                    break;
                case "B":
                    test = randNum7List[1];
                    break;
                case "C":
                    test = randNum7List[2];
                    break;
                case "D":
                    test = randNum7List[3];
                    break;
                case "E":
                    test = randNum7List[4];
                    break;
                case "F":
                    test = randNum7List[5];
                    break;
                case "G":
                    test = randNum7List[6];
                    break;

                default:
                    return false;
                    break;
            }
            if (randNum4List[userRounds] == test)
            {
                return true;
            }
            return false;

        }
        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// The finish button checks if the user gets the ordering correct within the time limit, if not they shall try again 
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        private void finishButton_Click(object sender, EventArgs e)
        {
           
            this.startGameButton.Enabled = true;


            bool userInput1 = GettingUserInput(answerTxbox.Text.ToUpper(),0);
            bool userInput2 = GettingUserInput(answer2Txbox.Text.ToUpper(), 1);
            bool userInput3 = GettingUserInput(answer3Txbox.Text.ToUpper(), 2);
            bool userInput4 = GettingUserInput(answer4Txbox.Text.ToUpper(), 3);

            if (!userInput1 || !userInput2 || !userInput3 || !userInput4)
            {
                MessageBox.Show("You got the ordering wrong or did not fill in everything");
            }
            else
            {
                secondsTotal = 0;
                this.timer1.Enabled = false;
                congratulations yaaay = new congratulations();
                yaaay.Show();
                label17.Text = "You have completed within ";

                left1Txbox.Clear();
                left2Txbox.Clear();
                left3Txbox.Clear();
                left4Txbox.Clear();

                answerTxbox.Clear();
                answer2Txbox.Clear();
                answer3Txbox.Clear();
                answer4Txbox.Clear();

                questionBox.Clear();
                randNum4List.Clear();
                randNum7List.Clear();
            }
        }
        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// The keyPress makes sure that the user ONLY inserts letters and nothing else
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        private void answerTxbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void answer2Txbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void answer3Txbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void answer4Txbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// Upon start up the for loops is to make sure that the user can select an time they wish to beat while playing the game
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        private void Form3_Load(object sender, EventArgs e)
        {
            this.finishButton.Enabled = false;

            for (int i = 0; i < 60; i++)
            {
                this.comboBox1.Items.Add(i.ToString());
            }
            for (int j = 0; j < 3; j++)
            {
                this.comboBox2.Items.Add(j.ToString());

            }
            this.comboBox2.SelectedIndex = 2;
            this.comboBox1.SelectedIndex = 59;
        }
        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// Upon start up the for loops is to make sure that the user can select an time they wish to beat while playing the game
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (secondsTotal > 0)
            {
                secondsTotal--;
                int minutes = secondsTotal / 60;
                int seconds = secondsTotal - (minutes * 60);
                this.timeLabel.Text = minutes.ToString() + ":" + seconds.ToString();
            }
            else
            {
                this.timer1.Stop();
                MessageBox.Show("Time is up , start a new game !");

                left1Txbox.Clear();
                left2Txbox.Clear();
                left3Txbox.Clear();
                left4Txbox.Clear();

                answerTxbox.Clear();
                answer2Txbox.Clear();
                answer3Txbox.Clear();
                answer4Txbox.Clear();

                questionBox.Clear();

                randNum4List.Clear();
                randNum7List.Clear();
                this.startGameButton.Enabled = true;
            }
        }
        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// Allow the user to go back to the home screen
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 task2 = new Form1();
            task2.Show();
        }

       

        ///-------------------------------------------------------------------------------------------------------------------///
    }
    ///--------------------------------------------------------- END OF CODE -----------------------------------------------///


}

