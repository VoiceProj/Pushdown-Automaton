using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Pushdown Automaton checking input string for condition  {1^n 0^m | n>m≥0};
/// </summary>
namespace Lab3
{
    enum States
    {
        S1,
        S2
    }

    class PushdownAutomat
    {
        private Stack<char> stack;
        private string input;
        States state;

        public PushdownAutomat(string a)
        {
            stack = new Stack<char>();
            input = a;
            state = States.S1;
            stack.Push('e');
        }

        public bool Calculate()
        {
            if (input.Length == 0)
                return false;
            for (int i=0;i<input.Length;i++)
            {
                char a = input[i];
                switch (state)
                {
                    case States.S1:
                        if (stack.Contains('A'))
                        {
                            if (a == '1')
                            {
                                stack.Push('A');
                            }
                            else if (a == '0')
                            {
                                i--;
                                state = States.S2;
                            }
                            if (i == input.Length-1)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (a == '1')
                            {
                                stack.Push('A');
                            }
                            else if (a == '0')
                            {
                                return false;
                            }
                            if (i == input.Length-1)
                            {
                                if (stack.Contains('A'))
                                    return true;
                                else
                                    return false;
                            }
                        }
                        break;
                    case States.S2:
                        if (stack.Contains('A'))
                        {
                            if (a == '1')
                            {
                                return false;
                            }
                            else if (a == '0')
                            {
                                stack.Pop();
                            }
                            if (i == input.Length - 1)
                            {
                                if (stack.Contains('A'))
                                    return true;
                                else
                                    return false;
                            }
                        }
                        else
                        {
                            if (a == '1')
                            {
                                return false;
                            }
                            else if (a == '0')
                            {
                                return false;
                            }
                            if (i == input.Length - 1)
                            {
                                return false;
                            }
                        }
                        break;


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
                Console.WriteLine("Accepted");
            else
                Console.WriteLine("Rejected");

            Console.ReadLine();
        }
    }
}
