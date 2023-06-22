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
    public partial class Form1 : Form
    {
        //------------------------------ START OF CODE --------------------------------//
        //------------------------------ REFERENCE:  https://stackoverflow.com/questions/6724224/how-to-grey-out-disable-a-button-control-in-win-forms#:~:text=Enabled%20%3D%20false%3B%20this.,fade%20out%20and%20also%20disabled.---//

        public Form1()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------//

        /// <summary>
        /// The identifying and finding call buttons are disabled for now as it is implemented in task 2 and 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IdentifyingButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            answer1Txbox task2 = new answer1Txbox();
            task2.Show();
        }

        private void findingCallButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 POE = new Form4();
            POE.Show();
        }
        /// <summary>
        /// Calling the next form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replacingBookButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 task1 = new Form2();
            task1.Show();
        }
    }
     //------------------------------ END OF CODE --------------------------------//
}
