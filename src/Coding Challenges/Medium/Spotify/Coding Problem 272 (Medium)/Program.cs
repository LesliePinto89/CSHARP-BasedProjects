using System;
using System.Linq;

namespace SpotifyChallenges
{
    /// <summary>
    /// Write a function, throw_dice(N, faces, total), 
    /// that determines how many ways it is possible to 
    /// throw N dice with some number of faces each to 
    /// get a specific total.
    /// </summary>
    class Program
    {
        private static int count = 0;

        static void Main(string[] args)
        {
            int n = 3;
            int faces = 6;
            int total = 7;
            Throw_dice(n,faces,total);
        }

        public static int IndexOfAdjustedDice(int [] dices,int faces) {
            int innerIndex = 0;
            int units = 0;
            foreach (int a in dices)
            {
                if (a == faces)
                {
                    //Apart from first dice, change current dice face to 1.
                    //e.g. 6,1,6 should count other 6's, not first
                    if (innerIndex != 0)
                    {
                        dices.SetValue(1, innerIndex);
                        units++;
                    }
                }
                innerIndex++;
            }
            return units;
        }

        public static void Throw_dice(int n, int faces, int total) {
            int [] dices = Enumerable.Repeat(1, n).ToArray();
            int endIndex = n - 1;

            //While i not equals sum of faces on all dices
            //e.g. 3 dices, 6 faces (666) or 6^3 would be i == 216
            for (int i = 0; i < Math.Pow(faces,n); i++) {
                int sum = dices.Sum();
                if (sum == total)
                    count++;
   
                   //Current dice/s is at face limit
                    if (dices.Skip(endIndex).All(x => x == faces)) {
                    int adjustValue = IndexOfAdjustedDice(dices,faces);

                    //Increment previous dice face. e.g. arr[currentLimit(2) 
                    // - adjustValue] is arr[0], so arr[0]++ == arr{2,1,1}
                    dices[endIndex - adjustValue]++;
                    adjustValue = 0;
                    }
                    //Increment face value on current last dice: e.g. 1,2,1 becomes 1,2,2 
                    else
                        dices[endIndex]++;
            }
            PrintCount(count);
        }

        public static void PrintCount(int count) {
            if (count == 0)
                Console.WriteLine($"{count} Total found using dice/faces");
            else
                Console.WriteLine($"The number of throws is {count} times");
        }
    }
}