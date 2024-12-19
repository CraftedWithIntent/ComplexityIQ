// ------------------------------------------------------------
// Copyright (c) CraftedWithIntent.  All rights reserved.
// ------------------------------------------------------------

namespace ComplexityAnalyzer.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class ComplexityAnalyzerTests
    {
        [TestMethod]
        public void Detect_ShouldReturnO1_WhenCodeContainsDirectArrayAccess()
        {
            // Arrange
            string code = "int value = array[5];";

            // Act
            string result = ComplexityDetector.Detect(code);

            // Assert
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnUndetermined_WhenCodeIsUnrecognized()
        {
            // Arrange
            string code = "int sum = 0;";

            // Act
            string result = ComplexityDetector.Detect(code);

            // Assert
            Assert.AreEqual("Complexity Undetermined", result);
        }
    }
}


