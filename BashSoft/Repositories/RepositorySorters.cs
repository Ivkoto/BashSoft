using System.Collections.Generic;
using System.Linq;

namespace BashSoft.Repositories
{
    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparision, int studentsToTake)
        {
            comparision = comparision.ToLower();
            if (comparision == "ascending")
            {
                PrintStudents(wantedData.OrderBy(x => x.Value.Sum())
                                                       .Take(studentsToTake)
                                                       .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparision == "descending")
            {
                PrintStudents(wantedData.OrderByDescending(x => x.Value.Sum())
                                                                       .Take(studentsToTake)
                                                                       .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private static void PrintStudents(Dictionary<string, List<int>> studentsSorted)
        {
            foreach (var keyValuepair in studentsSorted)
            {
                OutputWriter.PrintStudent(keyValuepair);
            }
        }
    }
}