
using System.Text.RegularExpressions;

namespace Password.Domain.Entities
{
    public struct Password
    {
        private const string atLeastOneLowerCaseRegex = "(?=(.*[A-Z]){1,})";
        private const string atLeastOneUpperCaseRegex = "(?=(.*[a-z]){1,})";
        private const string atLeastOneNumbeRegex = "(?=(.*[\\d]){1,})";
        private const string atLeastOneSpecialCharacterRegex = "(?=(.*[\\W]){1,})";
        private const string atLeastNineCharacters = ".{9,}";

        public string Value { get; }

        public Password(string value)
        {
            Value = value;
        }

        public bool IsValid()
        {
            return Regex.IsMatch(Value ?? string.Empty, string.Concat(atLeastOneLowerCaseRegex, atLeastOneUpperCaseRegex, atLeastOneNumbeRegex, atLeastOneSpecialCharacterRegex, atLeastNineCharacters));
        }
    }
}
