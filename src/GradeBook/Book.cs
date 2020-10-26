using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var total = 0.0;
            var gradeAverage = 0.0;
            var highestGrade = double.MinValue;
            var lowestGrade = double.MaxValue;

            foreach (var grade in grades)
            {
                total += grade;
                highestGrade = Math.Max(highestGrade, grade);
                lowestGrade = Math.Min(lowestGrade, grade);
            }

            gradeAverage = total / grades.Count;
            
            Console.WriteLine($"The lowest grade is {lowestGrade}");            
            Console.WriteLine($"The highest grade is {highestGrade}");            
            Console.WriteLine($"The average grade is {gradeAverage:N1}");            
        }

        private List<double> grades;
        private string name;
    }

}