/*
- PROCESS VS THREAD
- START AND JOIN THREAD
- MULTI THREADING
- RACE CONDITION
- DEADLOCK
- THREAD POOL
*/
Console.WriteLine($"Process Id: {Process.GetCurrentProcess().Id}");
Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
Console.WriteLine($"Processor Id: {Thread.GetCurrentProcessorId()}");
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
var wallet = new Wallet("Issam", 80);

wallet.RunRandomTransactions();
Console.WriteLine("----------------");
Console.WriteLine($"{wallet}\n");

wallet.RunRandomTransactions();
Console.WriteLine("----------------");
Console.WriteLine($"{wallet}\n");

Console.ReadKey();

class Wallet
{
    public Wallet(string name, int bitcoins)
    {
        Name = name;
        Bitcoins = bitcoins;
    }

    public string Name { get; private set; }
    public int Bitcoins { get; private set; }


    public void Debit(int amount)
    {
        Bitcoins -= amount;
    }

    public void Credit(int amount)
    {
        Bitcoins += amount;
    }

    public void RunRandomTransactions()
    {
        int[] amounts = { 10, 20, 30, -20, 10, -10, 30, -10, 40, -20 }; // 80

        foreach (var amount in amounts)
        {
            var absValue = Math.Abs(amount);
            if (amount < 0)
                Debit(absValue);
            else
                Credit(absValue);
            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}" +
                $", Processor Id: {Thread.GetCurrentProcessorId()}] {amount}");
        }
    }

    public override string ToString()
    {
        return $"[{Name} -> {Bitcoins} Bitcoins]";
    }
}
//===========================================================================
//===========================================================================
//===========================================================================


Thread.CurrentThread.Name = "Main Thread";
Console.WriteLine(Thread.CurrentThread.Name);
//Console.WriteLine($"Background Thread: {Thread.CurrentThread.IsBackground}");
var wallet = new Wallet("Issam", 80);

Thread t1 = new Thread(wallet.RunRandomTransactions);
t1.Name = "T1";
//Console.WriteLine($"T1 Background Thread: {t1.IsBackground}");
Console.WriteLine($"after declaration {t1.Name} state is: {t1.ThreadState}");

t1.Start();
Console.WriteLine($"after start() {t1.Name} state is: {t1.ThreadState}");
t1.Join();

Thread t2 = new Thread(new ThreadStart(wallet.RunRandomTransactions));
t2.Name = "T2";
t2.Start();

Console.WriteLine($"after start {t1.Name} state is: {t1.ThreadState}");



Console.ReadKey();


class Wallet
{
    public Wallet(string name, int bitcoins)
    {
        Name = name;
        Bitcoins = bitcoins;
    }

    public string Name { get; private set; }
    public int Bitcoins { get; private set; }


    public void Debit(int amount)
    {
        Thread.Sleep(1000);
        Bitcoins -= amount;
        Console.WriteLine(
            $"[Thread: {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name} " +
            $", Processor Id: {Thread.GetCurrentProcessorId()}] -{amount}");
    }

    public void Credit(int amount)
    {
        Thread.Sleep(1000);
        Bitcoins += amount;
        Console.WriteLine(
            $"[Thread: {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name} " +
            $", Processor Id: {Thread.GetCurrentProcessorId()}] +{amount}");
    }

    public void RunRandomTransactions()
    {
        int[] amounts = { 10, 20, 30, -20, 10, -10, 30, -10, 40, -20 }; // 80

        foreach (var amount in amounts)
        {
            var absValue = Math.Abs(amount);
            if (amount < 0)
                Debit(absValue);
            else
                Credit(absValue);

        }
    }

    public override string ToString()
    {
        return $"[{Name} -> {Bitcoins} Bitcoins]";
    }
}
//===========================================================================
//===========================================================================
//===========================================================================


var wallet = new Wallet("Issam", 50);

//wallet.Debit(40);
//wallet.Debit(30); // 10


var t1 = new Thread(() => wallet.Debit(40));
var t2 = new Thread(() => wallet.Debit(30));

t1.Start();
t2.Start();

t1.Join();
t2.Join();

Console.WriteLine(wallet);
Console.ReadKey();

class Wallet
{
    private readonly object bitcoinsLock = new object();
    public Wallet(string name, int bitcoins)
    {
        Name = name;
        Bitcoins = bitcoins;
    }

    public string Name { get; private set; }
    public int Bitcoins { get; private set; }


    public void Debit(int amount)
    {
        lock (bitcoinsLock)
        {
            if (Bitcoins >= amount)
            {
                Thread.Sleep(1000);

                Bitcoins -= amount;
            }
        }
    }

    public void Credit(int amount)
    {
        Thread.Sleep(1000);
        Bitcoins += amount;
    }


    public override string ToString()
    {
        return $"[{Name} -> {Bitcoins} Bitcoins]";
    }
}
//===========================================================================
//===========================================================================
//===========================================================================

var wallet1 = new Wallet(1, "Issam", 100);
var wallet2 = new Wallet(2, "Reem", 50);
Console.WriteLine("\n Before Transaction");
Console.WriteLine("\n---------------------");
Console.Write(wallet1 + ", "); Console.Write(wallet2); Console.WriteLine();
Console.WriteLine("\n After Transaction");
Console.WriteLine("\n---------------------");

var transferManager1 = new TransferManager(wallet1, wallet2, 50);
var transferManager2 = new TransferManager(wallet2, wallet1, 30);

var t1 = new Thread(transferManager1.Transfer);
t1.Name = "T1";
var t2 = new Thread(transferManager2.Transfer);
t2.Name = "T2";

t1.Start();
t2.Start();

t1.Join();
t2.Join();

Console.Write(wallet1 + ", "); Console.Write(wallet2); Console.WriteLine();
Console.ReadKey();


class Wallet
{
    private readonly object bitcoinsLock = new object();
    public Wallet(int id, string name, int bitcoins)
    {
        Id = id;
        Name = name;
        Bitcoins = bitcoins;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Bitcoins { get; private set; }


    public void Debit(int amount)
    {
        lock (bitcoinsLock)
        {
            if (Bitcoins >= amount)
            {
                Thread.Sleep(1000);

                Bitcoins -= amount;
            }
        }
    }

    public void Credit(int amount)
    {
        Thread.Sleep(1000);
        Bitcoins += amount;
    }


    public override string ToString()
    {
        return $"[{Name} -> {Bitcoins} Bitcoins]";
    }
}

class TransferManager
{
    private Wallet from;
    private Wallet to;

    private int amountToTransfer;

    public TransferManager(Wallet from, Wallet to, int amountToTransfer)
    {
        this.from = from;
        this.to = to;
        this.amountToTransfer = amountToTransfer;
    }

    public void Transfer()
    {
        var lock1 = from.Id < to.Id ? from : to;
        var lock2 = from.Id < to.Id ? to : from;

        Console.WriteLine($"{Thread.CurrentThread.Name} trying to lock ... {from}");
        lock (lock1)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} lock acquired ... {from}");
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.Name} trying to lock ... {to}");

            lock (lock2)
            {
                from.Debit(amountToTransfer);
                to.Credit(amountToTransfer);
            }

            if (Monitor.TryEnter(to, 1000))
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} lock acquired ... {to}");
                try
                {
                    from.Debit(amountToTransfer); to.Credit(amountToTransfer);
                }
                catch
                {
                }
                finally
                {
                    Monitor.Exit(to);
                }
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} unable to acquire lock...{to}");
            }
        }
    }
}
//===========================================================================
//===========================================================================
//===========================================================================

Console.WriteLine("Using ThreadPool");

//1 
ThreadPool.QueueUserWorkItem(new WaitCallback(Print));

Console.WriteLine("Using Task");
//2 
Task.Run(Print);


var employee = new Employee { Rate = 10, TotalHours = 40 };

ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateSalary), employee);

Console.WriteLine(employee.TotalSalary);
Console.ReadKey();


private static void CalculateSalary(object employee)
{
    var emp = employee as Employee;
    if (employee is null)
        return;
    emp.TotalSalary = emp.TotalHours * emp.Rate;
    Console.WriteLine(emp.TotalSalary.ToString("C"));
}

private static void Print()
{
    Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Thread Name: {Thread.CurrentThread.Name}");
    Console.WriteLine($"Is Pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine($"Background: {Thread.CurrentThread.IsBackground}");
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Cycle {i + 1}");
    }
}

private static void Print(object state)
{
    Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Thread Name: {Thread.CurrentThread.Name}");
    Console.WriteLine($"Is Pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine($"Background: {Thread.CurrentThread.IsBackground}");
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Cycle {i + 1}");
    }
}


class Employee
{
    public decimal TotalHours { get; set; }
    public decimal Rate { get; set; }

    public decimal TotalSalary { get; set; }

}


