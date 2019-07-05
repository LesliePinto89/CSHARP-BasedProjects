using System;
using System.Linq;
using System.Collections.Generic;

namespace MoreTesting
{
    class Program
    {
        static void Main(string[] args)
        {
           int n = 5;
           List <int> papers = new List<int>() { 4, 3, 0, 1, 5 };
           Console.WriteLine(CalculateHIndex(n, papers));  //3

           n = 5;
           papers = new List<int>() {10, 8, 5, 4, 3 };
           Console.WriteLine(CalculateHIndex(n, papers));  //4

           n = 5;
           papers = new List<int>() { 25, 8, 5, 3, 3 };
           Console.WriteLine(CalculateHIndex(n, papers));

           n = 6;
           papers = new List<int>() {11, 6, 21, 5, 13, 11 };
           Console.WriteLine(CalculateHIndex(n, papers));
        }

        /// <summary>
        /// In academia, the h-index is a metric used to calculate the impact of a researcher's papers. 
        /// It is calculated as follows: A researcher has index h if at least h of her N papers have h citations each.
        /// If there are multiple h satisfying this formula, the maximum is chosen.Given a list of paper citations of
        /// a researcher, calculate their h-index.
        /// </summary>
        /// <param name="n">The number of papers</param>
        /// <param name="papers">Each paper with a given citation</param>
        /// <returns>The paper who has the value of h-index</returns>
        public static int CalculateHIndex(int n, List<int> papers)
        {
         int hIndex = 0;
         papers.Sort();
         papers.Reverse();
         for (int i = 0; i < n; i++)
         {
            int baseLine = papers.Count(x => x >= papers[i]);
            if (baseLine >= papers[i])
            {
                hIndex = papers[i];
                break;
            }
        }
         return hIndex;
        }
    }
}