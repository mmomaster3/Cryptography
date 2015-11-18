using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Encryption_Vernam
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите сообщение: ");
            //string msg = Console.ReadLine();

            byte[] image = File.ReadAllBytes("sakuya-izayoi-snow.jpg");
            Console.WriteLine(Cipher(RandKey(image), image));
           
            Console.ReadLine();
        }

        public static char[] RandKey(byte[] image)
        {
            char[] key = new char[image.Length];
            Random r = new Random();

            for (int i = 0; i < image.Length; i++)
            {
                key[i] = ((char)(r.Next() % 255));
            }
            return key;
        }

        public static string Cipher(char[] key, byte[] image)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < image.Length; i++)
            {
                sb.Append((char)(image[i] ^ key[i]));
            }
            return sb.ToString();
        }
    }
}