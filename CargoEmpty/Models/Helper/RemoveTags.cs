using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CargoEmpty.Models.Helper
{
    public static class RemoveTags
    {
        public static string StripHTML(string input, string HTML_TAG_PATTERN)
        {
         
            return Regex.Replace(input, HTML_TAG_PATTERN, String.Empty);
        }
    }
}