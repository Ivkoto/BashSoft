using System.IO;

namespace BashSoft.DataStructures
{
    public static class SessionData
    {
        private static string currentPath = Directory.GetCurrentDirectory();

        public static string CurrentPath { get => currentPath; set => currentPath = value; }


    }
}