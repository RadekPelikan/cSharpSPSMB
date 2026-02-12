using EFCoreVirgin.Common.Model;

namespace EFCoreVirgin.Common.Facade;

public interface ITimeTableFacade
{
    TimeTableModel GetForClass(int id);
    TimeTableModel GetForTeacher(int id);
    TimeTableModel GetForStudent(int id);
    TimeTableDetailModel GetDetailForClass(int id);
    TimeTableDetailModel GetDetailForTeacher(int id);
    TimeTableDetailModel GetDetailForStudent(int id);
}