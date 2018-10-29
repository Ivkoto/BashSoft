using BashSoft.DataStructures;
using System.Collections.Generic;
using System.IO;

namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.CurrentPath.Split('\\').Length;
            var subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.CurrentPath);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));

                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }

                //get and write file names for current directory
                foreach (var file in Directory.GetFiles(currentPath))
                {
                    var indexOfLastSplash = file.LastIndexOf('\\');
                    var fileName = file.Substring(indexOfLastSplash);
                    OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSplash) + fileName);
                }

                if (depth - identation < 0)
                {
                    break;
                }
            }
        }

        //this is my test class that is not part of the project
        public static void countDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            var subFolder = new Queue<string>();
            subFolder.Enqueue(path);
            int counter = 0;

            while (subFolder.Count != 0)
            {
                string currentPath = subFolder.Dequeue();
                foreach (var dir in Directory.GetDirectories(currentPath))
                {
                    subFolder.Enqueue(dir);
                    counter++;
                }
            }

            OutputWriter.WriteMessageOnNewLine($"Total directory count: {counter}");
        }

        public static void CreateDirectoryInCurrentFolder(string folderName)
        {
            string path = SessionData.CurrentPath + "\\" + folderName;
            Directory.CreateDirectory(path);
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                string currentPath = SessionData.CurrentPath;
                int indexofLastSlash = currentPath.LastIndexOf('\\');
                string newPath = currentPath.Substring(0, indexofLastSlash);
                SessionData.CurrentPath = newPath;
            }
            else
            {
                string currentPath = SessionData.CurrentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidPath);
                return;
            }

            SessionData.CurrentPath = absolutePath;
        }
    }
}