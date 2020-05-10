using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab9
{
    public class Fifth
    {
        /*
        Дан текстовый файл со словами, разделенными пробелами. Написать
        программу, которая выводит 10 наиболее встречаемых слов в файле,
        отсортированных в порядке убывания частоты встречаемости. При равном
        числе вхождений слова упорядочивать по алфавиту.
        */
        public static void Execute()
        {
            string[] words;
            using (StreamReader text = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fifth.txt")))
                words = text.ReadToEnd().ToLower().Split(new char[] { ' ', ',', '-', '.', ';', ':', '?' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordsDictionary.Keys.Contains<string>(word))
                    wordsDictionary[word]++;
                else
                    wordsDictionary.Add(word, 1);
            }
            int conter = 10;
            foreach (var word in wordsDictionary.OrderBy(key => key.Key).OrderByDescending(key => key.Value))
            {
                if (conter > 0)
                    Console.WriteLine(word);
                conter--;
            }
        }
    }
}
