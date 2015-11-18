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
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Random r = new Random();


            for (int i = 0;  i< 10 ; i++)
            {
                Console.Write((char) (r.Next() % 255) + " ");
            }
            Console.ReadLine();
        }
    }
}
