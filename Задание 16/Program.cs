using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static List<string> ls = new List<string>();
        static List<string> ls2 = new List<string>();
        static List<string> ls3 = new List<string>();

        static void Main(string[] args)
        {
            string text = "<!--Создаём строку таблицы--> < tr > < !--Создаём столбец таблицы--> < th > < !--Содержание ячейки столбца--> < h1 > Название сайта (организации) </ h1 > < h3 > Описание сайта </ h3 > " +
                    "< !--Закрываем таблицу-- > </ th > </ tr > </ table > <> Арбуз банан  < h1 > Название сайта (организации) </ h1 >";

            ExtractMethod(text); // Метод извлекает текст между тегами, достает слова, удаляет дубли.

            foreach (var n in ls3)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }

        private static List<string> ExtractMethod(string text)
        {
            Regex regex = new Regex(">(.*?)<");
            MatchCollection matchCollection = regex.Matches(text);
            foreach (Match m in matchCollection) //создаем массив с не пустыми значениями
            {
                if ((m.Value.Remove(0, 1)).Remove(m.Length - 2, 1) == " ")  // > тут пусто <
                {
                    continue;
                }
                else
                {
                    ls.Add((m.Value.Remove(0, 1)).Remove(m.Length - 2, 1)); // > есть что-то <
                }
            }
            foreach (string s in ls) //создадим список слов из извлеченного текста
            {
                string[] str = s.Split();
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != "")
                    {
                        ls2.Add(str[i]);
                    }
                }
            }
            ls3 = ls2.Distinct().ToList(); //удалим из списка дублирующиеся элементы
            return ls3;
        }
    }
}