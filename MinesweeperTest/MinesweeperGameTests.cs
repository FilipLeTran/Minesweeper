using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;
using System;
using System.IO;

namespace MinesweeperTest
{


    [TestClass]
    public class MinesweeperGameTests
    {
        const int MINE_CELL_VALUE = -1;
        const int EMPTY_CELL_VALUE = 10;

        // Test that the MineView object is initialized correctly
        [TestMethod]
        public void MinesweeperGame_Main_ReturnsViewObject()
        {
            // Arrange
            Minefield field = new Minefield();

            // Act
            MineView fieldView = new MineView(field);

            // Assert
            Assert.IsNotNull(fieldView);
        }

        
        // Test that the Minefield object is initialized correctly
        [TestMethod]
        public void MinesweeperGame_Main_MinefieldObjectInitialized()
        {
            Minefield field = new Minefield();

            // Assert that the Minefield object is not null
            Assert.IsNotNull(field);

            // Assert that the Minefield object has the correct dimensions
            Assert.AreEqual(5, field.GetBombs().GetLength(0));
            Assert.AreEqual(5, field.GetBombs().GetLength(1));

            // Assert that the Minefield object is empty
            for (int i = 0; i < field.GetBombs().GetLength(0); i++)
            {
                for (int j = 0; j < field.GetBombs().GetLength(1); j++)
                {
                    Assert.IsFalse(field.GetBombs()[i, j]);
                }
            }
        }

        // Test that the ParseCoordinates function correctly parses valid user input
        [TestMethod]
        public void MinesweeperGame_Main_CatchesValidInput()
        {
            // Arrange
            string userInput = "2 3";
            int[] expectedCoordinates = new int[] { 2, 3 };

            // Act
            int[] actualCoordinates = MinesweeperGame.ParseCoordinates(userInput);

            // Assert
            Assert.AreEqual(expectedCoordinates[0], actualCoordinates[0]);
            Assert.AreEqual(expectedCoordinates[1], actualCoordinates[1]);
        }

        // Test that the ParseCoordinates function correctly parses invalid user input
        [TestMethod]
        public void MinesweeperGame_Main_CatchesInvalidInput()
        {
            // Arrange
            string userInput = "00";
            int[] expectedCoordinates = null;

            // Act
            int[] actualCoordinates = MinesweeperGame.ParseCoordinates(userInput);

            // Assert
            Assert.AreEqual(expectedCoordinates, actualCoordinates);
        }
    }
}
