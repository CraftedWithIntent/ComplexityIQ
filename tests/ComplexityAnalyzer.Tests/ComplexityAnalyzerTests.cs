// ------------------------------------------------------------
// Copyright (c) CraftedWithIntent.  All rights reserved.
// ------------------------------------------------------------

using Xunit;

namespace ComplexityAnalyzer.Tests
{
    public class ComplexityAnalyzerTests
    {
        [Fact]
        public void Detect_ShouldReturnO1_WhenCodeContainsDirectArrayAccess()
        {
            string code = "int value = array[5];";
            string result = ComplexityDetector.Detect(code);

            Assert.Equal("O(1) - Constant Time Complexity Detected", result);
        }

        [Fact]
        public void Detect_ShouldReturnUndetermined_WhenCodeIsUnrecognized()
        {
            string code = "int sum = 0;";
            string result = ComplexityDetector.Detect(code);

            Assert.Equal("Complexity Undetermined", result);
        }
    }
}

