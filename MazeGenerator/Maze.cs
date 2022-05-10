using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public class Maze
    {
        public List<List<int>> Tiles { get; } = new List<List<int>>();

        readonly int width;
        readonly int height;
        readonly MazeEngine mazeEngine = new MazeEngine();

        public Maze(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Generate()
        {
            mazeEngine.Generate(width, height);
            GenerateMaze();
            ExpandToMap();
        }
        
        private void GenerateMaze()
        {
            int width = mazeEngine.matrix[0].Count * 2 + 1;
            int height = mazeEngine.matrix.Count * 2 + 1;
            for (int j = 0; j < height; j++)
            {
                List<int> l = new List<int>();
                for (int i = 0; i < width; i++)
                    if (!(i % 2 == 1 && j % 2 == 1) || (j == height * 2))
                        l.Add(1);
                    else
                        l.Add(0);
                Tiles.Add(l);
            }
        }

        private void ExpandToMap()
        {
            for (int j = 0; j < mazeEngine.matrix.Count; j++)            
                for (int i = 0; i < mazeEngine.matrix[j].Count; i++)
                {
                    Tiles[(j * 2) + 0][(i * 2) + 1] = mazeEngine.matrix[j][i].value[Direction.Up] == CellValue.Open ? 0 : 1;
                    Tiles[(j * 2) + 1][(i * 2) + 0] = mazeEngine.matrix[j][i].value[Direction.Left] == CellValue.Open ? 0 : 1;
                }
        }

        public override string ToString()
        {
            return Output(' ', '#');
        }

        public string Output(char space, char wall)
        {
            StringBuilder sb = new StringBuilder();
            foreach (List<int> row in Tiles)
            {
                foreach (int cell in row)
                    sb.Append(cell == 0 ? space : wall);
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}
