using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace core
{
    public static class TelephoneNumberStringExtensions
    {
        static string pattern = "^[+][0-9]{12}$";
        /// <summary>
        /// Verifies if number is correct, example: +14155238886
        /// </summary>
        /// <param name="number">Telephone number in string</param>
        /// <returns>True if it's a telephone number that matches the pattern, False if it's not </returns>
        public static bool IsTelephoneNumber(this string number) => Regex.IsMatch(number, pattern);
    }
}
