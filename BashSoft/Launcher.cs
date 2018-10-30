using BashSoft.DataStructures;

namespace BashSoft
{
    internal class Launcher
    {
        private static void Main(string[] args)
        {
            //visualising all subfolders in given folder
            //int testDept = 10;
            //IOManager.TraverseDirectory(testDept);

            //this part count all subdirectory in given directory
            //OutputWriter.WriteMessage("Specify directory path: ");
            //var testDirectory = Console.ReadLine();
            //IOManager.countDirectory(testDirectory);

            //initialize student data
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentsFromCourse("Unity");

            //compare text files
            string expectedOutput = @"C:\Users\ikost\Documents\Visual Studio 2017\Projects\BashSoft\BashSoft\SimpleJudge\testFiles\test2.txt";
            string userOutput = @"C:\Users\ikost\Documents\Visual Studio 2017\Projects\BashSoft\BashSoft\SimpleJudge\testFiles\test3.txt";
            Tester.CompareContent(userOutput, expectedOutput);

            //create subdirectory in current directory
            //IOManager.CreateDirectoryInCurrentFolder("Pesho");

            //test traverse directory with curent path
            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(1);
        }
    }
}