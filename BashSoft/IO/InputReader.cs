using BashSoft.DataStructures;
using System;

namespace BashSoft.IO
{
    public static class InputReader
    {
        private const string endCommand = "quit";
        public static void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.CurrentPath}>");
            string input = Console.ReadLine().Trim();

            while (input != endCommand)
            {
                CommandInterpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}>");
                input = Console.ReadLine().Trim();
            }
        }
    }
}