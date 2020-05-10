using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Fourth
    {
        /*
        Модифицировать код задания 5 из лабораторной работы №2: перебрать все
        числа N от 1 до 50000 и вывести только те числа, для которых существует
        более двух (три и более) комбинаций суммы кубов. Использовать
        ассоциативный массив .NET (Dictionary) для решения задачи.
        */
        public static void Execute()
        {
            int n = 50000, limit = (int)Math.Pow(n, 1.0 / 3.0), count = 0;
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int x = 0; x <= limit; x++)
                for (int y = 0; y <= limit; y++)
                    for (int z = 0; z <= limit; z++)
                        if (Math.Pow(x, 3) + Math.Pow(y, 3) + Math.Pow(z, 3) <= n && Math.Pow(x, 3) + Math.Pow(y, 3) + Math.Pow(z, 3) > 0)
                            numbers.Add(++count, (int)(Math.Pow(x, 3) + Math.Pow(y, 3) + Math.Pow(z, 3)));
            int[] coincidences = new int[n+1];
            foreach (var number in numbers)
                if (number.Value <= n)
                    coincidences[number.Value]++;
            for (int i = 0; i < coincidences.Length; i++)
                if (coincidences[i] > 2)
                    Console.WriteLine(i);
        }
    }
}
