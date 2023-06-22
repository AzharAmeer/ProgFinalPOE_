using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog7312_task1
{
    public class randomLetters
    {
        //------------------------------ START OF CODE --------------------------------------------------------------------------------------------------------------//
        //------------------------------ REFERENCE: https://www.codegrepper.com/code-examples/csharp/random+alphanumeric+generator+dewey+decimal+call+number+c%23 ---//
        private static Random random = new Random();

        public string ranLetters()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(letters, 3).Select(s => s[random.Next(s.Length)]).ToArray());

        }
        //------------------------------ END OF CODE ----------------------------------------------------------------------------------------------------------------//
    }
}