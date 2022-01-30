using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codec.Library;

namespace Codec.Tests
{
    [TestClass]
    public class PositionTests
    {
        [DataTestMethod]
        [DataRow("FFFFFFFFFF", FacingDirection.North)]
        [DataRow("LFFFFFFFFF", FacingDirection.West)]
        [DataRow("LLFFFFFFFF", FacingDirection.South)]
        [DataRow("LLLFFFFFFF", FacingDirection.East)]
        [DataRow("LLLLFFFFFF", FacingDirection.North)]
        [DataRow("RFFFFFFFFF", FacingDirection.East)]
        [DataRow("RRFFFFFFFF", FacingDirection.South)]
        [DataRow("RRRFFFFFFF", FacingDirection.West)]
        [DataRow("RRRRFFFFFF", FacingDirection.North)]

        public void Move_AlwaysForwardSameDirection_SameFacing(string movements, FacingDirection expected)
        {
            // Arrange
            var robot = new Robot();

            // Act
            var position = robot.Move("10x10", movements);

            // Assert
            Assert.AreEqual(expected, position.Facing);
        }

        [DataTestMethod]
        [DataRow("FFFFLLFFFF")]
        [DataRow("FFFFRRFFFF")]
        public void Move_GoFrontAndReturnSamePositionYAxis_StartPositionOfYAxis(string movements)
        {
            // Arrange
            var robot = new Robot();

            // Act
            var position = robot.Move("10x10", movements);

            // Assert
            Assert.AreEqual(1, position.y);
        }

        [DataTestMethod]
        [DataRow("RFFFFRRFFFF")]
        [DataRow("RFFFFLLFFFF")]
        public void Move_GoFrontAndReturnSamePositionXAxis_StartPositionOfXAxis(string movements)
        {
            // Arrange
            var robot = new Robot();

            // Act
            var position = robot.Move("10x10", movements);

            // Assert
            Assert.AreEqual(1, position.x);
        }

        [DataTestMethod]
        [DataRow("FFFFFF")]
        [DataRow("RFFFFF")]
        [DataRow("RRFFFF")]
        [DataRow("RRRFFF")]
        [DataRow("RRRRFF")]
        [DataRow("LFFFFF")]
        [DataRow("LLFFFF")]
        [DataRow("LLLFFF")]
        [DataRow("LLLLFF")]
        public void Move_IgnoreAllMovementsInPlateau1x1_Position1(string movements)
        {
            // Arrange
            var robot = new Robot();

            // Act
            var position = robot.Move("1x1", movements);

            // Assert
            Assert.AreEqual(1, position.x);
            Assert.AreEqual(1, position.y);
        }

        [DataTestMethod]
        [DataRow("FLFLFLF")]
        [DataRow("FRFRFRF")]
        public void Move_WalkingInASquare_Position1(string movements)
        {
            // Arrange
            var robot = new Robot();

            // Act
            var position = robot.Move("1x1", movements);

            // Assert
            Assert.AreEqual(1, position.x);
            Assert.AreEqual(1, position.y);
        }

        [DataTestMethod]
        [DataRow("FFFLFFF")]
        [DataRow("FFLLFFF")]
        [DataRow("FFLLLFF")]
        [DataRow("FFFRFFF")]
        [DataRow("FFRRFFF")]
        [DataRow("FFRRRFF")]
        public void Move_GoOutOfPlateau_IgnoreMovementsReturnInitialPosition(string movements)
        {
            // Arrange
            var robot = new Robot();

            // Act
            var position = robot.Move("1x1", movements);

            // Assert
            Assert.AreEqual(1, position.x);
            Assert.AreEqual(1, position.y);
        }
    }
}