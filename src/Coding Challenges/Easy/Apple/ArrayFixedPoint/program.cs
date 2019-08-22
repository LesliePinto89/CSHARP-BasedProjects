    class Program
    {
        static void Main(string[] args)
        {
            int[] sample = new[] { 1, 5, 7, 8, 4};
            int answer = FindFixedPoint(sample);
            string output = (answer == -1) ? "false" : answer.ToString();
            Console.WriteLine(output);
        }

        /// <summary>
        /// Daily Coding Problem: Problem #273 A fixed point in 
        /// an array is an element whose value is equal to its 
        /// index. Given a sorted array of distinct elements, 
        /// return a fixed point, if one exists. Otherwise, return False.
        /// </summary>
        /// <param name="sample">The array to check for a fixed point</param>
        /// <returns>A value that represents if fixed point is found</returns>
        public static int FindFixedPoint(int [] sample) {
            int i = 0;
            foreach (int number in sample) {
                if (number == i) {
                    return number;
                }
                i++;
            }
            return -1;
        }
    }