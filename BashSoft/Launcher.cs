﻿namespace BashSoft
{
    internal class Launcher
    {
        private static void Main(string[] args)
        {
            //this is test code for visualising and counting all subfolders in given folder
            //OutputWriter.WriteMessage("Specify directory path: ");
            //var testDirectory = Console.ReadLine();
            //IOManager.TraverceDirectory(testDirectory);
            //IOManager.countDirectory(testDirectory);

            StudentsRepository.InitializeData();
            StudentsRepository.GetAllStudentsFromCourse("Unity");

            //TODO
            Tester.CompareContent("");
        }
    }
}