using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Repositories
{
    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> studentsWithScores, string sorter, int studentsToTake)
        {

        }

        private static void OrderAndTake(Dictionary<string, List<int>> studentsWithScores, int studentsToTake, 
            Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
        {

        }

        private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
        {
            int totalCoresOfFirst = 0;
            foreach (int mark in firstValue.Value)
            {
                totalCoresOfFirst += mark;
            }

            int totalScoreSecond = 0;
            foreach (int mark in secondValue.Value)
            {
                totalScoreSecond += mark;
            }

            return totalScoreSecond.CompareTo(totalCoresOfFirst);
        }

        private static int CompareDescendingOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
        {
            int totalScoresOfFirst = 0;
            foreach (int mark in firstValue.Value)
            {
                totalScoresOfFirst += mark;
            }

            int totalScoresOfSecond = 0;
            foreach (int mark in secondValue.Value)
            {
                totalScoresOfSecond += mark;
            }

            return totalScoresOfFirst.CompareTo(totalScoresOfSecond);
        }
    }
}
