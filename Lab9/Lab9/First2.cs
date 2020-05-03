using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    /*
    Модифицировать код проекта из лабораторной работы №5 дважды: в
    первом проекте данные предметной области хранить и обрабатывать в виде
    двусвязного списка (структуру реализовать самостоятельно), во втором –
    использовать коллекцию .NET List.
    */
    public class First2
    {
        enum Pos
        {
            П,
            С,
            А
        }
        struct Worker
        {
            public string surname;
            public Pos position;
            public int year;
            public decimal salary;
            public void showTable()
            {
                Console.WriteLine("{0, -20} {1, -5} {2, -10} {3, -10}", surname, position, year, salary);
                Console.WriteLine();
            }
        }
        struct Log
        {
            public DateTime time;
            public string operation;
            public string name;
            public void logOutput()
            {
                Console.WriteLine("{0, -20} : {1, -15} {2, -15}", time, operation, name);
            }
        }
        public static void Execute()
        {
            var logOfSession = new List<Log>();
            DateTime firstTime = DateTime.Now;
            DateTime secondTime = DateTime.Now;
            TimeSpan downtime = secondTime - firstTime;

            Worker Иванов;
            Иванов.surname = "Иванов И.И.";
            Иванов.position = Pos.П;
            Иванов.year = 1975;
            Иванов.salary = 4170.50M;

            Worker Петренко;
            Петренко.surname = "Петренко П.П.";
            Петренко.position = Pos.С;
            Петренко.year = 1996;
            Петренко.salary = 790.10M;

            Worker Сидоревич;
            Сидоревич.surname = "Сидоревич М.С.";
            Сидоревич.position = Pos.А;
            Сидоревич.year = 1990;
            Сидоревич.salary = 2200.00M;

            List<Worker> table = new List<Worker>();
            table.Add(Иванов);
            table.Add(Петренко);
            table.Add(Сидоревич);

            bool working = true;
            bool stopper = true;
            do
            {
                Console.WriteLine("Select an action:\n1 - View the table\n2 - Add a record\n3 - Delete a record\n4 - Change a record\n5 - Search a record\n6 - Show log\n7 - Exit\n");
                int selector = int.Parse(Console.ReadLine());
                if (selector == 1)
                {
                    Console.WriteLine("Surname{0, -13} Position{0, -12} Birth year{0, -10} Salary{0, -14}", " ");
                    for (int i = 0; i < table.Count; i++)
                        table[i].showTable();
                    Console.WriteLine();
                }
                else if (selector == 2)
                {
                    Console.Write("Enter the surname: ");
                    string surname = Console.ReadLine();
                    var position = Pos.А;
                    int year = 0;
                    decimal salary = 0;
                    do
                    {
                        Console.Write("Enter the position in Russian: ");
                        string pos = Console.ReadLine();
                        if (pos == "П")
                        {
                            position = Pos.П;
                            stopper = false;
                        }
                        else if (pos == "С")
                        {
                            position = Pos.С;
                            stopper = false;
                        }
                        else if (pos == "А")
                        {
                            position = Pos.А;
                            stopper = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter the correct position!");
                            Console.WriteLine();
                        }
                    }
                    while (stopper);
                    stopper = true;
                    do
                    {
                        Console.Write("Enter the year of birth: ");
                        try
                        {
                            year = int.Parse(Console.ReadLine());
                            stopper = false;
                        }
                        catch (FormatException)
                        {
                            year = 0;
                            Console.WriteLine("Enter the correct year!");
                        }
                    }
                    while (stopper);
                    stopper = true;
                    do
                    {
                        Console.Write("Enter the salary: ");
                        try
                        {
                            salary = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                            stopper = false;
                        }
                        catch (FormatException)
                        {
                            salary = 0;
                            Console.WriteLine("Enter the correct salary!");
                        }
                    }
                    while (stopper);
                    stopper = true;

                    Worker newWorker;
                    newWorker.surname = surname;
                    newWorker.position = position;
                    newWorker.year = year;
                    newWorker.salary = salary;
                    table.Add(newWorker);

                    Log newLog;
                    newLog.time = DateTime.Now;
                    newLog.operation = "Record added";
                    newLog.name = surname;
                    logOfSession.Add(newLog);

                    firstTime = newLog.time;
                    TimeSpan secondDowntime = firstTime - secondTime;
                    if (downtime < secondDowntime)
                        downtime = secondDowntime;
                    secondTime = newLog.time;
                    Console.WriteLine();
                }
                else if (selector == 3)
                {
                    int number = 0;
                    string surname = string.Empty;
                    do
                    {
                        Console.WriteLine("Choose the number of row to delete: ");
                        number = int.Parse(Console.ReadLine());
                        if (number > 0 && number <= table.Count)
                        {
                            surname = table[number - 1].surname;
                            table.RemoveAt(number - 1);
                            stopper = false;
                        }
                        else
                            Console.WriteLine("Enter the correct number!");
                    }
                    while (stopper);
                    stopper = true;

                    Log newLog;
                    newLog.time = DateTime.Now;
                    newLog.operation = "Record deleted";
                    newLog.name = surname;
                    logOfSession.Add(newLog);

                    firstTime = newLog.time;
                    TimeSpan secondDowntime = firstTime - secondTime;
                    if (downtime < secondDowntime)
                        downtime = secondDowntime;
                    secondTime = newLog.time;
                    Console.WriteLine();
                }
                else if (selector == 4)
                {
                    string oldSurname = string.Empty;
                    string surname = string.Empty;
                    var position = Pos.А;
                    int year = 0;
                    decimal salary = 0;
                    int number = 0;
                    do
                    {
                        Console.WriteLine("Choose the number of row to update: ");
                        number = int.Parse(Console.ReadLine());
                        if (number > 0 && number <= table.Count)
                        {
                            oldSurname = table[number - 1].surname;
                            Console.Write("Enter the surname: ");
                            surname = Console.ReadLine();
                            do
                            {
                                Console.Write("Enter the position in Russian: ");
                                string pos = Console.ReadLine();
                                if (pos == "П")
                                {
                                    position = Pos.П;
                                    stopper = false;
                                }
                                else if (pos == "С")
                                {
                                    position = Pos.С;
                                    stopper = false;
                                }
                                else if (pos == "А")
                                {
                                    position = Pos.А;
                                    stopper = false;
                                }
                                else
                                {
                                    Console.WriteLine("Enter the correct position!");
                                    Console.WriteLine();
                                }
                            }
                            while (stopper);
                            stopper = true;
                            do
                            {
                                Console.Write("Enter the year of birth: ");
                                try
                                {
                                    year = int.Parse(Console.ReadLine());
                                    stopper = false;
                                }
                                catch (FormatException)
                                {
                                    year = 0;
                                    Console.WriteLine("Enter the correct year!");
                                }
                            }
                            while (stopper);
                            stopper = true;
                            do
                            {
                                Console.Write("Enter the salary: ");
                                try
                                {
                                    salary = decimal.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                                    stopper = false;
                                }
                                catch (FormatException)
                                {
                                    salary = 0;
                                    Console.WriteLine("Enter the correct salary!");
                                }
                            }
                            while (stopper);
                        }
                        else
                            Console.WriteLine("Enter the correct number!");
                    }
                    while (stopper);
                    stopper = true;

                    Worker editWorker;
                    editWorker.surname = surname;
                    editWorker.position = position;
                    editWorker.year = year;
                    editWorker.salary = salary;
                    table.Insert(number - 1, editWorker);
                    table.Remove(table[number]);

                    Log newLog;
                    newLog.time = DateTime.Now;
                    newLog.operation = "Record updated";
                    newLog.name = oldSurname + " --> " + surname;
                    logOfSession.Add(newLog);

                    firstTime = newLog.time;
                    TimeSpan secondDowntime = firstTime - secondTime;
                    if (downtime < secondDowntime)
                        downtime = secondDowntime;
                    secondTime = newLog.time;
                    Console.WriteLine();
                }
                else if (selector == 5)
                {
                    var pos = Pos.П;
                    do
                    {
                        Console.WriteLine("П - teachers");
                        Console.WriteLine("С - students");
                        Console.WriteLine("А - graduate students");
                        Console.WriteLine("Enter who you want to find (russian letter): ");
                        string select = Console.ReadLine();
                        Console.WriteLine();
                        if (select == "П" || select == "С" || select == "А")
                        {
                            if (select == "П")
                                pos = Pos.П;
                            if (select == "С")
                                pos = Pos.С;
                            if (select == "А")
                                pos = Pos.А;
                            for (int i = 0; i < table.Count; i++)
                                if (table[i].position == pos)
                                    table[i].showTable();
                            stopper = false;
                        }
                        else
                            Console.WriteLine("Enter in the correct form!");
                    }
                    while (stopper);
                    stopper = true;
                    Console.WriteLine();
                }
                else if (selector == 6)
                {
                    for (int i = 0; i < logOfSession.Count; i++)
                        logOfSession[i].logOutput();
                    Console.WriteLine("\n" + downtime + " - the largest downtime\n");
                }
                else if (selector == 7)
                    working = false;
                else if (selector < 1 || selector > 7)
                    Console.WriteLine("Choose the correct action!\n");
            }
            while (working);
            Console.WriteLine();
        }
    }
}
