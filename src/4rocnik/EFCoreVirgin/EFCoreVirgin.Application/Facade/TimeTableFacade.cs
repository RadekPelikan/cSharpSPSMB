using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;

namespace EFCoreVirgin.Application.Facade;

public class TimeTableFacade: ITimeTableFacade
{
    // Pouzij repozitare
    private ISubjectRepository SubjectRepository { get; init; }
    private ITeacherRepository TeacherRepository { get; init; }
    private IStudentRepository StudentRepository { get; init; }
    public TimeTableModel GetForClass(int id)
    {
        throw new NotImplementedException();
    }

    public TimeTableModel GetForTeacher(int id)
    {
        throw new NotImplementedException();
    }

    public TimeTableModel GetForStudent(int id)
    {
        throw new NotImplementedException();
    }

    public TimeTableDetailModel GetDetailForClass(int id)
    {
        throw new NotImplementedException();
    }

    public TimeTableDetailModel GetDetailForTeacher(int id)
    {
        throw new NotImplementedException();
    }

    public TimeTableDetailModel GetDetailForStudent(int id)
    {
        throw new NotImplementedException();
    }
}