// ------------------------------------------------------------
// Copyright (c) CraftedWithIntent.  All rights reserved.
// ------------------------------------------------------------
using System;

namespace ComplexityAnalyzer
{
    public static class ComplexityDetector
    {
        public static string Detect(string codeSnippet)
        {
            if (codeSnippet == null)
            {
                throw new ArgumentNullException(nameof(codeSnippet), "Code snippet cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(codeSnippet))
            {
                return "Complexity Undetermined";
            }

            // Normalize code snippet for consistent analysis
            string normalizedCode = NormalizeCode(codeSnippet);


            if (IsBinarySearchPattern(normalizedCode) || IsLogarithmicLoop(normalizedCode) || IsDivideAndConquerPattern(normalizedCode))
            {
                return "O(log n) - Logarithmic Time Complexity Detected";
            }

            // Check for O(1) complexity
            if (IsDirectArrayAccess(normalizedCode) || IsConstantReturnStatement(normalizedCode))
            {
                return "O(1) - Constant Time Complexity Detected";
            }

            // Default case
            return "Complexity Undetermined";
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

        // Helper methods
        private static bool IsBinarySearchPattern(string codeSnippet)
        {
            // Simplified detection for binary search pattern
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
            // Check for loop patterns with exponential growth or halving logic
            return codeSnippet.Contains("for") &&
                   codeSnippet.Contains(";") &&
                   (codeSnippet.Contains("i *= 2") || codeSnippet.Contains("i /= 2"));
        }

        private static string NormalizeCode(string codeSnippet)
        {
            // Simplify code for easier detection (remove whitespace, comments, etc.)
            return codeSnippet.Replace("\n", "").Replace("\r", "").Trim();
        }

        private static bool IsLogarithmicRecursion(string codeSnippet)
        {
            return codeSnippet.Contains("n/2") && codeSnippet.Contains("return");
        }

        private static bool IsLinearLoop(string codeSnippet)
        {
            return codeSnippet.Contains("for(") && codeSnippet.Contains("i++");
        }

        private static bool IsDivideAndConquerPattern(string codeSnippet)
        {
            // Simplified detection for recursive divide-and-conquer methods
            return codeSnippet.Contains("return") &&
                   codeSnippet.Contains("(") &&
                   codeSnippet.Contains(")") &&
                   (codeSnippet.Contains("n / 2") || codeSnippet.Contains("n >> 1")) &&
                   codeSnippet.Contains("if") &&
                   codeSnippet.Contains("else");
        }

        private static bool IsSortingPattern(string codeSnippet)
        {
            return codeSnippet.Contains("Array.Sort") || codeSnippet.Contains("List.Sort");
        }

        private static bool IsNestedLoop(string codeSnippet, int nestingLevel)
        {
            int loopCount = 0;
            foreach (var token in codeSnippet.Split('('))
            {
                if (token.Contains("for") || token.Contains("while"))
                {
                    loopCount++;
                }
            }
            return loopCount >= nestingLevel;
        }

        private static bool IsExponentialRecursion(string codeSnippet)
        {
            return codeSnippet.Contains("f(n-1)") && codeSnippet.Contains("f(n-2)");
        }

        private static bool IsFactorialPattern(string codeSnippet)
        {
            return codeSnippet.Contains("Permutations") || codeSnippet.Contains("factorial");
        }
    }
}