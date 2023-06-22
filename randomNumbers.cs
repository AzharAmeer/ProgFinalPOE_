using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog7312_task1
{
    public class randomNumbers
    {
        //------------------------------ START OF CODE --------------------------------//
        //------------------------------ REFERENCE: https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp ---//

        Random num = new Random();

        public string randomNums()
        {

            int number = num.Next(1, 999);
           
            if (number < 10)
            {

                return "00" + number.ToString();
                
            }
            else if (number < 100)

            {
                return "0" + number.ToString();
            }
           
            return number.ToString();

        }
    }
    //------------------------------ END OF CODE --------------------------------//
}
