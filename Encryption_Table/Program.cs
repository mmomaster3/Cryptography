using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Table
{
    class Program
    {
        static string str = @"АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя";

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер таблицы N x M ");
            int n = Int32.Parse(Console.ReadLine());
            int m = Int32.Parse(Console.ReadLine());
            char[,] a = new char[n, m];// сообщение
            char[] k = new char[m]; //key
            int[] abc = new int[m];// алфовит
            Console.WriteLine("Введите ключ размером " + m);
            string key = Console.ReadLine().ToUpper().Replace(" ", "");  //"ОСЕНЬ" //Console.ReadLine().ToUpper().Replace(" ", "")
            Console.WriteLine("Введите сообщение размером " + n * m);
            string msg = Console.ReadLine().ToUpper().Replace(" ", "");//"чем_меньше_люди_знают,_тем_меньше_сомневаются"; //"АМЧЕМЮЕЕ_НТНМЛЕ,Ь_ЮВ_ШМДАТЕЕИЮЕ_Н_ТМСЬЗС_ОШНЯ"  //чем_меньше_люди_знают,_тем_меньше_сомневаются  //Console.ReadLine().ToUpper().Replace(" ", "")
            string estr = null;
            string disstr = null;

            Console.WriteLine("1-Расшифровка\n2-Зашифровка");
            int caseSwitch = Int32.Parse(Console.ReadLine());
            Encryption(n, m, key, msg, a, k, abc, out estr, out disstr, caseSwitch);
            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("\nРасшифрованый ключ: " + disstr);
                    break;
                case 2:
                    Console.WriteLine("\nЗашифрованый ключ: " + estr);
                    break;
            }
            Console.ReadLine();
        }
        static void Encryption(int n, int m, string key, string msg, char[,] a, char[] k, int[] abc, out string estr, out string disstr, int caseSwitch)
        {
            //исходный ключ
            Console.WriteLine("\n-----------------key-------------");
            for (int i = 0; i < m; i++)
            {
                Console.Write(key[i] + "\t");
                k[i] = key[i];
            }
            Console.WriteLine();

            for (int i = 0; i < m; i++)
            {

                abc[i] = str.IndexOf(key[i]) / 2;
                Console.Write(abc[i] + "\t");
            }

            //исходное сообщение
            Console.WriteLine("\n\n--------------message-------------");
            int c = 0;
            char buf2;
            if (caseSwitch == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        a[i, j] = msg[c];
                        c++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a[j, i] = msg[c];
                        c++;
                    }
                }
            }

            //вывод сообщения
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine(" ");
            }

            Console.WriteLine("\n---------------ecording--key---------");
            int buf = 0;
            //шифровка
            bool swapped = false;
            do
            {
                swapped = false;

                for (int i = 0; i < m - 1; i++)
                {
                    if (abc[i] > abc[i + 1])
                    {
                        swapped = true;

                        buf = abc[i];
                        abc[i] = abc[i + 1];
                        abc[i + 1] = buf;

                        buf2 = k[i];
                        k[i] = k[i + 1];
                        k[i + 1] = buf2;

                        for (int j = 0; j < n; j++)
                        {
                            buf2 = a[j, i];
                            a[j, i] = a[j, i + 1];
                            a[j, i + 1] = buf2;
                        }
                    }
                }
            } while (swapped == true);

            //вывод сортированого ключа
            for (int w = 0; w < m; w++)
            {
                Console.Write(k[w] + "\t");
            }

            //вывод сортированого номера алфавита
            Console.WriteLine();
            for (int w = 0; w < m; w++)
            {
                //      abc[w] = w;
                Console.Write(abc[w] + "\t");
            }
            Console.WriteLine();

            //вывод массива сообщения сортированого
            Console.WriteLine("\n----------ecorging--message-----------");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine(" ");
            }

            estr = null;
            disstr = null;

            //вывод строки шифровки
            Console.WriteLine("\n----------ecorging--string-----------");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    estr += a[i, j];
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    disstr += a[j, i];
                }
            }
        }
    }
}
