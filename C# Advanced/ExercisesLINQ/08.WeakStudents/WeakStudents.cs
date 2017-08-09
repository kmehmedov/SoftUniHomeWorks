﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentsByGroup
{
    class WeakStudents
    {
        static void Main()
        {
            string input = Console.ReadLine();

            List<Student> allStudents = new List<Student>();

            while (input.ToLower() != "end")
            {
                var tokens = input.Split(' ');
                var firstName = tokens[0];
                var lastName = tokens[1];
                var grades = tokens
                    .Skip(2)
                    .Select(int.Parse)
                    .ToList();

                var student = new Student(firstName, lastName, grades);

                allStudents.Add(student);

                input = Console.ReadLine();
            }

            allStudents
                .Where(s => s.Grades.Where(n => n <= 3).Count() >= 2)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }

    public class Student
    {
        public Student(string firstName, string lastName, List<int> grades)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grades = grades;

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Grades { get; set; }
    }
}
