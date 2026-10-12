using System;
using System.Collections.Generic;

namespace Problem2
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    class Program
    {
        static void Main()
        {
            Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();
            int choice = 0;

            while (choice != 4)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("     STUDENT LOOKUP USING DICTIONARY");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                Console.Write("Enter choice: ");
                int.TryParse(Console.ReadLine(), out choice);
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddStudent(studentDictionary);
                        break;
                    case 2:
                        SearchStudent(studentDictionary);
                        break;
                    case 3:
                        DisplayAll(studentDictionary);
                        break;
                    case 4:
                        Console.WriteLine("Program exited.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static int ReadYearLevel()
        {
            int year;
            Console.Write("Enter Year Level: ");
            while (!int.TryParse(Console.ReadLine(), out year) || year < 1 || year > 4)
            {
                Console.Write("Year level must be 1, 2, 3, or 4. Try again: ");
            }
            return year;
        }

        static void PrintStudent(Student s)
        {
            Console.WriteLine("Student Number: " + s.StudentNumber);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Program: " + s.Program);
            Console.WriteLine("Year Level: " + s.YearLevel);
        }

        static void AddStudent(Dictionary<string, Student> studentDictionary)
        {
            Console.Write("Enter Student Number: ");
            string number = Console.ReadLine();

            if (studentDictionary.ContainsKey(number))
            {
                Console.WriteLine("Student number already exists. Duplicate not allowed.");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Program: ");
            string program = Console.ReadLine();
            int year = ReadYearLevel();

            Student s = new Student();
            s.StudentNumber = number;
            s.Name = name;
            s.Program = program;
            s.YearLevel = year;

            studentDictionary.Add(number, s);

            Console.WriteLine();
            Console.WriteLine("Student added successfully!");
        }

        static void SearchStudent(Dictionary<string, Student> studentDictionary)
        {
            Console.Write("Enter Student Number to search: ");
            string number = Console.ReadLine();

            Student found;
            if (studentDictionary.TryGetValue(number, out found))
            {
                Console.WriteLine();
                Console.WriteLine("Student Found!");
                PrintStudent(found);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void DisplayAll(Dictionary<string, Student> studentDictionary)
        {
            if (studentDictionary.Count == 0)
            {
                Console.WriteLine("No student records found.");
                return;
            }

            Console.WriteLine("========================================");
            Console.WriteLine("            STUDENT RECORDS");
            Console.WriteLine("========================================");
            foreach (KeyValuePair<string, Student> item in studentDictionary)
            {
                PrintStudent(item.Value);
                Console.WriteLine();
            }
        }
    }
}
