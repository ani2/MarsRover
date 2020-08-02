using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MarsRover.Test
{
    [TestClass]
    public class RoverControllerTests
    {
        [TestMethod]
        public void TestInBoundsPosition()
        {
            RoverController rc = new RoverController
            {
                NorthEastBound = new Tuple<int, int>(3, 3)
            };

            Assert.IsTrue(rc.IsInBounds(new Tuple<int, int>(1, 3)));
        }

        [TestMethod]
        public void TestOutOfBoundsPosition()
        {
            RoverController rc = new RoverController
            {
                NorthEastBound = new Tuple<int, int>(3, 3)
            };

            Assert.IsFalse(rc.IsInBounds(new Tuple<int, int>(4, 3)));
        }

        [TestMethod]
        public void TestOutOfBoundsPosition_Negative()
        {
            RoverController rc = new RoverController
            {
                NorthEastBound = new Tuple<int, int>(3, 3)
            };

            Assert.IsFalse(rc.IsInBounds(new Tuple<int, int>(-1, 3)));
        }

        [TestMethod]
        public void ReadRoverInstructions()
        {
            RoverController rc = new RoverController();
            string[] instructions =
            {
                "3 3",
                "1 1 N",
                "MRMM"
            };
            string expected = $"3 2 E{Environment.NewLine}";

            string actual = rc.ReadInstructions(instructions);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadRoverInstructions_InvalidBounds()
        {
            RoverController rc = new RoverController();
            string[] instructions =
            {
                "3 -3",
                "1 1 N",
                "MRMM"
            };

            Assert.ThrowsException<InvalidDataException>(() => rc.ReadInstructions(instructions));
        }
    }
}
