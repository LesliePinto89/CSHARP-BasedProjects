      /// <summary>
        /// Finds the natural language equivalent of its numerical
        /// counterpart written in a string. e.g. 132 would return one hundred and thirty two
        /// </summary>
        /// <param name="sample">A string formated numeral value</param>
        /// <returns></returns>
        public static string ThreeUnitWordDictionary(string sample)
        {
            if (sample == "0" || sample.Length == 0 || sample.Length > 3) 
                return null;
            
            int unitOne = Int32.Parse(sample[0].ToString());
            string word = "";
            List<string> upToTwenty = new List<string> {
                "one","two","three","four","five","six","seven","eight",
                "nine","ten","eleven","twelve","threeteen","fourteen","fiveteen","sixteen",
                "seventeen","eightteen","nineteen"
            };        
            List<string> baseTenDoubleHigher = new List<string> {
                "twenty","thirty","fourty","fifty","sixty","seventy",
                "eighty","ninety",
            };

            //e.g. 1,2,3
            if (sample.Length == 1) 
            word = upToTwenty.Find(x => unitOne-1 == upToTwenty.IndexOf(x));
            
            else if (sample.Length == 2)
            {
                //e.g. 11,13
                int unitTwo = Int32.Parse(sample[0].ToString()+ sample[1].ToString());
                word = upToTwenty.Find(x => unitTwo == upToTwenty.IndexOf(x));
                if (word == null) 
                {
                    //e.g. 20,30
                    unitTwo = Int32.Parse(sample[1].ToString());
                    word = baseTenDoubleHigher.Find(x => unitOne - 2 == baseTenDoubleHigher.IndexOf(x));

                    //e.g. adds one unit to make 31,42
                    string last = upToTwenty.Find(x => unitTwo-1 == upToTwenty.IndexOf(x));
                    word += " " + last;
                }
            }

            else if (sample.Length == 3) //e.g.147
            {
                int unitTwo = Int32.Parse(sample[1].ToString() + sample[2].ToString());
                int unitThree = Int32.Parse(sample[1].ToString());

                //e.g. 1 in 1 hundred
                word = upToTwenty.Find(x => unitOne-1 == upToTwenty.IndexOf(x));
                word += " hundred and ";
  
                //same as previous if case
                string joinWord = upToTwenty.Find(x => unitTwo-1 == upToTwenty.IndexOf(x));
                if (joinWord == null)
                {
                    joinWord = baseTenDoubleHigher.Find(x => unitThree - 2 == baseTenDoubleHigher.IndexOf(x));
                    string last = upToTwenty.Find(x => unitThree == upToTwenty.IndexOf(x));
                    word += joinWord + " " + last;
                }
                else
                    word += joinWord;
            }
            return word;
        }