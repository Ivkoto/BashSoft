using BashSoft.DataStructures;

namespace BashSoft
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

            //StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentsFromCourse("Unity");

            //string expectedOutput = @"C:\Users\ikost\Documents\Visual Studio 2017\Projects\BashSoft\BashSoft\SimpleJudge\testFiles\test1.txt";
            //string userOutput = @"C:\Users\ikost\Documents\Visual Studio 2017\Projects\BashSoft\BashSoft\SimpleJudge\testFiles\test3.txt";
            //Tester.CompareContent(userOutput, expectedOutput);

            IOManager.CreateDirectoryInCurrentFolder("Pesho");
        }
    }
}