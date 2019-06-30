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
            int[] product = ProductOfNumbers(sample);

            int[] sampleTwo = new int[] { 3, 2, 1 };
            int[] productTwo = ProductOfNumbers(sampleTwo);

            int[] sampleThree = new int[] {10,9,8,7,6,5,4,3,2,1};
            int[] productThree = ProductOfNumbers(sampleThree);
        }

        /// <summary>
        /// Added total sum per value to array, increment current index to manage, and reset
        /// iteration from the beginning
        /// </summary>
        /// <param name="sum"> product of all values minus value in current index</param>
        public static void AddToProductArray (int sum){
            productArray[avoidIndex] = sum;
            avoidIndex++;
            start = false;
        } 

        /// <summary>
        /// Generate product of all values minus the current index for each value
        /// </summary>
        /// <param name="sampleList"> array that stores initial values </param>
        /// <returns> an array of product numbers for each value minus their index during iteration </returns>
        public static int[] ProductOfNumbers(int [] sampleList)
        {
            int sum = 0;
            avoidIndex = 0;
            productArray = new int[sampleList.Count()];
            string sampleToString = String.Join(",", sampleList);
            Console.WriteLine($"Out of all values from ({sampleToString}): \n");

            for (int i = 0; i < sampleList.Count(); i++)
            {  for (int j = 0; j < sampleList.Count(); j++)
                {  if (j != avoidIndex) {
                        //First index in the iteration being checked
                        if (!start)
                        {
                            //Detected that should multiply current index value's sum after then next index
                            //as it is the one to avoid in this product of numbers
                            if (j + 1 == avoidIndex) {
                                sum = sampleList[j] * sampleList[j + 2];
                            }
                            else { //multiple next index value as expected
                            sum = sampleList[j] * sampleList[j+1];
                            }
                            start = true;
                        }
                        else
                        { //Second and further - Below code manages desired next index, 
                          //current avoiding one, and if at end of array
                            if (j == sampleList.Length - 1) {
                                AddToProductArray(sum);
                                break;
                            } if (j + 1 == avoidIndex) {//HERE: Detected that next index is to one to avoid,
                                                        //If not at end of array, add multiply next 
                                                        //index value to sum
                                
                                //If processed last index by end of array, leave loop
                                if (i == sampleList.Length-1){ AddToProductArray(sum);       
                                    break;
                                }
                               sum *= sampleList[j + 2];  //<================================HERE
                            } else {
                                sum *= sampleList[j+1];  //else multiple next index value as expected
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
