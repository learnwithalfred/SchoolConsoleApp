using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Entiteis
{
    public class Classroom
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public List<Student> Students { get; } = new List<Student>();

        public Classroom(int id, string name)
        {
            ID = id;
            Name = name;
            Students = new List<Student>();
        }

        public override string ToString()
        {
            return $"ID: {ID}\nName: {Name}\nStudents: {string.Join(", ", Students.Select(s => s.Name))}";
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        public int GetStudentCount()
        {
            return Students.Count;
        }

        public Student GetStudentByID(int studentID)
        {
            return Students.FirstOrDefault(student => student.ID == studentID);
        }
    }
}
