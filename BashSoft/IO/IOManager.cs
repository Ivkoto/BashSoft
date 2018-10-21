using System.Collections.Generic;
using System.IO;
using BashSoft.DataStructures;

namespace BashSoft
{
    public static class IOManager
    {
        public static void TraverceDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split('\\').Length;
            var subFolders = new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));

                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
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
            string path = SessionData.currentPath + "\\" + folderName;
            Directory.CreateDirectory(path);
        }
    }
}