using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace Server.Services
{
    public class RegexService
    {
        public string ChangeBrackets(string input)
        {
            var pattern = @"(\()|(\))";
            string result;
            result = Regex.Replace(input, pattern, m => m.Value == "(" ? "[" : "]");
            return result;
        }
    }
}
