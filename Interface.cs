/*
- DEFINITION
- IMPLEMENTING INTERFACE
- INTERFACE VS ABSTRACT CLASS
- ABSTRACT VS CONCRETE
- TIGHT/LOOSE COUPLING
- REAL WORLD EXAMPLE
*/
Vehicle v1 = new Honda("Honda", "Civic", 2021);
Honda v2 = new Honda("Honda", "Accord", 2021);
ILoader v3 = new Caterpillar("Caterpillar", "ZXU", 2020);
v3.Load();
Console.ReadKey();
abstract class Vehicle // abstract type
{
    protected string Brand; protected string Model; protected int Year;

    public Vehicle(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }
}

interface IDrivable
{
    void Move();
    void Stop();
}

interface ILoader
{
    void Load();
    void Unload();
}
class Honda : Vehicle, IDrivable // concrete
{

    public Honda(string brand, string model, int year) : base(brand, model, year)
    { }

    public void Move()
    {
        Console.WriteLine("Moving");
    }
    public void Stop()
    {
        Console.WriteLine("Stopping");
    }
}

class Caterpillar : Vehicle, ILoader, IDrivable
{

    public Caterpillar(string brand, string model, int year) : base(brand, model, year)
    {
    }
    public void Move()
    {
        Console.WriteLine("Moving");
    }
    public void Stop()
    {
        Console.WriteLine("Stopping");
    }
    public void Load()
    {
        Console.WriteLine("Loading");
    }
    public void Unload()
    {
        Console.WriteLine("Unloading");
    }
}
//===========================================================================
//===========================================================================
//===========================================================================
IMove = new Vehicle();
m.Move();
m.Turn();
Console.ReadKey();
class Vehicle : IMove, IDisplace
{
    void IMove.Move()
    {
        Console.WriteLine("Ilove move");
    }
    void IDisplace.Move()
    {
        Console.WriteLine("IDisplace move");

    }
}

interface IMove
{
    void Turn()
    {
        Console.WriteLine("turning");
    }
    void Move();
}
interface IDisplace
{
    void Move();
}
//===========================================================================
//===========================================================================
//===========================================================================
Cashier c1 = new Cashier(new Cash());
c1.Checkout(99999.99m);

Cashier c2 = new Cashier(new Mastercard());
c2.Checkout(99999.99m);

Cashier c3 = new Cashier(new AmericanExpress());
c3.Checkout(99999.99m);
Console.ReadKey();

public class AmericanExpress : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"AmericanExpress Payment: ${Math.Round(amount, 2):N0}"); //$99,999.99
    }
}
class Cashier
{
    private IPayment _payment;
    private Cash _cash;

    public Cashier(IPayment payment)
    {
        _payment = payment;
    }

    public void Checkout(decimal amount)
    {
        _payment.Pay(amount);
    }
}

interface IPayment
{
    void Pay(decimal amount);
}
class Cash : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Cash Payment: ${Math.Round(amount, 2):N0}"); //$99,999.99
    }
}

class Debit : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Debit Payment: ${Math.Round(amount, 2):N0}"); //$99,999.99
    }
}

class Visa : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Visa Payment: ${Math.Round(amount, 2):N0}"); //$99,999.99
    }
}

class Mastercard : IPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Mastercard Payment: ${Math.Round(amount, 2):N0}"); //$99,999.99
    }
}
