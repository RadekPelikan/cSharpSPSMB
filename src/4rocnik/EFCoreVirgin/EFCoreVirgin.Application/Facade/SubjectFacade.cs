using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Application.Facade;

public class SubjectFacade : ISubjectFacade
{
    private readonly IBaseRepository<SubjectEntity> _subjectRepository;

    public SubjectFacade(IBaseRepository<SubjectEntity> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }
    
    public SubjectDetailModel GetById(int id)
    {
        var entity = _subjectRepository.GetById(id);
        if (entity == null) return null;

        return MapToDetailModel(entity);
    }

    public ListModel<SubjectModel> GetAll()
    {
        var entities = _subjectRepository.GetAll();
        return new ListModel<SubjectModel>
        {
            Items = entities.Select(MapToModel).ToList()
        };
    }

    public SubjectDetailModel Create(SubjectEditModel editModel)
    {
        var entity = new SubjectEntity
        {
            Name = editModel.Name
        };

        var created = _subjectRepository.Add(entity);
        return MapToDetailModel(created);
    }

    public SubjectDetailModel Update(int id, SubjectEditModel editModel)
    {
        var entity = _subjectRepository.GetById(id);
        if (entity == null) return null;

        entity.Name = editModel.Name;
        var updated = _subjectRepository.Update(entity);

        return MapToDetailModel(updated);
    }

    public SubjectDetailModel Delete(int id)
    {
        var removed = _subjectRepository.Remove(id);
        if (removed == null) return null;

        return MapToDetailModel(removed);
    }
    
    private static SubjectModel MapToModel(SubjectEntity entity)
        => new SubjectModel
        {
            Id = entity.Id,
            Name = entity.Name,
            StudentCount = 0,
            TeacherCount = 0
        };

    private static SubjectDetailModel MapToDetailModel(SubjectEntity entity)
        => new SubjectDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            StudentCount = 0,
            TeacherCount = 0,
            Students = null
        };
}