using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            int select;
            Console.Write("Choose the task from 1 to 8: ");
            select = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (select)
            {
                case 1:
                    string s = String.Empty;
                    Console.Write("Type 1 if you want to use the table with doublylinked list and type 2 to use with .NET list: ");
                    s = Console.ReadLine();
                    if (s == "1")
                        First1.Execute();
                    else if (s == "2")
                        First2.Execute();
                    break;
                case 2:
                    Console.WriteLine("The second task: \n");
                    Second.Execute();
                    break;
                case 3:
                    Console.WriteLine("The third task: \n");
                    Third.Execute();
                    break;
                case 4:
                    Console.WriteLine("The fourth task: \n");
                    Fourth.Execute();
                    break;
                case 5:
                    Console.WriteLine("The fifth task: \n");
                    Fifth.Execute();
                    break;
                case 6:
                    Console.WriteLine("The sixth task: \n");
                    Sixth.Execute();
                    break;
                case 7:
                    Console.WriteLine("The seventh task: \n");
                    Seventh.Execute();
                    break;
                case 8:
                    Console.WriteLine("The additional task: \n");
                    Eighth.Execute();
                    break;
                default:
                    break;
            }
        }
    }
}
