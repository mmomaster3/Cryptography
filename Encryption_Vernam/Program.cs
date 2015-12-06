using System;
using System.IO;

namespace Encryption_Vernam
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] image = File.ReadAllBytes("Image.jpg");

            int choose = 0;

            Console.WriteLine("1-Шифровка\n2-Дешифровка");
            int.TryParse(Console.ReadLine(), out choose);
            Console.WriteLine();

            using (FileStream sb = new FileStream("Pass.txt", FileMode.OpenOrCreate))
            {
                switch (choose)
                {
                    case 1:
                        {
                            StreamWriter sw = new StreamWriter(sb);
                            char[] pass = RandKey(image);
                            sw.Write(pass);
                            sw.Close();
                            File.WriteAllBytes("Image.jpg", (Cipher(pass, image)));
                            break;
                        }
                    case 2:
                        {
                            StreamReader sr = new StreamReader(sb);
                            string TextFile = sr.ReadToEnd();
                            sr.Close();
                            File.WriteAllBytes("Image.jpg", (Cipher(TextFile.ToCharArray(), image)));
                            break;
                        }
                    default:
                        {
                            //сделать исключение для другой переменной
                            break;
                        }
                }
            }
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

        public static byte[] Cipher(char[] key, byte[] image)
        {
            for (int i = 0; i < image.Length; i++)
            {
                image[i] = (byte)(image[i] ^ key[i]);
            }
            return image;
        }
    }
}