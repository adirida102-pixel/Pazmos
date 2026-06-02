using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pazmos
{
    public class Point
    {
        private double x;
        private double y;

        public static void PointUT()
        {
            //Point p1 = new Point(2.2, 5.5);
            //Point p2 = new Point(1.2, 2.5);
            //Console.WriteLine(p1);
            //Console.WriteLine(p1.Distance(p2));
            //Console.WriteLine(p1.Middle(p2));
            //Point p3 = new Point(p2);
            //Point[] points = {p1, p2, p3};
            //Point[] mids = Middles(points);
            //for (int i = 0; i < mids.Length; i++)
            //{
            //    Console.WriteLine(mids[i]);
            //}
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point() : this(0, 0)
        {

        }

        public Point(Point p) : this(p.GetX(), p.GetY())
        {

        }

        public double GetX()
        {
            return this.x;
        }

        public void SetX(double x)
        {
            this.x = x;
        }

        public double GetY()
        {
            return this.y;
        }

        public void SetY(double y)
        {
            this.y = y;
        }

        public double Distance(Point p)
        {
            double dist = Math.Sqrt((this.x - p.GetX()) * (this.x - p.GetX()) + (this.y - p.GetY()) * (this.y - p.GetY()));
            return dist;
        }

        public Point Middle(Point p)
        {
            double newX = (this.x + p.GetX()) / 2;
            double newY = (this.y + p.GetY()) / 2;
            Point finalP = new Point(newX, newY);
            return finalP;
        }

        public override string ToString()
        {
            return $"({this.x}, {this.y})";
        }

        public double Slope(Point point)
        {
            double slope = (point.GetY() - this.GetY()) / (point.GetX() - this.GetX());
            return slope;
        }

        public static Point Furthest(Point[] points)
        {
            Point furthest = new Point();
            Point origin = new Point();
            double mostDist = 0;
            double crntDist = 0;
            for (int i = 0; i < points.Length; i++)
            {
                crntDist = origin.Distance(points[i]);
                if (mostDist > crntDist)
                {
                    mostDist = crntDist;
                    furthest = points[i];
                }
            }
            return furthest;
        }

        public static Point[] Middles(Point[] points)
        {
            Point[] mids = new Point[points.Length];
            Point origin = new Point();
            for (int i = 0; i < points.Length; i++)
            {
                mids[i] = origin.Middle(points[i]);
            }
            return mids;
        }
    }
}