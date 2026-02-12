using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Application.Facade;

public class GradeFacade : IGradeFacade
{
    // Pouzij repozitare
    private IGradeRepository _GradeRepository { get; init; }
    public GradeDetailModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public ListModel<GradeModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public GradeDetailModel Create(GradeEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public GradeDetailModel Update(int id, GradeEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public GradeDetailModel Delete(int id)
    {
        throw new NotImplementedException();
    }
}
