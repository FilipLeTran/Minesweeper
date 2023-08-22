using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinesweeperTest
{
    [TestClass]
    public class AdjacentCalculatorTests
    {
        const int EMPTY_CELL_VALUE = 10;

        // Test the TotalAdjacentMines() method when the minefield contains no mines
        [TestMethod]
        public void AdjacentCalculator_TotalAdjacentMines_ReturnsEmpty()
        {
            // Arrange
            bool[,] minefield = new bool[3, 3] {
                { false, false, false },
                { false, false, false },
                { false, false, false }
            };
            AdjacentCalculator calculator = new AdjacentCalculator(1, 1, minefield);
        
            // Act
            int result = calculator.TotalAdjacentMines();
        
            // Assert
            Assert.AreEqual(EMPTY_CELL_VALUE, result);
        }


        // Test if TotalAdjacentMines() returns 10 (empty space) when there are no adjacent mines in the minefield
        [TestMethod]
        public void AdjacentCalculator_TotalAdjacentMines_ReturnsEmptyNoAdjacent()
        {
            // Arrange
            bool[,] minefield = new bool[,]
            {
                { true, false, false },
                { false, false, false },
                { false, false, false }
            };
            int x = 1;
            int y = 2;
            AdjacentCalculator calculator = new AdjacentCalculator(x, y, minefield);

            // Act
            int result = calculator.TotalAdjacentMines();

            // Assert
            Assert.AreEqual(EMPTY_CELL_VALUE, result);
        }

        // Test the TotalAdjacentMines() method when there is only one mine adjacent to the given x,y coordinates
        [TestMethod]
        public void AdjacentCalculator_TotalAdjacentMines_ReturnsOne()
        {
            // Arrange
            bool[,] minefield = new bool[,]
            {
                { false, false, false },
                { false, false, true },
                { false, false, false }
            };
            int x = 1;
            int y = 1;
            AdjacentCalculator calculator = new AdjacentCalculator(x, y, minefield);

            // Act
            int result = calculator.TotalAdjacentMines();

            // Assert
            Assert.AreEqual(1, result);
        }

        // Test the TotalAdjacentMines() method when it skips the given x,y coordinates
        [TestMethod]
        public void AdjacentCalculator_TotalAdjacentMines_ReturnsSkip()
        {
            // Arrange
            bool[,] minefield = new bool[,]
            {
                { false, false, false },
                { false, true, false },
                { false, false, false }
            };
            int x = 1;
            int y = 1;
            AdjacentCalculator calculator = new AdjacentCalculator(x, y, minefield);

            // Act
            int result = calculator.TotalAdjacentMines();

            // Assert
            Assert.AreEqual(EMPTY_CELL_VALUE, result);
        }

        // Test if the TotalAdjacentMines() method returns the correct number of adjacent mines when the minefield contains mines only at the corners of the field
        [TestMethod]
        public void AdjacentCalculator_TotalAdjacentMines_ReturnsAllCornersMines()
        {
            // Arrange
            bool[,] minefield = new bool[,]
            {
                { true, false, true },
                { false, false, false },
                { true, false, true }
            };
            int x = 1;
            int y = 1;
            AdjacentCalculator adjacentCalculator = new AdjacentCalculator(x, y, minefield);

            // Act
            int result = adjacentCalculator.TotalAdjacentMines();

            // Assert
            Assert.AreEqual(4, result);
        }

        // Test if the TotalAdjacentMines() method returns the correct number of adjacent mines when the minefield contains all mines.
        [TestMethod]
        public void AdjacentCalculator_TotalAdjacentMines_ReturnsAllMines()
        {
            // Arrange
            bool[,] minefield = new bool[,]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true }
            };
            int x = 1;
            int y = 1;
            AdjacentCalculator adjacentCalculator = new AdjacentCalculator(x, y, minefield);

            // Act
            int result = adjacentCalculator.TotalAdjacentMines();

            // Assert
            Assert.AreEqual(8, result);
        }

        // Test if the TotalAdjacentMines() method returns the correct number of adjacent mines when the minefield is
        // bigger and mines are placed outside range of the given x and y coordinates.
        [TestMethod]
        public void AdjacentCalculator_TotalAdjacentMines_ReturnsOnlyAdjacentMines()
        {
            // Arrange
            bool[,] minefield = new bool[,]
            {
                { false, false, true, true, true },
                { false, false, true, false, false },
                { true, true, false, false, true },
                { false, false, true, false, true },
                { true, true, false, false, true }
            };
            int x = 3;
            int y = 3;
            AdjacentCalculator adjacentCalculator = new AdjacentCalculator(x, y, minefield);

            // Act
            int result = adjacentCalculator.TotalAdjacentMines();

            // Assert
            Assert.AreEqual(4, result);
        }

        // Test if the TotalAdjacentMines() method returns only mines within the minefield and does not check outside
        [TestMethod]
        public void AdjacentCalculator_TotalAdjacentMines_ReturnsMinesInsideBorder()
        {
            // Arrange
            bool[,] minefield = new bool[,]
            {
                { true, true, true },
                { true, false, false },
                { true, false, true }
            };
            int x = 2;
            int y = 1;
            AdjacentCalculator adjacentCalculator = new AdjacentCalculator(x, y, minefield);

            // Act
            int result = adjacentCalculator.TotalAdjacentMines();

            // Assert
            Assert.AreEqual(3, result);
        }
    }
}













