using Generator;

namespace MazeGeneratorConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Maze2Screen();

            //Maze2File();
        }

        private static void Maze2File()
        {
            Maze maze = new Maze(10, 10);
            maze.Generate(true);
            Console.WriteLine(maze.ToString());
            File.AppendAllText($"{Directory.GetCurrentDirectory()}/maze.txt", maze.ToString());
        }

        private static void Maze2Screen()
        {
            Maze maze = new Maze(10, 10);
            maze.Generate(true);
            Console.WriteLine(maze.ToString());
        }
    }
}
