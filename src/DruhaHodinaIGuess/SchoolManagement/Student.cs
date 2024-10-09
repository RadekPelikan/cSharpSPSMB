namespace SchoolManagement
{
    public class Student : Person
    {
        public string AssignedClass;


        public Student(string name, string assignedClass) : base(name)
        {
            AssignedClass = assignedClass;
        }
    }
}