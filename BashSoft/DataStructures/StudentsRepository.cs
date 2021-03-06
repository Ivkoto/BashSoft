﻿using BashSoft.DataStructures;
using BashSoft.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace BashSoft
{
    //this class store data for our student database
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;

        //Dictionary<course_name, Dictionary<user_name, scoreOnTasks>>
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private static void ReadData(string fileName)
        {
            string path = SessionData.CurrentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                string pattern = @"([A-Z][A-Za-z+#]*_[A-Z][a-z]{2}_[\d]{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s(\d+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);
                        
                        string course = currentMatch.Groups[1].Value;
                        string student = currentMatch.Groups[2].Value;
                        int studentsScoreOnTask;
                        bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out studentsScoreOnTask);

                        if (hasParsedScore && studentsScoreOnTask >= 0 && studentsScoreOnTask <= 100)
                        {
                            if (!studentsByCourse.ContainsKey(course))
                            {
                                studentsByCourse.Add(course, new Dictionary<string, List<int>>());
                            }

                            if (!studentsByCourse[course].ContainsKey(student))
                            {
                                studentsByCourse[course].Add(student, new List<int>());
                            }

                            studentsByCourse[course][student].Add(studentsScoreOnTask);
                        }                        
                    }
                }
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InvalidPath);
                return;
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayExeptions(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayExeptions(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }

        public static void GetStudentScoresFromCourse(string courseName, string userName)
        {
            if (IsQueryForStudentPossible(courseName, userName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(userName, studentsByCourse[courseName][userName]));
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}..");
                foreach (var studentsMarkEntry in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(studentsMarkEntry);
                }
            }
        }

        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
            }
        }
    }
}