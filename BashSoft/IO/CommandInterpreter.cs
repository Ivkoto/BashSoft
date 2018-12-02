using BashSoft.DataStructures;
using System;
using System.Diagnostics;

namespace BashSoft.IO
{
    public static class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0].ToLower();

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

                case "cdrel":
                    TryChangePathRelatively(input, data);
                    break;

                case "cdabs":
                    TryChangePathAbsolute(input, data);
                    break;

                case "readdb":
                    TryReadDataBaseFromFile(input, data);
                    break;

                case "help":
                    TryGetHelp(input, data);
                    break;

                case "show":
                    TryShowWantedData(input, data);
                    break;

                case "filter":
                    TryFilterAndTake(input, data);
                    break;

                case "order":
                    TryOrderAndTake(input, data);
                    break;

                case "decorder":
                    //TODO
                    break;

                case "download":
                    //TODO
                    break;

                case "downloadasync":
                    //TODO
                    break;

                default:
                    OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
                    break;
            }
        }

        private static void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string studentName = data[2];
                StudentsRepository.GetStudentScoresFromCourse(courseName, studentName);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }

        private static void TryGetHelp(string input, string[] data)
        {
            if (data.Length == 1)
            {
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 124)}");
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "make directory - mkdir: path "));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "traverse directory - ls: depth "));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "comparing files - cmp: path1 path2"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "change directory - cdRel: relative path or .."));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "change directory - cdAbs: absolute path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "read students data base - readDb: path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "display data entities - display: students/courses ascending/descending"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "filter {courseName} excelent/average/poor  take 2/5/all - filterExcelent (the output is written on the console)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "download file - download: path of file (saved in current directory)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -122}|", "get help – help"));
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 124)}");
                OutputWriter.WriteEmptyLine();
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }

        private static void TryReadDataBaseFromFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                StudentsRepository.InitializeData(fileName);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }

        private static void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string absPath = data[1];

                IOManager.ChangeCurrentDirectoryAbsolute(absPath);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }

        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string relPath = data[1];
                IOManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }

        private static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                string firstPath = data[1];
                string secondPath = data[2];

                Tester.CompareContent(firstPath, secondPath);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }

        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(data[1], out depth);
                if (hasParsed)
                {
                    IOManager.TraverseDirectory(depth);
                }
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.UnableToParseNumber);
            }
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string folerName = data[1];
                IOManager.CreateDirectoryInCurrentFolder(folerName);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }

        private static void TryOpenFile(string input, string[] data)
        {
            try
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
            catch (Exception ex)
            {
                OutputWriter.DisplayExeptions(ex.Message);
            }
        }

        private static void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForFilterAndtake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }

        private static void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string order = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantiy = data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQuantiy, courseName, order);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidCommandMessage(input));
            }
        }

        private static void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantiy, string courseName, string order)
        {
            if (takeCommand == "take")
            {
                if (takeQuantiy == "all")
                {
                    StudentsRepository.OrderAndTake(courseName, order);
                }
                else
                {
                    int studetsToTake;
                    bool isParsed = int.TryParse(takeQuantiy, out studetsToTake);
                    if (isParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, order, studetsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayExeptions(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
        }

        private static void TryParseParametersForFilterAndtake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool isParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (isParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayExeptions(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }
    }
}