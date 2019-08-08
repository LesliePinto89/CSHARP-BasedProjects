using System;
using System.Collections.Generic;
using System.Linq;

namespace ZillowChallenges
{
    class Program
    {
        private static readonly List<int> temp = new List<int>();
        static void Main(string[] args)
        {
            while (true) { 
            int n = Int32.Parse(Console.ReadLine());
            int foundSevenish = FindNSevenish(n);
            Console.WriteLine($"The value of the {n} sevenish is: {foundSevenish}");
        }
        }

        /// <summary>
        /// Let's define a "sevenish" number to be one which is either a power of 7, or the sum of 
        /// unique powers of 7.The first few sevenish numbers are 1, 7, 8, 49, and so on. 
        /// Create an algorithm to find the nth sevenish number.
        /// </summary>
        /// <param name="n">The nth term</param>
        /// <returns>The nth sevenish based on the nth term</returns>
        public static int FindNSevenish(int n)
   {
            int originalPower = 1;
            int basePower = 7;

            if (n == 1) {
                return originalPower;
            }
            else if (n == 2) {
                return basePower;
            }
            temp.Add(originalPower);
            temp.Add(basePower);

            int incrementedBasePower = 0;
            int sumOfUniquePowers = originalPower + basePower;
            Boolean started = false;
            int nSevenish = 0;

            for (int i = 3; i <= n; i++)
            {
                
                switch (i % 2) {

                    case 0:  if (!started) {
                            started = true;
                            incrementedBasePower = basePower * basePower;
                            temp.Add(incrementedBasePower);
                                if (i == n){
                                nSevenish = incrementedBasePower;}
                              }
                            else{

                            incrementedBasePower *= basePower;
                            temp.Add(incrementedBasePower);
                            if (i == n){
                                nSevenish = incrementedBasePower;
                            }
                        }
                            break ;
                    case 1:
                        //Two ways of doing this:
                        //1) plusBaseSevenish = temp.Where(x => x ==1 || x % basePower == 0).Sum();
                        //The formula of a number's first power is a^0 so they all start of as 1.
                        // If not equals 1, then if the given index's remainder from 7 is 0, it is a unique 
                        // power so add it to sum.

                        //The other, more efficent way is just add current power to last sum of unique powers
                        sumOfUniquePowers += incrementedBasePower;

                        temp.Add(sumOfUniquePowers);
                                if (i == n)
                                {
                                  nSevenish = sumOfUniquePowers;
                                }
                        break;
                }

            }
            temp.Clear();
            return nSevenish;
   }
    }
}