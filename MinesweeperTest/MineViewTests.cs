using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;
using System;
using System.IO;

namespace MinesweeperTest
{
    [TestClass]
    public class MineViewTests
    {
        private const int EMPTY_CELL_VALUE = 10;
        private const int MINE_CELL_VALUE = -1;

        // Test that the PrintInitialField method prints the initial minefield view correctly
        [TestMethod]
        public void MineView_PrintInitialField_PrintInitialField()
        {
            // Arrange
            Minefield field = new Minefield();
            MineView mineView = new MineView(field);
            string expectedField = "  01234\r\n" +
                                   "4|?????\r\n" +
                                   "3|?????\r\n" +
                                   "2|?????\r\n" +
                                   "1|?????\r\n" +
                                   "0|?????\r\n" +
                                   "---------------------\r\n";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                mineView.PrintInitialField();
                string actualField = sw.ToString();

                // Assert
                Assert.AreEqual(expectedField, actualField);
            }
        }

        // Test that the MineExploded() method prints the correct loss message
        [TestMethod]
        public void MineView_MineExplored_PrintMineExplodeMessage()
        {
            // Arrange
            Minefield field = new Minefield();
            MineView mineView = new MineView(field);
            string expectedMessage = "You lost! Mine exploded!\r\n";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                mineView.MineExploded();
                string actualField = sw.ToString();

                // Assert
                Assert.AreEqual(expectedMessage, actualField);
            }
        }

        // To verify that the GameCleared() method prints the victory message correctly
        [TestMethod]
        public void MineView_GameCleared_PrintGameClearedMessage()
        {
            // Arrange
            Minefield field = new Minefield();
            MineView mineView = new MineView(field);
            string expectedMessage = "Victory! You completed the game :)\r\n";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                mineView.GameCleared();
                string consoleOutput = sw.ToString();

                // Assert
                Assert.AreEqual(expectedMessage, consoleOutput);
            }
        }

        // Test that the UpdateBoard() method updates the minefield view correctly when given valid input
        [TestMethod]
        public void MineView_UpdateBoard_PrintUpdatedBoard()
        {
            // Arrange
            Minefield field = new Minefield();
            MineView mineView = new MineView(field);
            int[,] squares = new int[,]
            {
                { 0, 0, 0, 0 , 0 },
                { 3, MINE_CELL_VALUE, 2, 0, 0 },
                { 1, 1, 1, 0, 0},
                { EMPTY_CELL_VALUE, 1, 1, 0, 0 },
                { EMPTY_CELL_VALUE, 1, 0, 0, 0 }
            };
            string expectedField = "  01234\r\n" +
                                   "4|?????\r\n" +
                                   "3|?????\r\n" +
                                   "2|?211?\r\n" +
                                   "1|?X111\r\n" +
                                   "0|?31  \r\n" +
                                   "---------------------\r\n";
            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                mineView.UpdateBoard(squares);
                string consoleOutput = sw.ToString();

                // Assert
                Assert.AreEqual(expectedField, consoleOutput);
            }
        }

        // Test if the CorrectInputFormat() method prints the correct message when called
        [TestMethod]
        public void MineView_CorrectInputFormat_PrintCorrectInputMessage()
        {
            // Arrange
            Minefield field = new Minefield();
            MineView mineView = new MineView(field);
            string expectedMessage = "Please type the in the following format: 'x y'\r\n";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                mineView.CorrectInputFormat();
                string actualMessage = sw.ToString();

                // Assert
                Assert.AreEqual(expectedMessage, actualMessage);
            }
        }

        // Test that the CorrectInputRange() method in the MineView class prints the correct message when called.
        [TestMethod]
        public void MineView_CorrectInputRange_PrintRangeInputMessage()
        {
            // Arrange
            Minefield field = new Minefield();
            MineView mineView = new MineView(field);
            StringWriter stringWriter = new StringWriter();
            int xBoardLength = field.GetBombs().GetLength(0);
            int yBoardLength = field.GetBombs().GetLength(1);
            Console.SetOut(stringWriter);
            string expectedMessage = $"Please type the values within the ranges of: 0-{xBoardLength - 1} for the x value and 0-{yBoardLength - 1} for the y value\r\n";

            // Act
            mineView.CorrectInputRange();
            string output = stringWriter.ToString();

            // Assert
            Assert.AreEqual(expectedMessage, output);
        }

        // Test that the UpdateBoard() method updates the minefield view correctly when all cells have been explored
        [TestMethod]
        public void MineView_UpdateBoard_PrintAllCellsExplored()
        {
            // Arrange
            Minefield field = new Minefield();
            MineView mineView = new MineView(field);
            int[,] squares = new int[,]
            {
                {MINE_CELL_VALUE, MINE_CELL_VALUE, 2, 1, 1 },
                { 3, MINE_CELL_VALUE, 2, 1, MINE_CELL_VALUE },
                { 1, 1, 1, 1, 1},
                { EMPTY_CELL_VALUE, 1, 1, 1, EMPTY_CELL_VALUE },
                { EMPTY_CELL_VALUE, 1, MINE_CELL_VALUE, 1, EMPTY_CELL_VALUE }
            };
            string expectedField = "  01234\r\n" +
                                   "4|1X1  \r\n" +
                                   "3|11111\r\n" +
                                   "2|2211X\r\n" +
                                   "1|XX111\r\n" +
                                   "0|X31  \r\n" +
                                   "---------------------\r\n";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                mineView.UpdateBoard(squares);
                string actualField = sw.ToString();

                // Assert
                // Verify that the minefield view is updated correctly
                Assert.AreEqual(expectedField, actualField);
            }
        }
    }
}
