using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Common.Repository;

public class StudentRepository : IBaseRepository<StudentEntity>
{
    public StudentEntity GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<StudentEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public StudentEntity Add(StudentEntity entity)
    {
        throw new NotImplementedException();
    }

    public StudentEntity Update(StudentEntity entity)
    {
        throw new NotImplementedException();
    }

    public StudentEntity Remove(int id)
    {
        throw new NotImplementedException();
    }
}