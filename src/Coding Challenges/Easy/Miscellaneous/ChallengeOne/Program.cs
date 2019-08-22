class Program
    {
        static void Main(string[] args)
        {
         FindAlphabetPosition("The sunset sets at twelve o' clock.");
        }

        public static string FindAlphabetPosition(string text)
        {

            //Store values into new string
            List<string> edited = new List<string>();

            List<string> characters = new List<string>();
            for (char c = 'A'; c <= 'Z'; c++)
                characters.Add("" + c);

            foreach (char data in text)
            {
                if (Char.IsLetter(data))
                {
                    int asValue = characters.IndexOf(data.ToString().ToUpper()) + 1;
                    edited.Add(asValue.ToString() + " ");
                }
            }
            return String.Join("", edited.ToArray()).Trim();

        }
	}