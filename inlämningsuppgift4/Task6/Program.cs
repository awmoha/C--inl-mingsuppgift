using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Course { get; set; }
    public int Grade { get; set; }

    public Student(string name, DateTime birthDate, string course, int grade)
    {
        Name = name;
        BirthDate = birthDate;
        Course = course;
        Grade = grade;
    }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        Console.WriteLine("Welcome to the Student Management System!");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add a new student");
            Console.WriteLine("2. Check whether a student is on the list");
            Console.WriteLine("3. Search for students in 'C# Programming' course");
            Console.WriteLine("4. Display a sorted list of all students");
            Console.WriteLine("5. Remove a student from the list");
            Console.WriteLine("6. Exit");

            int choice = GetChoice(1, 6);

            switch (choice)
            {
                case 1:
                    AddNewStudent();
                    break;
                case 2:
                    CheckStudentOnList();
                    break;
                case 3:
                    SearchAndDisplayStudentsByCourse("C# Programming");
                    break;
                case 4:
                    DisplaySortedStudents();
                    break;
                case 5:
                    RemoveStudent();
                    break;
                case 6:
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
            }
        }
    }

    static int GetChoice(int min, int max)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
        {
            Console.WriteLine($"Please enter a number between {min} and {max}.");
        }
        return choice;
    }

    static void AddNewStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter birth date (YYYY-MM-DD): ");
        DateTime birthDate;
        while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
        {
            Console.WriteLine("Invalid date format. Please enter a valid date (YYYY-MM-DD): ");
        }

        Console.Write("Enter course: ");
        string course = Console.ReadLine();

        Console.Write("Enter grade: ");
        int grade;
        while (!int.TryParse(Console.ReadLine(), out grade))
        {
            Console.WriteLine("Invalid grade. Please enter a valid number: ");
        }

        students.Add(new Student(name, birthDate, course, grade));
        Console.WriteLine($"Student {name} added successfully.");
    }

    static void CheckStudentOnList()
    {
        Console.Write("Enter student name to check: ");
        string name = Console.ReadLine();

        bool isStudentOnList = students.Any(student => student.Name == name);
        Console.WriteLine($"Is {name} on the list? {isStudentOnList}");
    }

    static void SearchAndDisplayStudentsByCourse(string course)
    {
        var studentsInCourse = students.Where(student => student.Course == course);

        Console.WriteLine($"Students enrolled in {course}:");

        foreach (var student in studentsInCourse)
        {
            Console.WriteLine($"{student.Name}: Grade {student.Grade}");
        }
    }

    static void DisplaySortedStudents()
    {
        var sortedStudents = students.OrderBy(student => student.Name);

        Console.WriteLine("Sorted list of students:");

        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.Name}: Grade {student.Grade}");
        }
    }

    static void RemoveStudent()
    {
        Console.Write("Enter student name to remove: ");
        string name = Console.ReadLine();

        var studentToRemove = students.FirstOrDefault(student => student.Name == name);

        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
            Console.WriteLine($"Student {name} removed successfully.");
        }
        else
        {
            Console.WriteLine($"Student {name} not found in the list.");
        }
    }
}
