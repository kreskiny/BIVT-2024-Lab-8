using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _pattern;
        private string _output;

        public Blue_2(string input, string pattern) : base(input)
        {
            _pattern = pattern;
            _output = null;
        }

        public string Output => _output;

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = null;
                return;
            }

            var words = Input.Split(' ');
            var resultWords = new List<string>();

            foreach (string originalWord in words)
            {
                if (originalWord==null || originalWord.Length==0) continue;
                string word = "";
                string prefix = "";
                string suffix = "";

                int start = 0;
                int end = originalWord.Length - 1;

                while (start <= end && !char.IsLetter(originalWord[start]) && originalWord[start] != '-')
                {
                    prefix += originalWord[start];
                    start++;
                }

                while (end >= start && !char.IsLetter(originalWord[end]) && originalWord[end] != '-')
                {
                    suffix = originalWord[end] + suffix;
                    end--;
                }

                if (start <= end)
                {
                    word = originalWord.Substring(start, end - start + 1);
                }

                if (!word.ToLower().Contains(_pattern))
                {
                    resultWords.Add(prefix + word + suffix);
                }
                else
                {
                    string glued = prefix + suffix;

                    if (resultWords.Count > 0 && glued.Length > 0)
                    {
                        int lastIndex = resultWords.Count - 1;
                        resultWords[lastIndex] += glued;
                    }
                    else if (glued.Length > 0)
                    {
                        resultWords.Add(glued);
                    }
                }
            }

            _output = string.Join(" ", resultWords).Trim();
            _output = string.Join(" ", resultWords).Trim();

            _output = Regex.Replace(_output, @"-""", "- \"\"");
            _output = Regex.Replace(_output, @"""""", " \"\"");
            _output = Regex.Replace(_output, @"\s{2,}", " ");

        }



        public override string ToString()
        {
            return _output;
        }
    }
}
