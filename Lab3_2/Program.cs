using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Non-primitive Pushdown Automaton transforming string according to the following rule "0^n 1^m" to "0 1^(2n) 0^(2m) 0", n>0, m>0.
/// </summary>
namespace Lab3_2
{
    class PushdownAutomat
    {
        private Stack<char> stack;
        private string input;
        public string result="";

        public PushdownAutomat(string a)
        {
            stack = new Stack<char>();
            input = a;
        }

        public bool Calculate()
        {
            if (input.Length == 0)
                return false;
            if (!input.Contains("0") || !input.Contains("1"))
                return false;
            for (int i = 0; i < input.Length; i++)
            {
                char a = input[i];
                if (stack.Count!=0)
                {
                    if (a == '0')
                    {
                        stack.Push('0');
                    }
                    else if (a == '1')
                    {
                        if (stack.Contains('1'))
                        {
                            stack.Push('1');
                        }
                        else
                        {
                            while (stack.Contains('0'))
                            {
                                stack.Pop();
                                result += "11";
                            }
                            stack.Push('1');
                        }
                    }
                    if (i == input.Length - 1)
                    {
                        if (stack.Contains('1'))
                        {
                            while (stack.Contains('1'))
                            {
                                stack.Pop();
                                result += "00";
                            }
                            i--;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (i == input.Length - 1)
                    {
                        result += "0";
                        return true;
                    }
                    if (a == '0')
                    {
                        result += "0";
                        stack.Push('0');
                    }
                    else if (a == '1')
                    {
                        return false;
                    }                    
                }

            }

            return true;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input string: ");
            string input;
            input = Console.ReadLine();

            PushdownAutomat automat = new PushdownAutomat(input);
            bool result = automat.Calculate();

            if (result)
            {
                Console.WriteLine("Accepted");
                Console.WriteLine("Transformed string {0}", automat.result);
            }
            else
                Console.WriteLine("Rejected");

            Console.ReadLine();
        }
    }
}
