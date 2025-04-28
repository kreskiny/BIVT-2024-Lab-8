using System;
using System.Text;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _pattern;
        private string _output;

        public Blue_2(string input, string pattern) : base(input)
        {
            _pattern = pattern?.ToLower();
            _output = null;
        }

        public string Output => _output;

        public override void Review()
        {
            if (Input == null || _pattern == null)
            {
                _output = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = "";
                return;
            }

            string[] tempWords = Input.Split(' ');
            int wordCount = 0;
            foreach (string w in tempWords)
            {
                if (!string.IsNullOrEmpty(w)) wordCount++;
            }

            string[] words = new string[wordCount];
            int index = 0;
            foreach (string w in tempWords)
            {
                if (!string.IsNullOrEmpty(w))
                {
                    words[index++] = w;
                }
            }

            string result = "";
            bool spaceNeeded = false;

            for (int i = 0; i < words.Length; i++)
            {
                string originalWord = words[i];
                if (string.IsNullOrEmpty(originalWord)) continue;

                string word = originalWord;
                string prefix = "";
                string suffix = "";

                int start = 0;
                while (start < word.Length && !char.IsLetter(word[start]) && word[start] != '-')
                {
                    prefix += word[start];
                    start++;
                }

                int end = word.Length - 1;
                while (end >= start && !char.IsLetter(word[end]) && word[end] != '-')
                {
                    suffix = word[end] + suffix;
                    end--;
                }

                string coreWord = (start <= end) ? word.Substring(start, end - start + 1) : "";

                if (!coreWord.ToLower().Contains(_pattern))
                {
                    if (spaceNeeded) result += " ";
                    result += prefix + coreWord + suffix;
                    spaceNeeded = true;
                }
                else
                {
                    string glued = prefix + suffix;
                    if (!string.IsNullOrEmpty(glued))
                    {
                        if (spaceNeeded) result += " ";
                        result += glued;
                        spaceNeeded = true;
                    }
                }
            }

            _output = result;

            _output = _output.Replace(" .", ".")
                            .Replace(" ,", ",")
                            .Replace(" ;", ";");
                            //.Replace(" \"", "\"")
                            //.Replace("\" ", "\"");
        }

        public override string ToString()
        {
            return _output;
        }
    }
}
