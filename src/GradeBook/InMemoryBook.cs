using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args); // TODO Move to a separate file.

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >=0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public event GradeAddedDelegate GradeAdded;

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
    }

}