using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{    
    internal class MazeEngine
    {
        internal List<List<MazeNode>> matrix;
        int width;
        int height;
        
        internal void Generate(int width, int height)
        {
            this.width = width;
            this.height = height;

            Random random = new Random();

            GenerateMatrix();
            Stack<MazeNode> nodes = new Stack<MazeNode>();
            nodes.Push(new MazeNode(0, 0));

            while (nodes.Count > 0)
            {
                MazeNode current = nodes.Pop();

                List<MazeNode> neighbours = GetNeighbours(current);
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

        private List<MazeNode> GetNeighbours(MazeNode c)
        {
            List<MazeNode> lNodes = new List<MazeNode>();
            MazeNode node;

            node = GenerateValidNeighbour(c.position.X, c.position.Y - 1, Direction.Up);
            if (node != null)
                lNodes.Add(node);
            node = GenerateValidNeighbour(c.position.X + 1, c.position.Y, Direction.Right);
            if (node != null)
                lNodes.Add(node);
            node = GenerateValidNeighbour(c.position.X, c.position.Y + 1, Direction.Down);
            if (node != null)
                lNodes.Add(node);
            node = GenerateValidNeighbour(c.position.X - 1, c.position.Y, Direction.Left);
            if (node != null)
                lNodes.Add(node);

            return lNodes;
        }

        private MazeNode GenerateValidNeighbour(int x, int y, Direction d)
        {
            MazeNode valid = new MazeNode(x, y);
            valid.direction = d;
            return valid.Valid(width, height) && matrix[valid.position.Y][valid.position.X].Valid(width, height) ? valid : null;
        }

        private void GenerateMatrix()
        {
            matrix = new List<List<MazeNode>>();
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
