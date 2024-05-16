/*
- EXCEPTION CLASS
- BUILT-IN EXCEPTIONS
- CUSTOM EXCEPTION
- HANDLE EXCEPTION TRY/CATCH
- SWALLOW/DUCK EXCEPTION
- EXCEPTION FILTER
*/
try
{
    var result = BadMethod();
    Console.WriteLine(result);
}
catch (ArgumentNullException ex)
{
    // handle the exception
    Console.WriteLine("you can not divide by zero");
}
catch (DivideByZeroException ex) when (ex.Source == "CAExceptions")
{
    Console.WriteLine("you can not divide by zero");
}
// handle the exception
catch (Exception ex)
{

}
finally
{

}

static int BadMethod()
{
    var x = 2;
    var y = 0;
    return
    x / y;
}

//===========================================================================
//===========================================================================
//===========================================================================
var delivery = new Delivery { Id = 1, CustomerName = "Issam A.", Address = "123 Street" };
var service = new DeliveryService();
try
{
    service.Start(delivery);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine(delivery);
Console.ReadKey();

public class Delivery
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }

    public override string ToString()
    {
        return $"{{\n   Id: {Id},\n   Customer: {CustomerName},\n   Address: {Address},\n   Status: {DeliveryStatus}\n}}";
    }
}

public class DeliveryService
{
    private readonly static Random random = new Random();
    public void Start(Delivery delivery)
    {
        try
        {
            Process(delivery);
            Ship(delivery);
            Transit(delivery);
            Deliver(delivery);
        }
        catch (AccidentException ex)
        {
            // inform the user
            // log the exception
            // Ducking (rethrowing)
            throw;
            //Console.WriteLine($"There was an accident at {ex.Location} preventing us from delivering your parcel: {ex.Message}");
            //delivery.DeliveryStatus = DeliveryStatus.UNKNOWN;
        }
        catch (Exception ex)
        {
            throw;
            //Console.WriteLine($"Deliver Fails due to: {ex.Message}");
            //delivery.DeliveryStatus = DeliveryStatus.UNKNOWN;
        }
        finally
        {
            Console.WriteLine("End");
        }
    }

    private void Process(Delivery delivery)
    {
        FakeIt("Processing");
        if (random.Next(1, 10) == 1)
        {
            throw new InvalidOperationException("unable to process the item");
        }
        delivery.DeliveryStatus = DeliveryStatus.PROCESSED;
    }
    private void Ship(Delivery delivery)
    {
        FakeIt("Shipping");
        if (random.Next(1, 10) == 1)
        {
            throw new InvalidOperationException("Parcel is damaged during the loading process");
        }
        delivery.DeliveryStatus = DeliveryStatus.SHIPPED;
    }
    private void Transit(Delivery delivery)
    {
        FakeIt("On Its way");
        if (random.Next(1, 5) == 1)
        {
            throw new AccidentException("354 some another street", "ACCIDENT !!!");
        }
        delivery.DeliveryStatus = DeliveryStatus.INTRANSIT;
    }
    private void Deliver(Delivery delivery)
    {
        FakeIt("Delivering");
        if (random.Next(1, 5) == 1)
        {
            throw new InvalidAddressException($"'{delivery.Address}' is invalid !!!");
        }
        delivery.DeliveryStatus = DeliveryStatus.DELIVERED;
    }

    private void FakeIt(string title)
    {
        Console.Write(title);
        System.Threading.Thread.Sleep(300);
        Console.Write(".");
        System.Threading.Thread.Sleep(300);
        Console.Write(".");
        System.Threading.Thread.Sleep(300);
        Console.Write(".");
        System.Threading.Thread.Sleep(300);
        Console.Write(".");
        System.Threading.Thread.Sleep(300);
        Console.Write(".");
        System.Threading.Thread.Sleep(300);
        Console.WriteLine(".");
    }
}

public enum DeliveryStatus
{
    UNKNOWN,
    PROCESSED,
    SHIPPED,
    INTRANSIT,
    DELIVERED
}

public class InvalidAddressException : Exception
{
    public InvalidAddressException(string message) : base(message)
    {
    }
}

public class AccidentException : Exception
{
    public string Location { get; set; }
    public AccidentException(string location, string message) : base(message)
    {
        Location = location;
    }
}
