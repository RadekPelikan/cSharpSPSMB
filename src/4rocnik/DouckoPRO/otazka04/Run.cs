using System.ComponentModel;

namespace otazka04;

public static class Run
{
    public static void Task01(Person person)
    {
        
        var phase = person switch
        {
            { Age: < 1} => OntogeneticPhase.InfantPeriod,
            { Age: < 3 } => OntogeneticPhase.ToddlerPeriod,
            { Age: < 6 } => OntogeneticPhase.PreschoolAge,
            { Age: < 15 } => OntogeneticPhase.SchoolAge,
            { Age: < 20 } => OntogeneticPhase.Adolescence,
            { Age: < 30 } => OntogeneticPhase.FullAdulthood,
            { Age: < 45 } => OntogeneticPhase.MaturityPeriod,
            { Age: < 60 } => OntogeneticPhase.MiddleAge,
            { Age: < 70 } => OntogeneticPhase.OldAge,
            { Age: < 90 } => OntogeneticPhase.AdvancedOldAge,
            { Age: >= 90 } => OntogeneticPhase.ExtremeOldAge,
            _ => throw new ArgumentException("Invalid Age")
        };
        Console.WriteLine($"{person.Name}({person.Age}): {phase}");
    }
}

public record Person
{
    public string Name { get; set; }

    private int _age;
    public int Age
    {
        get => _age;
        set
        {
            if (value < 0)
            {
                _age = 0;
                return;
            }

            _age = value;
        }
    }

    public Person(string Name, int Age)
    {
        this.Name = Name;
        this.Age = Age;
    }
}

public enum OntogeneticPhase
{
    // Postnatal period
    InfantPeriod,            // < 1 year

    // Toddler period
    ToddlerPeriod,           // 1–3 years

    // Childhood
    PreschoolAge,            // 3–6(7) years
    SchoolAge,               // 6(7)–15 years

    // Adolescence
    Adolescence,             // 15–18(20) years

    // Adulthood
    Adulthood,               // 18+ years
    FullAdulthood,           // 18–30 years
    MaturityPeriod,          // 30–45 years
    MiddleAge,               // 45–60 years

    // Old age
    OldAge,                  // 60+ years
    AdvancedOldAge,          // 70+ years
    ExtremeOldAge            // 90+ years
}
