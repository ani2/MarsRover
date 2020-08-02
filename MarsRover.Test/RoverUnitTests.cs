using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRover.Test
{
    [TestClass]
    public class RoverUnitTests
    {
        [TestMethod]
        public void CreateRover_Default()
        {
            Tuple<int, int> expectedPos = new Tuple<int, int>(0, 0);
            int expectedDir = 0;

            Rover rover = new Rover();

            Assert.AreEqual(expectedPos, rover.Position);
            Assert.AreEqual(expectedDir, rover.Direction);
        }

        [TestMethod]
        public void CreateRover_GivenPosition()
        {
            Tuple<int, int> expectedPos = new Tuple<int, int>(3, 4);
            int expectedDir = 2;

            Rover rover = new Rover(3, 4, "S");

            Assert.AreEqual(expectedPos, rover.Position);
            Assert.AreEqual(expectedDir, rover.Direction);
        }

        [TestMethod]
        public void RotateRight_FacingNorth()
        {
            int expected = 1;
            Rover rover = new Rover();

            rover.RotateRight();

            Assert.AreEqual(expected, rover.Direction);
        }

        [TestMethod]
        public void RotateLeft_FacingNorth()
        {
            int expected = 3;
            Rover rover = new Rover();

            rover.RotateLeft();

            Assert.AreEqual(expected, rover.Direction);
        }

        [TestMethod]
        public void RotateRight_FacingSouth()
        {
            int expected = 3;
            Rover rover = new Rover
            {
                Direction = 2
            };

            rover.RotateRight();

            Assert.AreEqual(expected, rover.Direction);
        }

        [TestMethod]
        public void RotateLeft_FacingSouth()
        {
            int expected = 1;
            Rover rover = new Rover
            {
                Direction = 2
            };

            rover.RotateLeft();

            Assert.AreEqual(expected, rover.Direction);
        }

        [TestMethod]
        public void GetNextPosition_Positive()
        {
            Tuple<int, int> expected = new Tuple<int, int>(2, 1);
            Rover rover = new Rover(1, 1, "E");

            var actual = rover.GetNextPosition();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNextPosition_Negative()
        {
            Tuple<int, int> expected = new Tuple<int, int>(-1, 1);
            Rover rover = new Rover(0, 1, "W");

            var actual = rover.GetNextPosition();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RoverToString()
        {
            string expected = "1 2 W";
            Rover rover = new Rover(1, 2, "W");

            string actual = rover.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
