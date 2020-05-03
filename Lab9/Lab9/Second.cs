using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    /*
    С помощью стека проверить, что математическое выражение в скобках
    записано корректно.
    */
    public class Second
    {
        public static void Execute()
        {
            Console.Write("Write example: ");
            string example = Console.ReadLine();
            string brackets = String.Empty;
            foreach (char ch in example)
                if (ch == '(' || ch == ')')
                    brackets += ch;
            Stack<char> stk = new Stack<char>();
            foreach (char ch in brackets)
                if (ch == '(')
                    stk.Push(ch);
                else if (ch == ')' && stk.Count != 0)
                    stk.Pop();
            if (stk.Count == 0)
                Console.WriteLine("The example is right");
            else
                Console.WriteLine("The example has mistakes!");
        }
    }
}
