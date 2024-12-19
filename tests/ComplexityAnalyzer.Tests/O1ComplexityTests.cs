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
        /// <summary>
        /// Verifies that direct array index access is detected as O(1) complexity.
        /// </summary>
        [TestMethod]
        public void GivenArrayIndexAccess_WhenDetected_ThenReturnsO1()
        {
            string code = "int value = array[0];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Verifies that dictionary key access is detected as O(1) complexity.
        /// </summary>
        [TestMethod]
        public void GivenDictionaryKeyAccess_WhenDetected_ThenReturnsO1()
        {
            string code = "var value = dictionary[\"key\"];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Verifies that a constant return statement is detected as O(1) complexity.
        /// </summary>
        [TestMethod]
        public void GivenConstantReturnStatement_WhenDetected_ThenReturnsO1()
        {
            string code = "return 42;";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Ensures that an empty or whitespace code snippet returns "Complexity Undetermined."
        /// </summary>
        [TestMethod]
        public void GivenEmptyCodeSnippet_WhenAnalyzed_ThenReturnsUndetermined()
        {
            string code = "";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        /// <summary>
        /// Ensures that a null code snippet throws an ArgumentNullException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullCodeSnippet_WhenAnalyzed_ThenThrowsException()
        {
            string code = null;
            ComplexityDetector.Detect(code);
        }

        /// <summary>
        /// Ensures that code snippets containing only comments return "Complexity Undetermined."
        /// </summary>
        [TestMethod]
        public void GivenCommentOnlyCode_WhenAnalyzed_ThenReturnsUndetermined()
        {
            string code = "// This is a comment";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        /// <summary>
        /// Ensures that code snippets without O(1) patterns return "Complexity Undetermined."
        /// </summary>
        [TestMethod]
        public void GivenCodeWithoutO1Pattern_WhenAnalyzed_ThenReturnsUndetermined()
        {
            string code = "for (int i = 0; i < n; i++) { sum += i; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        /// <summary>
        /// Ensures that array initialization without direct access returns "Complexity Undetermined."
        /// </summary>
        [TestMethod]
        public void GivenArrayInitializationWithoutAccess_WhenAnalyzed_ThenReturnsUndetermined()
        {
            string code = "int[] array = new int[10];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        /// <summary>
        /// Verifies that array access within a function body is detected as O(1) complexity.
        /// </summary>
        [TestMethod]
        public void GivenArrayAccessInsideFunction_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "int GetValue(int[] array) { return array[2]; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Verifies that nested array access is detected as O(1) complexity.
        /// </summary>
        [TestMethod]
        public void GivenChainedArrayAccess_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "var value = array1[array2[5]];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Verifies that array access with arithmetic index calculations is detected as O(1) complexity.
        /// </summary>
        [TestMethod]
        public void GivenArrayAccessWithArithmeticIndex_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "int value = array[2 + 3];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Verifies that array access with a large index value is detected as O(1) complexity.
        /// </summary>
        [TestMethod]
        public void GivenLargeArrayIndexAccess_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "int value = array[100000];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Verifies that array access within a nested block is detected as O(1) complexity.
        /// </summary>
        [TestMethod]
        public void GivenArrayAccessInNestedBlock_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "{ int value = array[3]; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Verifies that array access inside a conditional statement is detected as O(1) complexity.
        /// </summary>
        [TestMethod]
        public void GivenArrayAccessInConditional_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "if (condition) { int value = array[0]; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Verifies that array access within a ternary expression is detected as O(1) complexity.
        /// </summary>
        [TestMethod]
        public void GivenArrayAccessInTernaryExpression_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "int value = condition ? array[1] : array[2];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }
    }
}
