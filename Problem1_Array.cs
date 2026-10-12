using System;

namespace Problem1
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
            Student[] students = new Student[10];
            int studentCount = 0;
            int choice = 0;

            while (choice != 6)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("        STUDENT RECORD MANAGEMENT");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
                Console.WriteLine();
                Console.Write("Enter choice: ");
                int.TryParse(Console.ReadLine(), out choice);
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddStudent(students, ref studentCount);
                        break;
                    case 2:
                        DisplayAll(students, studentCount);
                        break;
                    case 3:
                        SearchStudent(students, studentCount);
                        break;
                    case 4:
                        UpdateStudent(students, studentCount);
                        break;
                    case 5:
                        DeleteStudent(students, ref studentCount);
                        break;
                    case 6:
                        Console.WriteLine("Program exited.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static int FindStudent(Student[] students, int count, string studentNumber)
        {
            for (int i = 0; i < count; i++)
            {
                if (students[i].StudentNumber == studentNumber)
                {
                    return i;
                }
            }
            return -1;
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

        static void AddStudent(Student[] students, ref int count)
        {
            if (count == students.Length)
            {
                Console.WriteLine("Cannot add more students. The list is full (10 students).");
                return;
            }

            Console.Write("Enter Student Number: ");
            string number = Console.ReadLine();

            if (FindStudent(students, count, number) != -1)
            {
                Console.WriteLine("Student number already exists.");
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

            students[count] = s;
            count++;

            Console.WriteLine();
            Console.WriteLine("Student added successfully!");
        }

        static void DisplayAll(Student[] students, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("No student records found.");
                return;
            }

            Console.WriteLine("========================================");
            Console.WriteLine("            STUDENT RECORDS");
            Console.WriteLine("========================================");
            for (int i = 0; i < count; i++)
            {
                PrintStudent(students[i]);
                Console.WriteLine();
            }
        }

        static void SearchStudent(Student[] students, int count)
        {
            Console.Write("Enter Student Number to search: ");
            int index = FindStudent(students, count, Console.ReadLine());

            if (index == -1)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Student Found!");
            PrintStudent(students[index]);
        }

        static void UpdateStudent(Student[] students, int count)
        {
            Console.Write("Enter Student Number to update: ");
            int index = FindStudent(students, count, Console.ReadLine());

            if (index == -1)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter new Name: ");
            students[index].Name = Console.ReadLine();
            Console.Write("Enter new Program: ");
            students[index].Program = Console.ReadLine();
            students[index].YearLevel = ReadYearLevel();

            Console.WriteLine();
            Console.WriteLine("Student updated successfully!");
        }

        static void DeleteStudent(Student[] students, ref int count)
        {
            Console.Write("Enter Student Number to delete: ");
            int index = FindStudent(students, count, Console.ReadLine());

            if (index == -1)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            for (int i = index; i < count - 1; i++)
            {
                students[i] = students[i + 1];
            }
            count--;
            students[count] = new Student();

            Console.WriteLine();
            Console.WriteLine("Student deleted successfully!");
        }
    }
}
