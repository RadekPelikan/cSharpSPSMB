using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Application.Facade;

public class TeacherFacade : ITeacherFacade
{
    // Pouzij repozitare
    private ITeacherRepository _TeacherRepository { get; init; }
    public TeacherDetailModel GetById(int id)
    {
        var teacher = _TeacherRepository.GetById(id);
        return new TeacherDetailModel()
        {
            Id = teacher.Id,
            Name = teacher.Name,
        };
    }

    public ListModel<TeacherModel> GetAll()
    {
        var teachers = c.GetAll();
        ListModel
        return teachers;
    }

    public TeacherDetailModel Create(TeacherEditModel eitMdodel)
    {
        var teacher = _TeacherRepository.Add(new TeacherEntity()
        {
            Name = eitMdodel.Name,
        });
        
        return new TeacherDetailModel()
        {
            Id = teacher.Id,
            Name = teacher.Name,
        };
    }

    public TeacherDetailModel Update(int id, TeacherEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public TeacherDetailModel Delete(int id)
    {
        var teacher = _TeacherRepository.Remove(id);
        return new TeacherDetailModel()
        {
            Id = teacher.Id,
            Name = teacher.Name,
        };
    }
}