using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Elgamal
{
    class MyClass
    {
        public int P()
        {
            Random r = new Random();
            for (int p = r.Next(2, 2000); p < 2222; p++)
            {
                if (isPrime(p)) return p;
            }
            return 2;
        }

        public bool isPrime(int x)
        {
            for (int i = 2; i < x / 2 + 1; i++)
                if (x % i == 0) { return false; }
            return true;
        }

        //    int[] s = null;
        //    s[1] = 0;

        //    for (int i = 2; i <= x; i++)
        //    {
        //        s[i] = 1;
        //    }

        //    for (int i = 2; i * i <= x; i++)
        //    {
        //        if (s[i] == 1)
        //        {
        //            for (int l = i * i; l <= x; l += i)
        //            {
        //                s[l] = 0;
        //            }
        //        }
        //    }
        //    return s;
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass myclass = new MyClass();
            int p = myclass.P();
            Random r = new Random();
            int x = r.Next(2, p - 1);
            BigInteger g = GetPRoot(p) ?? 2;
            BigInteger y = BigInteger.ModPow(g, x, p);
            Console.WriteLine("Y = " + y + " G = " + g + " P = " + p + " and X = " + x);
            Console.WriteLine(new string('-', 50));
            string s = crypt(p, g, x, Console.ReadLine());
            Console.WriteLine(s);
            Console.WriteLine("\n" + new string('-', 50));
            decrypt(p, x, s);
            Console.ReadLine();
        }

        public static string crypt(int p, BigInteger g, int x, string strIn)
        {
            string s = null;
            Random r = new Random();
            BigInteger y = BigInteger.ModPow(g, x, p);
            Console.WriteLine("Открытый ключ (p,g,y) = (" + p + "," + g + "," + y + ")");
            Console.WriteLine("Закрытый ключ x = " + x);
            if (String.IsNullOrEmpty(strIn))
            {
                throw new ArgumentNullException();
            }
            char[] temp = new char[strIn.Length - 1];
            temp = strIn.ToCharArray();
            Console.WriteLine();
            for (int i = 0; i < strIn.Length; i++)
            {
                int k = r.Next(2, p - 1); // 1 < k < (p-1)
                int m = temp[i];
                BigInteger a = BigInteger.ModPow(g, k, p);
                BigInteger b = (BigInteger.Pow(y, k) * m) % p;
                s += (a + " " + b + " ");
            }
            return s;
        }

        public static void decrypt(int p, int x, string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
            {
                throw new ArgumentNullException();
            }
            string[] strA = strIn.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < strA.Length; i += 2)
            {
                int a = int.Parse(strA[i]);
                int b = int.Parse(strA[i + 1]);

                char Message = (char)((b * BigInteger.Pow(a, p - 1 - x)) % p);
                Console.Write(Message);
            }


        }

        public static BigInteger? GetPRoot(BigInteger p)
        {
            for (BigInteger i = 2; i < p; i++)
                if (IsPRoot(p, i))
                    return i;
            return null;
        }

        public static bool IsPRoot(BigInteger p, BigInteger a)
        {
            BigInteger last = 1;
            List<BigInteger> set = new List<BigInteger>();
            for (BigInteger i = 0; i < p - 1; i++)
            {
                last = (last * a) % p;
                if (set.Contains(last))
                    return false;
                set.Add(last);
            }
            return true;
        }
    }
}
