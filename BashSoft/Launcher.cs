using System;
using System.IO;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var testDirectory = @"C:\Users\ikost\Documents\Visual Studio 2017\Projects\BashSoft\BashSoft";
            IOManager.TraverceDirectory(testDirectory);
        }
    }
}
