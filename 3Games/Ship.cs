using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Games
{
    internal class Ship
    {
        public char Type { get; private set; }
        public int Size { get; private set; }
        public List<Point> Coordinates { get; private set; }
        private HashSet<Point> hits;

        public Ship(char type, int size, List<Point> coordinates)
        {
            Type = type;
            Size = size;
            Coordinates = coordinates;
            hits = new HashSet<Point>(new PointComparer());
        }

        public bool RegisterHit(Point p)
        {
            if (Coordinates.Any(coord => coord.Row == p.Row && coord.Col == p.Col))
            {
                hits.Add(p);
                return true;
            }
            return false;
        }

        public bool IsSunk()
        {
            return hits.Count >= Size;
        }
    }
}

