using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Application.Facade;

public class ClassFacade : IClassFacade
{
    // Pouzij repozitare
    private IClassRepository _ClassRepository { get; init; }
    public ClassDetailModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public ListModel<ClassModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public ClassDetailModel Create(ClassEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public ClassDetailModel Update(int id, ClassEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public ClassDetailModel Delete(int id)
    {
        throw new NotImplementedException();
    }
}
