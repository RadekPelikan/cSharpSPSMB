using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;

namespace EFCoreVirgin.Application.Facade;

public class TeacherFacade : ITeacherFacade
{
    // Pouzij repozitare
    private ITeacherRepository _TeacherRepository { get; init; }
    public TeacherDetailModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public ListModel<TeacherModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public TeacherDetailModel Create(TeacherEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public TeacherDetailModel Update(int id, TeacherEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public TeacherDetailModel Delete(int id)
    {
        throw new NotImplementedException();
    }
}