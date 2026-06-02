using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazmos
{
    public class Line
    {
        private double a;
        private double b;

        public static void LineUT()
        {
            //Line line1 = new Line(2, 6);
            //Line line2 = new Line();
            //Line line3 = new Line(1.5, new Point(3, 4));
            //Line line4 = new Line(2, -2);
            //Line line5 = new Line(-3, 4);
            //Console.WriteLine(line1);
            //Console.WriteLine(line2);
            //Console.WriteLine(line3);
            //Console.WriteLine(line1.YIntercept());
            //Console.WriteLine(line3.XIntercept());
            //Console.WriteLine(line2.GetY(4));
            //Console.WriteLine(line1.IsOnLine(new Point()));
            //Console.WriteLine(line2.IsOnLine(new Point(12, 12)));
            //Console.WriteLine(line1.LineStatus(line4));
            //Console.WriteLine(line2.LineStatus(line3));
            //Console.WriteLine(line3.LineIntercept(line4));
            //Console.WriteLine(line1.Perpendicular(new Point(-1, 1)));
            //Console.WriteLine(line2.DistanceFromPoint(new Point(3, 5)));
            //Console.WriteLine(line3.AreaWithX(line5));
        }

        public Line(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public Line()
        {
            this.a = 1;
            this.b = 0;
        }

        public Line(double a, Point p)
        {
            this.a = a;
            this.b = p.GetY() - a * p.GetX();
        }

        public Line(Point p1, Point p2)
        {
            this.a = (p2.GetY() - p1.GetY()) / (p2.GetX() - p1.GetX());
            this.b = p1.GetY() - a * p1.GetX();
        }

        public Line(Line line)
        {
            this.a = line.a;
            this.b = line.b;
        }

        public double GetA()
        {
            return this.a;
        }

        public double GetB()
        {
            return this.b;
        }

        public void SetA(double a)
        {
            this.a = a;
        }

        public void SetB(double b)
        {
            this.b = b;
        }

        public Point YIntercept()
        {
            return new Point(0, this.GetB());
        }

        public Point XIntercept()
        {
            if (this.GetA() == 0)
            {
                return null;
            }
            else
            {
                return new Point(-(this.GetB() / this.GetA()), 0);
            }
        }

        public double GetY(double x)
        {
            double y = this.GetA() * x + this.GetB();
            return y;
        }

        public bool IsOnLine(Point p)
        {
            bool onLine = false;
            if (p.GetY() == this.GetY(p.GetX()))
            {
                onLine = true;
            }
            return onLine;
        }

        public int LineStatus(Line line)
        {
            int status = 1;
            if (this.GetA() == line.GetA())
            {
                if (this.GetB() == line.GetB())
                {
                    status = -1;
                }
                else
                {
                    status = 0;
                }
            }
            return status;
        }

        public Point LineIntercept(Line line)
        {
            if (this.LineStatus(line) == 1)
            {
                Point intercept = new Point();
                double x = (line.GetB() - this.GetB()) / (this.GetA() - line.GetA());
                double y = this.GetY(x);
                intercept.SetX(x);
                intercept.SetY(y);
                return intercept;
            }
            else
            {
                return null;
            }
        }

        public Line Perpendicular(Point p)
        {
            double a = -1 / this.GetA();
            Line line = new Line(a, p);
            return line;
        }

        public double DistanceFromPoint(Point p)
        {
            double dist;
            if (this.GetA() == 0)
            {
                dist = Math.Abs(this.GetB() - p.GetY());
            }
            else
            {
                Line otherLine = this.Perpendicular(p);
                Point intercept = this.LineIntercept(otherLine);
                dist = p.Distance(intercept);
            }
            return dist;
        }

        public double AreaWithX(Line line)
        {
            if (this.LineStatus(line) == 1)
            {
                Point intercept = this.LineIntercept(line);
                double tBase = Math.Abs(this.XIntercept().GetX() - line.XIntercept().GetX());
                double tHeight = Math.Abs(intercept.GetY());
                double tArea = (tBase * tHeight) / 2;
                return tArea;
            }
            else
            {
                return 0;
            }
        }

        public double[] TriangleAnglesWithX(Line line)
        {
            if (this.LineStatus(line) == 1)
            {
                Point intercept = this.LineIntercept(line);
                double height = Math.Abs(intercept.GetY());
                double dist1 = Math.Abs(intercept.GetX() - this.XIntercept().GetX());
                double dist2 = Math.Abs(intercept.GetX() - line.XIntercept().GetX());
                double angle1 = Math.Atan(height / dist1);
                double angle2 = Math.Atan(height / dist2);
                double angle3 = 180 - angle1 - angle2;
                double[] angles = { angle1, angle2, angle3 };
                return angles;
            }
            else
            {
                double[] noAngles = { 0 };
                return noAngles;
            }
        }

        public override string ToString()
        {
            char bSign = this.GetB() >= 0 ? '+' : '-';
            string aStr = this.GetA() == 1 ? "" : $"{this.GetA()}";
            string bStr = this.GetB() == 0 ? "" : $" {bSign} {Math.Abs(this.GetB())}";
            string str = $"f(x) = {aStr}x{bStr}";
            return str;
        }
    }
}