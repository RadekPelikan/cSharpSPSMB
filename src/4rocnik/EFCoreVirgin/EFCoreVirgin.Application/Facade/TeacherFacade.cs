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
        var teachers = _TeacherRepository.GetAll();
        var result = new ListModel<TeacherModel>
        { 
            Items = teachers.Select(t => new TeacherModel
            {
                Id = t.Id,
                Name = t.Name,
            }).ToList()
        };

        return result;
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
        var teacher = _TeacherRepository.GetById(id);
        
        teacher.Name = editModel.Name;
        
        _TeacherRepository.Update(teacher);
        return new TeacherDetailModel()
        {
            Id = teacher.Id,
            Name = teacher.Name,
        };
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