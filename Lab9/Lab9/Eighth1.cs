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
            Random rand = new Random();
            Console.Write("Write length of matrices: ");
            int l = int.Parse(Console.ReadLine());
            int[,] firstMatrix = new int[l, l];
            int[,] secondMatrix = new int[l, l];
            for (int i = 0; i < l * 2; i++)
            {
                firstMatrix[rand.Next(0, l - 1), rand.Next(0, l - 1)] = rand.Next(0, 10);
                secondMatrix[rand.Next(0, l - 1), rand.Next(0, l - 1)] = rand.Next(0, 10);
            }
            Console.WriteLine("The first matrix: ");
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                    Console.Write(firstMatrix[i,j] + "  ");
                Console.WriteLine("\n");
            }
            Console.WriteLine("\nThe second matrix: ");
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                    Console.Write(secondMatrix[i, j] + "  ");
                Console.WriteLine("\n");
            }
        }
    }
}