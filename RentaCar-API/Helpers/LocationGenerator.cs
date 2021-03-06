using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RentaCar_API.Helpers
{
    public static class LocationGenerator
    {
        public static string GenerateSlug(string incomingString, string slugSeparator = "-")
        {
            var alphaNum = Regex.Replace(incomingString, @"[^a-zA-Z0-9\s]", string.Empty);
            alphaNum = Regex.Replace(alphaNum, @"\s+", slugSeparator);

            return alphaNum.ToLower();
        }
    }
}
