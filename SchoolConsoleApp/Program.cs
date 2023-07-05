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

                Teacher teacher = userFactory.CreateTeacher("Jane Smith", "jane@example.com", "Math", "Female", "987654321");

                Console.WriteLine(student.Name);
                Console.WriteLine(parent.Name);
                Console.WriteLine(teacher.PhoneNumber);

            }
            else
            {
                // Handle the case when the user factory is null
                Console.WriteLine("Error: Failed to resolve IUserFactory from the DI container.");
            }
        }
    }

}
