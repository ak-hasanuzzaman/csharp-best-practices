using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimCorp.TextManipulation.StringManipulation;

namespace SimCorp.TextManipulation.UnitTestStringManipulation
{
    /// <summary>
    /// These are some very basic test cases only to demonostrate how to build unit test for a feature.
    /// </summary>
    [TestClass()]
    public class UnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFormattedData_NullAsInput()
        {
            //Arrange
            var processInput = new TextManipulate();

            //Act
            var actual = processInput.GetFormattedData(null);

            //Assert
            //Exception expected
        }
        [TestMethod]
        public void GetFormattedData_CountOfOutputItems()
        {
            //Arrange
            var processInput = new TextManipulate();
            var inputText = "Go do that thing that you do so well";
            var expectedCount = 7;

            //Act
            var actual = processInput.GetFormattedData(inputText);

            //Assert
            Assert.AreEqual(actual.Count, expectedCount);

        }
        [TestMethod]
        public void GetFormattedData_CompareFirstItem()
        {
            //Arrange
            var processInput = new TextManipulate();
            var inputText = "Go do that thing that you do so well";
            var expected = "1: Go";

            //Act
            var actual = processInput.GetFormattedData(inputText);

            //Assert
            Assert.AreEqual($"{actual[0].WorkCount}: {actual[0].Word}", expected);

        }
    }
}

