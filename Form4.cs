using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace prog7312_task1
{
    public partial class Form4 : Form
    {
        /// <summary>
        /// REFERENCES
        /// </summary>
        /// https://stackoverflow.com/questions/273313/randomize-a-listt
        /// https://stackoverflow.com/questions/28547222/reset-boolean-list
        /// https://stackoverflow.com/questions/11161546/find-node-when-traversing-tree
        /// https://stackoverflow.com/questions/13885783/query-or-algorithm-to-generate-a-structure-to-populate-a-tree-c-linq
        /// https://www.youtube.com/watch?v=hs74fKPJpFw
        /// https://www.youtube.com/watch?v=ocD7wuF8PTg
        /// https://www.youtube.com/watch?v=kwfc7QkCDZI&t=892s
        /// 
        /// 
        /// --------------------------------------------------------------START - OF - CODE-----------------------------------------------------------//

        /// <summary>
        /// Setting my lists and making them global
        /// </summary>
        List<int> randNum10List = new List<int>();
        List<int> randNum4ListSecondTier = new List<int>();
        List<int> randNum4ListThirdTier = new List<int>();
       
        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Making a random generator and allocating the file both, both global
        /// </summary>
        Random rand = new Random();
        string path = Path.GetFullPath("prog7312_POE_TextFile.txt");

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Setting global variables for my booleeans and multi - levels
        /// </summary>
        int multilevelOne;
        int multilevelTwo;
        int multilevelThree;
        private int totalSeconds;
        bool question1 = false;
        bool question2 = false;

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Calling my node class which displays and formats the root of the tree
        /// </summary>
        NodesClass root;

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        public Form4()
        {
            InitializeComponent();
            //txtFile();
            root = FetchingTree(path);

            this.FindButton.Enabled = false;
            this.restartButton.Enabled = false;

        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Reading from the textfile
        /// </summary>
        public void txtFile()
        {
            //string path = @"C:\Users\Azhar\Desktop\Azhar_Ameer_ST10114639_Prog7312_Task2\prog7312_task2\prog7312_task1\prog7312_POE_TextFile.txt";
            StreamReader stream = new StreamReader(path);
            string dataInFile = stream.ReadToEnd();
            //fileTxtTxtBox.Text = dataInFile.ToString();
            stream.Close();
            
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Upon clicking the start button the user will begin to play the game
        /// </summary>
        private void startButton_Click(object sender, EventArgs e)
        {
            this.startButton.Enabled = false;
           

            BeginGame();
            CountDownClock();
            
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// In this method everything regarding the tree is being created. The root is created , the length and adding the nodes to the parent
        /// </summary>
        public NodesClass FetchingTree(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);

            
            if (lines.Length == 0)
            {
                return null;
            }

            //create the root
            NodesClass root = new NodesClass(lines[0].Trim());
            char tabedSpave ='\t';

            
            int rootWhiteSpaceLength = lines[0].TakeWhile(c => c == tabedSpave).Count();

            //Crete  a list to hold the nodes 
            List<Tuple<NodesClass, int>> nodesAndLengths = new List<Tuple<NodesClass, int>>();

            //add the root to nodes 
            nodesAndLengths.Add(new Tuple<NodesClass, int>(root, rootWhiteSpaceLength));

           
            for (var i = 1; i < lines.Length; i++)
            {
                //creating the node
                NodesClass node = new NodesClass(lines[i].Trim());

                //get the node 
                int nodeWhiteSpaceLength = lines[i].TakeWhile(c => c == tabedSpave).Count();

                
                if (nodeWhiteSpaceLength <= rootWhiteSpaceLength)
                {
                    throw new Exception("There is more than one root");
                }

                //LINQS to find the node parent 
                NodesClass parent = nodesAndLengths.Last(nodeAndLength => nodeAndLength.Item2 < nodeWhiteSpaceLength).Item1;


                //adding the node to it's parent
                parent.Children.Add(node);

                //adding the node to nodes list 
                nodesAndLengths.Add(new Tuple<NodesClass, int>(node, nodeWhiteSpaceLength));
            }
              root.PrintNode("", true);
              return root;
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// In this method random 10 numbers is generated which adds the random  numbers to a list
        /// </summary>
        public void RandomNumberGenerator()
        {
            int generating10Num;
     
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    generating10Num = rand.Next(0, 10);
                } while (randNum10List.Contains(generating10Num));
                randNum10List.Add(generating10Num);
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the finding button function where the user will be able to give an answer to see if they got the answer correct
        /// </summary>
        private void FindButton_Click(object sender, EventArgs e)
        {
            
            bool userInput = GettingUserInput(userAnswerTextbox.Text.ToUpper());

            if (!userInput)
            {
                MessageBox.Show("You got it wrong try again ! ");
            }

        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This is the method to see if the user gets the answer correct by giving answer by either A, B ,C, D. If the user gets it correct it will notify them and they shall 
        /// continue answering till the final tier. If not they will be notifed they have gotten it wrong till they get it correct
        /// </summary>
        private bool GettingUserInput(string userAnswer)
        {
            int test;
            switch (userAnswer)
            {
                case "A":
                    test =  1 ;
                    break;
                case "B":
                    test =  2 ;
                    break;
                case "C":
                    test =  3;
                break;
                case "D":
                    test =  4;
                break;
                default:
                    return false;
                    break;
            }
            if (!question1 && multilevelOne + 1 == test)
            {
                question1 = true;
                tier1Label.Text = "Well done you've gotten it correct";
                userAnswerTextbox.Text = "";
                MultiLevelTwoPopulate();
                return true;

            }
            if (question1 && multilevelTwo + 1 == test)
            {
                question2 = true;
                tier2Label.Text = "Well done you've gotten it correct";
                userAnswerTextbox.Text = "";
                MultiLevelThreePopulate();
                return true;
                
            }
            if (question2 && multilevelThree + 1 == test)
            {

            tier3Label.Text = "Well done you've gotten it correct";
            totalSeconds = 0;
            this.timer1.Enabled = false;
            completedWithinLbl.Text = "You have completed within";
            congratulations yaaay = new congratulations();
            yaaay.Show();
            return true;
            }
            
        return false;
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method ensures that i fetch the type of number thats generated in the list to the tree
        /// </summary>
        public void BeginGame()
        {
            this.FindButton.Enabled = true;
            this.restartButton.Enabled = true;

            multilevelOne = rand.Next(0, 3);
            multilevelTwo = rand.Next(0, 3);            
            multilevelThree = rand.Next(0, 3);

            RandomNumberGenerator();
            RandomNumberGeneratorSecondTier();
            RandomNumberGenThirdTier();

            string findTheMultiLevel = root.Children[randNum10List[multilevelOne]].Children[randNum4ListSecondTier[multilevelTwo]].Children[randNum4ListThirdTier[multilevelThree]].Value;

            findingLabel.Text = findTheMultiLevel;

            topLevelTxtBox1.Text = root.Children[randNum10List[0]].Value;
            topLevelTxtBox2.Text = root.Children[randNum10List[1]].Value;
            topLevelTxtBox3.Text = root.Children[randNum10List[2]].Value;
            topLevelTxtBox4.Text = root.Children[randNum10List[3]].Value;

           // multiLevelTwoPopulate();

        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        // <summary>
        /// This method generates random numbers that consist of 4. It adds it to the second tier and stores it within a list
        /// </summary>
        public void RandomNumberGeneratorSecondTier()
        {
            int generating4Num;
            int max = root.Children[randNum10List[multilevelOne]].Children.Count;

            if (max == 4)
            {
                randNum4ListSecondTier.Add(0);
                randNum4ListSecondTier.Add(1);
                randNum4ListSecondTier.Add(2);
                randNum4ListSecondTier.Add(3);

                randNum4ListSecondTier = randNum4ListSecondTier.OrderBy(a => rand.Next()).ToList();
            }
            else
            {
                 for (int i = 0; i < 4; i++)
            {
                do
                {
                    generating4Num = rand.Next(0, max -1);
                } while (randNum4ListSecondTier.Contains(generating4Num));

                    randNum4ListSecondTier.Add(generating4Num);
            }

            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        // <summary>
        /// This method generates random numbers that consist of 4. It adds it to the third tier and stores it within a list
        /// </summary>
        public void RandomNumberGenThirdTier()
        {
            int generating4Num;
            int max =  root.Children[randNum10List[multilevelOne]].Children[randNum4ListSecondTier[multilevelTwo]].Children.Count;

            if (max == 4)
            {
                randNum4ListThirdTier.Add(0);
                randNum4ListThirdTier.Add(1);
                randNum4ListThirdTier.Add(2);
                randNum4ListThirdTier.Add(3);

                randNum4ListThirdTier = randNum4ListThirdTier.OrderBy(a => rand.Next()).ToList();
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    do
                    {
                        generating4Num = rand.Next(0, max -1);
                    } while (randNum4ListThirdTier.Contains(generating4Num));

                    randNum4ListThirdTier.Add(generating4Num);
                }
            }
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        // <summary>
        /// This methods populates the multi - level 2 items in the textboxes for the user 
        /// </summary>
        public void MultiLevelTwoPopulate()
        {
            
            topLevelTxtBox1.Text = root.Children[randNum10List[multilevelOne]].Children[randNum4ListSecondTier[0]].Value;
            topLevelTxtBox2.Text = root.Children[randNum10List[multilevelOne]].Children[randNum4ListSecondTier[1]].Value;
            topLevelTxtBox3.Text = root.Children[randNum10List[multilevelOne]].Children[randNum4ListSecondTier[2]].Value;
            topLevelTxtBox4.Text = root.Children[randNum10List[multilevelOne]].Children[randNum4ListSecondTier[3]].Value;
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        // <summary>
        /// This methods populates the multi - level 3 items in the textboxes for the user 
        /// </summary>
        public void MultiLevelThreePopulate()
        {
            topLevelTxtBox1.Text = root.Children[randNum10List[multilevelOne]].Children[randNum4ListSecondTier[multilevelTwo]].Children[randNum4ListThirdTier[0]].Value;
            topLevelTxtBox2.Text = root.Children[randNum10List[multilevelOne]].Children[randNum4ListSecondTier[multilevelTwo]].Children[randNum4ListThirdTier[1]].Value;
            topLevelTxtBox3.Text = root.Children[randNum10List[multilevelOne]].Children[randNum4ListSecondTier[multilevelTwo]].Children[randNum4ListThirdTier[2]].Value;
            topLevelTxtBox4.Text = root.Children[randNum10List[multilevelOne]].Children[randNum4ListSecondTier[multilevelTwo]].Children[randNum4ListThirdTier[3]].Value;
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        // <summary>
        /// This methods that are inside this method clears all the functionalities and everything that is stored.
        /// </summary>
        public void StopAllFunctions()
        {
            ClearingtextBoxes();
            ClearingLabels();
            ClearingListsAndBooleans();
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        // <summary>
        /// This method clears all the textboxes for the user
        /// </summary>
        public void ClearingtextBoxes()
        {
            topLevelTxtBox1.Text = "";
            topLevelTxtBox2.Text = "";
            topLevelTxtBox3.Text = "";
            topLevelTxtBox4.Text = "";
            userAnswerTextbox.Text = "";

        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        // <summary>
        /// This method clears all the answering labels for the user
        /// </summary>
        public void ClearingLabels()
        {
            tier1Label.Text = "";
            tier2Label.Text = "";
            tier3Label.Text = "";

            completedWithinLbl.Text = "";
            timeLbl.Text = "";

            this.timer1.Enabled = false;

        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        // <summary>
        /// This method clears all lists that was made and resets the boolean variables
        /// </summary>
        public void ClearingListsAndBooleans()
        {
            randNum10List.Clear();
            randNum4ListSecondTier.Clear();
            randNum4ListThirdTier.Clear();

            question1 = false;
            question2 = false;
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This restarts the game for the user if they make a mistake and wish to play again
        /// </summary>
        private void restartButton_Click(object sender, EventArgs e)
        {
            StopAllFunctions();
            CountDownClock();
            BeginGame();
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method adds the minutes and seconds for the user to choose between
        /// </summary>
        private void Form4_Load(object sender, EventArgs e)
        {
            for (int j = 0; j < 3; j++)
            {
                this.minuteCombobox.Items.Add(j.ToString());

            }
            for (int i = 0; i < 60; i++)
            {
                this.secondCombobox.Items.Add(i.ToString());
            }
            this.minuteCombobox.SelectedIndex = 2;
            this.secondCombobox.SelectedIndex = 59;

        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method allows the user to select the time they wish to beat
        /// </summary>
        public void CountDownClock()
        {
            this.startButton.Enabled = false;
            int minutes = int.Parse(this.minuteCombobox.SelectedItem.ToString());
            int seconds = int.Parse(this.secondCombobox.SelectedItem.ToString());

            totalSeconds = (minutes * 60 ) + seconds;

            this.timer1.Enabled = true;


        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This timer1_tick is the calculation for the timer
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0)
            {
                totalSeconds--;
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds - (minutes * 60);
                this.timeLbl.Text = minutes.ToString() + ":" + seconds.ToString();
            }
            else
            {
                this.timer1.Stop();
                MessageBox.Show("You can out of time :(");
            }
        }

        ///-------------------------------------------------------------------------------------------------------------------///
        /// <summary>
        /// Allow the user to go back to the home screen
        /// </summary>
        ///-------------------------------------------------------------------------------------------------------------------///
        private void homeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 task2 = new Form1();
            task2.Show();
        }

        /// ------------------------------------------------------------------------------------------------------------------------------------------//

    }
    /// --------------------------------------------------------------END - OF - CODE-----------------------------------------------------------//

}

