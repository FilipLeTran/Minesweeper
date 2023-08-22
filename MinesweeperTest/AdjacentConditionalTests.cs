using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinesweeperTest
{
    [TestClass]
    public class AdjacentConditionalTests
    {
        // Test if the IsOutsideField method returns false when x and y values are within the field length
        [TestMethod]
        public void AdjacentConditional_IsOutsideField_ReturnsFalseWhenInside()
        {
            // Arrange
            int x = 2;
            int y = 3;
            int xFieldLength = 5;
            int yFieldLength = 5;
            AdjacentConditional adjacentConditional = new AdjacentConditional();

            // Act
            bool result = adjacentConditional.IsOutsideField(x, y, xFieldLength, yFieldLength);

            // Assert
            Assert.IsFalse(result);
        }

        // Test if the IsOutsideField method returns false when x and y values are at the edge of the field length i.e. inside
        [TestMethod]
        public void AdjacentConditional_IsOutsideField_ReturnsFalseWhenAtEdge()
        {
            // Arrange
            int x = 0;
            int y = 0;
            int xFieldLength = 10;
            int yFieldLength = 10;
            AdjacentConditional adjacentConditional = new AdjacentConditional();

            // Act
            bool result = adjacentConditional.IsOutsideField(x, y, xFieldLength, yFieldLength);

            // Assert
            Assert.IsFalse(result);
        }

        // Test if the IsOutsideField method returns true when x and y values are at the minimum field length
        [TestMethod]
        public void AdjacentConditional_IsOutsideField_ReturnsFalseInsideMinimumLength()
        {
            // Arrange
            int x = 0;
            int y = 0;
            int xFieldLength = 1;
            int yFieldLength = 1;
            AdjacentConditional adjacentConditional = new AdjacentConditional();

            // Act
            bool result = adjacentConditional.IsOutsideField(x, y, xFieldLength, yFieldLength);

            // Assert
            Assert.IsFalse(result);
        }

        // Test if the IsOutsideField method returns true when x and y values are at the maximum field length
        [TestMethod]
        public void AdjacentConditional_IsOutsideField_ReturnsTrueOutsideMaxLength()
        {
            // Arrange
            int x = int.MaxValue;
            int y = int.MaxValue;
            int xFieldLength = int.MaxValue;
            int yFieldLength = int.MaxValue;
            AdjacentConditional adjacent = new AdjacentConditional();

            // Act
            bool result = adjacent.IsOutsideField(x, y, xFieldLength, yFieldLength);

            // Assert
            Assert.IsTrue(result);
        }

        // Test if the IsOutsideField method returns true when the x value is less than 0
        [TestMethod]
        public void AdjacentConditional_IsOutsideField_ReturnsTrueXIsNegative()
        {
            // Arrange
            int x = -1;
            int y = 1;
            int xFieldLength = 10;
            int yFieldLength = 10;
            AdjacentConditional adjacentConditional = new AdjacentConditional();

            // Act
            bool result = adjacentConditional.IsOutsideField(x, y, xFieldLength, yFieldLength);

            // Assert
            Assert.IsTrue(result);
        }

        // Test if the IsOutsideField method returns true when the x value is equal to 0
        [TestMethod]
        public void AdjacentConditional_IsOutsideField_ReturnsFalseIfXEqualTo0()
        {
            // Arrange
            int x = 0;
            int y = 5;
            int xFieldLength = 10;
            int yFieldLength = 10;
            AdjacentConditional adjacentConditional = new AdjacentConditional();

            // Act
            bool result = adjacentConditional.IsOutsideField(x, y, xFieldLength, yFieldLength);

            // Assert
            Assert.IsFalse(result);
        }

        // Test if the IsOutsideField method returns true when the x value is greater than or equal to the field length
        [TestMethod]
        public void AdjacentConditional_IsOutsideField_ReturnsTrueIfXGreaterThanFieldLength()
        {
            // Arrange
            int x = 10;
            int y = 5;
            int xFieldLength = 10;
            int yFieldLength = 10;
            AdjacentConditional adjacent = new AdjacentConditional();

            // Act
            bool result = adjacent.IsOutsideField(x, y, xFieldLength, yFieldLength);

            // Assert
            Assert.IsTrue(result);
        }

        // Test if the IsOutsideField method returns true when the y value is less than 0
        [TestMethod]
        public void AdjacentConditional_IsOutsideField_ReturnsTrueYLessThan0()
        {
            // Arrange
            int x = 5;
            int y = -1;
            int xFieldLength = 10;
            int yFieldLength = 10;
            AdjacentConditional adjacentConditional = new AdjacentConditional();

            // Act
            bool result = adjacentConditional.IsOutsideField(x, y, xFieldLength, yFieldLength);

            // Assert
            Assert.IsTrue(result);
        }

        // Test the IsOutsideField method when the y value is equal to 0
        [TestMethod]
        public void AdjacentConditional_IsOutsideField_ReturnsFalseYEqualTo0()
        {
            // Arrange
            int x = 5;
            int y = 0;
            int xFieldLength = 10;
            int yFieldLength = 10;
            AdjacentConditional adjacentConditional = new AdjacentConditional();

            // Act
            bool result = adjacentConditional.IsOutsideField(x, y, xFieldLength, yFieldLength);

            // Assert
            Assert.IsFalse(result);
        }

        // Test the behavior of the IsOutsideField method when the y value is greater than or equal to the field length
        [TestMethod]
        public void AdjacentConditional_IsOutsideField_ReturnsTrueYGreaterThanFieldLength()
        {
            // Arrange
            int x = 0;
            int y = 10;
            int xFieldLength = 10;
            int yFieldLength = 10;
            AdjacentConditional adjacentConditional = new AdjacentConditional();

            // Act
            bool result = adjacentConditional.IsOutsideField(x, y, xFieldLength, yFieldLength);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
