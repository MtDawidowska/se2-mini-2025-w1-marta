using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YourNamespace
{
    public class YourClass
    {
        public int Calc(string a)
        {
            if (string.IsNullOrEmpty(a))
            {
                return 0;
            }

            var delimiters = new[] { ',', '\n', ';', ' ', '|', ':', '#', '[' , ']' };

            var numbers = a.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
          


            int sum = 0;
            foreach (var number in numbers)
            {
                int n = int.Parse(number);
                if (n < 0)
                {
                    throw new ArgumentException("Number cannot be negative");
                }
                if (n > 1000)
                {
                    continue;
                }
                sum += int.Parse(number);
            }
            return sum;
        }
    }
}