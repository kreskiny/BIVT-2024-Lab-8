using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        public int Output
        {
            get { return _output; }
        }

        public override void Review()
        {
            int sum = 0;
            int i = 0;

            while (i < Input.Length)
            {
                if ((Input[i] >= '0' && Input[i] <= '9') || Input[i] == '-')
                {
                    bool isNegative = false;
                    if (Input[i] == '-')
                    {
                        isNegative = true;
                        i++;
                    }

                    int number = 0;
                    bool hasDigits = false;

                    while (i < Input.Length && Input[i] >= '0' && Input[i] <= '9')
                    {
                        number = number * 10 + (Input[i] - '0');
                        hasDigits = true;
                        i++;
                    }

                    if (hasDigits)
                    {
                        if (isNegative)
                            number = -number;

                        sum += number;
                    }
                }
                else
                {
                    i++;
                }
            }

            _output = sum;
        }

        public override string ToString()
        {
            return "" + Output;
        }
    }
}

