using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

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
            var result = "";
            var words = Input.Split(' ');

            foreach (var part in words)
            {
                string word = "";
                string punctuation = "";

                int i = 0;
                while (i < part.Length && (char.IsLetterOrDigit(part[i]) || part[i] == '-'))
                {
                    word += part[i];
                    i++;
                }

                if (i < part.Length)
                    punctuation = part.Substring(i);
                else
                    punctuation = "";


                if (!word.Contains(_pattern))
                {
                    if (result.Length > 0)
                        result += " ";

                    result += word;

                    if (punctuation!=null && punctuation!="")
                        result += punctuation;
                }
                else
                {
                    if (punctuation != null && punctuation != "" && result.Length > 0)
                    {
                        if (result[result.Length - 1] == ' ')
                            result = result.Substring(0, result.Length - 1);

                        result += punctuation;
                    }
                }
            }

            _output = result.Trim();
        }




        public override string ToString()
        {
            return Output;
        }
    }

}

