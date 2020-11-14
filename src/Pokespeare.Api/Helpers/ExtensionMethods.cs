using System;
using System.Text.RegularExpressions;

namespace Pokespeare.Api.Helpers {
    
    public static class ExtensionMethods {
        public static string CleanText(this string input) {
            return Regex.Replace(input, @"\t|\\t|\n|\\n|\r|\\r|\f|\\f", " ");
        }
    }
}