using System.Collections.Generic;

namespace OneOneFive
{
    internal static class NumberExt
    {
        #region Extension Methods
        public static string ToWords(this int number)
        {
            return Convert(number);
        }

        public static string ToWords(this long number)
        {
            return Convert(number);
        }
        #endregion

        #region Implementation
        // Code adapted from Humanizr
        // https://github.com/Humanizr/Humanizer/blob/main/LICENSE

        private static readonly string[] UnitsMap = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] TensMap = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        // private static string Convert(long number, bool isOrdinal = false, bool addAnd = true)
        private static string Convert(long number)
        {
            if (number == 0)
            {
                return UnitsMap[0];
            }

            if (number < 0)
            {
                return string.Format("minus {0}", Convert(-number));
            }

            var parts = new List<string>();
            if ((number / 1000000000) > 0)
            {
                parts.Add(string.Format("{0} billion", Convert(number / 1000000000)));
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                parts.Add(string.Format("{0} million", Convert(number / 1000000)));
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                parts.Add(string.Format("{0} thousand", Convert(number / 1000)));
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                parts.Add(string.Format("{0} hundred", Convert(number / 100)));
                number %= 100;
            }

            if (number > 0)
            {
                if (parts.Count != 0)
                {
                    parts.Add("and");
                }

                if (number < 20)
                {
                    parts.Add(UnitsMap[number]);
                }
                else
                {
                    var lastPart = TensMap[number / 10];
                    if ((number % 10) > 0)
                    {
                        lastPart += string.Format("-{0}", UnitsMap[number % 10]);
                    }

                    parts.Add(lastPart);
                }
            }

            return string.Join(" ", parts.ToArray());
        }
        #endregion
    }
}
