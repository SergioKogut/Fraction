using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Разработать класс Fraction, представляющий простую
дробь в классе предусмотреть два поля: числитель
и знаменатель дроби Выполнить перегрузку следующих операторов: +,-,*,/,==,!=,<,>, true и false
Арифметические действия и сравнение выполняется
в соответствии с правилами работы с дробями Оператор true возвращает true если дробь правильная
(числитель меньше знаменателя), оператор false
возвращает true если дробь неправильная (числитель больше знаменателя)
 */
namespace Fraction
{
    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        // найбільший спільний дільник анг. Greatest Common Divisor 
        public static int Gcd(int n, int d)
        {
            return d == 0 ? n : Gcd(d, n % d);
        } 

        public Fraction(int a, int b)
        {
            this.Numerator = a;
            this.Denominator = b;
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction((f1.Numerator * f2.Denominator + f1.Denominator * f2.Numerator) / Gcd(f1.Numerator * f2.Denominator + f1.Denominator * f2.Numerator, f1.Denominator * f2.Denominator),
                                 f1.Denominator * f2.Denominator / Gcd(f1.Numerator * f2.Denominator + f1.Denominator * f2.Numerator, f1.Denominator * f2.Denominator));

        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
        }

        public static Fraction operator *(Fraction f1, int a)
        {
            return new Fraction(a*f1.Numerator , f1.Denominator);
        }

        public static Fraction operator *(int a,Fraction f1 )
        {
            return new Fraction(a * f1.Numerator, f1.Denominator);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            Fraction temp = new Fraction(f2.Denominator, f2.Numerator);
            return f1 * temp;
        }


        public static implicit operator Fraction(double d)
        {
            string str = d.ToString();
            if (str.Contains(','))
            {
                String[] parts = str.Split(',');
                int whole = int.Parse(parts[0]);
                int numerator = int.Parse(parts[1]);
                int denominator = (int)Math.Pow(10, parts[1].Length);
                int den = denominator / Gcd(numerator, denominator);
                int num = numerator/ Gcd(numerator, denominator);

                return new Fraction(whole * den + num, den);
            }
            else
            {
                return new Fraction(1, 1);
            }
        }

        public static bool operator true(Fraction f1)
        {
            return f1.Numerator < f1.Denominator ? true :false;
        }
        public static bool operator false(Fraction f1)
        {
            return f1.Numerator > f1.Denominator ? true : false;
        }


        public override bool Equals(object obj)
        {
            //якщо  obj == null,  то він не дорівнює обєкту 
            if (obj == null) return false;
            Fraction p = obj as Fraction;
            //якщо переданий обєкт не є Fraction 
            if (p == null) return false;
            // тоді перевіряємо значення числвника і знаменника
            return ((Numerator == p.Numerator) && (Denominator == p.Denominator));
        }


        public override int GetHashCode()
        {
            return this.ToString().GetHashCode(); 
        }
        
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            //перевірка чи змінн ссилаються на одну і ту саму адресу
            //порівняння приведе до безкінечної рекурсії
            if (ReferenceEquals(f1, f2)) return true;
            //приведення до object необхідне,порівняння p1 == null приведе до безкінечної рекурсії
            if ((object)f1 == null) return false;
            return f1.Equals(f2);
        }

        
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return (!(f1 == f2));
        }

        public static bool operator >(Fraction f1, Fraction f2)
        {
            return (f1.Numerator * f2.Denominator) > (f2.Numerator * f1.Denominator);

        }

        public static bool operator <(Fraction f1, Fraction f2)
        {
            return (f1.Numerator * f2.Denominator) < (f2.Numerator * f1.Denominator);

        }
        
        public override string ToString()
        {
            if (this.Numerator!=this.Denominator)
            {
                return $"{Numerator}/{Denominator}";
            }
            else
            {
                return $"{Numerator/Denominator}";
            }
            
        }

        
    }




    class Program
    {
        static void Main(string[] args)
        {
            //створюємо дроби
            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(1, 3);
            Fraction c = new Fraction(1, 2);

            //основні операції : 

            Console.WriteLine($"{a} + {b} = {a + b}");
            Console.WriteLine($"{a} - {b} = {a - b}");
            Console.WriteLine($"{a} * {b} = {a * b}");
            Console.WriteLine($"{a} / {b} = {a / b}");

            //операції порівняння: 

            Console.WriteLine($"{a} > {b} : {a > b}");
            Console.WriteLine($"{a} < {b} : {a < b}");
            Console.WriteLine($"{a} = {c} : {a == c}");
            Console.WriteLine($"{a} != {b} : {a != b}");

            Fraction f = new Fraction(3, 4);
            int a1 = 10;
            Fraction f1 = f * a1;
            Fraction f2 = a1 * f;
            double d = 0.8;
            f2 = d;
            Console.WriteLine($"{d} = {f2} ");
            Fraction f3 = f + d;

        }
    }
}
