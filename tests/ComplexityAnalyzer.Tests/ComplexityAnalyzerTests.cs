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
        // PHASE 1: O(1) Tests
        [TestMethod]
        public void GivenArrayIndexAccess_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "int value = array[0];";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        [TestMethod]
        public void GivenConstantReturnStatement_WhenAnalyzed_ThenReturnsO1()
        {
            string code = "return 42;";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(1) - Constant Time Complexity Detected", result);
        }

        // PHASE 2: O(log n) Tests
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

        [TestMethod]
        public void GivenLogarithmicLoop_WhenAnalyzed_ThenReturnsOLogN()
        {
            string code = "for (int i = 1; i < n; i *= 2) { sum += i; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(log n) - Logarithmic Time Complexity Detected", result);
        }

        // PHASE 3: O(n) Tests
        [TestMethod]
        public void GivenSingleLoop_WhenAnalyzed_ThenReturnsON()
        {
            string code = "for (int i = 0; i < n; i++) { sum += i; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(n) - Linear Time Complexity Detected", result);
        }

        [TestMethod]
        public void GivenWhileLoop_WhenAnalyzed_ThenReturnsON()
        {
            string code = "while (i < n) { i++; }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(n) - Linear Time Complexity Detected", result);
        }

        // PHASE 4: O(n log n) Tests
        [TestMethod]
        public void GivenSortingAlgorithm_WhenAnalyzed_ThenReturnsNLogN()
        {
            string code = "Array.Sort(array);";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(n log n) - Linearithmic Time Complexity Detected", result);
        }

        [TestMethod]
        public void GivenMergeSort_WhenAnalyzed_ThenReturnsNLogN()
        {
            string code = @"
                void MergeSort(int[] array) {
                    if (array.Length <= 1) return;
                    int mid = array.Length / 2;
                    int[] left = array.Take(mid).ToArray();
                    int[] right = array.Skip(mid).ToArray();
                    MergeSort(left);
                    MergeSort(right);
                    Merge(array, left, right);
                }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(n log n) - Linearithmic Time Complexity Detected", result);
        }

        // PHASE 5: O(n²) Tests
        [TestMethod]
        public void GivenNestedLoops_WhenAnalyzed_ThenReturnsON2()
        {
            string code = "for (int i = 0; i < n; i++) { for (int j = 0; j < n; j++) { sum += i + j; } }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(n²) - Quadratic Time Complexity Detected", result);
        }

        [TestMethod]
        public void GivenQuadraticMatrixTraversal_WhenAnalyzed_ThenReturnsON2()
        {
            string code = "for (int i = 0; i < matrix.Length; i++) { for (int j = 0; j < matrix[i].Length; j++) { Process(matrix[i][j]); } }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(n²) - Quadratic Time Complexity Detected", result);
        }

        // PHASE 6: O(n³) Tests
        [TestMethod]
        public void GivenTripleNestedLoops_WhenAnalyzed_ThenReturnsON3()
        {
            string code = "for (int i = 0; i < n; i++) { for (int j = 0; j < n; j++) { for (int k = 0; k < n; k++) { sum += i + j + k; } } }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(n³) - Cubic Time Complexity Detected", result);
        }

        [TestMethod]
        public void GivenCubicMatrixTraversal_WhenAnalyzed_ThenReturnsON3()
        {
            string code = "for (int i = 0; i < cube.Length; i++) { for (int j = 0; j < cube[i].Length; j++) { for (int k = 0; k < cube[i][j].Length; k++) { Process(cube[i][j][k]); } } }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(n³) - Cubic Time Complexity Detected", result);
        }

        // PHASE 7: O(2ⁿ) Tests
        [TestMethod]
        public void GivenExponentialRecursion_WhenAnalyzed_ThenReturnsO2N()
        {
            string code = @"
                int Fibonacci(int n) {
                    if (n <= 1) return n;
                    return Fibonacci(n - 1) + Fibonacci(n - 2);
                }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(2ⁿ) - Exponential Time Complexity Detected", result);
        }

        // PHASE 8: O(n!) Tests
        [TestMethod]
        public void GivenPermutations_WhenAnalyzed_ThenReturnsONFactorial()
        {
            string code = @"
                void Permutations(char[] str, int l, int r) {
                    if (l == r) Console.WriteLine(new string(str));
                    else {
                        for (int i = l; i <= r; i++) {
                            Swap(ref str[l], ref str[i]);
                            Permutations(str, l + 1, r);
                            Swap(ref str[l], ref str[i]);
                        }
                    }
                }";
            string result = ComplexityDetector.Detect(code);
            Assert.AreEqual("O(n!) - Factorial Time Complexity Detected", result);
        }
    }
}