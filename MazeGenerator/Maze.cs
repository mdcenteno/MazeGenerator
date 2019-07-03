using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public class Maze
    {
        public List<List<int>> Tiles { get; } = new List<List<int>>();

        int width;
        int height;
        MazeEngine mazeGenerator = new MazeEngine();

        public Maze(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Generate()
        {            
            mazeGenerator.Generate(width, height);
            GenerateMaze();
            ExpandToMap();
        }
        
        private void GenerateMaze()
        {
            int width = mazeGenerator.matrix[0].Count * 2 + 1;
            int height = mazeGenerator.matrix.Count * 2 + 1;
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
            for (int j = 0; j < mazeGenerator.matrix.Count; j++)            
                for (int i = 0; i < mazeGenerator.matrix[j].Count; i++)
                {
                    Tiles[(j * 2) + 0][(i * 2) + 1] = ExpandCell(mazeGenerator.matrix[j][i].value[Direction.Up]);
                    Tiles[(j * 2) + 1][(i * 2) + 0] = ExpandCell(mazeGenerator.matrix[j][i].value[Direction.Left]);
                }            
        }

        private int ExpandCell(CellValue cv)
        {
            return cv == CellValue.Open ? 0 : 1;            
        }

    }
}
