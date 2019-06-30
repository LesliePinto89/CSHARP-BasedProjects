using System;
using System.Linq;
using System.Collections.Generic;

namespace UberChallenges
{
    class Program
    {
        public static int avoidIndex = 0;
        public static int[] productArray;
        public static bool start;
        /*
       Given an array of integers, return a new array such that each element at index i of the new array
       is the product of all the numbers in the original array except the one at i.
        */
        static void Main(string[] args)
        {
            int[] sample = new int[] { 1, 2, 3, 4, 5 };
            int[] product = productOfNumbers(sample);

            int[] sampleTwo = new int[] { 3, 2, 1 };
            int[] productTwo = productOfNumbers(sampleTwo);

            int[] sampleThree = new int[] {10,9,8,7,6,5,4,3,2,1};
            int[] productThree = productOfNumbers(sampleThree);
        }

        public static void addToProductArray (int sum){
            productArray[avoidIndex] = sum;
            avoidIndex++;
            start = false;
        } 

        public static int[] productOfNumbers(int [] sampleList)
        {
            int sum = 0;
            avoidIndex = 0;
            productArray = new int[sampleList.Count()];
            string sampleToString = String.Join(",", sampleList);
            Console.WriteLine($"Out of all values from ({sampleToString}): \n");

            for (int i = 0; i < sampleList.Count(); i++)
            {  for (int j = 0; j < sampleList.Count(); j++)
                {  if (j != avoidIndex) {
                        //First index in the iteratoin being checked
                        if (!start)
                        {
                            if (j + 1 == avoidIndex) {
                                sum = sampleList[j] * sampleList[j + 2];
                            }
                            else { 
                            sum = sampleList[j] * sampleList[j+1];
                            }
                            start = true;
                        }
                        else
                        { //Second and further - Below code manages desired next index, 
                          //current avoiding one, and if at end of array
                            if (j == sampleList.Length - 1) {
                                addToProductArray(sum);
                                break;
                            } if (j + 1 == avoidIndex) {//Detected that next index is to one to avoid,
                                                        //If not at end of array, multiple next index to sum
                                
                                //If processed last index by end of array, leave loop
                                if (i == sampleList.Length-1){ addToProductArray(sum);       
                                    break;
                                }
                               sum *= sampleList[j + 2];  //<================================HERE
                            } else {
                                sum *= sampleList[j+1];  
                            }
                        }
                    }
                }
            }
            string productToString = String.Join(",", productArray);
            Console.WriteLine($"The product of all values apart from i each value is: {productToString} \n");

            return productArray;    
        }
    }
}
