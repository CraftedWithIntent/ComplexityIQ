// ------------------------------------------------------------
// Copyright (c) CraftedwithIntent.  All rights reserved.
// ------------------------------------------------------------
namespace ComplexityAnalyzer
{
    public static class ComplexityDetector
    {
        public static string Detect(string codeSnippet)
        {
            // Simplified detection logic for O(1)
            if (codeSnippet.Contains("array["))
            {
                return "O(1) - Constant Time Complexity Detected";
            }
            return "Complexity Undetermined";
        }
    }
}
