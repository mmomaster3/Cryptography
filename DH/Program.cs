using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace DH
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            BigInteger a = r.Next();
            BigInteger b = r.Next();

            BigInteger p = P();
            BigInteger g = GetPRoot(P()) ?? 2;

            BigInteger A = BigInteger.ModPow(g, a, p);
            BigInteger B = BigInteger.ModPow(g, b, p);

            BigInteger Alice = BigInteger.ModPow(B, a, p);
            BigInteger Bob = BigInteger.ModPow(A, b, p);

            Console.WriteLine($"Alice = {Alice} & Bob = {Bob}");

            Console.ReadLine();
        }

        public static int P()
        {
            Random r = new Random();
            for (int p = r.Next(2, 9999); p < 10000 + 1; p++)
            {
                if (isPrime(p)) return p;
            }
            return 2;
        }

        public static bool isPrime(int x)
        {
            for (int i = 2; i < x / 2 + 1; i++)
                if (x % i == 0) { return false; }
            return true;
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
