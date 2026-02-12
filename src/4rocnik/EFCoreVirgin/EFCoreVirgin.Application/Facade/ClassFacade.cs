using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Application.Facade;

public class ClassFacade : IClassFacade
{
    // Pouzij repozitare
    private IClassRepository _classRepository { get; init; }

    public ClassFacade(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }
    public ClassDetailModel GetById(int id)
    {
        var entity = _classRepository.GetById(id);
        if (entity == null)
            throw new KeyNotFoundException($"Class with id {id} not found.");

        return new ClassDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Students = entity.Students?.Select(s => new StudentModel
            {
                Id = s.Id,
                Name = s.Name,
                ClassName = null
            }).ToList(),
        };
    }

    public ListModel<ClassModel> GetAll()
    {
        var entities = _classRepository.GetAll();
        var models = entities.Select(e => new ClassModel { Id = e.Id, Name = e.Name }).ToList();
        return new ListModel<ClassModel> { Items = models };
    }

    public ClassDetailModel Create(ClassEditModel editModel)
    {
        if (editModel == null)
            throw new ArgumentNullException(nameof(editModel));

        var entity = new ClassEntity { Name = editModel.Name };
        var created = _classRepository.Add(entity);

        return new ClassDetailModel
        {
            Id = created.Id,
            Name = created.Name,
            Students = new List<StudentModel>()
        };
    }

    public ClassDetailModel Update(int id, ClassEditModel editModel)
    {
        if (editModel == null)
            throw new ArgumentNullException(nameof(editModel));

        var entity = _classRepository.GetById(id);
        if (entity == null)
            throw new KeyNotFoundException($"Class with id {id} not found.");

        entity.Name = editModel.Name;
        var updated = _classRepository.Update(entity);

        return new ClassDetailModel
        {
            Id = updated.Id,
            Name = updated.Name,
            Students = updated.Students?.Select(s => new StudentModel
            {
                Id = s.Id,
                Name = s.Name,
                ClassName = null
            }).ToList()
        };
    }


    public ClassDetailModel Delete(int id)
    {
        var entity = _classRepository.GetById(id);
        if (entity == null)
            throw new KeyNotFoundException($"Class with id {id} not found.");

        var deleted = _classRepository.Remove(id);

        return new ClassDetailModel
        {
            Id = deleted.Id,
            Name = deleted.Name,
            Students = deleted.Students?.Select(s => new StudentModel
            {
                Id = s.Id,
                Name = s.Name,
                ClassName = deleted.Name
            }).ToList()
        };
    }

}
