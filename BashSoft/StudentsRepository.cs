﻿using System;
using System.Collections.Generic;

namespace BashSoft
{
    //this class store data for our needs
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;

        //Dictionary<course_name, Dictionary<user_name, scoreOnTasks>>
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData()
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private static void ReadData()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] tokens = input.Split(' ');
                string course = tokens[0];
                string student = tokens[1];
                int mark = int.Parse(tokens[2]);

                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse.Add(course, new Dictionary<string, List<int>>());
                }

                if (!studentsByCourse[course].ContainsKey(student))
                {
                    studentsByCourse[course].Add(student, new List<int>());
                }

                studentsByCourse[course][student].Add(mark);

                input = Console.ReadLine();
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
    }
}