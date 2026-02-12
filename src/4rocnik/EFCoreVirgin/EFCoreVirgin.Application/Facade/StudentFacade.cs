using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Application.Facade;

public class StudentFacade : IStudentFacade
{
    // Pouzij repozitare
    private IStudentRepository _StudentRepository { get; init; }

    public StudentDetailModel GetById(int id)
    {
        var entity = _StudentRepository.GetById(id);

        if (entity == null) return null; // Or throw exception

        // Step 2: Map Entity -> DetailModel
        return new StudentDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            ClassId = entity.ClassId
        };
    }

    public ListModel<StudentModel> GetAll()
    {
        var entities = _StudentRepository.GetAll();

        // Step 2: Map List<Entity> -> List<StudentModel>
        var studentModels = entities.Select(e => new StudentModel
        {
            Id = e.Id,
            Name = e.Name,
            ClassId = e.ClassId
        }).ToList();

        // Step 3: Wrap in your ListModel
        return new ListModel<StudentModel>
        {
            Items = studentModels
        };
    }

    public StudentDetailModel Create(StudentEditModel editModel)
    {
        
        var student = _StudentRepository.Add(new StudentEntity()
        {
            Name = editModel.Name,
            ClassId = editModel.ClassId
        });


        return new StudentDetailModel()
        {
            Id = student.Id,
            Name = student.Name,
            ClassId = student.ClassId
        };
    }

    public StudentDetailModel Update(int id, StudentEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public StudentDetailModel Delete(int id)
    {
        var student = _StudentRepository.GetById(id);

        return new StudentDetailModel
        {
            Id = student.Id,
            Name = student.Name,
            ClassId = student.ClassId
        };
    }
}