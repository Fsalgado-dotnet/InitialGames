using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Games
{
    public class PointComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point p1, Point p2)
        {
            return p1.Row == p2.Row && p1.Col == p2.Col;
        }
        public int GetHashCode(Point p)
        {
            return p.Row * 397 ^ p.Col;
        }
    }

}