namespace OopExamples.Interfaces;

public interface ICompany: IEntity
{
    IPerson Owner { get; set; }
}