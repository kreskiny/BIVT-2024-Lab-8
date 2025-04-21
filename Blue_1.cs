using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_1
{
    public class Blue_1 : Blue
    {
        private string[] _output;

        public Blue_1(string input) : base(input)
        {
            _output = new string[0];
        }

        public string[] Output
        {
            get { return _output; }
        }

        public override void Review()
        {
            List<string> lines = new List<string>();
            string[] words = Input.Split(' ');
            string currentLine = "";

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (currentLine.Length == 0)
                {
                    currentLine = word;
                }
                else if (currentLine.Length + 1 + word.Length <= 50)
                {
                    currentLine += " " + word;
                }
                else
                {
                    lines.Add(currentLine);
                    currentLine = word;
                }
            }

            if (currentLine.Length > 0)
            {
                lines.Add(currentLine);
            }

            _output = lines.ToArray();
        }

        public override string ToString()
        {
            return string.Join("\n", _output); ;
        }
    }
}
