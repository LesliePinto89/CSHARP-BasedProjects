    class Program
    {
        static void Main(string[] args)
        {
            StringScramble("nwinee33r", "winner");
        }

		/// <summary>
        /// Checks if a given string can be used to make a source string.
        /// </summary>
        /// <param name="str1">The comparison string that can contains characters to create str2</param>
        /// <param name="str2">The source file to find if str1 can be used to make it</param>
        /// <returns>bool as string that states if str1 can make str2</returns>
        public static string StringScramble(string str1, string str2)
        {

            char[] test = new char[] { };
            
            foreach (char letter in str1)
            {
                bool atLeastOne = str2.Any(x => x == letter);
                if (atLeastOne)
                {
                    int firstOccurance = str2.IndexOf(letter);
                    str2 = new string(str2.Remove(firstOccurance, 1));
                }
            }
            if (str2.Length == 0)
                str1 = "true";
           
            else
                str1 = "false";
            
            return str1;
        }
    }