using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft.Repositories
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData, x => x >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, x => x >= 3.5 && x < 5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinting = 0;

            foreach (var studentPoints in wantedData)
            {
                if (counterForPrinting == studentsToTake)
                {
                    break;
                }

                var averageScores = studentPoints.Value.Average();
                var pecentageOfFullfilment = averageScores / 100;
                var averageMark = pecentageOfFullfilment * 4 + 2;

                if (givenFilter(averageMark))
                {
                    OutputWriter.PrintStudent(studentPoints);
                    counterForPrinting++;
                }
            }
        }
    }
}