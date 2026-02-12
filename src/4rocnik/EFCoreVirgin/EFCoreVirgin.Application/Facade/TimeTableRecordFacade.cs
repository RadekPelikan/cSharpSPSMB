using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;

namespace EFCoreVirgin.Application.Facade;

public class TimeTableRecordFacade : ITimeTableRecordFacade
{
    // Pouzij repozitare
    private ITimeTableRecordRepository _recordRepository { get; init; }


    public TimeTableRecordDetailModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public ListModel<TimeTableRecordModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public TimeTableRecordDetailModel Create(TimeTableRecordEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public TimeTableRecordDetailModel Update(int id, TimeTableRecordEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public TimeTableRecordDetailModel Delete(int id)
    {
        throw new NotImplementedException();
    }
}