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
            if (codeSnippet.StartsWith("return ") && !codeSnippet.Contains(";"))
            {
                return "O(1) - Constant Time Complexity Detected";
            }

            // If no pattern matches, return undetermined
            return "Complexity Undetermined";
        }
    }
}
