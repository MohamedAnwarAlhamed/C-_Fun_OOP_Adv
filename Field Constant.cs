/*
- INTRODUCTION
- COP DEFINITION
- CLASS VS. OBJECT
- CLASS MODIFIERS
- ACCESS MODIFIERS
- FIELD CONSTANT
*/
Employee[] emps = new Employee[2];
Console.Write("TAX:");
Employee.TAX = Convert.ToDouble(Console.ReadLine());
Employee el = new Employee(); Console.WriteLine("First Employee");
Console.Write("First Name: ");
e1.FName = Console.ReadLine();
Console.Write("Last Name: ");
el.LName = Console.ReadLine();
Console.Write("Wage: ");
e1.Wage = Convert.ToDouble(Console.ReadLine());
Console.Write("LoggedHours: ");
el.LoggedHours = Convert.ToDouble(Console.ReadLine());
emps[0] = e1;
Console.WriteLine("\nSecond Employee");
Employee e2 = new Employee();
Console.Write("First Name: ");
e2.FName = Console.ReadLine();
Console.Write("Last Name: ");
e2.LName = Console.ReadLine();
Console.Write("Wage: ");
e2.Wage = Convert.ToDouble(Console.ReadLine());
Console.Write("LoggedHours: ");
e2.LoggedHours = Convert.ToDouble(Console.ReadLine());
emps[1] = e2;
foreach (var emp in emps)
{
    Console.WriteLine(emp.Printslip());
}
Console.ReadKey();

public class Employee
{
    // static fields
    public static double TAX = 0.03;
    public const double TAX = 0.03;

    // ifistance fields
    public string FName;
    public string LName;
    public double Wage;
    public double LoggedHours;
    public double Calculate() => Wage * LoggedHours;
    public double CalculateTax() => calculate() * TAX;

    public double Calculatelet() => calculate() - calculateTax();
    public string Printslip()
    {
        return $"\nFirst Name: {FName}" +
        $"\nLast Name: {LName}" +
        $"\nwage: {Wage}" +
        $"\nLogged Hours: {LoggedHours}" +
        $"\nsalary: ${Calculate()}" +
        $"\nDeductable Tax ((TAX 100%) Amount: ${CalculateTax()}" +
        $"\nSalary: ${CalculateNet()}\n";
    }
}