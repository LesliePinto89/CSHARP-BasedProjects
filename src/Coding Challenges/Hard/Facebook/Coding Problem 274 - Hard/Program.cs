using System;
using System.Collections.Generic;
using System.Globalization;

namespace FacebookChallenges
{
    /// <summary>
    /// Daily Coding Problem: Problem #274 [Hard]
    /// Given a string consisting of parentheses, single digits, and positive and 
    /// negative signs, convert the string into a mathematical expression to obtain the answer.
    /// </summary>
    class Program
    {
        private static List<string> bracketElements = new List<string>();
        private static List<int> sumBracketElements = new List<int>();
        private static List<string> otherElements = new List<string>();
        private static string sample;
        private static int equationIndex; //Used for complete iteration

        static void Main(string[] args)
        {
            sample = @"-1 + (6 - -3 - 3)";
            BreakdownExpression(sample);
        }

        public static void BreakdownExpression(string sample)
        {
            for (; equationIndex < sample.Length;)
            {
                if (sample[equationIndex] == '(')
                {
                    equationIndex -= 1;
                    FindBracketsFirst(sample);
                }

                else if (sample[equationIndex] != '(' || sample[equationIndex] != ')')
                    OrganiseElements(otherElements, sample);

                equationIndex++; // Seperate from else if
            }
            PrintResult();
        }

           public static void FindBracketsFirst(string sample)
        {
            bool start = false;
            for (; equationIndex < sample.Length; equationIndex++)
            {
                if (Char.GetUnicodeCategory(sample[equationIndex]) == UnicodeCategory.ClosePunctuation)
                {
                    bracketElements.Add(sample[equationIndex].ToString());
                    break;
                }
                if (Char.GetUnicodeCategory(sample[equationIndex]) == UnicodeCategory.OpenPunctuation)
                {
                    if (!start)
                    {
                        start = true;
                        bracketElements.Add(sample[equationIndex].ToString());
                    }
                }
                else
                    OrganiseElements(bracketElements, sample);
            }
            //Sort out values in brackets
            sumBracketElements.Add(DefineTerms(bracketElements, false));
        }
            
          public static void OrganiseElements(List<string> list, string sample)
        {
            //Check for absolute number
            if (Char.GetUnicodeCategory(sample[equationIndex]) == UnicodeCategory.DashPunctuation &&
           Char.GetUnicodeCategory(sample[equationIndex + 1]) == UnicodeCategory.DecimalDigitNumber)
                CreateAbsoluteNumber(list);

            else
            {
                switch (Char.GetUnicodeCategory(sample[equationIndex]))
                {
                    case UnicodeCategory.DecimalDigitNumber:
                        MultipleDigits(list, sample);
                        break;
                    case UnicodeCategory.DashPunctuation: //Handle '-' as minus at this point
                    case UnicodeCategory.MathSymbol:
                        list.Add(sample[equationIndex].ToString());
                        break;
                }
            }
        }
        
         public static void CreateAbsoluteNumber(List<string> list) {
            string sign = sample[equationIndex].ToString(); //Store sign first
            equationIndex += 1; //jump to next index in sample string
            MultipleDigits(list, sample); //build variable length digits
            string missingSignNumber = list[list.Count-1];
            string absoluteDigit = sign + missingSignNumber; //add sign to complete digit
            list.Remove(missingSignNumber);
            list.Add(absoluteDigit);
        }
 
         public static void MultipleDigits(List<string> list, string sample)
        {
            string build = "";
            for (; equationIndex < sample.Length; equationIndex++)
            {
                UnicodeCategory elementType = Char.GetUnicodeCategory(sample[equationIndex]);
                if (elementType == UnicodeCategory.DecimalDigitNumber)
                    build += sample[equationIndex].ToString();

                else
                {
                    list.Add(build);
                    break;
                }
            }
        }
        
        public static int TermsArithmetic(List<string> expresions, int e, int pendingSum, int a, int b)
        {
            int term = (pendingSum != 0) ? pendingSum : a;
            switch (expresions[e])
            {
                case "+":
                    pendingSum = term + b;
                    break;
                case "-":
                    pendingSum = term - b;
                    break;
            }
            return pendingSum;
        }

        public static int DefineTerms(List<string> expresions, bool end)
        {
            int sum = 0;
            int a = 0;
            int b = 0;
            var bIsNumeric = false;

            for (int i = 0; i < expresions.Count; i++)
            {
                var aIsNumeric = int.TryParse(expresions[i], out int aN);
                if (aIsNumeric)
                    a = aN;

                //Used to later print out final value, might cause problems
                //later though
                if (end && i != expresions.Count - 1)
                {
                    bIsNumeric = int.TryParse(expresions[i + 2], out int bN);
                    if (bIsNumeric)
                        b = bN;
                }

                else if ((i + 2) >= expresions.Count == false && !end)
                {
                    bIsNumeric = int.TryParse(expresions[i + 2], out int bN);
                    if (bIsNumeric)
                        b = bN;
                }
                else
                    break;
                if (aIsNumeric && bIsNumeric)
                {
                    i++;
                    aIsNumeric = bIsNumeric = false;
                }
                sum = TermsArithmetic(expresions, i, sum, a, b);
            }
            return sum;
        }
        
          public static void PrintResult()
        {
            var equationElements = new List<string>(otherElements)
            {
                sumBracketElements[0].ToString()
            };
            int finalValue = DefineTerms(equationElements, true);
            Console.WriteLine($"The answer to the equation '{sample}' is: {finalValue}");
        }   
    }
}
