   public class ConvertQuxes
    {
		/// <summary>
        /// On a mysterious island there are creatures known as Quxes which come in three colors: red, green, and blue. 
        /// One power of the Qux is that if two of them are standing next to each other, they can transform into a single 
        /// creature of the third color. Given N Quxes standing in a line, determine the smallest number of them remaining 
        /// after any possible sequence of such transformations.
        /// </summary>
        /// <param name="quxes">The sequence of qux elements</param>
        /// <returns>The remainder of quixes after changing colours</returns>
        public static List<char> FindQuxConverts(char[] quxes){  //e.g. new char[] { 'B', 'G', 'R', 'B', 'G' }
        List<char> quxesList  = quxes.ToList();
        List<Tuple<char,char,char>> quxChanges = new List<Tuple<char,char,char>>{
          new Tuple<char,char,char> ('R','G','B'),
          new Tuple<char,char,char> ('G','R','B'),
          new Tuple<char,char,char> ('B','R','G'),
          new Tuple<char,char,char>('R','B','G'),
          new Tuple<char,char,char> ('G','B','R'),
          new Tuple<char,char,char> ('B','G','R'),
        };

           for (int i =0; i < quxesList.Count(); i++)
            {
            var termOne = quxesList[i];
            var termTwo = quxesList[i+1];
               foreach(var pair in quxChanges)
                {
                    if (termOne == pair.Item1 && termTwo == pair.Item2)
                    {
                        int updateIndex = i;
                        quxesList.Remove(termOne);
                        quxesList.Remove(termTwo);
                        quxesList.Insert(updateIndex, pair.Item3);
                        i = -1;
                        break;
                    }
                }
                if (i + 2 == quxesList.Count())
                    break;
            }
            return quxesList;
        } 
    }