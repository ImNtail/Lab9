using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab9
{
    public class First1
    {
        enum Pos
        {
            П,
            С,
            А
        }
        struct Worker
        {
            public string fullname;
            public Pos position;
            public int year;
            public decimal salary;
            public void showTable()
            {
                Console.WriteLine("{0, -20} {1, -20} {2, -20} {3, -20}", fullname, position, year, salary);
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
                Console.WriteLine("{0, -20}: {1, -15} {2, -15}", time, operation, name);
            }
        }
        public class DoublyNode<T>
        {
            public DoublyNode(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public DoublyNode<T> Previous { get; set; }
            public DoublyNode<T> Next { get; set; }
        }
        public class DoublyLinkedList<T> : IEnumerable<T>
        {
            DoublyNode<T> head;
            DoublyNode<T> tail;
            int count;
            public void Add(T data)
            {
                DoublyNode<T> node = new DoublyNode<T>(data);
                if (head == null)
                    head = node;
                else
                {
                    tail.Next = node;
                    node.Previous = tail;
                }
                tail = node;
                count++;
            }
            public bool Remove(T data)
            {
                DoublyNode<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        break;
                    current = current.Next;
                }
                if (current != null)
                {
                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    else
                        tail = current.Previous;
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        head = current.Next;
                    count--;
                    return true;
                }
                return false;
            }
            public void Change(T dataToChange, T newData)
            {
                DoublyNode<T> node = new DoublyNode<T>(dataToChange);
                DoublyNode<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(dataToChange))
                        break;
                    current = current.Next;
                }
                current.Data = newData;
            }
            public int Count { get { return count; } }
            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }
            public bool Contains(T data)
            {
                DoublyNode<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
                return false;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                DoublyNode<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
        public static void Execute()
        {
            var logOfSession = new DoublyLinkedList<Log>();
            DateTime firstTime = DateTime.Now;
            DateTime secondTime = DateTime.Now;
            TimeSpan downtime = secondTime - firstTime;

            Worker Иванов;
            Иванов.fullname = "Иванов И.И.";
            Иванов.position = Pos.П;
            Иванов.year = 1975;
            Иванов.salary = 4170.50M;

            Worker Петренко;
            Петренко.fullname = "Петренко П.П.";
            Петренко.position = Pos.С;
            Петренко.year = 1996;
            Петренко.salary = 790.10M;

            Worker Сидоревич;
            Сидоревич.fullname = "Сидоревич М.С.";
            Сидоревич.position = Pos.А;
            Сидоревич.year = 1990;
            Сидоревич.salary = 2200.00M;

            var table = new DoublyLinkedList<Worker>();
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
                    Console.WriteLine("\nFull name{0, -11} Position{0, -12} Birth year{0, -10} Salary{0, -14}\n", " ");
                    foreach (var item in table)
                        item.showTable();
                }
                else if (selector == 2)
                {
                    Console.Write("\nEnter the full name: ");
                    string fullname = Console.ReadLine();
                    Pos position = new Pos();
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
                    newWorker.fullname = fullname;
                    newWorker.position = position;
                    newWorker.year = year;
                    newWorker.salary = salary;
                    table.Add(newWorker);

                    Log newLog;
                    newLog.time = DateTime.Now;
                    newLog.operation = "Record added";
                    newLog.name = fullname;
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
                    string s = String.Empty;
                    bool deleted = false;
                    string fullname = string.Empty;
                    do
                    {
                        Console.WriteLine("Write the full name you want to delete: ");
                        s = Console.ReadLine();
                        foreach (var item in table)
                        {
                            if (item.fullname == s)
                            {
                                table.Remove(item);
                                deleted = true;
                                fullname = s;
                                stopper = false;
                                break;
                            }
                        }
                        if (!deleted)
                            Console.WriteLine("There are no such workers!");
                    }
                    while (stopper);
                    stopper = true;

                    Log newLog;
                    newLog.time = DateTime.Now;
                    newLog.operation = "Record deleted";
                    newLog.name = fullname;
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
                    string s = String.Empty;
                    string oldFullName = string.Empty;
                    string fullname = string.Empty;
                    Pos position = new Pos();
                    int year = 0;
                    decimal salary = 0;
                    bool exist = true;
                    do
                    {
                        Console.WriteLine("Write the full name of worker you want to change: ");
                        s = Console.ReadLine();
                        foreach (var item in table)
                        {
                            if (item.fullname == s)
                            {
                                oldFullName = item.fullname;
                                Console.Write("Enter the full name: ");
                                fullname = Console.ReadLine();
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

                                Worker newWorker;
                                newWorker.fullname = fullname;
                                newWorker.position = position;
                                newWorker.year = year;
                                newWorker.salary = salary;
                                table.Change(item, newWorker);
                                exist = true;
                            }                               
                        }
                    }
                    while (stopper);
                    stopper = true;

                    if (!exist) Console.WriteLine("Enter the correct full name!");

                    Log newLog;
                    newLog.time = DateTime.Now;
                    newLog.operation = "Record updated";
                    newLog.name = oldFullName + " --> " + fullname;
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
                    Pos pos = new Pos();
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
                            foreach (var item in table)
                                if (item.position == pos)
                                    item.showTable();
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
                    foreach (var item in logOfSession)
                        item.logOutput();
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