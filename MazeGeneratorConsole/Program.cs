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
            Console.WriteLine(maze.ToString());
        }

    }
}
