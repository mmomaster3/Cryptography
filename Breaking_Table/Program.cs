using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Breaking_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"D:/Chifr.txt", System.Text.Encoding.Default);
            string s = "";
            while (false == reader.EndOfStream)
            {
                s = reader.ReadLine();
                Console.WriteLine(s);
                int m = 5;
                int n = 9;
                int c = 0;
                char[,] a = new char[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {

                        a[i, j] = s[c];
                        c++;
                        Console.Write(a[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            while (true)
            {
                ConsoleKey kb = Console.ReadKey().Key;
                if (kb == ConsoleKey.Enter) { Console.WriteLine(new string('!', 160)); break; }
                Console.WriteLine(kb);
            }
        }
    }
}






//int size = s.Length / 2;
//if (size % 2 != 0) { size++; }
//for (int m = 2; m < size; m++)
//{
//    int n = s.Length / m;
//    if (n % 2 != 0) { n++; }
//    if (n * m < s.Length) { Console.WriteLine("Мешьше чем динна строки! " + "n = " + n + "m = " + m); }
//    char[,] a = new char[n, m];
//    for(int i = 0; i< n;i++)
//    {
//        for(int j = 0; j< m;j++)
//        {
//            for (int f = 0; f < s.Length; f++)
//            {
//                a[i, j] = s[f];
//                Console.Write(a[i,j] + "\t");
//            }
//        }
//        Console.WriteLine();
//    }
//    Console.ReadLine();
//    Console.Clear();
//}