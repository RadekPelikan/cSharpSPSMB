using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Application.Facade;

public class SubjectFacade : ISubjectFacade
{
    // Pouzij repozitare
    private ISubjectRepository _SubjectRepository { get; init; }
    public SubjectDetailModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public ListModel<SubjectModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public SubjectDetailModel Create(SubjectEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public SubjectDetailModel Update(int id, SubjectEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public SubjectDetailModel Delete(int id)
    {
        throw new NotImplementedException();
    }
}