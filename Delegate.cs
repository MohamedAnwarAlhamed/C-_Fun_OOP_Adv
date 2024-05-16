/*
- WHAT IS DELEGATE
- SCENARIOS WHEN TO USE
- WHEN TO APPLY DELEGATE
- ANNONYMOUS DELEGATE
- LAMBDA EXPRESSION
- MULTICAST DELEGATE
*/

var emps = new Employee[]
{
    new Employee { Id = 1, Name = "Issam A", Gender "M", TotalSales = 65000m },
    new Employee { Id = 2, Name "Sara A", Gender = "F", TotalSales = 40000m },
    new Employee { Id = 3, Name "Sara A", Gender = "F", TotalSales = 40000m },
    new Employee { Id = 4, Name "Sara A", Gender = "F", TotalSales = 40000m },
    new Employee { Id = 5, Name "Salah C", Gender "M", TotalSales = 42000m },
    new Employee { Id = 6, Name = "Rateb A", Gender "M", TotalSales = 30000m },
    new Employee { Id = 7, Name = "Abeer C", Gender = "F", TotalSales = 16000m },
    new Employee { Id = 8, Name = "Marwan M", Gender = "M", TotalSales = 15000m },
};
var report = new Report();
// report.ProcessEmployeewith60000PlusSales(emps);
// report.ProcessEmployeeWithSalesBetween30000And59999(emps);
// report.ProcessEmployeewithSalesLessThan30000(emps);
// Console.ReadKey();


report.ProcessEmployee(emps, "Sales > $60,000", delegate (Employee e) { return e.TotalSales > 60000m});
report.ProcessEmployee(emps, "Sales between $30, 000 and $60,000", (Employee e) => e.TotalSales > 30000m && e.TotalSales < 60000m);
report.ProcessEmployee(emps, "Sales < $30,000", IsLessThan30000);
Console.ReadKey();

static bool IsGreaterThanOrEqual60000(Employee e) => e.TotalSales > 60000m;

static bool IsBetween30000And59999(Employee e) => e.TotalSales > 30000m && e.TotalSales < 60000m;

static bool IsLessThan30000(Employee e) => e.TotalSales < 30000m;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal TotalSales { get; set; }
    public string Gender { get; set; }
}
public class Report
{

    public delegate bool illegiblesales(Employee e);
    public void ProcessEmployee(Employee[] employees, string title, illegiblesales isillegible)
    {
        Console.WriteLine(title);
        Console.WriteLine("=================================================");
        foreach (var e in employees)
        {
            if (isillegible(e))
            {
                Console.WriteLine($"(e.Id) | (e.Name} | (e.Gender) | $(e.TotalSales)");
                Console.WriteLine("\n\n");
            }
        }
    }
    // public void ProcessEmployeewith60000PlusSales(Employee[] employees)
    // {
    //     Console.WriteLine("Employees with $60,000+ Sales");
    //     Console.WriteLine("====================================================")
    // foreach (var e in employees)
    //     {
    //         if (e.TotalSales >= 60000m)
    //         {
    //             Console.WriteLine($" (e.Id) | (e.Name) | (e.Gender) | $(e.TotalSales)");
    //         }
    //         Console.WriteLine("\n\n");
    //     }
    // }

    // public void ProcessEmployeeWithSalesBetween30000And59999(Employee[] employees)
    // {
    //     Console.WriteLine("Employees with between $60,000 and $30,000 Sales");
    //     Console.WriteLine("====================================================")
    // foreach (var e in employees)
    //     {
    //         if (e.TotalSales < 60000m && e.TotalSales >= 30000m)
    //         {
    //             Console.WriteLine($" (e.Id) | (e.Name) | (e.Gender) | $(e.TotalSales)");
    //         }
    //         Console.WriteLine("\n\n");
    //     }
    // }

    // public void ProcessEmployeewithSalesLessThan30000(Employee[] employees)
    // {
    //     Console.WriteLine("Employees with $30,000- Sales");
    //     Console.WriteLine("====================================================")
    // foreach (var e in employees)
    //     {
    //         if (e.TotalSales <= 30000m)
    //         {
    //             Console.WriteLine($" (e.Id) | (e.Name) | (e.Gender) | $(e.TotalSales)");
    //         }
    //         Console.WriteLine("\n\n");
    //     }
    // }
}
//===========================================================================
//===========================================================================
//===========================================================================
public delegate void RectDelegate(decimal width, decimal height);


var helper = new RectangeHelper();
RectDelegate rect = helper.GetArea;
rect += helper.GetPerimeter;
rect(10, 10);
rect -= helper.GetArea;
Console.WriteLine("after unsubscribing rect.GetArea");
rect(10, 10);
Console.ReadKey();


public class RectangeHelper
{
    public void GetArea(decimal width, decimal height)
    {
        var result = width * height;
        Console.WriteLine($"Area: {width} x {height} = {result}");
    }
    public void GetPerimeter(decimal width, decimal height)
    {
        var result = 2 * (width height);
        Console.WriteLine($"Perimeter: 2 x ({width} {height}) = {result}");
    }
}


