using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Application.Facade;

public class StudentFacade : IStudentFacade
{
    
    private IStudentRepository _StudentRepository { get; init; }
    private ISubjectRepository _SubjectRepository { get; init; }
    private IClassRepository _ClassRepository { get; init; }
    
    public StudentDetailModel GetById(int id)
    {
        var entity = _StudentRepository.GetById(id);
        var classEntity = _ClassRepository.GetById(entity.ClassId);
        var subjectEntity = _SubjectRepository.GetById();
        
        if (entity == null) return null; 

        return new StudentDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            ClassId = entity.ClassId,
            ClassName = classEntity.Name,
            Subject = new SubjectModel
            {
                Id = ,
                StudentCount = ,
                TeacherCount = 
            }
        };
    }

    public ListModel<StudentModel> GetAll()
    {
        var entities = _StudentRepository.GetAll();
        var classes = _ClassRepository.GetAll();

        var result = new ListModel<StudentModel>
        { 
            Items = entities.Select(t => new StudentModel
            {
                Id = t.Id,
                Name = t.Name,
                ClassId = t.ClassId,
                ClassName = classes
            }).ToList()
        };

        return result;
    }

    public StudentDetailModel Create(StudentEditModel editModel)
    {
        
        var student = _StudentRepository.Add(new StudentEntity()
        {
            Name = editModel.Name,
            ClassId = editModel.ClassId
        });
        
        var className = _ClassRepository.GetById(student.ClassId).Name;
      

        return new StudentDetailModel
        {
            Id = student.Id,
            Name = student.Name,
            ClassId = student.ClassId,
            ClassName = className,
            Subject = null
        };
    }

    public StudentDetailModel Update(int id, StudentEditModel editModel)
    {
        var student = _StudentRepository.GetById(id);
        var classes = _ClassRepository.GetById(student.ClassId);
        
        student.Name = editModel.Name;
        student.ClassId = editModel.ClassId;
        
        _StudentRepository.Update(student);
        return new StudentDetailModel
        {
            Id = student.Id,
            ClassId = student.ClassId,
            Name = student.Name,
            ClassName = classes.Name,
            Subject = null,
        };
    }

    public StudentDetailModel Delete(int id)
    {
        var student = _StudentRepository.Remove(id);
        var classes = _ClassRepository.Remove(student.ClassId);

        return new StudentDetailModel
        {
            Id = student.Id,
            Name = student.Name,
            ClassId = student.ClassId,
            ClassName = classes.Name,
            Subject = null
        };
    }
}