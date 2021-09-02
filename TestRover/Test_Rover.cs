using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.BL.Models;

namespace TestRover
{
    [TestClass]
    public class Test_Rover
    {
        [TestMethod]
        public void Test1()
        {
            string expectedResponse = "1 3 N";
            InputData input = new InputData();
            input.Grid = "5 5";
            input.Position = "1 2 N";
            input.Instructions = "LMLMLMLMM";
            string response = MarsRoverChallenge.Program.MoveRover(input);
            Assert.AreEqual(expectedResponse, response);

        }

        [TestMethod]
        public void Test2()
        {
            string expectedResponse = "5 1 E";
            InputData input = new InputData();

            input.Grid = "5 5";
            input.Position = "3 3 E";
            input.Instructions = "MMRMMRMRRM";
            string response = MarsRoverChallenge.Program.MoveRover(input);
            Assert.AreEqual(expectedResponse, response);

        }
    }
}
