using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace AmazonChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            SmallestPossibleInteger(new int[] { 1, 2, 3, 10});
            SmallestPossibleInteger(new int[] { 21, 2, 43, 110, 7});
            SmallestPossibleInteger(new int[] { 1001, 22, 343, 410, 247 });
        }

        /// <summary>
        /// Given a sorted array, find the smallest positive integer that is
        /// not the sum of a subset of the array.
        /// </summary>
        /// <param name="array">The sample array </param>
        public static void SmallestPossibleInteger(int [] array) {
            string original = string.Join(" , ", array.Select(i => i.ToString()).ToArray());
            Console.WriteLine($"Original List {original}");
            Array.Sort(array);
            string reOrdered = string.Join(" , ", array.Select(i => i.ToString()).ToArray());
            Console.WriteLine($"Re-ordered List {reOrdered}");

            int sum = array.Where(i => i < array [array.Length-1]).Sum();
            Console.WriteLine($"The smallest postive interger not in the list is: {sum +=1}");
           }
        }