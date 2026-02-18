using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Common.Repository;

public interface ITimeTableRecordRepository : IBaseRepository<TimeTableRecordEntity>
{
    List<TimeTableRecordEntity> GetByClassId(int id);
}