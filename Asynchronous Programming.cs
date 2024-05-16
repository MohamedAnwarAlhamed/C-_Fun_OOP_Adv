/*
- TASKS VS THREADS
- HOW TO IMPLEMENT
- SYNCHRONOUS VS ASYNCHRONOUS
- ASYNCHRONOUS FUNCTIONS
- CANCELLATION TOKEN
- REPORTING A PROGRESS
- CONCURRENCY VS PARALLELISM
*/

var th = new Thread(() => Display("Metigator using thread !!!"));
th.Start();
th.Join();

Task.Run(() => Display("Metigator using task !!!")).Wait();
Console.ReadKey();


static void Display(string message)
{
    ShowThreadInfo(Thread.CurrentThread);
    Console.WriteLine(message);
}

private static void ShowThreadInfo(Thread th)
{
    Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
}
//===========================================================================
//===========================================================================
//===========================================================================

Task<DateTime> task = Task.Run(GetCurrentDatetime);
//Console.WriteLine(task.Result); // block thead until result is ready

Console.WriteLine(task.GetAwaiter().GetResult());
Console.ReadKey();


static DateTime GetCurrentDatetime() => DateTime.Now;
//===========================================================================
//===========================================================================
//===========================================================================

var task = Task.Factory.StartNew(() => RunLongTask(), TaskCreationOptions.LongRunning);
Console.ReadKey();

static void RunLongTask()
{
    Thread.Sleep(3000);
    ShowThreadInfo(Thread.CurrentThread);
    Console.WriteLine("Completed");
}
static void ShowThreadInfo(Thread th)
{
    Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
}
//===========================================================================
//===========================================================================
//===========================================================================

// -- 1 --
//try
//{
//    var th = new Thread(ThrowException);
//    th.Start();
//    th.Join();
//}
//catch
//{
//    Console.WriteLine("Exception is thrown!!");
//}

// -- 2 --
//var th = new Thread(ThrowExceptionWithTryCatchBlock);
//th.Start();
//th.Join();

// -- 3 --

try
{
    Task.Run(ThrowException).Wait();
}
catch
{
    Console.WriteLine("Exception is thrown!!");

}
Console.ReadKey();


static void ThrowException()
{
    throw new NullReferenceException();
}

static void ThrowExceptionWithTryCatchBlock()
{
    try
    {
        throw new NullReferenceException();

    }
    catch
    {
        Console.WriteLine("Exception is thrown!!");

        throw;
    }
}
//===========================================================================
//===========================================================================
//===========================================================================

//  Console.WriteLine(CountPrimeNumberInARange(2, 2_000_000));

Task<int> task = Task.Run(() => CountPrimeNumberInARange(2, 3_000_000));
// Console.WriteLine(task.Result); // bad it blocks the thead

//Console.WriteLine("using awaiter, onComplete");
//var awaiter = task.GetAwaiter();
//awaiter.OnCompleted(() => {
//    Console.WriteLine(awaiter.GetResult()); // block the thread but task is completed
//});
//Console.WriteLine("using task continuewith");

task.ContinueWith((x) => Console.WriteLine(x.Result));
Console.WriteLine("Metigator");
Console.ReadKey();


static int CountPrimeNumberInARange(int lowerBound, int upperBound)
{
    var count = 0;
    for (int i = lowerBound; i < upperBound; i++)
    {
        var j = 2;
        var isPrime = true;
        while (j <= (int)Math.Sqrt(i))
        {
            if (i % j == 0)
            {
                isPrime = false;
                break;
            }
            ++j;
        }

        if (isPrime)
            ++count;
    }
    return count;
}
//===========================================================================
//===========================================================================
//===========================================================================

DelayUsingTask(5000);
Console.ReadKey();

static void DelayUsingTask(int ms)
{
    Task.Delay(ms).GetAwaiter().OnCompleted(() =>
    {
        Console.WriteLine($"Completed after Task.Delay({ms})");

    });
}

static void SleepUsingThread(int ms)
{
    Thread.Sleep(ms);
    Console.WriteLine($"Completed after Thread.Sleep({ms})");
}
//===========================================================================
//===========================================================================
//===========================================================================

ShowThreadInfo(Thread.CurrentThread, 11);
CallSynchronous();

ShowThreadInfo(Thread.CurrentThread, 14);
CallAsynchronous();

ShowThreadInfo(Thread.CurrentThread, 17);
Console.ReadKey();


static void CallSynchronous()
{
    Thread.Sleep(4000);
    ShowThreadInfo(Thread.CurrentThread, 24);
    Task.Run(() => Console.WriteLine("++++++++++ Synchronous +++++++++++")).Wait();
}

static void CallAsynchronous()
{
    ShowThreadInfo(Thread.CurrentThread, 30);
    Task.Delay(4000).GetAwaiter().OnCompleted(() =>
    {
        ShowThreadInfo(Thread.CurrentThread, 32);
        Console.WriteLine("++++++++++ Asynchronous +++++++++++");
    });
}

private static void ShowThreadInfo(Thread th, int line)
{
    Console.WriteLine($"Line#: {line}, TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
}
//===========================================================================
//===========================================================================
//===========================================================================
// -- 1 --
//var task = Task.Run(() => ReadContent("https://www.youtube.com/c/Metigator"));
//var awaiter = task.GetAwaiter();
//awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));

Console.WriteLine(await ReadContentAsync("https://www.youtube.com/c/Metigator"));
Console.ReadKey();


static Task<string> ReadContent(string url)
{
    var client = new HttpClient();

    var task = client.GetStringAsync(url);

    return task;
}

static async Task<string> ReadContentAsync(string url)
{
    var client = new HttpClient();

    var content = await client.GetStringAsync(url);

    return content;
}
//===========================================================================
//===========================================================================
//===========================================================================
CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
//await DoCheck01(cancellationTokenSource);
//await DoCheck02(cancellationTokenSource);
await DoCheck03(cancellationTokenSource);


Console.ReadKey();


static async Task DoCheck01(CancellationTokenSource cancellationTokenSource)
{
    Task.Run(() =>
    {
        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Q)
        {
            cancellationTokenSource.Cancel();
            Console.WriteLine("Task has been cancelled !!!");
        }
    });

    while (!cancellationTokenSource.Token.IsCancellationRequested)
    {
        Console.Write("Checking ...");
        await Task.Delay(4000);
        Console.Write($" Completed on {DateTime.Now}");
        Console.WriteLine();
    }

    Console.WriteLine("Check was Terminated");
    cancellationTokenSource.Dispose();
}

static async Task DoCheck02(CancellationTokenSource cancellationTokenSource)
{
    Task.Run(() =>
    {
        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Q)
        {
            cancellationTokenSource.Cancel();
            Console.WriteLine("Task has been cancelled !!!");
        }
    });

    while (true)
    {
        Console.Write("Checking ...");
        await Task.Delay(4000, cancellationTokenSource.Token);
        Console.Write($" Completed on {DateTime.Now}");
        Console.WriteLine();
    }

    Console.WriteLine("Check was Terminated");
    cancellationTokenSource.Dispose();
}

static async Task DoCheck03(CancellationTokenSource cancellationTokenSource)
{
    Task.Run(() =>
    {
        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Q)
        {
            cancellationTokenSource.Cancel();
            Console.WriteLine("Task has been cancelled !!!");
        }
    });

    try
    {
        while (true)
        {
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            Console.Write("Checking ...");
            await Task.Delay(4000);
            Console.Write($" Completed on {DateTime.Now}");
            Console.WriteLine();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("Check was Terminated");
    cancellationTokenSource.Dispose();
}
//===========================================================================
//===========================================================================
//===========================================================================

Action<int> progress = (p) => { Console.Clear(); Console.WriteLine($"{p}%"); };
await Copy(progress);
Console.ReadKey();


static Task Copy(Action<int> onProgressPercentChanged)
{
    return Task.Run(() =>
    {
        for (int i = 0; i <= 100; i++)
        {
            Task.Delay(50).Wait();
            if (i % 10 == 0)
                onProgressPercentChanged(i);
        }
    });
}
//===========================================================================
//===========================================================================
//===========================================================================

var has1000SubscriberTask = Task.Run(() => Has1000Subscriber());
var has4000ViewHoursTask = Task.Run(() => Has4000ViewHours());
Console.WriteLine("Using WhenAny()");
Console.WriteLine("---------------");

var any = await Task.WhenAny(has1000SubscriberTask, has4000ViewHoursTask);
Console.WriteLine(any.Result);

Console.WriteLine("Using WhenAll()");
Console.WriteLine("---------------");

var all = await Task.WhenAll(has1000SubscriberTask, has4000ViewHoursTask);
foreach (var t in all)
{
    Console.WriteLine(t);

}
Console.ReadKey();


static Task<string> Has1000Subscriber()
{
    Task.Delay(4000).Wait();
    return Task.FromResult("congratulation !! you have 1000 subscribers");
}

static Task<string> Has4000ViewHours()
{
    Task.Delay(3000).Wait();
    return Task.FromResult("congratulation !! you have 4000 view hours");
}
//===========================================================================
//===========================================================================
//===========================================================================

var things = new List<DailyDuty>
            {
                new DailyDuty("Cleaning House"),
                new DailyDuty("Washing Dishes"),
                new DailyDuty("Doing Laundry"),
                new DailyDuty("Preparing Meals"),
                new DailyDuty("Checking Emails"),
                new DailyDuty("Cleaning House")
            };

//Console.WriteLine("Using Parallel Processing");
//await ProcessThingsInParallel(things);

Console.WriteLine("Using Concurrent Processing");
await ProcessThingsInConcurrent(things);

Console.ReadKey();


static Task ProcessThingsInParallel(IEnumerable<DailyDuty> things)
{
    Parallel.ForEach(things, thing => thing.Process());
    return Task.CompletedTask;
}

static Task ProcessThingsInConcurrent(IEnumerable<DailyDuty> things)
{
    foreach (var thing in things)
    {
        thing.Process();
    }
    return Task.CompletedTask;
}


class DailyDuty
{
    public string title { get; private set; }

    public bool Processed { get; private set; }

    public DailyDuty(string title)
    {
        this.title = title;
    }

    public void Process()
    {
        Console.WriteLine($"TID: {Thread.CurrentThread.ManagedThreadId}," +
            $"ProcessorId: {Thread.GetCurrentProcessorId()}");
        Task.Delay(100).Wait();
        this.Processed = true;
    }
}








