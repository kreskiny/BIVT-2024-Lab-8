using System;
using System.Collections.Generic;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _pattern;
        private string _output;

        public Blue_2(string input, string pattern) : base(input)
        {
            _pattern = pattern;
            _output = string.Empty;
        }

        public string Output => _output;

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = "";
                return;
            }

            var words = Input.Split(' ');
            var resultWords = new List<string>();

            foreach (string part in words)
            {
                string word = "";
                string prefix = "";
                string suffix = "";

                int start = 0;
                int end = part.Length - 1;

                while (start <= end && !char.IsLetterOrDigit(part[start]) && part[start] != '-')
                {
                    prefix += part[start];
                    start++;
                }

                while (end >= start && !char.IsLetterOrDigit(part[end]) && part[end] != '-')
                {
                    suffix = part[end] + suffix;
                    end--;
                }

                if (start <= end)
                    word = part.Substring(start, end - start + 1);

                if (!word.Contains(_pattern))
                {
                    resultWords.Add(prefix + word + suffix);
                }
                else
                {
                    if (prefix.Contains("\"") && suffix.Contains("\""))
                    {
                        resultWords.Add(prefix.Replace("\"", "") + "\"" + "\"" + suffix.Replace("\"", ""));
                    }
                }
            }

            _output = string.Join(" ", resultWords).Replace("  ", " ").Trim();
        }


        public override string ToString()
        {
            return _output;
        }
    }
}
