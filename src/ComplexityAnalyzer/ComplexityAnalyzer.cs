// ------------------------------------------------------------
// Copyright (c) CraftedWithIntent.  All rights reserved.
// ------------------------------------------------------------
using System;

namespace ComplexityAnalyzer
{
    public static class ComplexityDetector
    {
        /// <summary>
        /// Detects the time complexity of a given code snippet.
        /// </summary>
        /// <param name="codeSnippet">The code snippet to analyze.</param>
        /// <returns>A string indicating the detected complexity or "Complexity Undetermined."</returns>
        public static string Detect(string codeSnippet)
        {
            if (string.IsNullOrWhiteSpace(codeSnippet))
            {
                return codeSnippet == null
                    ? throw new ArgumentNullException(nameof(codeSnippet), "Code snippet cannot be null.")
                    : "Complexity Undetermined";
            }

            string normalizedCode = NormalizeCode(codeSnippet);

            // Phase 8: Factorial complexity detection
            if (IsFactorialComplexity(normalizedCode))
            {
                return "O(n!) - Factorial Time Complexity Detected";
            }

            // Phase 7: Exponential complexity detection
            if (IsExponentialComplexity(normalizedCode))
            {
                return "O(2ⁿ) - Exponential Time Complexity Detected";
            }

            // Phase 6: Cubic complexity detection
            if (IsCubicComplexity(normalizedCode))
            {
                return "O(n³) - Cubic Time Complexity Detected";
            }

            // Phase 5: Quadratic complexity detection
            if (IsQuadraticComplexity(normalizedCode))
            {
                return "O(n²) - Quadratic Time Complexity Detected";
            }

            // Phase 4: Linearithmic complexity detection
            if (IsLinearithmicComplexity(normalizedCode))
            {
                return "O(n log n) - Linearithmic Time Complexity Detected";
            }

            // Phase 2: Logarithmic complexity detection
            if (IsLogarithmicComplexity(normalizedCode))
            {
                return "O(log n) - Logarithmic Time Complexity Detected";
            }

            // Phase 3: Linear complexity detection
            if (IsLinearComplexity(normalizedCode))
            {
                return "O(n) - Linear Time Complexity Detected";
            }

            // Phase 1: Constant complexity detection
            if (IsConstantComplexity(normalizedCode))
            {
                return "O(1) - Constant Time Complexity Detected";
            }

            return "Complexity Undetermined";
        }

        /// <summary>
        /// Normalizes the code snippet for consistent analysis by removing unnecessary whitespace and line breaks.
        /// </summary>
        private static string NormalizeCode(string codeSnippet)
        {
            return codeSnippet.Replace("\n", "").Replace("\r", "").Trim();
        }

        // Phase 1: Constant Time Complexity Detection
        private static bool IsConstantComplexity(string codeSnippet)
        {
            return IsDirectArrayAccess(codeSnippet) || IsConstantReturnStatement(codeSnippet);
        }

        private static bool IsDirectArrayAccess(string codeSnippet)
        {
            return codeSnippet.Contains("[") && codeSnippet.Contains("]") && !codeSnippet.Contains("new");
        }

        private static bool IsConstantReturnStatement(string codeSnippet)
        {
            return codeSnippet.StartsWith("return") && codeSnippet.EndsWith(";") && IsConstantValue(codeSnippet.Substring(7).TrimEnd(';'));
        }

        private static bool IsConstantValue(string value)
        {
            return int.TryParse(value, out _) || double.TryParse(value, out _);
        }

        // Phase 2: Logarithmic Time Complexity Detection
        private static bool IsLogarithmicComplexity(string codeSnippet)
        {
            return IsBinarySearchPattern(codeSnippet) || IsLogarithmicLoop(codeSnippet) || IsDivideAndConquerPattern(codeSnippet);
        }

        private static bool IsBinarySearchPattern(string codeSnippet)
        {
            return codeSnippet.Contains("while") &&
                   codeSnippet.Contains("low") &&
                   codeSnippet.Contains("high") &&
                   codeSnippet.Contains("mid") &&
                   codeSnippet.Contains("/") &&
                   codeSnippet.Contains("<=") &&
                   codeSnippet.Contains("return");
        }

        private static bool IsLogarithmicLoop(string codeSnippet)
        {
            return codeSnippet.Contains("for") && (codeSnippet.Contains("i *= 2") || codeSnippet.Contains("i /= 2"));
        }

        private static bool IsDivideAndConquerPattern(string codeSnippet)
        {
            return codeSnippet.Contains("return") &&
                   codeSnippet.Contains("(") &&
                   codeSnippet.Contains(")") &&
                   (codeSnippet.Contains("n / 2") || codeSnippet.Contains("n >> 1")) &&
                   codeSnippet.Contains("if");
        }

        // Phase 3: Linear Time Complexity Detection
        private static bool IsLinearComplexity(string codeSnippet)
        {
            return ContainsSingleLoop(codeSnippet) && !IsNestedLoop(codeSnippet, 2);
        }

        private static bool ContainsSingleLoop(string codeSnippet)
        {
            int loopCount = CountLoops(codeSnippet);
            return loopCount == 1;
        }

        private static int CountLoops(string codeSnippet)
        {
            int forCount = CountOccurrences(codeSnippet, "for (");
            int whileCount = CountOccurrences(codeSnippet, "while (");
            int foreachCount = CountOccurrences(codeSnippet, "foreach (");

            return forCount + whileCount + foreachCount;
        }

        private static int CountOccurrences(string source, string substring)
        {
            int count = 0;
            int index = source.IndexOf(substring, StringComparison.Ordinal);
            while (index != -1)
            {
                count++;
                index = source.IndexOf(substring, index + substring.Length, StringComparison.Ordinal);
            }
            return count;
        }

        private static bool IsNestedLoop(string codeSnippet, int nestingLevel)
        {
            int loopCount = CountLoops(codeSnippet);
            return loopCount >= nestingLevel;
        }

        // Phase 4: Linearithmic Time Complexity Detection
        private static bool IsLinearithmicComplexity(string codeSnippet)
        {
            return IsSortingPattern(codeSnippet) || IsMergeSortPattern(codeSnippet);
        }

        private static bool IsSortingPattern(string codeSnippet)
        {
            return codeSnippet.Contains("Array.Sort") || codeSnippet.Contains("List.Sort");
        }

        private static bool IsMergeSortPattern(string codeSnippet)
        {
            return codeSnippet.Contains("return") &&
                   codeSnippet.Contains("(") &&
                   codeSnippet.Contains(")") &&
                   codeSnippet.Contains("merge") &&
                   codeSnippet.Contains("sort");
        }

        // Phase 5: Quadratic Time Complexity Detection
        private static bool IsQuadraticComplexity(string codeSnippet)
        {
            return IsNestedLoop(codeSnippet, 2);
        }

        // Phase 6: Cubic Time Complexity Detection
        private static bool IsCubicComplexity(string codeSnippet)
        {
            return IsNestedLoop(codeSnippet, 3);
        }

        // Phase 7: Exponential Time Complexity Detection
        private static bool IsExponentialComplexity(string codeSnippet)
        {
            return codeSnippet.Contains("f(n-1)") && codeSnippet.Contains("f(n-2)") && codeSnippet.Contains("return");
        }

        // Phase 8: Factorial Time Complexity Detection
        private static bool IsFactorialComplexity(string codeSnippet)
        {
            return codeSnippet.Contains("Permutations") ||
                   codeSnippet.Contains("factorial") ||
                   (codeSnippet.Contains("for") && codeSnippet.Contains("!"));
        }
    }
}