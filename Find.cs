using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar2
{
    internal class Find
    {
        public int[,,] map;
        private int width, heigth, depth;
        private const int visited = 4;
        private const int seen = 2;

        public Find(int[,,] matrix)
        {
            this.map = matrix;
            this.width = matrix.GetLength(0);
            this.heigth = matrix.GetLength(1);
            this.depth = matrix.GetLength(2);
        }

        public Find(int width, int heigth, int depth)
        {
            this.width = width;
            this.heigth = heigth;
            this.depth = depth;
            this.map = new int[width, heigth, depth];
        }

        private void SetMap(int x, int y, int z, int number)
        {
            if (x < 0 || x >= width) return;
            if (y < 0 || y >= heigth) return;
            if (z < 0 || z >= depth) return;
            map[x, y, z] = number;
        }

        private bool IsEmpty(int x, int y, int z)
        {
            if (x < 0 || x >= width) return false;
            if (y < 0 || y >= heigth) return false;
            if (z < 0 || z >= depth) return false;
            return map[x, y, z] == 0;
        }

        private int Exit(int coord, int border)
        {
            if (coord == 0 || coord == border - 1) return 1;
            return 0;
        }

        public int FindQueue(int startPos_x, int startPos_y, int startPos_z)
        {
            int exits = 0;
            int x,y,z;

            SetMap(startPos_x, startPos_y, startPos_z, seen);

            Queue<Coord> queue = new Queue<Coord>();
            queue.Enqueue(new Coord(startPos_x, startPos_y, startPos_z));

            while (queue.TryDequeue(out Coord coord))
            {
                x = coord.x; 
                y = coord.y; 
                z = coord.z;

                exits += Exit(x, width) + Exit(y, heigth) + Exit(z, depth);

                SetMap(x, y, z, visited);

                if (IsEmpty(x + 1, y, z)) { queue.Enqueue(new Coord(x + 1, y, z)); SetMap(x + 1, y, z, seen); }
                if (IsEmpty(x - 1, y, z)) { queue.Enqueue(new Coord(x - 1, y, z)); SetMap(x - 1, y, z, seen); }
                if (IsEmpty(x, y + 1, z)) { queue.Enqueue(new Coord(x, y + 1, z)); SetMap(x, y + 1, z, seen); }
                if (IsEmpty(x, y - 1, z)) { queue.Enqueue(new Coord(x, y - 1, z)); SetMap(x, y - 1, z, seen); }
                if (IsEmpty(x, y, z + 1)) { queue.Enqueue(new Coord(x, y, z + 1)); SetMap(x, y, z + 1, seen); }
                if (IsEmpty(x, y, z - 1)) { queue.Enqueue(new Coord(x, y, z - 1)); SetMap(x, y, z - 1, seen); }

            }
            return exits;
        }

        public void PutRandomNumber(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                SetMap(random.Next(width), random.Next(heigth), random.Next(depth), 1);
            }
        }
    }
}
