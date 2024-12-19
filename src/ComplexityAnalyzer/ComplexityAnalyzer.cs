// ------------------------------------------------------------
// Copyright (c) CraftedwithIntent.  All rights reserved.
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
                // Throw exception for null input as expected
                throw new ArgumentNullException(nameof(codeSnippet), "Code snippet cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(codeSnippet))
            {
                // Handle empty or whitespace input
                return "Complexity Undetermined";
            }

            // Check for direct array access
            if (IsDirectArrayAccess(codeSnippet))
            {
                return "O(1) - Constant Time Complexity Detected";
            }

            // Check for dictionary key access
            if (codeSnippet.Contains("dictionary["))
            {
                return "O(1) - Constant Time Complexity Detected";
            }

            // Check for constant return statements
            if (IsConstantReturnStatement(codeSnippet))
            {
                return "O(1) - Constant Time Complexity Detected";
            }

            // If no pattern matches, return undetermined
            return "Complexity Undetermined";
        }

        private static bool IsDirectArrayAccess(string codeSnippet)
        {
            // Normalize the code snippet (remove line breaks, extra spaces)
            string normalizedCode = codeSnippet.Replace("\n", "").Replace("\r", "").Trim();

            // Match patterns that indicate array access
            if (normalizedCode.Contains("[") && normalizedCode.Contains("]"))
            {
                // Exclude array initializations like "int[] array = new int[10];"
                if (normalizedCode.Contains("new")) return false;

                // Check for array access inside conditionals or blocks
                if (normalizedCode.Contains("if (") || normalizedCode.Contains("{") || normalizedCode.Contains("}"))
                {
                    string innerCode = ExtractInnerBlock(normalizedCode);
                    return IsDirectArrayAccess(innerCode);
                }

                return true;
            }

            return false;
        }

        private static string ExtractInnerBlock(string codeSnippet)
        {
            // Extract the inner block of a conditional or nested structure
            int openBraceIndex = codeSnippet.IndexOf("{");
            int closeBraceIndex = codeSnippet.LastIndexOf("}");
            if (openBraceIndex != -1 && closeBraceIndex != -1)
            {
                return codeSnippet.Substring(openBraceIndex + 1, closeBraceIndex - openBraceIndex - 1).Trim();
            }
            return codeSnippet;
        }

        private static bool IsConstantReturnStatement(string codeSnippet)
        {
            // Check if the snippet starts with 'return', contains a constant, and ends with a semicolon
            if (codeSnippet.TrimStart().StartsWith("return ") && codeSnippet.TrimEnd().EndsWith(";"))
            {
                string value = codeSnippet.Trim().Substring(7).TrimEnd(';');
                return IsConstantValue(value);
            }

            return false;
        }

        private static bool IsConstantValue(string value)
        {
            // Check if the value is numeric or a character literal
            return int.TryParse(value, out _) || double.TryParse(value, out _) || IsCharLiteral(value);
        }

        private static bool IsCharLiteral(string value)
        {
            // Check for valid character literals like 'a'
            return value.Length == 3 && value.StartsWith("'") && value.EndsWith("'");
        }
    }
}
