using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public (char, double)[] Output
        {
            get
            {
                if (_output == null) return null;
                (char, double)[] copy = new (char, double)[_output.Length];
                Array.Copy(_output, copy, _output.Length);
                return copy;
            }
        }

        public override void Review()
        {
            if (Input == null)
            {
                _output = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = Array.Empty<(char, double)>();
                return;
            }

            string processed = Input.Replace(" - ", " ").Replace(" -", " ").Replace("- ", " ")
                                  .Replace("–", " ");

            string[] words = processed.Split(new[] { ' ', '\t', '\n', '\r', ',', '.', '!', '?', ':', ';', '"', '(', ')' },
                                       StringSplitOptions.RemoveEmptyEntries);

            int[] counts = new int[char.MaxValue];
            int totalWords = 0;

            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word) || word.Any(char.IsDigit))
                    continue;

                char firstChar = char.ToLower(word[0]);
                if (char.IsLetter(firstChar))
                {
                    counts[firstChar]++;
                    totalWords++;
                }
            }

            if (totalWords == 0)
            {
                _output = Array.Empty<(char, double)>();
                return;
            }

            int uniqueCount = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0) uniqueCount++;
            }

            (char, double)[] temp = new (char, double)[uniqueCount];
            int index = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    double percent = (100.0 * counts[i]) / totalWords;
                    percent = Math.Floor(percent * 10000 + 0.5) / 10000;
                    temp[index++] = ((char)i, percent);
                }
            }

            for (int i = 0; i < temp.Length - 1; i++)
            {
                for (int j = i + 1; j < temp.Length; j++)
                {
                    if (temp[i].Item2 < temp[j].Item2 ||
                       (Math.Abs(temp[i].Item2 - temp[j].Item2) < 0.0001 && temp[i].Item1 > temp[j].Item1))
                    {
                        var t = temp[i];
                        temp[i] = temp[j];
                        temp[j] = t;
                    }
                }
            }

            _output = temp;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;

            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += $"{_output[i].Item1} - {_output[i].Item2:0.0000}";
                if (i < _output.Length - 1)
                    result += Environment.NewLine;
            }
            return result;
        }
    }
}