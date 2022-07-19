using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserNameFetcher
{
    internal class Query
    {
        public static string ToCommaSeparatedString(string[] items, string quote)
        {
            if (string.IsNullOrWhiteSpace(quote))
            {
                quote = "\"";
            }

            if (items.Length == 0)
                return string.Empty;

            var stringBuilder = new StringBuilder();
            foreach (var item in items)
            {
                stringBuilder.Append($"{quote}{item}{quote},");
            }

            var commaString = stringBuilder.ToString();
            commaString = commaString[..commaString.LastIndexOf(',')];

            return commaString;
        }
    }
}
