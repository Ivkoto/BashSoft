using System;
using System.IO;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {
            OutputWriter.WriteMessage("Specify directory path: ");
            var testDirectory = Console.ReadLine();
            IOManager.TraverceDirectory(testDirectory);
            //IOManager.countDirectory(testDirectory);
        }
    }
}
