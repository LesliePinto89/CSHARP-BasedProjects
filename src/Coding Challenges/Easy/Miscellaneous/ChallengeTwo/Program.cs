     class Program
    {
        static void Main(string[] args)
        {
            LookForAnagrams("racer", new List<string> { "carer", "arcre", "carre", "racrs",
                "racers", "arceer", "raccer", "carrer", "cerarr" });
        }
    
        public static List<string> LookForAnagrams(string word, List<string> words)
        {
            List<string> storeNames = new List<string>();
            for (int i = 0; i < words.Count(); i++)
            {
                 string copy = word;
                 string temp = words[i].ToString();
                 foreach (char letter in temp)
                 {

                    bool atLeastOne = copy.Any(x => x == letter);
                    if (atLeastOne)
                    {
                       int firstOccurance = copy.IndexOf(letter);
                       copy = new string(copy.Remove(firstOccurance, 1));

                       int firstInListOccurance = temp.IndexOf(letter);
                       temp = new string(temp.Remove(firstOccurance, 1));
                    }

                    if (copy == "")
                    {
                            storeNames.Add(words[i]);
                    }
                  }
               copy = word;
             }

         return storeNames;
        }
    }