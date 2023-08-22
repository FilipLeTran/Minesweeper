using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinesweeperTest
{
    [TestClass] 
    public class MinefieldTests
    {
        const int MINE_CELL_VALUE = -1;
        const int EMPTY_CELL_VALUE = 10;

        [TestMethod]
        // Test if the SetBomb method correctly sets a bomb in the specified location
        public void Minefield_SetBomb_SetsBombUserInput()
        {
            // Arrange
            Minefield minefield = new();

            // Act
            minefield.SetBomb(2, 3);
            bool[,] bombs = minefield.GetBombs();

            // Assert
            Assert.IsTrue(bombs[2, 3]);
        }

        // Test if the GetBombs method returns the correct bomb locations
        [TestMethod]
        public void Minefield_GetBombs_ValuesAtBombLocationsAreTrueElseFalse()
        {
            // Arrange
            Minefield minefield = new();
            minefield.SetBomb(1, 2);
            minefield.SetBomb(3, 4);

            // Act
            bool[,] bombLocations = minefield.GetBombs();

            // Assert
            Assert.IsTrue(bombLocations[1, 2]);
            Assert.IsTrue(bombLocations[3, 4]);
            Assert.IsFalse(bombLocations[0, 0]);
            Assert.IsFalse(bombLocations[2, 3]);
        }

        // Test if the RevealSquares method correctly reveals the adjacent squares
        [TestMethod]
        public void Minefield_SetBomb_ReturnsArrayWithTotalAdjacentMinesAtSurroundingCells()
        {
            // Arrange
            Minefield minefield = new();
            minefield.SetBomb(1, 1);
            minefield.SetBomb(3, 3);

            // Act
            int[,]? result = minefield.RevealCells(2, 2);

            // Assert
            Assert.AreEqual(MINE_CELL_VALUE, result[1, 1]); 
            Assert.AreEqual(1, result[1, 2]); 
            Assert.AreEqual(EMPTY_CELL_VALUE, result[1, 3]);
            Assert.AreEqual(1, result[2, 1]); 
            Assert.AreEqual(2, result[2, 2]); 
            Assert.AreEqual(1, result[2, 3]);
            Assert.AreEqual(EMPTY_CELL_VALUE, result[3, 1]);
            Assert.AreEqual(1, result[3, 2]); 
            Assert.AreEqual(MINE_CELL_VALUE, result[3, 3]); 
        }

        // Test that the RevealSquares method returns null when a mine is revealed
        [TestMethod]
        public void Minefield_RevealSquares_ReturnNull()
        {
            // Arrange
            Minefield minefield = new();
            minefield.SetBomb(2, 2);

            // Act
            int[,]? result = minefield.RevealCells(2, 2);

            // Assert
            Assert.IsNull(result);
        }

        // Test that the IsUnexplored method returns false when everything has been discovered
        [TestMethod]
        public void Minefield_IsUnexplored_ReturnFalseIfAllExplored()
        {
            // Arrange
            Minefield minefield = new();
            int[,]? result = minefield.RevealCells(0, 0);

            // Act
            for(int x = 0; x < minefield.GetBombs().GetLength(0); x++)
            {
                for (int y = 0; y < minefield.GetBombs().GetLength(1); y++)
                {
                    result = minefield.RevealCells(x, y);
                }
            }

            // Assert
            Assert.IsFalse(minefield.IsUnexplored());
        }

        // Test that the IsUnexplored method returns true when the field has yet to be fully discovered
        [TestMethod]
        public void Minefield_IsUnexplored_ReturnTrueIfAllExplored()
        {
            // Arrange
            Minefield minefield = new();

            // Act
            // Assert
            Assert.IsTrue(minefield.IsUnexplored());
        }


    }

}

