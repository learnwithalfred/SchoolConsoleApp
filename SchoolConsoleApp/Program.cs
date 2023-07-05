using Microsoft.Extensions.DependencyInjection;
using SchoolConsoleApp.Entiteis;
using SchoolConsoleApp.Factories;
using SchoolConsoleApp.Services;
using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the DI container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IUserFactory, UserFactory>()
                .BuildServiceProvider();

            var userFactory = serviceProvider.GetService<IUserFactory>();

            if (userFactory != null)
            {
                // Create parent
                Parent parent = userFactory.CreateParent("Mike Johnson", "mike@example.com", "123456789", "456 Elm St", "Male");

                // Create students
                Student student = userFactory.CreateStudent("John Doe", "john@example.com", 16, "Male", "123 Main St", DateTime.Now, parent);
                Student student2 = userFactory.CreateStudent("Felicia Sndras", "felicia@example.com", 16, "Female", "123 Main St", DateTime.Now, parent);

                // Create teacher
                Teacher teacher = userFactory.CreateTeacher("Jane Smith", "jane@example.com", "Math", "Female", "987654321");

                // Print student, parent, and teacher details
                Console.WriteLine(student);
                Console.WriteLine("----------------------------------------\n");
                Console.WriteLine(parent);
                Console.WriteLine("----------------------------------------\n");
                Console.WriteLine(teacher);
                Console.WriteLine("----------------------------------------\n");

                // Create classrooms
                Classroom classroom = new Classroom(2, "Primary Two");
                Classroom classroom2 = new Classroom(1, "Primary One");

                // Add students to the classroom
                classroom.AddStudent(student);
                classroom.AddStudent(student2);

                // Remove a student from the classroom
                // classroom.RemoveStudent(student2);
                classroom.RemoveStudent(student);

                // Get the student count in the classroom
                int studentCount = classroom.GetStudentCount();
                Console.WriteLine($"Student count in classroom {classroom.Name}: {studentCount}");

                // Create a bill service
                BillService billService = new BillService();

                // Create bills
                billService.CreateBill(1, "Canteen", "Term one bill", 1000, DateTime.Now, classroom);
                billService.CreateBill(2, "Canteen", "Term two bill", 2000, DateTime.Now, classroom);

                // Assign bills to students in the classroom
                billService.AssignBillsToClassroomStudents(classroom);

                // Calculate the total bill amount for a student
                decimal totalBillAmount2 = student.CalculateTotalBillAmount();
                Console.WriteLine($"Total bill amount for {student2.Name}: {totalBillAmount2}");

                Console.WriteLine("=========================\n");

                // Calculate the total bill amount for another student
                decimal totalBillAmount3 = student2.CalculateTotalBillAmount();
                Console.WriteLine($"Total bill amount for {student2.Name}: {totalBillAmount3}");

                Console.WriteLine("===================------===================\n");

                // Calculate the total bill amount
                decimal totalBillAmount = billService.CalculateTotalBillAmount();
                Console.WriteLine($"Total bill amount: {totalBillAmount}");

                // Calculate the total bill amount by type
                decimal totalCanteenBillAmount = billService.CalculateTotalBillAmountByType("Canteen");
                Console.WriteLine($"Total canteen bill amount: {totalCanteenBillAmount}");
            }
            else
            {
                // Handle the case when the user factory is null
                Console.WriteLine("Error: Failed to resolve IUserFactory from the DI container.");
            }
        }
    }
}
