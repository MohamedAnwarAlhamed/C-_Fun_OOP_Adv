/*
- WHAT, WHY AND HOW
- OBTAINING TYPES
- ACTIVATING TYPES
- REFLECTING MEMBERS
- INVOKING MEMBERS
- REFLECTING ASSEMBLIES
*/

Type t1 = DateTime.Now.GetType(); // at runtime
Console.WriteLine(t1);
Type t2 = typeof(DateTime); // at compile time
Console.WriteLine(t2);
Console.WriteLine($"FullName: {t1.FullName}");// Namespace. TypeName
Console.WriteLine($"Namespace: {t1.Namespace}");// Namespace
Console.WriteLine($"Name: {t1.Name}"); // Namespace
Console.WriteLine($"BaseType: {t1.BaseType}"); // Namespace

Console.WriteLine($"IsPublic: {t1.IsPublic}");
Console.WriteLine($"Assembly: {t1.Assembly}");

Type t3 = typeof(int[,]);
Console.WriteLine($"T3 Type: {t3.Name}");
var nestedTypes = typeof(Employee).GetNestedTypes();
for (int i = 0; i < nestedTypes.Length; i++)
{
    Console.WriteLine(nestedTypes[i]);
}
var t4 = typeof(int);
var interfaces = t4.GetInterfaces();
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
int i = (int)Activator.CreateInstance(typeof(int));
i = 3;
DateTime dt = (DateTime)Activator.CreateInstance(typeof(DateTime), 2021, 01, 01);
Console.WriteLine(dt);
Console.ReadKey();
//=================================//=============================//=========
do
{
    var input = "CAReflection." + Console.ReadLine();
    object obj = null;
    try
    {
        var aName = typeof(Program).Assembly.GetName().Name;
        var enemy = Activator.CreateInstance("CAReflection", input);
        obj = enemy.Unwrap();
    }
    catch
    {
    }
    switch (obj)
    {
        case Goon g:
            break;
            Console.WriteLine(g);
        case Agar a:
            Console.WriteLine(a);
            break;
        case Pixa p:
            Console.WriteLine(p);
            break;
        default:
            Console.WriteLine("Unknown enemy");
            break;
    }
} while (true);


public class Goon
{
    public override string ToString()
    {
        return $"{{ Speed: (20), HitPower: (13), Strength: {7} }}";
    }
}

public class Agar
{
    public override string ToString()
    {
        return $"{{ Speed: (20), HitPower: (13), Strength: {7} }}";
    }
}

public class Pixa
{
    public override string ToString()
    {
        return $"{{ Speed: (20), HitPower: (13), Strength: {7} }}";
    }
}
//===========================================================================
//===========================================================================
//===========================================================================
Console.WriteLine("MemberInfo");
MemberInfo[] members = typeof(BankAccount).GetMembers(BindingFlags.Public | BindingFlags.NonPublic);
foreach (var member in members)
{
    Console.WriteLine(member);
}
Console.WriteLine("FieldInfo");
FieldInfo[] fields = typeof(BankAccount).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
foreach (var field in fields)
{
    Console.WriteLine(field);
}
Console.WriteLine("PropertyInfo");
PropertyInfo[] properties = typeof(BankAccount).GetProperties();
foreach (var property in properties)
{
    Console.WriteLine(property);
}
Console.WriteLine("EventInfo");
EventInfo[] events = typeof(BankAccount).GetEvents();
foreach (var e in events)
{
    Console.WriteLine(e);
}
Console.WriteLine("ConstructorInfo");
ConstructorInfo[] ctors = typeof(BankAccount).GetConstructors();
foreach (var constructor in ctors)
{
    Console.WriteLine(constructor);
}
Console.WriteLine("Get Member By Name");
MemberInfo[] ctorss = typeof(BankAccount).GetMember(".ctor");
foreach (var constructor in ctorss)
{
    Console.WriteLine(constructor);
}
//==============================//========================//=======================
var account = new BankAccount("A123", "Issam A.", 0);
Type t = typeof(BankAccount); // account.Deposit(100);
Type[] parametersType = { typeof(decimal) };
MethodInfo method = t.GetMethod("Deposit");
method.Invoke(account, new object[] { 500m });
Console.WriteLine(account);
Console.ReadKey();

private static void Account_OnNegativeBalance(object sender, EventArgs e)
{
    var bankAccount = (BankAccount)sender;
    Console.WriteLine("NEGATIVE BALANCE!!!");
}

public class BankAccount
{
    private string accountNo;
    private string holder;
    private decimal balance;

    public string AccountNo => accountNo;
    public string Holder => holder;
    public decimal Balance => balance;

    public event EventHandler OnNegativeBalance;
    public BankAccount()
    {

    }
    public BankAccount(string accountNo, string holder, decimal balance)
    {
        this.accountNo = accountNo;
        this.holder = holder;
        this.balance = balance;
    }

    public void Deposit(decimal amount)
    {
        this.balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.balance -= amount;
        if (this.balance < 0)
            this.OnNegativeBalance.Invoke(this, null);
    }

    public override string ToString()
    {
        return $"{{ Account No.: {accountNo}, Holder: {holder}, Balance: ${balance}}}";
    }

}
//===========================================================================
//===========================================================================
//===========================================================================
var path = "C:\\Users\\Youya\\Desktop\\MOE.dll";
// var path = @"C:\Users\Youya\Desktop\MOE.dll";
var assembly = Assembly.LoadFile(path);
var types = assembly.GetTypes();
foreach (var t in types)
{
    Console.WriteLine(t);
}
Console.ReadKey();


