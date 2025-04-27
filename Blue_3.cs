using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_8_1;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        public Blue_3(string input) : base(input)
        {
            _output = Array.Empty<(char, double)>();
        }

        public (char, double)[] Output
        {
            get { return _output; }
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = Array.Empty<(char, double)>();
                return;
            }
            char[] separators = new char[] { ' ', '\t', '\r', '\n' };

            string[] parts = Input.Split(separators);
            List<string> words = new List<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(parts[i]) || parts[i] == "")
                    continue;

                string cleanWord = "";

                for (int j = 0; j < parts[i].Length; j++)
                {
                    if (char.IsLetter(parts[i][j]))
                    {
                        cleanWord += parts[i][j];
                    }
                }

                if (cleanWord.Length > 0)
                {
                    words.Add(cleanWord);
                }
            }

            int totalWords = words.Count;
            Dictionary<char, int> counts = new Dictionary<char, int>();

            // Подсчёт слов по первой букве
            for (int i = 0; i < words.Count; i++)
            {
                char first = char.ToLower(words[i][0]);

                if (counts.ContainsKey(first))
                {
                    counts[first]++;
                }
                else
                {
                    counts[first] = 1;
                }
            }


            List<(char, double)> tempList = new List<(char, double)>();

            // Считаем проценты и добавляем в список
            foreach (var pair in counts)
            {
                double percent = Math.Round(100.0 * pair.Value / totalWords, 4);
                tempList.Add((pair.Key, percent));
            }

            for (int i = 0; i < tempList.Count - 1; i++)
            {
                for (int j = i + 1; j < tempList.Count; j++)
                {
                    bool needSwap = false;

                    if (tempList[i].Item2 < tempList[j].Item2)
                    {
                        needSwap = true;
                    }
                    else if (tempList[i].Item2 == tempList[j].Item2)
                    {
                        if (tempList[i].Item1 > tempList[j].Item1)
                        {
                            needSwap = true;
                        }
                    }

                    if (needSwap)
                    {
                        var temp = tempList[i];
                        tempList[i] = tempList[j];
                        tempList[j] = temp;
                    }
                }
            }

            _output = new (char, double)[tempList.Count];
            for (int i = 0; i < tempList.Count; i++)
            {
                _output[i] = tempList[i];
            }


        }

        public override string ToString()
        {
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
