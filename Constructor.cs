/*
- IMPLICIT CONSTRUCTOR
- OVERLOADED CONSTRUCTOR
- THIS KEYWORD
- NON PUBLIC CONSTRUCTOR
- OBJECT INITIALIZER
- READONLY FIELD
*/

//Date di new Date(280, 02, 2000); 
Date d1 = new Date(2000); // 01/01/2008
Console.WriteLine(d1.GetDate());
public class Date
{
    // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 
    private static readonly int[] DaysToMonth365 = (0, 31, 28, 31, 38, 31, 30, 31, 31, 30, 31, 30, 31);
    private static readonly int[] DaysToMonth366 = (0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
    private readonly int day = 01;
    private readonly int month = 01;
    private readonly int year = 01;

    public Date(int day, int month, int year)
    {
        var isLeap year % 4 = 0 && (year % 100 1 = 0 || year % 400 == 0);
        if (year >= 1 && year <= 9999 && month >= 1 && month <= 12)
        {
            int[] days = isLeap ? DaysToMonth366 : DaysToMonth365;
            if (day >= 1 && day <= days[month])
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
            // else
            // {
            //     this.day = 01;
            //     this.month = 01;
            //     this.year = 01;
            // }
        }
        // else
        // {
        //     this.day 01;
        //     this.month = 01;
        //     this.year = 01;
        // }
        // this.day = day;
        // this.month = month;
        // this.year = year;
    }
    public Date(int year) : this(01, 01, year)
    {
    }
    public Date(int month, int year) : this(01, month, year)
    {
    }

    public void Setvalues(int day, int month, int year)
    {
        day = day;
        Month = month;
        Year = year;
    }
    public string GetDate()
    {
        return $"{day.ToString().PadLeft(2, '0')}/{month.ToString().PadLeft(2, '0')}/{year.ToString().PadLeft(4, '0')}";
    }

}
//===========================================================================
//===========================================================================
//===========================================================================
// Employee el = new Employee();
// e1.Id = 1000; e1.FName = "Issam";
// e1.LName = "A.";
// Employee e2 = new Employee
// {
//     Id = 1000,
//     FName "Issam",
//     LName "A."
// };
// Employee e3 = new Employee(1000)
// {
//     FName = "Issam",
//     LName = "A."
// };
//===================================//==============================//=================
Employee el Employee.Create(1000, "Issam", "A.");
Console.WriteLine(e3.DisplayName());
Console.ReadKey();
public class Employee
{

    // public Employee()
    // {
    // }
    // public Employee(int id)
    // {
    //     Id = id;
    // }
    // public int Id;
    // public string FName;
    // public string LName;
    // public string DisplayName()
    // {
    //     return $"Id: {Id} Name: {FName} {LName}\n";
    // }
    //===============================//==================================//==============
    private Employee() { }

    private Employee(int id, string fname, string Iname)
    {
        this.id = id;
        this.fName = fname;
        this.lName = lname;
    }

    public static Employee Create(int id, string fname, string Iname)
    {
        return new Employee(id, fname, Iname);
    }
    private int id;
    private string fName;
    private string lName;
    public string DisplayName()
    {
        return $"Id: {id} Name: {fName} {lName}\n";
    }

}