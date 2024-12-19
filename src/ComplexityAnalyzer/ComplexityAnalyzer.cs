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
            if (codeSnippet.Contains("[") && codeSnippet.Contains("]") && !codeSnippet.Contains("for") && !codeSnippet.Contains("foreach"))
            {
                return "O(1) - Constant Time Complexity Detected";
            }

            // Check for dictionary access pattern
            if (codeSnippet.Contains("dictionary["))
            {
                return "O(1) - Constant Time Complexity Detected";
            }

            // Check for constant return statements
            if (codeSnippet.Trim().StartsWith("return ") && IsConstantValue(codeSnippet.Trim().Substring(7).TrimEnd(';')))
            {
                return "O(1) - Constant Time Complexity Detected";
            }

            // If no pattern matches, return undetermined
            return "Complexity Undetermined";
        }

        private static bool IsConstantValue(string value)
        {
            // Check if the value is a numeric literal or similar constant
            return int.TryParse(value, out _) || double.TryParse(value, out _) || IsCharLiteral(value);
        }

        private static bool IsCharLiteral(string value)
        {
            // Check if the value is a valid character literal, e.g., 'a'
            return value.Length == 3 && value.StartsWith("'") && value.EndsWith("'");
        }

        private static bool IsArrayAccess(string codeSnippet)
        {
            if (codeSnippet.Contains("[") && codeSnippet.Contains("]"))
            {
                if (codeSnippet.Contains("new") || codeSnippet.Contains("="))
                {
                    return false;
                }
                return true;
            }
            return false;
        }

    }
}
