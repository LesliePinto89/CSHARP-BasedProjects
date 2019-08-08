using System;
using System.Linq;

namespace StripeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            StripeChallenge(233);
        }

        /// <summary>
        /// Given an integer n, return the length of the longest consecutive run of 
        /// 1s in its binary representation.
        /// </summary>
        /// <param name="input">Integer value to find longest bit shifts of 1 in binary</param>
        public static void StripeChallenge(int input)
        {
            string previousLongest = " ";
            string findLongest = "";
            string convertToBinary = Convert.ToString(input, 2);

            for (int i = 0; i <= convertToBinary.Length; i++)
            {
                //Keep track of types 1 was encounter in a consecutive sequence each attempt
                int numberOfOnesCount = findLongest.Count(x => x == '1');
                int numberOfAlternativeOnesCount = previousLongest.Count(x => x == '1');

                if (i == convertToBinary.Length)
                {
                    if (numberOfOnesCount > numberOfAlternativeOnesCount)
                    {
                        Console.WriteLine($"Longest number of 1's is {findLongest}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Longest number of 1's is {previousLongest}");
                        break;
                    }
                }

                if (convertToBinary[i] == '1')
                {
                    findLongest += convertToBinary[i];
                }

                else
                {
                    //Used only when latest series of 1's are higher than last instance
                    switch (numberOfOnesCount > numberOfAlternativeOnesCount)
                    {
                        case true:
                            previousLongest = findLongest;
                            findLongest = "";
                            break;
                        case false: continue;
                        default:
                            previousLongest = findLongest;
                            findLongest = "";
                            break;
                    }
                }
            }
        }
    }
}