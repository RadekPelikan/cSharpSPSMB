using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record TimeTableRecordEditModel : IBaseEditModel
{
    
    public string Name { get; set; }

    public int ClassId { get; set; }
}