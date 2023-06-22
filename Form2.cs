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
    //------------------------------ START OF CODE --------------------------------//
    //------------------------------ REFERENCE: https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp ---//
    public partial class Form2 : Form
    {
        /// <summary>
        /// Assigning a name for my created lists 
        /// </summary>
        List<string> listStorage = new List<string>();
        List<string> listBoxBooks = new List<string>();

        /// <summary>
        /// Calling my classes created, this is where my random generated numbers and letters are created 
        /// </summary>
        randomNumbers ran = new randomNumbers();
        randomLetters ranLet = new randomLetters();
        string newLine = Environment.NewLine;

        private int secondsTotal;
        //----------------------------------------------------------------------------------------------------------------------------------//
        public Form2()
        {
            InitializeComponent();
          
        }
        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// This generate button starts the game, once game has started their will be a timer as well as the random numbers and letters greated will display in the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    private void generateButton_Click(object sender, EventArgs e)
        {
            this.generateButton.Enabled = false;
            

            int minutes = int.Parse(this.comboBox1.SelectedItem.ToString());
            int seconds = int.Parse(this.comboBox2.SelectedItem.ToString());
            secondsTotal = (minutes * 60) + seconds;

            this.timer1.Enabled = true;

            for (int i = 0; i <= 9; i++ )
            {
               string book = ran.randomNums().ToString()+"."+ran.randomNums().ToString()+ " " +ranLet.ranLetters();
               listBox1.Items.Add(book);
               listStorage.Add(book);
                label6.Text = " ";

            }
            
        }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// The up and down picture box allows the user playing the game to select an item within the listbox and have the ability to move it up and down the listbox
        /// If the user does not select an item it will notify the user to first select something before moving it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upPictureBox_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select an item to move","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else
            {
                int newIndex = listBox1.SelectedIndex - 1;

                if (newIndex < 0)
                
                    return;
                
                object selectedItem = listBox1.SelectedItem;
                listBox1.Items.Remove(selectedItem);
                listBox1.Items.Insert(newIndex, selectedItem);
                listBox1.SetSelected(newIndex, true);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------//

        private void downPictureBox_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select an item to move", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int newIndex = listBox1.SelectedIndex + 1;

                if (newIndex >= listBox1.Items.Count)

                    return;

                object selectedItem = listBox1.SelectedItem;
                listBox1.Items.Remove(selectedItem);
                listBox1.Items.Insert(newIndex, selectedItem);
                listBox1.SetSelected(newIndex, true);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// The done button is used when the user is done playing the game. I have used .Sort to sort the items in the listbox. If the user does not 
        /// get the ordering correct in decending order it will notify the user. 
        /// </summary>
        
        private void doneButton_Click(object sender, EventArgs e)
        {
            listStorage.Sort();
            foreach (string temp in listBox1.Items)
            {
                listBoxBooks.Add(temp);
            }

            //listStorage.Reverse();

            /// <summary>
            //This if statement checks if the user has gotten the ordering correct. If not it will notify the user till they get it correct
            //Here we compare the items generated in decending order to the order that the user has given
            /// </summary>

            if (listStorage.SequenceEqual(listBoxBooks))
                {
                //MessageBox.Show("Well done, you finished within time range !");
                listBox1.Items.Clear();
                listBoxBooks.Clear();
                listStorage.Clear();
                this.generateButton.Enabled = true;
                label6.Text = "You have completed within ";
                secondsTotal = 0;
                this.timer1.Enabled = false;

                congratulations yaaay = new congratulations();
                yaaay.Show();
                
            }
            else
            {
               
                MessageBox.Show("Incorrect try again !");
                listBoxBooks.Clear();

            }

        }
        //----------------------------------------------------------------------------------------------------------------------------------//
        private void Form2_Load(object sender, EventArgs e)
        {
            for(int i =0; i < 60; i++)
            {
                this.comboBox2.Items.Add(i.ToString());
            }
            for (int j = 0; j < 3; j++)
            {
                this.comboBox1.Items.Add(j.ToString());

            }
            this.comboBox1.SelectedIndex = 2;
            this.comboBox2.SelectedIndex = 59;
        }
        //----------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// REFERENCE: https://www.youtube.com/watch?v=kwfc7QkCDZI&t=892s
        /// </summary>
        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        //Here an timer is used. An gameification of an countdown clock is implemented.
        //The user will have an option to select an time to start counting down from and if the time runs up the user must select an new game
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(secondsTotal >0)
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
                listBox1.Items.Clear();
                this.generateButton.Enabled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// Allow the user to go back to the home screen
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 task1 = new Form1();
            task1.Show();
        }
    }
        //------------------------------------------------------- END OF CODE ---------------------------------------------------------------//
}

