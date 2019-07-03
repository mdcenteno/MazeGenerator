using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    internal enum Direction { None, Up, Down, Left, Right }
    internal enum CellValue { Open, Wall, Border }

    internal class MazeNode
    {
        internal Pair<int> position = new Pair<int>();
        internal Direction direction = Direction.None;
        internal Dictionary<Direction, CellValue> value = new Dictionary<Direction, CellValue>();

        internal MazeNode()
        {
            value.Add(Direction.Up, CellValue.Wall);
            value.Add(Direction.Left, CellValue.Wall);
        }

        internal MazeNode(int x, int y)
        {
            position = new Pair<int>(x, y);
            value.Add(Direction.Up, CellValue.Wall);
            value.Add(Direction.Left, CellValue.Wall);
        }

        internal void SetValueSource(Direction direction)
        {
            value[direction] = CellValue.Open;
        }

        internal void SetValueTarget()
        {
            value[direction] = CellValue.Open;
        }

        internal bool Valid(int width, int height)
        {
            return
                position.X >= 0 &&
                position.X < width &&
                position.Y >= 0 &&
                position.Y < height &&
                !value.Values.ToList().Exists(l => l == CellValue.Open);
        }

        internal Direction Opposite()
        {
            switch (direction)
            {
                case Direction.None:
                    return Direction.None;
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Left:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Left;
                default:
                    return Direction.None;
            }
        }

    }

    class Pair<T>
    {
        public T X;
        public T Y;

        public Pair()
        {

        }

        public Pair(T X, T Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

}
