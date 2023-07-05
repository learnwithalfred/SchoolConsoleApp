namespace MyConsoleApp
{
    // Program.cs

    using Microsoft.Extensions.DependencyInjection;
    using SchoolConsoleApp.Entiteis;
    using SchoolConsoleApp.Factories;

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

                // Resolve the user factory
                Parent parent = userFactory.CreateParent("Mike Johnson", "mike@example.com", "123456789", "456 Elm St", "Male");

                Student student = userFactory.CreateStudent("John Doe", "john@example.com", 16, "Male", "123 Main St", DateTime.Now, parent);
                Student student2 = userFactory.CreateStudent("Felicia Sndras", "felicia@example.com", 16, "Female", "123 Main St", DateTime.Now, parent);

                Teacher teacher = userFactory.CreateTeacher("Jane Smith", "jane@example.com", "Math", "Female", "987654321");

                Console.WriteLine(student);
                Console.WriteLine("----------------------------------------\n");
                Console.WriteLine(parent);
                Console.WriteLine("----------------------------------------\n");
                Console.WriteLine(teacher);
                Console.WriteLine("----------------------------------------\n");
                Classroom classroom = new(2, "Primary two");
                Classroom classroom2 = new(1, "Primary One");

                // Add students to the classroom
                classroom.AddStudent(student);
                classroom.AddStudent(student2);

                // Remove a student from the classroom
                classroom.RemoveStudent(student2);
                classroom.RemoveStudent(student);

                // Get the student count in the classroom
                int studentCount = classroom.GetStudentCount();
                Console.WriteLine($"Student count in classroom {classroom.Name}: {studentCount}");

            }
            else
            {
                // Handle the case when the user factory is null
                Console.WriteLine("Error: Failed to resolve IUserFactory from the DI container.");
            }


        }
    }

}
