using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encryption_Caesar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сдвиг на : ");
            int k = Int32.Parse(Console.ReadLine()) % 32;
            Console.WriteLine(k);
            Console.WriteLine("\n1-Шифрование\n2-Дешифрование");
            ushort caseSwitch = ushort.Parse(Console.ReadLine());
            while ((caseSwitch != 1) && (caseSwitch != 2))
            {
                ushort.TryParse(Console.ReadLine(), out caseSwitch);
                if ((caseSwitch != 1) && (caseSwitch != 2))
                    Console.WriteLine("Ошибка ввода, повторите попытку");
            }
            Console.WriteLine("\nВведите слово: ");
            string word = Cipher(Console.ReadLine(), k, caseSwitch); //Проблема с честными людьми в том, что они ждут честности от всех остальных  
                                                                     //Ювцчу кшявхшю евхшдлшббв бшыбуюва е кша-яьфв, вб вфокбв бш гвчкшдюьхушё ехвш гвябвш бшыбубьш.    

            Console.WriteLine("\nСлово: " + word);
            Console.ReadLine();
        }
        //1072 1103  рус мал //1040 1071 рус больш // 97 122 small //65 90 large
        private static string Cipher(string s, int k, ushort caseSwitch)
        {
            StringBuilder word = new StringBuilder();
            int buf = 0;
            for (int i = 0; i < s.Length; i++)
            {
                buf = 0;
                if ((s[i]) >= 1040 && (s[i]) <= 1103)
                {
                    if (caseSwitch == 1)
                    {
                        if (s[i] + k > 1103)
                        {
                            buf = s[i] + k;
                            buf = buf % 1103;
                            word.Append((char)(1039 + buf));
                        }
                        else { word.Append((char)(s[i] + k)); }
                    }
                    else
                    {
                        if (s[i] - k < 1040)
                        {
                            buf = s[i] - k;
                            buf = buf % 1040;
                            word.Append((char)(1102 - buf));
                        }
                        else { word.Append((char)(s[i] - k)); }
                    }
                }
                else
                {
                    word.Append(s[i]);
                }
            }
            return word.ToString();
        }
    }
}


