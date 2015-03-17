﻿namespace Webcal.Connect.Shared.Macros
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Models;

    public static class MacroHelper
    {
        public static string FindAndReplace(string input, string macro, string value)
        {
            return input.Replace(macro, value);
        }

        public static string FindAndReplace(string content, Document document)
        {
            foreach (Match match in Regex.Matches(content, @"\{(\s*?.*?)*?\}", RegexOptions.IgnoreCase))
            {
                content = content.Replace(match.Value, GetMappingValue(document, match.Value));
            }

            return content;
        }

        private static string GetMappingValue(Document document, string mapping)
        {
            var property = document.GetType().GetProperties().FirstOrDefault(prop =>
            {
                var attribute = Attribute.GetCustomAttribute(prop, typeof(MacroAttribute)) as MacroAttribute;
                return attribute != null && string.Equals(mapping, attribute.Placeholder, StringComparison.CurrentCultureIgnoreCase);
            });

            if (property == null)
                return mapping;

            return property.GetValue(document, null) as string;
        }
    }
}