/*
- DEFINITION
- STACK CONSTRUCTOR
- STACK METHODS
- STACK PROPERTIES
- QUEUE CONSTRUCTOR
- QUEUE METHOD
- QUEUE PROPERTIES
*/

//Stack<Command> undo = new Stack<Command>();
//Stack<Command> redo = new Stack<Command>();

//string line;

//while (true)
//{
//    Console.Write("Url ('exit' to quit): ");
//    line = Console.ReadLine().ToLower();
//    if (line == "exit")
//    {
//        break;
//    }
//    else if(line == "back")
//    {
//        if (undo.Count > 0)
//        {
//            var item = undo.Pop();
//            redo.Push(item);
//        }
//        else
//        {
//            continue;
//        }
//    }
//    else if(line == "forward")
//    {
//        if (redo.Count > 0)
//        {
//            var item = redo.Pop();
//            undo.Push(item);
//        }
//        else
//        {
//            continue;
//        }
//    }
//    else
//    {
//        // add url to undo list
//        undo.Push(new Command(line));
//    }
//    Console.Clear();

//    Print("Back", undo);
//    Print("Forward", redo);

//} // end of while

Stack<int> numbers = new Stack<int>(new List<int> { 1, 2, 3 });

while (numbers.Count > 0)
{
    var n = numbers.Peek();

    Console.WriteLine(n);
}



static void Print(string name, Stack<Command> commands)
{
    Console.WriteLine($"{name} history");
    Console.BackgroundColor = name.ToLower() == "back" ? ConsoleColor.DarkGreen : ConsoleColor.DarkBlue;
    foreach (var u in commands)
    {
        Console.WriteLine($"\t{u}");
    }
    Console.BackgroundColor = ConsoleColor.Black;
}


class Command
{
    private readonly DateTime _createdAt;
    private readonly string _url;

    public Command(string url)
    {
        _createdAt = DateTime.Now;
        _url = url;
    }

    public override string ToString()
    {
        return $"[{this._createdAt.ToString("yyyy-MM-dd hh:mm")}] {this._url}";
    }
}
//===========================================================================
//===========================================================================
//===========================================================================

//Queue<PrintingJob> printingJobs = new Queue<PrintingJob>();
//printingJobs.Enqueue(new PrintingJob("documentation.docx", 2));
//printingJobs.Enqueue(new PrintingJob("user-stories.pdf", 6));
//printingJobs.Enqueue(new PrintingJob("report.xlsx", 6));
//printingJobs.Enqueue(new PrintingJob("payroll.report", 5));
//printingJobs.Enqueue(new PrintingJob("budget.xlsx", 4));
//printingJobs.Enqueue(new PrintingJob("algorithm.ppt", 1));
//Console.WriteLine($"Current  Before while Queue Count: {printingJobs.Count}");

//Random rnd = new Random();
//while(printingJobs.Count > 0)
//{
//    Console.ForegroundColor = ConsoleColor.Green;
//    var job = printingJobs.Dequeue();
//    Console.WriteLine($"printing ... [{job}]");
//    System.Threading.Thread.Sleep(rnd.Next(1, 5) * 1000);
//}

//Console.WriteLine($"Current  After while Queue Count: {printingJobs.Count}");

Queue<int> numbers = new Queue<int>();

if (numbers.TryPeek(out int n))
{
    Console.WriteLine(n);

}

Console.ReadKey();




class PrintingJob
{
    private readonly string _file;
    private readonly int _copies;
    public PrintingJob(string file, int copies)
    {
        _file = file;
        _copies = copies;
    }

    public override string ToString()
    {
        return $"{_file} x #{_copies} copies";
    }
}




