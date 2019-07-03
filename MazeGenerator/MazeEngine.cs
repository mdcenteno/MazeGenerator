using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{    
    public class MazeEngine
    {
        internal List<List<MazeNode>> matrix = new List<List<MazeNode>>();
        int width;
        int height;
        Stack<MazeNode> nodes = new Stack<MazeNode>();
        List<MazeNode> neighbours = new List<MazeNode>();        

        internal void Generate(int w, int h)
        {
            Random random = new Random();

            Initialize(w, h);

            nodes.Push(new MazeNode(0, 0));

            while (nodes.Count > 0)
            {
                MazeNode current = nodes.Pop();
                GetNeighbours(current);

                if (neighbours.Count > 0)
                {
                    int roll = random.Next(neighbours.Count);
                    MazeNode next = neighbours[roll];

                    current.SetValueSource(next.direction);
                    
                    next.SetValueTarget();
                    
                    nodes.Push(current);
                    nodes.Push(next);
                    neighbours.Clear();

                    matrix[current.position.Y][current.position.X].value[next.direction] = current.value[next.direction];
                    matrix[next.position.Y][next.position.X].value[next.Opposite()] = next.value[next.direction];
                }
            }            
        }

        private List<Tuple<int, int, Direction>> PrepareMatrix()
        {
            List<Tuple<int, int, Direction>> walls = new List<Tuple<int, int, Direction>>();
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (j == 0)
                        matrix[j][i].value[Direction.Up] = CellValue.Border;
                    if (i == 0)
                        matrix[j][i].value[Direction.Left] = CellValue.Border;
                    
                    if (matrix[j][i].value[Direction.Up] == CellValue.Wall)
                        walls.Add(new Tuple<int, int, Direction>(j, i, Direction.Up));
                    if (matrix[j][i].value[Direction.Left] == CellValue.Wall)
                        walls.Add(new Tuple<int, int, Direction>(j, i, Direction.Left));
                }
            }
            return walls;
        }

        private void GetNeighbours(MazeNode c)
        {
            MazeNode n = new MazeNode(c.position.X, c.position.Y - 1);
            n.direction = Direction.Up;
            AddValidNeighbour(n);

            n = new MazeNode(c.position.X + 1, c.position.Y);
            n.direction = Direction.Right;
            AddValidNeighbour(n);

            n = new MazeNode(c.position.X, c.position.Y + 1);
            n.direction = Direction.Down;
            AddValidNeighbour(n);

            n = new MazeNode(c.position.X - 1, c.position.Y);
            n.direction = Direction.Left;
            AddValidNeighbour(n);

        }

        private void AddValidNeighbour(MazeNode u)
        {
            if (u.Valid(width, height) &&
                matrix[u.position.Y][u.position.X].Valid(width, height))
            {
                neighbours.Add(u);
            }
        }

        private void Initialize(int w, int h)
        {
            width = w;
            height = h;
            GenerateMatrix();
        }

        private void GenerateMatrix()
        {
            for (int j = 0; j < height; j++)
            {
                List<MazeNode> l = new List<MazeNode>();
                for (int i = 0; i < width; i++)                
                    l.Add(new MazeNode());                
                matrix.Add(l);
            }
        }

    }
}
