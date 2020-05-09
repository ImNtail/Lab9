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
            int x = 0, y = 0, z = 0, n = 10, limit = (int)Math.Pow(n, 1.0 / 3.0);
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 1; i <= n; i++)
            {
                numbers[i] = 0;
                for (x = 0; x <= n; x++)
                    for (y = 0; y <= n; y++)
                        for (z = 0; z <= n; z++)
                            if (Math.Pow(x, 3) + Math.Pow(y, 3) + Math.Pow(z, 3) == i)
                                numbers[i]++;
            }
            foreach (var number in numbers)
                if (number.Value > 2)
                    Console.WriteLine(number.Key);
        }
    }
}
