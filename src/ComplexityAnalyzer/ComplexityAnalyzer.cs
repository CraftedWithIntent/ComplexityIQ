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
            // Match patterns that indicate array access without being an initialization
            if (codeSnippet.Contains("[") && codeSnippet.Contains("]") && !codeSnippet.Contains("new"))
            {
                // Exclude cases where there is an assignment like "int[] array = ..."
                if (codeSnippet.Contains("=") && !codeSnippet.Contains("?")) return false;

                return true;
            }

            return false;
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
