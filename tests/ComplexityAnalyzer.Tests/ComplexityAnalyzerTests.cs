// ------------------------------------------------------------
// Copyright (c) CraftedWithIntent.  All rights reserved.
// ------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComplexityAnalyzer.Tests
{
    [TestClass]
    public class ComplexityAnalyzerTests
    {
        [TestMethod]
        public void Detect_ShouldReturnO1_WhenArrayIndexAccess()
        {
            string code = "int value = array[0];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnO1_WhenDictionaryKeyAccess()
        {
            string code = "var value = dictionary[\"key\"];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnO1_WhenConstantReturnStatement()
        {
            string code = "return 42;";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnUndetermined_WhenCodeSnippetIsEmpty()
        {
            string code = "";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Detect_ShouldThrowException_WhenCodeSnippetIsNull()
        {
            string code = null;
            ComplexityDetector.Detect(code);
        }

        [TestMethod]
        public void Detect_ShouldReturnUndetermined_WhenCodeContainsOnlyComments()
        {
            string code = "// This is a comment";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnUndetermined_WhenCodeHasNoO1Pattern()
        {
            string code = "for (int i = 0; i < n; i++) { sum += i; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnUndetermined_WhenArrayInitializedWithoutAccess()
        {
            string code = "int[] array = new int[10];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnO1_WhenArrayAccessInsideFunction()
        {
            string code = "int GetValue(int[] array) { return array[2]; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnO1_WhenChainedArrayAccess()
        {
            string code = "var value = array1[array2[5]];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnO1_WhenArrayAccessWithArithmeticIndex()
        {
            string code = "int value = array[2 + 3];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnO1_WhenLargeArrayIndexAccess()
        {
            string code = "int value = array[100000];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnO1_WhenArrayAccessInNestedBlock()
        {
            string code = "{ int value = array[3]; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnO1_WhenArrayAccessInConditional()
        {
            string code = "if (condition) { int value = array[0]; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void Detect_ShouldReturnO1_WhenArrayAccessInTernaryExpression()
        {
            string code = "int value = condition ? array[1] : array[2];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }
    }
}
