using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab9
{
    public class Third
    {
        /*
         Написать игру «Считалка», в коде которой будет эмулироваться сам
        процесс игры с помощью циклического связного списка. В игре участвуют
        от 5 до 10 человек (имена участников ввести из текстового файла либо
        «прошить» в коде). Пользователь вводит строку считалки и указывает
        человека, с которого необходимо начать. Программа должна вывести
        человека, на которого придется последнее слово строки.
        */
        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }
        public class CircularLinkedList<T> : IEnumerable<T>
        {
            Node<T> head;
            Node<T> tail;
            int count;
            public void Add(T data)
            {
                Node<T> node = new Node<T>(data);
                if (head == null)
                {
                    head = node;
                    tail = node;
                    tail.Next = head;
                }
                else
                {
                    node.Next = head;
                    tail.Next = node;
                    tail = node;
                }
                count++;
            }
            public void Counting(int start, int countingCount)
            {
                for (int i = 0; i < start + countingCount - 2; i++)
                    head = head.Next;
                Console.WriteLine("The winner is: " + head.Data);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                do
                {
                    if (current != null)
                    {
                        yield return current.Data;
                        current = current.Next;
                    }
                }
                while (current != head);
            }
        }
        public static void Execute()
        {
            int select = 0;
            while (select > 2 || select < 1)
            {
                Console.Write("Write 1 to solve it by using circular linked list and 2 to solve it without no additional data structures: ");
                select = int.Parse(Console.ReadLine());
            }
            string people = String.Empty;
            using (StreamReader file = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "people.txt")))
                people = file.ReadToEnd();
            string[] participants = people.Split(new char[] { ' ' });
            Console.Write("Write counting sentence: ");
            string[] counting = Console.ReadLine().Split(new char[] { ' ', ',', '-', '.', '?', ';', ':', '"' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Choose which person to start with from 1 to {0}: ", participants.Length);
            int start = 0;
            while (start > participants.Length || start < 1)
                start = int.Parse(Console.ReadLine());
            if (select == 1)
            {
                CircularLinkedList<string> users = new CircularLinkedList<string>();
                foreach (string s in participants)
                    users.Add(s);
                users.Counting(start, counting.Length);
            }
            else if (select == 2)
                Console.WriteLine("The winner is: " + participants[(counting.Length % participants.Length) - 2 + start]);
        }
    }
}
