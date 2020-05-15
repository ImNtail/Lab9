using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Eighth1
    {
        /*
        Написать код для обработки разреженных матриц (состоящих, в основном,
        из нулей) в двух проектах. Для представления матриц использовать в одном
        проекте двумерный массив, в другом – связные списки. Реализовать
        функции: заполнения и вывода матрицы, транспонирования матрицы,
        суммирования и перемножения матриц.
        */
        public static void Execute()
        {
            //==============Creating==============
            Console.Write("\nWrite length of matrices: ");
            int l = int.Parse(Console.ReadLine());
            int[,] firstMatrix = new int[l, l];
            int[,] secondMatrix = new int[l, l];

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
                    case 5:
                        Multiplication(firstMatrix, secondMatrix);
                        break;
                    case 6:
                        break;
                }
            }
        }
        static int[,] Fill(int[,] matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < matrix.Length / 2; i++)
                matrix[rand.Next(0, matrix.GetLength(0) - 1), rand.Next(0, matrix.GetLength(1) - 1)] = rand.Next(0, 10);
            return matrix;
        }
        static void Output(int[,] matrix)
        {
            Console.WriteLine("\nOutput:\n");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write("{0, -2} ", matrix[i, j]);
                Console.WriteLine("\n");
            }
        }
        static int[,] Transpose(int[,] matrix)
        {
            int[,] newM = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    newM[i, j] = matrix[j, i];
            }
            return newM;
        }
        static void Summation(int[,] firstM, int[,] secondM)
        {
            Console.WriteLine("\nSummation:\n");
            int[,] newM = new int[firstM.GetLength(0), firstM.GetLength(1)];
            for (int i = 0; i < firstM.GetLength(0); i++)
            {
                for (int j = 0; j < firstM.GetLength(1); j++)
                {
                    newM[i, j] = firstM[i, j] + secondM[i, j];
                    Console.Write("{0, -2} ", newM[i, j]);
                }
                Console.WriteLine("\n");
            }
        }
        static void Multiplication(int[,] firstM, int[,] secondM)
        {
            Console.WriteLine("\nMultiplication:\n");
            int[,] newM = new int[firstM.GetLength(0), firstM.GetLength(1)];
            for (int i = 0; i < firstM.GetLength(0); i++)
            {
                for (int j = 0; j < secondM.GetLength(1); j++)
                {
                    for (int k = 0; k < secondM.GetLength(0); k++)
                    {
                        newM[i, j] += firstM[i, k] * secondM[k, j];
                    }
                    Console.Write("{0, -2} ", newM[i, j]);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
