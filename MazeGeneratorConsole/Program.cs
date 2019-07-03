using Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze(30, 20);
            maze.Generate();
            Output(maze.Tiles);
        }

        private static void Output(List<List<int>> Maze)
        {
            foreach (List<int> row in Maze)
            {
                foreach (int cell in row)
                    Console.Write(cell == 0 ? " " : "#");
                Console.WriteLine();
            }
        }

    }
}
