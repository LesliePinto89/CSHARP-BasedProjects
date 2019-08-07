using System;
using System.Linq;
using System.Collections.Generic;
namespace EpicChallenges
{
    /// <summary>
    /// The "look and say" sequence is defined as follows: 
    /// beginning with the term 1, each subsequent term visually 
    /// describes the digits appearing in the previous term.
    /// </summary>
    class Program
    {
        private static List<string> holdTerms = new List<string>();

        static void Main(string[] args)
        {
            StartSearch();
            string input;
            do
            {
                Console.Write($"Search again? Y | N: ");
                input = Console.ReadLine().ToUpperInvariant();

                while (input != "Y" && input != "N")
                {
                    Console.Write($"Incorrect option - Search again? Y | N: ");
                    input = Console.ReadLine().ToUpperInvariant();
                }
                if (input.Equals("Y"))
                    StartSearch();
            }

            while (input != "N");
            Console.WriteLine("Finished");
        }

        public static void StartSearch()
        {
            Console.Write("Type in your nTerm to begin: ");
            string nTerm = Console.ReadLine();
            while (Char.IsLetter(nTerm[0]) || nTerm.Contains("0"))
            {
                Console.Write("The nTerm cannot be 0 or a letter - Type in nTerm: ");
                nTerm = Console.ReadLine();
            }
            Console.WriteLine(1);
            LookAndSay("1", Int32.Parse(nTerm));
        }

        public static void LookAndSay(string startTerm, int nTerm)
        {
            for (int i = 0; i < nTerm-1; i++) {
                int visualCount = 0;
                int traverseCounter = 1;
                char last = 'l';
                for (; visualCount < startTerm.Length; visualCount++)
                {
                    foreach(char a in startTerm)
                    {
                        //Current character to begin counting matches current type
                        //start index (as removes later, this index is always 0)
                        if (a == startTerm[0])
                        {
                            //Second term or terms thereafter
                            if (startTerm.Length == traverseCounter)
                            {
                                //Count the number of current matches with type
                                holdTerms.Add(traverseCounter.ToString() + a.ToString());
                                break;
                            }
                            else
                                traverseCounter++;
                        }
                        //Record last valid character occurances, and remove its occurs
                        //from string. Allows continuing in repeat iteration.
                        else {
                            traverseCounter -= 1;
                            holdTerms.Add(traverseCounter.ToString() + last.ToString());
                            break;
                        }
                        //If current character does not match, use as last known
                        //valid chracter against traversal counter
                        last = a;
                    }
                   
                    //Remove dealt with character up to recorded point
                    startTerm = startTerm.Remove(visualCount, traverseCounter);
                    
                    //Start again from now new string
                    traverseCounter = 1;
                    visualCount = -1; 
                }
                startTerm = string.Join("", holdTerms);
                Console.WriteLine($"{startTerm}");
                holdTerms.Clear();
            }
        }
    }
}