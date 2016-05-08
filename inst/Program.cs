using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inst
{
    class Singleton
    {
        private static Singleton Instance;
        private Singleton() { }
        public Singleton getInstance;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s;
            //s.getInstance;

        }
    }
}
