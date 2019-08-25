     /// <summary>
        /// A friend of mine takes a sequence of numbers from 1 to n (where n > 0). Within that sequence, he chooses 
        /// two numbers, a and b. He says that the product of a and b should be equal to the sum of all numbers in the sequence, 
        /// excluding a and b. Given a number n, could you tell me the numbers he excluded from the sequence?
        /// </summary>
        /// <param name="n">Length of values to check</param>
        /// <returns>Pairs of a and b that fulfill challenge</returns>
        public static List<long[]> removNb(long n)
        {
            List<int> temp = new List<int>();

            for (int j = 1; j <= n; j++) {
                temp.Add(j);
            }

            int total = temp.Aggregate((a, b) => a + b);
           

            List<long[]> found = new List<long[]>();
            foreach (int x in temp)
            {
                for (int i =0; i < n; i++)
                {
                    int minusTerms = (total - x - temp[i]);

                    if ((x * temp[i]) == minusTerms)
                    {
                        long termOne = x;
                        long termTwo = temp[i];
                        found.Add(new long[] { termOne, termTwo });

                    }
                }
            }
            return found;
        }