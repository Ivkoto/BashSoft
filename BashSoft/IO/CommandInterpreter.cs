using BashSoft.DataStructures;
using System.Diagnostics;

namespace BashSoft.IO
{
    public static class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0];

            switch (command)
            {
                case "open":
                    TryOpenFile(input, data);
                    break;

                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;

                case "ls":
                    TryTraverseFolders(input, data);
                    break;

                case "cmp":
                    TryCompareFiles(input, data);
                    break;

                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;

                case "cdAbs":
                    TryChangePathAbsolute(input, data);
                    break;

                case "readDb":
                    TryReadDataBaseFromFile(input, data);
                    break;

                case "help":
                    TryGetHelp(input, data);
                    break;

                case "filter":
                    //TODO
                    break;

                case "order":
                    //TODO
                    break;

                case "decOrder":
                    //TODO
                    break;

                case "download":
                    //TODO
                    break;

                case "downloadAsync":
                    //TODO
                    break;

                default:
                    OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
                    break;
            }
        }

        private static void TryGetHelp(string input, string[] data)
        {
            if (data.Length == )
            {
                //TODO
            }
            else
            {
                //DisplayInavlidCommandMessage(input)
            }
        }

        private static void TryReadDataBaseFromFile(string input, string[] data)
        {
            if (data.Length == )
            {
                //TODO
            }
            else
            {
                //DisplayInavlidCommandMessage(input)
            }
        }

        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == )
            {
                //TODO
            }
            else
            {
                //DisplayInavlidCommandMessage(input)
            }
        }

        private static void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == )
            {
                //TODO
            }
            else
            {
                //DisplayInavlidCommandMessage(input)
            }
        }

        private static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == )
            {
                //TODO
            }
            else
            {
                //DisplayInavlidCommandMessage(input)
            }
        }

        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == )
            {
                //TODO
            }
            else
            {
                //DisplayInavlidCommandMessage(input)
            }
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }

        private static void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(SessionData.CurrentPath + "\\" + fileName);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }
    }
}