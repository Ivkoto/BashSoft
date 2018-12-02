using System;
using System.Collections.Generic;

namespace BashSoft.Repositories
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData, ExcellentFilter, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, AverageFilter, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, PoorFilter, studentsToTake);
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

                var averagePoint = Average(studentPoints.Value);

                if (givenFilter(averagePoint))
                {
                    OutputWriter.PrintStudent(studentPoints);
                    counterForPrinting++;
                }
            }
        }

        private static bool ExcellentFilter(double mark)
        {
            return mark >= 5.0;
        }

        private static bool AverageFilter(double mark)
        {
            return mark >= 3.5 && mark < 5.0;
        }

        private static bool PoorFilter(double mark)
        {
            return mark < 3.5;
        }

        private static double Average(List<int> scores)
        {
            double totalScore = 0;

            foreach (var curScore in scores)
            {
                totalScore += curScore;
            }

            var percentageOfAll = totalScore / (scores.Count * 100);
            var mark = percentageOfAll * 4 + 2;
            return mark;
        }
    }
}