using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Common.Repository;

public interface IClassRepository : IBaseRepository<ClassEntity>
{
    List<ClassEntity> GetByTeacherId(int teacherId);
}