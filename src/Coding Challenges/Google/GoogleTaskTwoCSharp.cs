using System;
using System.Linq;
using System.Collections.Generic;

namespace GoogleChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = false;
            List<int> sampleList = new List<int>  {10, 3, 15, 7};
            isTrue = DoesCoupleMakeTarget(17, sampleList);

            List<int> sampleListTwo = new List<int> {253, 336, 747, 21 };
            isTrue = DoesCoupleMakeTarget(1000, sampleListTwo);

            List<int> sampleListThree = new List<int> { 112, 24, 29, 40};
            isTrue = DoesCoupleMakeTarget(162, sampleListThree);
        }

        public static bool DoesCoupleMakeTarget(int k, List<int> sampleList)
        {
            int first = 0;
            int second = 0;
            bool addsToK = false;
            string arrayToString = String.Join(",", sampleList);
             Console.WriteLine($"Out of all values from ({arrayToString}),the task is to " +
                 $"check if the sum of any two values equal {k}\n");

            for (int i = 0; i < sampleList.Count; i++)
            {
                for (int j = 0; j < sampleList.Count; j++)
                {
                    if (sampleList[i] + sampleList[j] == k)
                    {
                        first = sampleList[i];
                        second = sampleList[j];
                        addsToK = true;
                        break;
                    }
                }
                if (addsToK)
                {
                    Console.WriteLine($"The answer is {addsToK} and the numbers are {first} + {second}\n");
                    break;
                }
                else if (i == sampleList.Count - 1)
                {
                    Console.WriteLine($"The answer is {addsToK} no sum of two values equal {k}\n");
                }
            }
            return addsToK;
        }
    }
}
