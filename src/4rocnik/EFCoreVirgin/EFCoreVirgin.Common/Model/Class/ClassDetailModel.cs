using EFCoreVirgin.Common.Model.Base;

namespace EFCoreVirgin.Common.Model;

public record ClassDetailModel : ClassEditModel, IBaseDetailModel
{
    public required int Id { get; set; }

    public int StudentCount => Students?.Count ?? 0;

    public required List<StudentModel>? Students { get; set; } = new List<StudentModel>();
}