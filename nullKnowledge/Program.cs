﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace nullKnowledge
{
    public class Primality
    {
        public enum NumberType
        {
            Composite,
            Prime
        }

        public bool IsPrimeMillerRabin(BigInteger integer)
        {
            NumberType type = MillerRabin(integer, 400);
            return type == NumberType.Prime;
        }

        public bool IsPrimePseudo(BigInteger integer)
        {
            NumberType type = PseudoPrime(integer);
            return type == NumberType.Prime;
        }

        public NumberType MillerRabin(BigInteger n, int s)
        {
            BigInteger nMinusOne = BigInteger.Subtract(n, 1);

            for (int j = 1; j <= s; j++)
            {
                BigInteger a = Random(1, nMinusOne);

                if (Witness(a, n))
                {
                    return NumberType.Composite;
                }
            }

            return NumberType.Prime;
        }

        public BigInteger Random(BigInteger min, BigInteger max)
        {
            byte[] maxBytes = max.ToByteArray();
            BitArray maxBits = new BitArray(maxBytes);
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < maxBits.Length; i++)
            {
                int randomInt = random.Next();
                if ((randomInt % 2) == 0)
                {
                    maxBits[i] = !maxBits[i];
                }
            }

            BigInteger result = new BigInteger();

            // Convert the bits back to a BigInteger
            for (int k = (maxBits.Count - 1); k >= 0; k--)
            {
                BigInteger bitValue = 0;

                if (maxBits[k])
                {
                    bitValue = BigInteger.Pow(2, k);
                }

                result = BigInteger.Add(result, bitValue);
            }

            // Generate the random number
            BigInteger randomBigInt = BigInteger.ModPow(result, 1, BigInteger.Add(max, min));
            return randomBigInt;
        }

        public NumberType PseudoPrime(BigInteger n)
        {
            BigInteger modularExponentiation =
                            ModularExponentiation(2,
                                                  BigInteger.Subtract(n, 1),
                                                  n);
            if (!modularExponentiation.IsOne)
            {
                return NumberType.Composite;
            }
            else
            {
                return NumberType.Prime;
            }
        }

        public bool Witness(BigInteger a, BigInteger n)
        {
            KeyValuePair<int, BigInteger> tAndU = GetTAndU(BigInteger.Subtract(n, 1));
            int t = tAndU.Key;
            BigInteger u = tAndU.Value;
            BigInteger[] x = new BigInteger[t + 1];

            x[0] = ModularExponentiation(a, u, n);

            for (int i = 1; i <= t; i++)
            {
                // x[i] = x[i-1]^2 mod n
                x[i] = BigInteger.ModPow(BigInteger.Multiply(x[i - 1], x[i - 1]), 1, n);
                BigInteger minus = BigInteger.Subtract(x[i - 1], BigInteger.Subtract(n, 1));

                if (x[i] == 1 && x[i - 1] != 1 && !minus.IsZero)
                {
                    return true;
                }
            }

            if (!x[t].IsOne)
            {
                return true;
            }

            return false;
        }

        public KeyValuePair<int, BigInteger> GetTAndU(BigInteger nMinusOne)
        {
            byte[] nBytes = nMinusOne.ToByteArray();
            BitArray bits = new BitArray(nBytes);
            int t = 0;
            BigInteger u = new BigInteger();

            int n = bits.Count - 1;
            bool lastBit = bits[n];

            while (!lastBit)
            {
                t++;
                n--;
                lastBit = bits[n];
            }

            for (int k = ((bits.Count - 1) - t); k >= 0; k--)
            {
                BigInteger bitValue = 0;

                if (bits[k])
                {
                    bitValue = BigInteger.Pow(2, k);
                }

                u = BigInteger.Add(u, bitValue);
            }

            KeyValuePair<int, BigInteger> tAndU = new KeyValuePair<int, BigInteger>(t, u);
            return tAndU;
        }

        public BigInteger ModularExponentiation(BigInteger a, BigInteger b, BigInteger n)
        {
            return BigInteger.ModPow(a, b, n);
        }
    }

    class Program
    {


        //BigInteger RngBigNumb()
        //{
        //    Random random = new Random();
        //    byte[] input = new byte[1024 / 8];
        //    random.NextBytes(input);
        //    BigInteger a = new BigInteger(input);
        //    a = BigInteger.Abs(a);
        //    return a;
        //}



        static Random random = new Random(DateTime.Now.Millisecond);

        static void Main(string[] args)
        {

            BigInteger n = GenerateLargePrime(150);
            BigInteger s = GenerateLarge(140);
            BigInteger t = BigInteger.ModPow(s, 2, n);
            BigInteger v = modInverse(t, n);

            if (BigInteger.ModPow(BigInteger.Multiply(v, t), 1, n) == 1)
            {
                Console.WriteLine("inverse");
            }
            else
            {
                Console.WriteLine("not inverse");
            }


            Random rnd = new Random();

            byte bit = (byte)rnd.Next(2);

            BigInteger c;
            BigInteger R = GenerateLarge(140);
            BigInteger Y = R;
            BigInteger c1 = BigInteger.ModPow(BigInteger.Multiply(R, R), 1, n);


            if (bit != 0)
            {
                Y = BigInteger.ModPow(R * s, 1, n);
            }

            if (bit == 0)
            {
                c = BigInteger.ModPow(R, 2, n);
            }
            else
            {
                c = BigInteger.ModPow(BigInteger.Pow(Y, 2) * v, 1, n);
            }

            if (c == c1)
            {
                Console.WriteLine("Good");
            }
            else
            {
                Console.WriteLine("Fail");
            }


            Console.ReadLine();
        }

        public static BigInteger modInverse(BigInteger a, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;

            return v;
        }

        static BigInteger GenerateLargePrime(int length)
        {
            Primality primality = new Primality();
            string numbers = "";

            for (int i = 0; i < length; i++)
            {
                numbers += random.Next(0, 10);
            }

            BigInteger number = BigInteger.Parse(numbers);

            if (primality.IsPrimeMillerRabin(number))
            {
                return number;
            }
            else
            {
                return GenerateLargePrime(length);
            }
        }

        static BigInteger GenerateLarge(int length)
        {
            Primality primality = new Primality();
            string numbers = "";

            for (int i = 0; i < length; i++)
            {
                numbers += random.Next(0, 10);
            }

            BigInteger number = BigInteger.Parse(numbers);

            return number;
        }
    }
}