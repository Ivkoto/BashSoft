using BashSoft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleJudje
{
    class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            string mismatchPath = GetMismatchPath(expectedOutputPath);

            string[] actualOutputLines = File.ReadAllLines(userOutputPath);
            string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

            bool hasMismatches;
            string[] mismatches = GetLineWithPossibleMismatche(actualOutputLines, expectedOutputLines, out hasMismatches);

            PrintOutput(mismatches, hasMismatches, mismatchPath);
            OutputWriter.WriteMessageOnNewLine("Files read!");
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            return directoryPath + @"\Mismatches.txt";
        }

        private static string[] GetLineWithPossibleMismatche(string[] actialOutputLines, string[] expectedOutputLines, out bool hasMismatches)
        {

        }

        private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {

        }
    }
}
