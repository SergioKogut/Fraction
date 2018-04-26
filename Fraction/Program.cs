using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Fraction
    {
        public int a { get; set; }
        public int b { get; set; }

        public Fraction(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public override string ToString()
        {
            return $"{a}/{b}";
        }

        
    }




    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(3, 5);

            Console.WriteLine(a);


        }
    }
}
