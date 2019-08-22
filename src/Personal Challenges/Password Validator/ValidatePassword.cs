    /// <summary>
    /// A password validator that must ensure the following criteria.
    /// - At least one symbol character
    /// - At least one upper case character
    /// - At least one lower case character
    /// - At least one digit
    /// - Password length between 8 and 12 characters
    /// - Contain no white spaces
    /// </summary>
    public class ValidatePassword
    {
        public static bool Validate(string input)
        {
            bool[] validate = {
            input.Any(x => char.IsSymbol(x)),
            input.Any(x => char.IsUpper(x)),
            input.Any(x => char.IsLower(x)),
            input.Any(x => char.IsDigit(x)),
            input.Length >= 8 && input.Length <= 12
        };
            if (validate.Any(x => x == false))
            { return false; }
            else
            {
                if (input.Any(x => char.IsWhiteSpace(x))) { return false; }
                else
                {
                    return true;
                }
            }
        }
    }