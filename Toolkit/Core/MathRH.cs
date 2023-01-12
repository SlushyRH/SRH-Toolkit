using System;
using System.Collections;
using System.Collections.Generic;

namespace SRH.Toolkit
{
    public static class MathRH
    {
        /// <summary>
        /// Generates a random number of a chosen length. UNTESTED.
        /// </summary>
        /// <param name="amountOfDigits">Max number is 9</param>
        public static int GenerateRandomNumber(int amountOfDigits)
        {
            string digits = "1";

            for (int i = 0; i < amountOfDigits; i++)
            {
                digits += "0";
            }

            System.Random random = new System.Random();

            int randNum = random.Next(0, int.Parse(digits));

            string result = digits.Remove(0, 1);
            string s = randNum.ToString(result);

            return int.Parse(s);
        }
    }
}