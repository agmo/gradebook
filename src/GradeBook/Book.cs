using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            var total = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                total += grade;
                result.High = Math.Max(result.High, grade);
                result.Low = Math.Min(result.Low, grade);
            }

            result.Average = total / grades.Count;
            
            return result;            
        }

        private List<double> grades;
        public string Name;
    }

}