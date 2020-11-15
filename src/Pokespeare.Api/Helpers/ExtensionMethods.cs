#nullable enable
using System;
using System.Text.RegularExpressions;

namespace Pokespeare.Api.Helpers {
    
    public static class ExtensionMethods {
        public static string? CleanText(this string? input) {
            return !string.IsNullOrEmpty(input) ? Regex.Replace(input, @"\t|\\t|\n|\\n|\r|\\r|\f|\\f", " ") : null;
        }
    }
}