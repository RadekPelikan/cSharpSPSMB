using EFCoreVirgin.Common.Facade;
using EFCoreVirgin.Common.Model;
using EFCoreVirgin.Common.Repository;

namespace EFCoreVirgin.Application.Facade;

public class StudentFacade : IStudentFacade
{
    // Pouzij repozitare
    private IStudentRepository _StudentRepository { get; init; }
    
    public StudentDetailModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public ListModel<StudentModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public StudentDetailModel Create(StudentEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public StudentDetailModel Update(int id, StudentEditModel editModel)
    {
        throw new NotImplementedException();
    }

    public StudentDetailModel Delete(int id)
    {
        throw new NotImplementedException();
    }
}