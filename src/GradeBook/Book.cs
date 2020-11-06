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
            if (grade <= 100 && grade >=0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
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

            switch (result.Average)
            {
                case var d when d >= 90.0:
                result.Letter = 'A';
                break;

                case var d when d >= 80.0:
                result.Letter = 'B';
                break;

                case var d when d >= 70.0:
                result.Letter = 'C';
                break;

                case var d when d >= 60.0:
                result.Letter = 'D';
                break;

                default:
                result.Letter = 'F';
                break;
            }
            
            return result;            
        }

        private List<double> grades;
        public string Name;
    }

}