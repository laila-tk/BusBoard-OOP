using System.Text.RegularExpressions;
using NLog;
namespace BusBoard
{
    class UserInput
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static readonly string pattern = @"^((([a-zA-Z][0-9])|([a-zA-Z][0-9]{2})|([a-zA-Z]{2}[0-9])|([a-zA-Z]{2}[0-9]{2})|([A-Za-z][0-9][a-zA-Z])|([a-zA-Z]{2}[0-9][a-zA-Z]))(\s*[0-9][a-zA-Z]{2}))$";
        public string GetPostCode()
        {
            Console.WriteLine("Please enter a PostCode");
            while (true)
            {
                string postCode = Console.ReadLine()?.Trim() ?? string.Empty;

                if (Regex.IsMatch(postCode, pattern))
                {
                    return postCode;
                }
                else
                {
                    Console.WriteLine("Please enter a valid post code");
                    Logger.Warn("Invalid Postcode entered");
                }
            }
        }
    }
}