/*
- DEFINITION
- WHY NESTED TYPES
- PRIVATE/PUBLIC/INTERNAL
- COMPOSITE OBJECTS
- INITIALIZE NESTED OBJECT
- CHECKLIST
*/


class A
{
    private int x;
    class B
    {
        void Method()
        {
            A a = new A();
            a.x = 10;
        }
    }
}
//===========================================================================
//===========================================================================
//===========================================================================
Employee e1 = new Employee();
Console.WriteLine(e1.EmployeeInsurance.CompanyName);
Console.ReadKey();

class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Insurance EmployeeInsurance { get; set; }


    public Employee() =>
        EmployeeInsurance = new Insurance { PolicyId = -1, CompanyName = "N/A" };
    public class Insurance
    {
        public int PolicyId { get; set; }
        public string CompanyName { get; set; }
    }
}



class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}


