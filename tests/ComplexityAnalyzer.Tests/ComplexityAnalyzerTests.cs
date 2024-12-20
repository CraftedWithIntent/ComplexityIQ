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
        /// Given direct array index access,
        /// When the code snippet is analyzed,
        /// Then it should return "O(1) - Constant Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenArrayIndexAccess_WhenDetected_ThenReturnsO1()
        {
            string code = "int value = array[0];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Given dictionary key access,
        /// When the code snippet is analyzed,
        /// Then it should return "O(1) - Constant Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenDictionaryKeyAccess_WhenDetected_ThenReturnsO1()
        {
            string code = "var value = dictionary[\"key\"];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Given a constant return statement,
        /// When the code snippet is analyzed,
        /// Then it should return "O(1) - Constant Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenConstantReturnStatement_WhenDetected_ThenReturnsO1()
        {
            string code = "return 42;";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Given an empty or whitespace code snippet,
        /// When the code snippet is analyzed,
        /// Then it should return "Complexity Undetermined."
        /// </summary>
        [TestMethod]
        public void GivenEmptyCodeSnippet_WhenAnalyzed_ThenReturnsUndetermined()
        {
            string code = "";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        /// <summary>
        /// Given a null code snippet,
        /// When the code snippet is analyzed,
        /// Then it should throw an ArgumentNullException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullCodeSnippet_WhenAnalyzed_ThenThrowsException()
        {
            string code = null;
            ComplexityDetector.Detect(code);
        }

        /// <summary>
        /// Given a code snippet containing only comments,
        /// When the code snippet is analyzed,
        /// Then it should return "Complexity Undetermined."
        /// </summary>
        [TestMethod]
        public void GivenCommentOnlyCode_WhenAnalyzed_ThenReturnsUndetermined()
        {
            string code = "// This is a comment";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        /// <summary>
        /// Given a code snippet without O(1) patterns,
        /// When the code snippet is analyzed,
        /// Then it should return "Complexity Undetermined."
        /// </summary>
        [TestMethod]
        public void GivenCodeWithoutO1Pattern_WhenAnalyzed_ThenReturnsUndetermined()
        {
            string code = "for (int i = 0; i < n; i++) { sum += i; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        /// <summary>
        /// Given array initialization without direct access,
        /// When the code snippet is analyzed,
        /// Then it should return "Complexity Undetermined."
        /// </summary>
        [TestMethod]
        public void GivenArrayInitializationWithoutAccess_WhenAnalyzed_ThenReturnsUndetermined()
        {
            string code = "int[] array = new int[10];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }

        /// <summary>
        /// Given array access within a function body,
        /// When the code snippet is analyzed,
        /// Then it should return "O(1) - Constant Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenArrayAccessInsideFunction_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "int GetValue(int[] array) { return array[2]; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Given nested array access,
        /// When the code snippet is analyzed,
        /// Then it should return "O(1) - Constant Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenChainedArrayAccess_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "var value = array1[array2[5]];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Given array access with arithmetic index calculations,
        /// When the code snippet is analyzed,
        /// Then it should return "O(1) - Constant Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenArrayAccessWithArithmeticIndex_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "int value = array[2 + 3];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Given array access with a large index value,
        /// When the code snippet is analyzed,
        /// Then it should return "O(1) - Constant Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenLargeArrayIndexAccess_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "int value = array[100000];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Given array access within a nested block,
        /// When the code snippet is analyzed,
        /// Then it should return "O(1) - Constant Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenArrayAccessInNestedBlock_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "{ int value = array[3]; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Given array access inside a conditional statement,
        /// When the code snippet is analyzed,
        /// Then it should return "O(1) - Constant Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenArrayAccessInConditional_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "if (condition) { int value = array[0]; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        /// <summary>
        /// Given array access within a ternary expression,
        /// When the code snippet is analyzed,
        /// Then it should return "O(1) - Constant Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenArrayAccessInTernaryExpression_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "int value = condition ? array[1] : array[2];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        // ------------------------------------------------------------
        // Phase 2: O(log n) - Logarithmic Time Complexity Tests
        // ------------------------------------------------------------

        /// <summary>
        /// Given a binary search implementation,
        /// When the code snippet is analyzed,
        /// Then it should return "O(log n) - Logarithmic Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenBinarySearch_WhenAnalyzed_ThenReturnsOLogN()
        {
            string code = @"
                int BinarySearch(int[] arr, int target) {
                    int low = 0, high = arr.Length - 1;
                    while (low <= high) {
                        int mid = low + (high - low) / 2;
                        if (arr[mid] == target) return mid;
                        if (arr[mid] < target) low = mid + 1;
                        else high = mid - 1;
                    }
                    return -1;
                }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(log n) - Logarithmic Time Complexity Detected", result);
        }

        /// <summary>
        /// Given a divide-and-conquer recursive function,
        /// When the code snippet is analyzed,
        /// Then it should return "O(log n) - Logarithmic Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenDivideAndConquer_WhenAnalyzed_ThenReturnsOLogN()
        {
            string code = @"
                int DivideAndConquer(int n) {
                    if (n <= 1) return 1;
                    return DivideAndConquer(n / 2) + DivideAndConquer(n / 2);
                }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(log n) - Logarithmic Time Complexity Detected", result);
        }

        /// <summary>
        /// Given a logarithmic loop (e.g., halving iteration),
        /// When the code snippet is analyzed,
        /// Then it should return "O(log n) - Logarithmic Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenLogarithmicLoop_WhenAnalyzed_ThenReturnsOLogN()
        {
            string code = @"
                for (int i = 1; i < n; i *= 2) {
                    Console.WriteLine(i);
                }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(log n) - Logarithmic Time Complexity Detected", result);
        }

        /// <summary>
        /// Given a mixed iteration pattern with logarithmic behavior,
        /// When the code snippet is analyzed,
        /// Then it should return "O(log n) - Logarithmic Time Complexity Detected."
        /// </summary>
        [TestMethod]
        public void GivenMixedLogarithmicIteration_WhenAnalyzed_ThenReturnsOLogN()
        {
            string code = @"
                int result = 0;
                for (int i = n; i > 0; i /= 2) {
                    result += i;
                }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(log n) - Logarithmic Time Complexity Detected", result);
        }

        /// <summary>
        /// Given an invalid recursive function without divide-and-conquer behavior,
        /// When the code snippet is analyzed,
        /// Then it should return "Complexity Undetermined."
        /// </summary>
        [TestMethod]
        public void GivenNonLogarithmicRecursion_WhenAnalyzed_ThenReturnsUndetermined()
        {
            string code = @"
                int InvalidRecursion(int n) {
                    if (n <= 0) return 1;
                    return InvalidRecursion(n - 1) + 1;
                }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("Complexity Undetermined", result);
        }
    }
}