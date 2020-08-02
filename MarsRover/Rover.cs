using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{ 
    public class Rover
    {
        public Tuple<int, int> Position { get; set; }
        public int Direction { get; set; }

        public Rover()
        {
            Position = new Tuple<int, int>(0, 0);
            Direction = 0;
        }

        public Rover(int x, int y, string direction)
        {
            Position = new Tuple<int, int>(x, y);
            Direction = Array.IndexOf(Constants.CardinalDirections, direction.ToUpper());
        }

        public void RotateLeft()
        {
            Direction = (Direction + 3) % 4; // use +3 instead of -1 to avoid negative numbers
        }

        public void RotateRight()
        {
            Direction = (Direction + 1) % 4;
        }

        public Tuple<int, int> GetNextPosition()
        {
            switch (Direction)
            {
                case 0: // NORTH
                    return new Tuple<int, int>(Position.Item1, Position.Item2 + 1);
                case 1: // EAST
                    return new Tuple<int, int>(Position.Item1 + 1, Position.Item2);
                case 2: // SOUTH
                    return new Tuple<int, int>(Position.Item1, Position.Item2 - 1);
                default: // WEST
                    return new Tuple<int, int>(Position.Item1 - 1, Position.Item2);
            }
        }

        public override string ToString()
        {
            return $"{Position.Item1} {Position.Item2} {Constants.CardinalDirections[Direction]}";
        }
    }
}
