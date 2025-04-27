using System;
using System.Text;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;

        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        public string[] Output
        {
            get { return _output; }
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
                _output = new string[0];
                return;
            }

            string[] words = Input.Split(' ');
            string[] temp = new string[0];
            string currentLine = "";

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (word != null)
                {
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
                        Array.Resize(ref temp, temp.Length + 1);
                        temp[temp.Length - 1] = currentLine;
                        currentLine = word;
                    }
                }
            }

            if (currentLine.Length > 0)
            {
                Array.Resize(ref temp, temp.Length + 1);
                temp[temp.Length - 1] = currentLine;
            }

            _output = temp;
        }

        public override string ToString()
        {
            if (_output == null) return null;
            if (_output.Length == 0) return "";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _output.Length; i++)
            {
                if (i > 0)
                {
                    sb.AppendLine();
                }
                sb.Append(_output[i]);
            }

            return sb.ToString();
        }
    }
}