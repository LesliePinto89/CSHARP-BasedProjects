using System;
using System.Linq;

namespace SpotifyChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int faces = 6;
            int total = 12;
            Throw_dice(n,faces,total);
        }

        /// <summary>
        /// Write a function, throw_dice(N, faces, total), 
        /// that determines how many ways it is possible to 
        /// throw N dice with some number of faces each to 
        /// get a specific total.
        /// </summary>
        /// <param name="n">Number of dices to throw</param>
        /// <param name="faces">number of sides / values each dice has</param>
        /// <param name="total">specific total to find using all dices</param>
        public static void Throw_dice(int n, int faces, int total) {
            int[] dices = Enumerable.Repeat(1, n).ToArray();
            int endIndex = n - 1;
            int count = 0;
            int moveDownEnd = 0;

            //While i not equals sum of faces on all dices
            //e.g. 3 dices, 6 faces (666) or 6^3 would be i== 216
            for (int i = 0; i < Math.Pow(faces,n); i++) {
                int sum = dices.Sum();
                int innerIndex = 0;
                if (sum == total)
                    count++;

                //If current dice/s is at face limit
                    if (dices.Skip(endIndex).All(x => x == faces)) {
                    foreach (int a in dices) {
                        if (a == faces) {

                            //Apart from first dice, change current dice face to 1.
                            //e.g. 6,1,6 should count other 6's, not first
                            if (innerIndex != 0)
                            {
                                dices.SetValue(1, innerIndex);
                                moveDownEnd++;                             
                            }
                        }
                        innerIndex++;
                    }

                    //Increment previous dice face. e.g. arr = {1,1,1}, 
                    //moveDownEnd = 2, arr[currentLimit(2) - moveDownEnd] 
                    //is arr[0], so arr[0]++ == arr{2,1,1}
                    dices[endIndex - moveDownEnd]++;
                        moveDownEnd = 0;
                    }
                    //Increment face value on current last dice
                    //e.g. 1,2,1 becomes 1,2,2 
                    else
                        dices[endIndex]++;
            }
            if (count == 0)
                Console.WriteLine($"{count} Total found using dice/faces");
            else
            Console.WriteLine($"The number of throws is {count} times");
        }
    }
}