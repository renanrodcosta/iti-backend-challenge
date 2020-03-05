using System.Text.RegularExpressions;

namespace Iti.BackendChallenge.WebAPI.UseCases
{
    public class ValidateStrongPassword
    {
        private const string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{9,})";
        private readonly Regex regex;
        public ValidateStrongPassword()
        {
            regex = new Regex(pattern);
        }

        public bool IsValid(string value) => regex.Match(value ?? "").Success;
    }
}
