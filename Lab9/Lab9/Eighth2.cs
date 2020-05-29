using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Eighth2
    {
        /*
        Написать код для обработки разреженных матриц (состоящих, в основном,
        из нулей) в двух проектах. Для представления матриц использовать в одном
        проекте двумерный массив, в другом – связные списки. Реализовать
        функции: заполнения и вывода матрицы, транспонирования матрицы,
        суммирования и перемножения матриц.
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
            public bool Remove(T data)
            {
                Node<T> current = head;
                Node<T> previous = null;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        if (previous != null)
                        {
                            previous.Next = current.Next;
                            if (current.Next == null)
                                tail = previous;
                        }
                        else
                        {
                            head = head.Next;
                            if (head == null)
                                tail = null;
                        }
                        count--;
                        return true;
                    }
                    previous = current;
                    current = current.Next;
                }
                return false;
            }
            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }
            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }
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
            public void Change(int index, T value)
            {
                Node<T> current = head;
                while (current != null)
                {
                    if (index == 0)
                        break;
                    index--;
                    current = current.Next;
                }
                current.Data = value;
            }
            public void Swap(T first, T second)
            {
                Node<T> currentF = head;
                while (currentF != null)
                {
                    if (currentF.Data.Equals(first))
                    {
                        currentF.Data = second;
                        break;
                    }
                    currentF = currentF.Next;
                }
                Node<T> currentS = head;
                while (currentS != null)
                {
                    if (currentS.Data.Equals(second))
                    {
                        currentS.Data = first;
                        break;
                    }
                    currentS = currentS.Next;
                }
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
            //==============Creating==============
            Console.Write("\nWrite length of matrices: ");
            int l = int.Parse(Console.ReadLine());
            var firstMatrix = new LinkedList<int>();
            var secondMatrix = new LinkedList<int>();
            for (int i = 0; i < l*l; i++)
            {
                firstMatrix.Add(0);
                secondMatrix.Add(0);
            }

            int select = 0, choise = 0;
            while (select != 6)
            {
                Console.Write("\nChoose the action to do:\n1 - Matrix filling\n2 - Matrix output\n3 - Matrix transpose\n4 - Matrix summaiton\n5 - Matrix miltiplication\n6 - Exit   =>   ");
                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        while (choise < 1 || choise > 2)
                        {
                            Console.Write("\nChoose the matrix to fill: ");
                            choise = int.Parse(Console.ReadLine());
                        }
                        if (choise == 1) firstMatrix = Fill(firstMatrix);
                        else if (choise == 2) secondMatrix = Fill(secondMatrix);
                        choise = 0;
                        break;
                    case 2:
                        while (choise < 1 || choise > 2)
                        {
                            Console.Write("\nChoose the matrix to output: ");
                            choise = int.Parse(Console.ReadLine());
                        }
                        if (choise == 1) Output(firstMatrix);
                        else if (choise == 2) Output(secondMatrix);
                        choise = 0;
                        break;
                    case 3:
                        while (choise < 1 || choise > 2)
                        {
                            Console.Write("\nChoose the matrix to transpose: ");
                            choise = int.Parse(Console.ReadLine());
                        }
                        if (choise == 1) firstMatrix = Transpose(firstMatrix);
                        else if (choise == 2) secondMatrix = Transpose(secondMatrix);
                        choise = 0;
                        break;
                    case 4:
                        Summation(firstMatrix, secondMatrix);
                        break;
                    //case 5:
                    //    Multiplication(firstMatrix, secondMatrix);
                    //    break;
                    case 6:
                        break;
                }
            }
        }
        static LinkedList<int> Fill(LinkedList<int> matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < matrix.Count * 0.4; i++)
            {
                int value = rand.Next(0, 10), index = rand.Next(0, matrix.Count - 1);
                matrix.Change(index, value);
            }
            return matrix;
        }
        static void Output(LinkedList<int> matrix)
        {
            int limit = 0;
            Console.WriteLine();
            foreach (var item in matrix)
            {
                Console.Write("{0, -3}", item);
                limit++;
                if (limit == (int)Math.Sqrt(matrix.Count))
                {
                    Console.WriteLine("\n");
                    limit = 0;
                }
            }
        }
        static LinkedList<int> Transpose(LinkedList<int> matrix)
        {
            for (int i = 0; i < (matrix.Count - (int)(Math.Sqrt(matrix.Count))) / 2; i++)
            {
                int firstIndex = 1, secondIndex = firstIndex + (int)(Math.Sqrt(matrix.Count)) - 1, cnt = 3;
                matrix.Swap(firstIndex, secondIndex);
                if (firstIndex % (int)(Math.Sqrt(matrix.Count)) == (int)(Math.Sqrt(matrix.Count)) - 1)
                {
                    firstIndex += cnt;
                    secondIndex = firstIndex + (int)(Math.Sqrt(matrix.Count)) - 1;
                    cnt++;
                }
                else
                {
                    firstIndex++;
                    secondIndex += 5;
                }
            }
            return matrix;
        }
        static void Summation(LinkedList<int> firstM, LinkedList<int> secondM)
        {
            var sum = firstM.Zip(secondM, (first, second) => first + second);
            int limit = 0;
            Console.WriteLine();
            foreach (var item in sum)
            {
                Console.Write("{0, -3}", item);
                limit++;
                if (limit == (int)Math.Sqrt(sum.Count()))
                {
                    Console.WriteLine("\n");
                    limit = 0;
                }
            }
        }
        static void Multiplication(LinkedList<int> firstM, LinkedList<int> secondM)
        {

        }
    }
}
