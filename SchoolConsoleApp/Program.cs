using Microsoft.Extensions.DependencyInjection;
using SchoolConsoleApp.Entiteis;
using SchoolConsoleApp.Factories;
using SchoolConsoleApp.Services;
using System;

namespace SchoolConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the DI container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IUserFactory, UserFactory>()
                .AddSingleton<IBillService, BillService>()
                .AddSingleton<IPaymentService, PaymentService>()
                .BuildServiceProvider();

            var userFactory = serviceProvider.GetService<IUserFactory>();
            var billService = serviceProvider.GetService<IBillService>();
            var paymentService = serviceProvider.GetService<IPaymentService>();

            if (userFactory != null && paymentService!= null && billService != null)
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

                // Add students to the classroom
                classroom.AddStudent(student);
                classroom.AddStudent(student2);

                // Remove a student from the classroom
                // classroom.RemoveStudent(student2);
                classroom.RemoveStudent(student);

                // Get the student count in the classroom
                int studentCount = classroom.GetStudentCount();
                Console.WriteLine($"Student count in classroom {classroom.Name}: {studentCount}");

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

                // Create some example students
                var student1 = userFactory.CreateStudent("John Doe", "john@example.com", 16, "Male", "123 Main St", DateTime.Now, parent);

                // Create some example bills
                var bill1 = new Bill(1, "Canteen", "Term one bill", 1000, DateTime.Parse("2023-01-20"), null);
                var bill2 = new Bill(2, "School Fees", "Term two bill", 2000, DateTime.Parse("2023-04-10"), null);

                Console.WriteLine("==========******=========********************=========*******==========\n");

                // Assign bills to students
                student1.AddBill(bill1);
                student1.AddBill(bill2);
                student2.AddBill(bill1);

                // Add some example payments
                paymentService.AddPayment(1, student1.ID, 500, bill1.ID);
                paymentService.AddPayment(2, student1.ID, 800, bill2.ID);
                paymentService.AddPayment(3, student2.ID, 900, bill1.ID);

                // Calculate total payment for a student
                decimal totalPaymentForStudent = paymentService.CalculateTotalPaymentForStudent(student1);
                Console.WriteLine($"Total payment for student1: {totalPaymentForStudent}");

                // Calculate total payment amount
                decimal totalPaymentAmount = paymentService.CalculateTotalPaymentAmount();
                Console.WriteLine($"Total payment amount: {totalPaymentAmount}");
            }
            else
            {
                // Handle the case when the user factory is null
                Console.WriteLine("Error: Failed to resolve IUserFactory from the DI container.");
            }
        }
    }
}
