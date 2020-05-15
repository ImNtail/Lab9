using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Lab9
{
    public class Seventh
    {
        /*
        Написать программу, в соответствии с вариантом. Решить задачу как на
        основе самостоятельно разработанного списка, так и на основе коллекции .NET.
        Вариант 1 (11).
        Написать программу, которая оставляет в списке только уникальные элементы.
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
        public class LinkedList<T> : IEnumerable<T>
        {
            Node<T> head;
            Node<T> tail;
            int count;
            public void Add(T data)
            {
                Node<T> node = new Node<T>(data);
                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;
                count++;
            }
            public int Count { get { return count; } }
            public bool Contains(T data)
            {
                Node<T> current = head;
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
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
        public static void Execute()
        {
            string[] words;
            int select = 0;
            using (StreamReader text = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sixth.txt")))
                words = text.ReadToEnd().ToLower().Split(new char[] { ' ', ',', '-', '.', ';', ':', '?', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            while (select != 1 && select != 2)
            {
                Console.Write("Type 1 if you want to use .NET list and type 2 to use new list: ");
                select = int.Parse(Console.ReadLine());
            }
            if (select == 1)
            {
                List<string> list = new List<string>();
                foreach (string word in words)
                    if (!list.Contains(word))
                        list.Add(word);
                foreach (var item in list)
                    Console.WriteLine(item);
            }
            else if (select == 2)
            {
                LinkedList<string> list = new LinkedList<string>();
                foreach (string word in words)
                    if (!list.Contains(word))
                        list.Add(word);
                foreach (var item in list)
                    Console.WriteLine(item);
            }
        }
    }
}
