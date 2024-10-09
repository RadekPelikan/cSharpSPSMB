using System.Collections.Generic;

namespace SchoolManagement
{
    public class School
    {
        public List<Teacher> Teachers = new List<Teacher>();
        public List<Student> Students = new List<Student>();
        public List<ClassRoom> ClassRooms;

        public School(List<string> classRoomNames)
        {
            foreach (var classRoomName in classRoomNames)
            {
                ClassRooms.Add(new ClassRoom(classRoomName));
            }
        }

        public School(List<ClassRoom> classRooms)
        {
            ClassRooms = classRooms;
        }

        public void HireTeacher(Teacher hiredTeacher)
        {
            Teachers.Add(hiredTeacher);
        }

        public void AcceptStudent(Student acceptedStudent)
        {
            Students.Add(acceptedStudent);
        }
    }
}