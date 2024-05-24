
using StudentProject.Domain.Common;

namespace StudentProject.Domain.Entities
{
    public class Student: BaseEntity
    {
        public string FullName { get; set; }
        public List<Subject> EnrolledSubjects { get; set; }
        public Student() => EnrolledSubjects = new List<Subject>();
    }
}
