/*
- WHAT, WHY AND HOW
- CASTING AND CONVERSION
- ABSTRACT/SEALED/VIRTUAL
- POLYMORPHISM
- CONSTRUCTOR AND INHERITANCE
- OBJECT CLASS
*/
var e = new Eagle();
// Animal a = e;
// Falcon = f(Falcon)a;
// Falcon = a as Falcon;
// Eagle e2 = (Eagle)a;
// e2.Fly();

// if (a is Falcon)
// {
//     Console.WriteLine("a is a falcon");
// }
// else
// {
//     Console.WriteLine("a is not a falcon");
// }

e.Move();
Console.ReadKey();
abstract class Animal
{

    // public void Move()
    // {
    //     Console.WriteLine("Moving");
    // }

    public virtual void Move()
    {
        Console.WriteLine("Moving");
    }

    public abstract void Move();

}
sealed class Eagle : Animal
{
    public override void Move()
    {
        base.Move();
        Console.WriteLine("The Eagle");
    }
    public sealed override void Move()
    {

        Console.WriteLine("The Eagle");
    }

    public void Fly()
    {
        Console.WriteLine("Flying");
    }
}

// class Falcon : Animal
// {

//     public void Fly()
//     {
//         Console.WriteLine("Flying");
//     }
// }
class AmericanEagle : Eagle
{
    public override void Move()
    {

        Console.WriteLine("The AmericanEagle");
    }

}

var Animal = new Animal();
class Animal
{
    public string Name { get; set; }
    public void Move()
    {
        Console.WriteLine($"Animal: (Name) is moving");
    }

    public override string ToString()
    {
        return $"Animal: {Name}"; // base.ToString();
    }
}

//===========================================================================
//===========================================================================
//===========================================================================
Subclass sc = new Subclass(123);
class Baseclass
{
    public int x;

    public Baseclass() { }

    public Baseclass(int value)
    {
        x = value;
    }
}
class Subclass : Baseclass
{

    public Subclass(int scValue) : base(scValue)
    { }
}
//===========================================================================
//===========================================================================
//===========================================================================
//class Employee
public class Employee
{
    public const int MinimumLoggedHours = 176;
    public const decimal OverTimeRate = 1.25m;

    protected Employee(int id, string name, decimal loggedHours, decimal wage)
    {
        Id = id;
        Name = name;
        LoggedHours = loggedHours;
        Wage = wage;
    }

    protected int Id { get; set; }

    protected string Name { get; set; }

    protected decimal LoggedHours { get; set; }

    protected decimal Wage { get; set; }


    protected virtual decimal Calculate()
    {
        return CalculateBaseSalary() + CalculateOverTime();
    }

    private decimal CalculateBaseSalary()
    {
        decimal regularHours = Math.Min(LoggedHours, MinimumLoggedHours);

        return regularHours * Wage;
    }
    private decimal CalculateOverTime()
    {
        var additionalHours = ((LoggedHours - MinimumLoggedHours) > 0 ? LoggedHours - MinimumLoggedHours : 0);

        return additionalHours * Wage * OverTimeRate;
    }
    public override string ToString()
    {
        var type = GetType().ToString().Replace("CAInheritance.", "");
        return $"{type}" +
               $"\nId: {Id}" +
               $"\nName: {Name}" +
               $"\nLogged Hours: {LoggedHours} hrs" +
               $"\nWage: {Wage} $/hr" +
               $"\nBase Salary: ${Math.Round(CalculateBaseSalary(), 2):N0}" +
               $"\nOvertime: ${Math.Round(CalculateOverTime(), 2):N0}";


    }
}

// class Manager
public class Manager : Employee
{
    private const decimal AllowanceRate = 0.05m;

    public Manager(int id, string name, decimal loggedHours, decimal wage) : base(id, name, loggedHours, wage)
    {

    }
    protected override decimal Calculate()
    {
        return base.Calculate() + CalculateAllowance();
    }

    private decimal CalculateAllowance()
    {
        return base.Calculate() * AllowanceRate;
    }
    public override string ToString()
    {
        return base.ToString() +
               $"\nAllowance: ${Math.Round(CalculateAllowance(), 2):N0}" +
               $"\nNet Salary: ${Math.Round(this.Calculate(), 2):N0}";
    }

}

//class Maintanence
public class Maintanence : Employee
{
    private const decimal Hardship = 100m;

    public Maintanence(int id, string name, decimal loggedHours, decimal wage) : base(id, name, loggedHours, wage)
    {

    }
    protected override decimal Calculate()
    {
        return base.Calculate() + Hardship;
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nHardship: ${Math.Round(Hardship, 2):N0}" +
               $"\nNet Salary: ${Math.Round(this.Calculate(), 2):N0}";
    }

}

//class Sales
public class Sales : Employee
{
    protected decimal SalesVolume { get; set; }
    protected decimal Commission { get; set; }

    public Sales(int id, string name, decimal loggedHours, decimal wage,
        decimal salesVolume, decimal commission) : base(id, name, loggedHours, wage)
    {
        this.SalesVolume = salesVolume;
        this.Commission = commission;
    }
    protected override decimal Calculate()
    {
        return base.Calculate() + CalculateBonus();
    }

    private decimal CalculateBonus()
    {
        return SalesVolume * Commission;
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nCommission: {Math.Round(Commission * 100, 2):N0}%" +
               $"\nBonus: ${Math.Round(CalculateBonus(), 2):N0}" +
               $"\nNet Salary: ${Math.Round(this.Calculate(), 2):N0}";
    }

}

//class Developer
public class Developer : Employee
{
    private const decimal Commission = 0.03m;


    protected bool TaskCompleted { get; set; }


    public Developer(int id, string name, decimal loggedHours, decimal wage,
      bool taskCompleted) : base(id, name, loggedHours, wage)
    {
        this.TaskCompleted = taskCompleted;
    }

    protected override decimal Calculate()
    {
        return base.Calculate() + CalculateBonus();
    }

    private decimal CalculateBonus()
    {
        if (TaskCompleted)
            return base.Calculate() * Commission;
        return 0;
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nTask Completed: ${(TaskCompleted ? "Yes" : "No")}" +
               $"\nBonus: ${Math.Round(CalculateBonus(), 2):N0}" +
               $"\nNet Salary: ${Math.Round(this.Calculate(), 2):N0}";
    }
}
// instance without constructor
Manager m = new Manager
{
    Id = 1000,
    Name "Ali A.",
    LoggedHours = 180,
    Wage 10,
};
Maintanence ms = new Maintanence
{
    Id = 1001,
    Name = "Salim M.",
    LoggedHours = 182,
    Wage = 8,
};
Sales s = new Sales
{
    Id = 1002,
    Name "Sally N.",
    LoggedHours = 176,
    Wage = 9,
    Commission = 0.05m,
    SalesVolume = 10000m
};
Developer d = new Developer
{
    Id = 1003,
    Name "Issam N.",
    LoggedHours = 186,
    Wage = 15,
    TaskCompleted = true,
};

// instance wit constructor 
Manager m = new Manager(1000, "Ali A.", 180, 10);
Maintanence ms = new Maintanence(1001, "Salim M.", 182, 8);
Sales s = new Sales(1002, "Sally N.", 176, 9, 0.05m, 10000m);
Developer d = new Developer(1003, "Issam A.", 186, 15, true);

//
Employee[] employees = { m, ms, s, d };
foreach (var employee in employees)
{
    Console.WriteLine("\n----------------------------");
    Console.WriteLine(employee);
}
Console.ReadKey();






