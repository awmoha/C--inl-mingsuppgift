// MainPage.xaml.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Inlämningsuppgift4_task_8
{
    public sealed partial class MainPage : Page
    {
        private List<Student> students;

        public MainPage()
        {
            this.InitializeComponent();
            students = new List<Student>
            {
                new Student("Louise Boller", 1990, 6, 14, "C# Programming", 8),
                // Add more initial students here
            };
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to add a new student
            string name = NameTextBox.Text;
            int birthYear, birthMonth, birthDay, grade;

            // Handle parsing errors gracefully
            if (!int.TryParse(BirthYearTextBox.Text, out birthYear) ||
                !int.TryParse(BirthMonthTextBox.Text, out birthMonth) || birthMonth < 1 || birthMonth > 12 ||
                !int.TryParse(BirthDayTextBox.Text, out birthDay) ||
                !int.TryParse(GradeTextBox.Text, out grade))
            {
                resultText.Text = "Invalid input. Please enter valid numeric values.";
                return;
            }

            string course = CourseTextBox.Text;

            Student newStudent = new Student(name, birthYear, birthMonth, birthDay, course, grade);
            students.Add(newStudent);

            // Clear the TextBox controls
            ClearTextBoxes();

            // Update the TextBlock to show the result
            resultText.Text = $"New student '{name}' added with grade {grade}.";
        }

        private void ClearTextBoxes()
        {
            // Helper method to clear TextBox controls
            NameTextBox.Text = BirthYearTextBox.Text = BirthMonthTextBox.Text = BirthDayTextBox.Text = CourseTextBox.Text = GradeTextBox.Text = string.Empty;
        }


        private void CheckStudent_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to check if a student is on the list
            string searchName = NameTextBox.Text;

            bool isStudentOnList = students.Any(student => student.Name == searchName);

            if (isStudentOnList)
            {
                resultText.Text = $"{searchName} is on the list.";
            }
            else
            {
                resultText.Text = $"{searchName} is not on the list.";
            }
        }

        private void SearchStudents_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to search for students in a specific course
            string searchCourse = CourseTextBox.Text;

            var matchingStudents = students.Where(student => student.Course == searchCourse).ToList();

            if (matchingStudents.Count > 0)
            {
                resultText.Text = "Students in " + searchCourse + ":\n";
                foreach (var student in matchingStudents)
                {
                    resultText.Text += $"{student.Name}, Grade: {student.Grade}\n";
                }
            }
            else
            {
                resultText.Text = $"No students found in {searchCourse}.";
            }
        }

        private void DisplaySortedList_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to display a sorted list of students
            var sortedStudents = students.OrderBy(student => student.Name).ToList();

            resultText.Text = "Sorted List of Students:\n";
            foreach (var student in sortedStudents)
            {
                resultText.Text += $"{student.Name}, Grade: {student.Grade}\n";
            }
        }

        private void RemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to remove a student from the list
            string removeName = NameTextBox.Text;

            var studentToRemove = students.FirstOrDefault(student => student.Name == removeName);

            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                resultText.Text = $"{removeName} has been removed from the list.";
            }
            else
            {
                resultText.Text = $"{removeName} is not on the list.";
            }
        }
    }

    public class Student
    {
        public string Name { get; }
        public int BirthYear { get; }
        public int BirthMonth { get; }
        public int BirthDay { get; }
        public string Course { get; }
        public int Grade { get; }

        public Student(string name, int birthYear, int birthMonth, int birthDay, string course, int grade)
        {
            Name = name;
            BirthYear = birthYear;
            BirthMonth = birthMonth;
            BirthDay = birthDay;
            Course = course;
            Grade = grade;
        }
    }
}
