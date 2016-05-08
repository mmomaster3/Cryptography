using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zalipalovo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WindowHeight = Console.LargestWindowHeight;
            //Console.WindowWidth = Console.LargestWindowWidth;
            //Random r = new Random();


            //for (int i = 0;  i< 10 ; i++)
            //{
            //    Console.Write((char) (r.Next() % 255) + " ");
            //}
            for (int i = 2; i < 10 / 2 + 1; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(new string('_', 20));

            for (int i = 2; i <= 10 / 2; i++)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
