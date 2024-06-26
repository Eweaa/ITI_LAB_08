using System.Net.Http.Headers;
using System.Numerics;
using static Lab_8.Program;

namespace Lab_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ComplexNumber c1 = new ComplexNumber(2, 4);
            //ComplexNumber c2 = new ComplexNumber(1, 3);

            ////Console.WriteLine(c1.Equals(c2));

            //Fraction f1 = new(2, 4);
            //Fraction f2 = new(1, 3);
            //Fraction f3 = f1 + f2;

            //Fraction f4 = new(6, 12);
            //Fraction f5 = new(3, 4);


            ////Console.WriteLine(f3);
            ////Console.WriteLine(f4 == f5);

            //Console.WriteLine(f4);
            //f4++;
            //Console.WriteLine(f4);
            //Console.WriteLine(++f5);


            //Console.WriteLine(Fraction.SimplifyFraction(f3));

            Duration d1 = new(61, 40);
            Console.WriteLine(d1);

        }

        #region ComplexNumber
        public class ComplexNumber
        {
            public ComplexNumber(int r = 0, int i = 0)
            {
                Real = r;
                Complex = i;
            }

            int real;
            int complex;

            public int Real
            {
                get => real;
                set { real = value; }
            }

            public int Complex
            {
                get => complex;
                set { complex = value; }
            }
            public override string ToString()
            {
                if (Complex == 0)
                    return $"{Real}";
                else if (Complex >= 0)
                {
                    return $"{Real} + {Complex}J";
                }
                else
                {
                    return $"{Real} - {Complex}J";
                }
            }
            public override bool Equals(object? obj)
            {
                //if (obj == null)
                //    return false;

                ComplexNumber? c = obj as ComplexNumber;

                //if(c == null || obj.GetType() != c.GetType())
                //    return false;


                //if (Real == c.Real && Complex == c.Complex)
                //    return true;

                //return false;



                if (obj is ComplexNumber)
                {
                    if (Real == c.Real && Complex == c.Complex)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }


            #region ComplexNumber Operators Overloading
            public static ComplexNumber operator +(ComplexNumber l, ComplexNumber r)
            {
                ComplexNumber Res = new() { Real = l.Real + r.Real, Complex = l.Complex + r.Complex };
                return Res;
            }

            public static ComplexNumber operator -(ComplexNumber l, ComplexNumber r)
            {
                ComplexNumber Res = new() { Real = l.Real - r.Real, Complex = l.Complex - r.Complex };
                return Res;
            }
            public static ComplexNumber operator *(ComplexNumber l, ComplexNumber r)
            {
                ComplexNumber Res = new() { Real = l.Real + r.Real, Complex = l.Complex + r.Complex };
                return Res;
            }

            public static ComplexNumber operator +(ComplexNumber l, int r)
            {
                ComplexNumber Res = new ComplexNumber() { Real = l.Real + r, Complex = l.Complex };
                return Res;
            }
            public static ComplexNumber operator +(int l, ComplexNumber r)
            {
                ComplexNumber Res = r + l;
                return Res;
            }
            #endregion

        }
        #endregion


        class Duration
        {
            public Duration(int hours, int minutes, int seconds)
            {
                
            }

            public Duration(int minutes, int seconds)
            {

                if(minutes >= 60)
                {
                    Hours = minutes / 60;
                    Minutes = minutes % 60;
                    Seconds = seconds;
                }
                else
                {
                    Minutes = minutes;
                    Seconds = seconds;
                }

                
            }

            public Duration(int seconds)
            {
            }

            public int Hours { get; set; }
            public int Minutes { get; set; }
            public int Seconds { get; set; }

            public override string ToString()
            {
                return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
            }
        }

        #region Fraction

        public class Fraction
        {
            public Fraction(int numerator = 0, int denominator = 0)
            {
                Numerator = numerator;
                Denominator = denominator;
            }

            public int Numerator { get; set; }
            public int Denominator { get; set; }
            public override string ToString()
            {
                return $"{Numerator}/{Denominator}";
            }
            public override bool Equals(object? obj)
            {
                Fraction? f = obj as Fraction;

                //if(c == null || obj.GetType() != c.GetType())
                //    return false;


                //if (Real == c.Real && Complex == c.Complex)
                //    return true;

                //return false;



                if (obj is Fraction)
                {
                    if (Numerator == f.Numerator && Denominator == f.Denominator)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            static public Fraction SimplifyFraction(Fraction f)
            {
                Fraction Res;
                int limit = Math.Min(f.Numerator, f.Denominator);

                for (int i = limit; i > 1; i--)
                {
                    if (f.Numerator % i == 0 && f.Denominator % i == 0)
                    {
                        return Res = new Fraction { Numerator = f.Numerator /= i, Denominator = f.Denominator /= i };
                    }
                }

                return f;
            }
            public static Fraction operator +(Fraction l, Fraction r)
            {
                Fraction Res;
                if (l.Denominator == r.Denominator)
                {
                    Res = new Fraction { Numerator = l.Numerator + r.Numerator, Denominator = l.Denominator };
                    return SimplifyFraction(Res);
                }

                else if (l.Denominator > r.Denominator && l.Denominator % r.Denominator == 0)
                {
                    int n = l.Denominator / r.Denominator;
                    r.Numerator *= n;
                    r.Denominator *= n;
                    Res = new Fraction { Numerator = l.Numerator + r.Numerator, Denominator = l.Denominator };
                    return SimplifyFraction(Res);
                }

                else if (r.Denominator > l.Denominator && r.Denominator % l.Denominator == 0)
                {
                    int n = r.Denominator / l.Denominator;
                    l.Numerator *= n;
                    l.Denominator *= n;
                    Res = new Fraction { Numerator = l.Numerator + r.Numerator, Denominator = l.Denominator };
                    return SimplifyFraction(Res);
                }

                else
                {
                    int newDen = l.Denominator * r.Denominator;

                    int n1 = newDen / l.Denominator;
                    int n2 = newDen / r.Denominator;

                    l.Numerator *= n1;
                    r.Numerator *= n2;

                    l.Denominator = newDen;
                    r.Denominator = newDen;

                    Res = new Fraction { Numerator = l.Numerator + r.Numerator, Denominator = newDen };

                    return SimplifyFraction(Res);

                }
            }

            public static bool operator ==(Fraction l, Fraction r)
            {
                SimplifyFraction(l);
                SimplifyFraction(r);

                return (l.Denominator == r.Denominator && l.Numerator == r.Numerator);
            }

            public static bool operator !=(Fraction l, Fraction r)
            {
                return !(l == r);
            }

            public static Fraction operator ++(Fraction f)
            {

                Fraction Added = new Fraction(f.Denominator, f.Denominator);

                return Added + f;
            }
        } 
        #endregion
    }
}
