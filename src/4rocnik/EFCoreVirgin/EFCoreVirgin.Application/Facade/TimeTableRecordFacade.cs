using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Application.Facade;

public class TimeTableRecordFacade : ITimeTableRecordFacade
{
    // Pouzij repozitare
    private ITimeTableRecordRepository _recordRepository { get; init; }

    public TimeTableRecordFacade(ITimeTableRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public TimeTableRecordDetailModel GetById(int id)
    {
        var entity = _recordRepository.GetById(id);
        return new TimeTableRecordDetailModel(){Id = entity.Id, StartTime = entity.StartTime, MinuteDuration = entity.MinuteDuration};
    }

    public ListModel<TimeTableRecordModel> GetAll()
    {
        var entities = _recordRepository.GetAll();
        ListModel<TimeTableRecordModel> model = new ListModel<TimeTableRecordModel>(); 
        foreach (var entity in entities)
        {
            model.Items.Add(new TimeTableRecordModel(){Id = entity.Id, StartTime = entity.StartTime, MinuteDuration = entity.MinuteDuration});
        }
        return model;
    }

    public TimeTableRecordDetailModel Create(TimeTableRecordEditModel editModel)
    {
        var entity = _recordRepository.Add(new TimeTableRecordEntity()
        {
            StartTime = editModel.StartTime,
            MinuteDuration = editModel.MinuteDuration
        });

        return new TimeTableRecordDetailModel()
        {
            Id = entity.Id,
            StartTime = entity.StartTime,
            MinuteDuration = entity.MinuteDuration
        };
    }

    public TimeTableRecordDetailModel Update(int id, TimeTableRecordEditModel editModel)
    {
        var entity = _recordRepository.GetById(id);
        entity.StartTime = editModel.StartTime;
        entity.MinuteDuration = editModel.MinuteDuration;
        _recordRepository.Update(entity);

        return new TimeTableRecordDetailModel() {Id = entity.Id, StartTime = entity.StartTime,  MinuteDuration = entity.MinuteDuration};
    }

    public TimeTableRecordDetailModel Delete(int id)
    {
        var entity = _recordRepository.Remove(id);
        return new TimeTableRecordDetailModel() {Id = entity.Id, StartTime = entity.StartTime, MinuteDuration = entity.MinuteDuration};
    }
}