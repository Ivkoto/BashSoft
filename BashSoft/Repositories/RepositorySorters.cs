using System;
using System.Collections.Generic;

namespace BashSoft.Repositories
{
    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparision, int studentsToTake)
        {
            comparision = comparision.ToLower();
            if (comparision == "ascending")
            {
                OrderAndTake(wantedData, studentsToTake, CompareInOrder);
            }
            else if (comparision == "descending")
            {
                OrderAndTake(wantedData, studentsToTake, CompareDescendingOrder);
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentsToTake,
            Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
        {
            var result = GetSortedStudents(wantedData, studentsToTake, comparisonFunc);
            foreach (var student in result)
            {
                OutputWriter.PrintStudent(student);
            }
        }

        private static Dictionary<string, List<int>> GetSortedStudents (Dictionary<string, List<int>> wantedData, int studentsToTake,
            Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisonFunc)
        {
            int studentsTaken = 0;
            var studentsSorted = new Dictionary<string, List<int>>();
            var nextInOrder = new KeyValuePair<string, List<int>>();
            bool isSorted = false;

            while (studentsTaken < studentsToTake)
            {
                isSorted = true;

                foreach (var studentScore in wantedData)
                {
                    if (!string.IsNullOrEmpty(nextInOrder.Key))
                    {
                        int comparisonResult = comparisonFunc(studentScore, nextInOrder);
                        if (comparisonResult >= 0 && !studentsSorted.ContainsKey(studentScore.Key))
                        {
                            nextInOrder = studentScore;
                            isSorted = false;
                        }
                    }
                    else
                    {
                        if (!studentsSorted.ContainsKey(studentScore.Key))
                        {
                            nextInOrder = studentScore;
                            isSorted = false;
                        }
                    }
                }

                if (!isSorted)
                {
                    studentsSorted.Add(nextInOrder.Key, nextInOrder.Value);
                    studentsTaken++;
                    nextInOrder = new KeyValuePair<string, List<int>>();
                }                
            }

            return studentsSorted;
        }

        private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
        {
            int totalScoresOfFirst = 0;
            foreach (int mark in firstValue.Value)
            {
                totalScoresOfFirst += mark;
            }

            int totalScoreSecond = 0;
            foreach (int mark in secondValue.Value)
            {
                totalScoreSecond += mark;
            }

            return totalScoreSecond.CompareTo(totalScoresOfFirst);
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