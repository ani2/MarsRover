using System;
using System.IO;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "instructions.txt";
            string[] instructions = File.ReadAllLines(path);

            RoverController rc = new RoverController();
            string response = rc.ReadInstructions(instructions);

            Console.WriteLine(response);

            Console.ReadLine();
        }
    }
}
