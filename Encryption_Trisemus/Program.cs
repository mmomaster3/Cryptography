using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption_Trisemus
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] mas = new char[4, 8];
            Console.WriteLine("Введите ключевое слово :");
            string key = Uniq(Console.ReadLine()).ToLower();
            int c = 0;
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (c < key.Length)
                    {
                        mas[i, j] = key[c];
                        c++;
                    }
                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("1-Зашифровка\n2-Расшифровка ");
            short caseSwitch = Int16.Parse(Console.ReadLine());
            if (caseSwitch == 1) Console.WriteLine("\nВведите шифуемое слово: "); else Console.WriteLine("\nВведите расшифруемое слово: ");
            string word = Cipher(Console.ReadLine(), ref mas, caseSwitch);

            if (caseSwitch == 1) Console.WriteLine("\nЗащифрованное слово: "); else Console.WriteLine("\nРасшифрованное слово: ");
            Console.WriteLine(word);
            Console.ReadKey();
        }

        private static string Uniq(string s)
        {
            string abc = @"абвгдежзийклмнопрстуфхцчшщъыьэюя";
            List<char> used = new List<char>();
            StringBuilder uniq = new StringBuilder();
            foreach (char i in s)
            {
                if (used.IndexOf(i) == -1)
                {
                    used.Add(i);
                    uniq.Append(i);
                }
            }
            foreach (char i in abc)
            {
                if (used.IndexOf(i) == -1)
                {
                    used.Add(i);
                    uniq.Append(i);
                }
            }
            return uniq.ToString();
        }

        private static string Cipher(string word, ref char[,] mas, short caseSwitch)
        {
            string cipher = "";
            for (int f = 0; f < word.Length; f++)
            {
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        if (mas[i, j] == word[f])
                        {
                            if (caseSwitch == 1)
                            {
                                if (i == mas.GetLength(0) - 1) { cipher += mas[0, j]; } else { cipher += mas[i + 1, j]; }
                            }
                            else
                            {
                                if (i == 0) { cipher += mas[mas.GetLength(0) - 1, j]; } else { cipher += mas[i - 1, j]; }
                            }
                        }
                    }
                }
            }
            return cipher.ToString();
        }
    }
}
