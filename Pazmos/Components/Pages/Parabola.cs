using Pazmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazmos
{
    public class Parabola
    {
        private double a;
        private double b;
        private double c;

        public static void ParabolaUT()
        {
            Parabola par1 = new Parabola(1, -2, 4);
            Parabola par2 = new Parabola(3, 5);
            Parabola par3 = new Parabola(1, -2, -6);
            Parabola par4 = new Parabola(-1, 0, 4);
            //Parabola par5 = new Parabola(0, 1, 4);
            //Parabola par6 = new Parabola(0, 0, 2);
            //Parabola par7 = new Parabola(0, 0, 0);
            Console.WriteLine(par1);
            Console.WriteLine(par2);
            Console.WriteLine(par3);
            Console.WriteLine(par4);
            //Console.WriteLine(par5);
            //Console.WriteLine(par6);
            //Console.WriteLine(par7);
            //Console.WriteLine(par1.YIntercept());
            //Console.WriteLine(par2.YIntercept());
            //Console.WriteLine(par3.YIntercept());
            //Console.WriteLine(par1.XIntercept()[0]);
            //Console.WriteLine(par1.XIntercept()[1]);
            //Console.WriteLine(par2.XIntercept()[0]);
            //Console.WriteLine(par2.XIntercept()[1]);
            //Console.WriteLine(par3.XIntercept()[0]);
            //Console.WriteLine(par3.XIntercept()[1]);
            //Console.WriteLine(par4.XIntercept()[0]);
            //Console.WriteLine(par4.XIntercept()[1]);
            //Console.WriteLine(par1.GetY(1));
            //Console.WriteLine(par2.GetY(0));
            //Console.WriteLine(par3.GetY(2));
            //Console.WriteLine(par4.GetY(-1));
            //Console.WriteLine(par1.IsOnParabola(new Point(1, 4)));
            //Console.WriteLine(par2.IsOnParabola(new Point(2, 6)));
            //Console.WriteLine(par3.IsOnParabola(new Point(3, 0)));
            //Console.WriteLine(par4.IsOnParabola(new Point(-3, -5)));
            //Console.WriteLine(par1.Extreme());
            //Console.WriteLine(par2.Extreme());
            //Console.WriteLine(par3.Extreme());
            //Console.WriteLine(par4.Extreme());
            //Console.WriteLine(par1.Tangent(4));
            //Console.WriteLine(par2.Tangent(6));
            Console.WriteLine(par1.InterceptLine(new Line(2, 4))[0]); //FAILED
            Console.WriteLine(par1.InterceptLine(new Line(2, 4))[1]); //FAILED
            //Console.WriteLine(par2.InterceptLine(new Line(2, 4))[0]);
            //Console.WriteLine(par2.InterceptLine(new Line(2, 4))[1]);
            //Console.WriteLine(par3.InterceptLine(new Line(2, 4))[0]);
            //Console.WriteLine(par3.InterceptLine(new Line(2, 4))[1]);
            //Console.WriteLine(par4.InterceptLine(new Line(2, 4))[0]);
            //Console.WriteLine(par4.InterceptLine(new Line(2, 4))[1]);
        }

        public Parabola(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Parabola(double p, double k)
        {
            this.a = 1;
            this.b = -2 * p;
            this.c = Math.Pow(p, 2) + k;
        }

        public double GetA()
        {
            return this.a;
        }

        public double GetB()
        {
            return this.b;
        }

        public double GetC()
        {
            return this.c;
        }

        public void SetA(double a)
        {
            this.a = a;
        }

        public void SetB(double b)
        {
            this.b = b;
        }

        public void SetC(double c)
        {
            this.c = c;
        }

        public Point YIntercept()
        {
            return new Point(0, this.GetC());
        }

        public Point[] XIntercept()
        {
            Point[] intercepts = { null, null };
            double a = this.GetA(), b = this.GetB(), c = this.GetC();
            double num = Math.Pow(b, 2) - 4 * a * c;
            double x1, x2;
            if (num >= 0)
            {
                x1 = -b + Math.Sqrt(num) / 2 * a;
                intercepts[0] = new Point(x1, 0);
                if (num != 0)
                {
                    x2 = -b - Math.Sqrt(num) / 2 * a;
                    intercepts[1] = new Point(x2, 0);
                }
            }
            return intercepts;
        }

        public double GetY(double x)
        {
            double a = this.GetA(), b = this.GetB(), c = this.GetC();
            double y = a * Math.Pow(x, 2) + b * x + c;
            return y;
        }

        public bool IsOnParabola(Point p)
        {
            bool check = this.GetY(p.GetX()) == p.GetY();
            return check;
        }

        public Point Extreme()
        {
            double a = this.GetA(), b = this.GetB(), c = this.GetC();
            Line derivative = new Line(2 * a, b);
            Point xAxisOnly = derivative.XIntercept();
            double x = xAxisOnly.GetX();
            double y = this.GetY(x);
            Point extremePoint = new Point(x, y);
            return extremePoint;
        }

        public Line Tangent(double x)
        {
            double derivativeA = 2 * this.GetA() * x;
            Point derivativeP = new Point(x, this.GetY(x));
            Line tangent = new Line(derivativeA, derivativeP);
            return tangent;
        }

        public Point[] InterceptLine(Line line)
        {
            Point[] intercepts = { null, null };
            Parabola xAxises = new Parabola(this.GetA(), this.GetB() - line.GetA(), this.GetC() - line.GetB()); //CHECK
            double x1, x2, y1, y2;
            double num = Math.Pow(xAxises.GetB(), 2) - 4 * xAxises.GetA() * xAxises.GetC();
            if (num >= 0)
            {
                x1 = xAxises.XIntercept()[0].GetX(); //CHECK
                y1 = this.GetY(x1);
                intercepts[0] = new Point(x1, y1);
                if (num != 0)
                {
                    x2 = xAxises.XIntercept()[1].GetX(); //CHECK
                    y2 = this.GetY(x2);
                    intercepts[1] = new Point(x2, y2);
                }
            }
            return intercepts;
        }

        public override string ToString()
        {
            double a = this.GetA();
            double b = this.GetB();
            double c = this.GetC();
            string aStr = a == 0 ? "" : a == 1 ? "x^2" : a == -1 ? "-x^2" : $"{a}x^2";
            string bStr = b == 0 ? "" : b == 1 ? "x" : b == -1 ? "-x" : $"{b}x";
            string cStr = $"{c}";
            string abPlus = b > 0 ? a == 0 ? "" : "+" : "";
            string bcPlus = c > 0 ? b == 0 && a == 0 ? "" : "+" : "";
            string finalStr = $"f(x) = {aStr}{abPlus}{bStr}{bcPlus}{cStr}";
            return finalStr;
        }

        public Point[] GetPoints()
        {
            Point[] points = new Point[8000];
            double x = 0, y = 0;
            for (int i = 0; i < 8000; i++)
            {
                points[i] = new Point();
            }
            for (int i = -4000; i < 4000; i++)
            {
                x = (double)i / 400;
                points[i + 4000].SetX(x);
                y = this.GetY(x);
                points[i + 4000].SetY(y);
            }
            return points;
        }
    }
}