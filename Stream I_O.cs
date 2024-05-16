/*
- STREAM ARCHETICTURE
- MANAGED / UNMANAGED CODE
- FILESTREAM (BACK STORE)
- STREAM READER/WRITER (ADAPTER)
- DEFLATESTREAM (DECORATOR)
- FILE CLASS
*/


// 1) not recommended
//CurrencyService currencyService = new CurrencyService();
//var result = currencyService.GetCurrencies();
//currencyService.Dispose();
//Console.WriteLine(result);

//2) recommended
//CurrencyService currencyService = null;
//try
//{
//    currencyService = new CurrencyService();
//    var result = currencyService.GetCurrencies();
//    Console.WriteLine(result);

//}
//catch (Exception)
//{
//    Console.WriteLine("Error");
//}
//finally
//{
//    currencyService?.Dispose(); 
//}

// 3) more recommended  using .net framework 2+

//using (CurrencyService currencyService = new CurrencyService())
//{ 
//    var result = currencyService.GetCurrencies();
//    Console.WriteLine(result);
//}

// 4) using with no blocks c# 8.0
CurrencyService currencyService = new CurrencyService();
var result = currencyService.GetCurrencies();
Console.WriteLine(result);
Console.ReadKey();


class CurrencyService : IDisposable
{
    private readonly HttpClient httpClient;
    private bool _disposed = false;
    public CurrencyService()
    {
        httpClient = new HttpClient();
    }

    ~CurrencyService()
    {
        Dispose(false);
    }

    // disposing : true (dispose managed + unmanaged)      
    // disposing : false (dispose unmanaged + large fields)
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        // Dispose Logic
        if (disposing)
        {
            // dispose managed resouces
            httpClient.Dispose();
        }
        // unmanaged object
        // set large fields to null
        _disposed = true;

    }

    public void Dispose()
    {
        // dipose() is called 100%
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public string GetCurrencies()
    {
        string url = "https://coinbase.com/api/v2/currencies";
        var result = httpClient.GetStringAsync(url).Result;
        return result;
    }
}

//===========================================================================
//===========================================================================
//===========================================================================
using (var stream = File.Create("data.bin"))
{
    using (var ds = new DeflateStream(stream, CompressionMode.Compress))
    {
        ds.WriteByte(65);
        ds.WriteByte(66);
    }
}

using (var stream = File.OpenRead("data.bin"))
{
    using (var ds = new DeflateStream(stream, CompressionMode.Decompress))
    {
        for (int i = 0; i < stream.Length; i++)
        {
            Console.WriteLine(ds.ReadByte());
        }
    }
}

Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
Example10();
Console.ReadKey();


static void Example01()
{
    string path = "C:\\Users\\Youya\\Desktop\\sample.txt";
    using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
    {
        Console.WriteLine($"Length: {fs.Length} Byte(s)");
        Console.WriteLine($"CanRead: {fs.CanRead}");
        Console.WriteLine($"CanWrite: {fs.CanWrite}");
        Console.WriteLine($"CanSeek: {fs.CanSeek}");
        Console.WriteLine($"CanTimeout: {fs.CanTimeout}");
        Console.WriteLine($"Position: {fs.Position}");
        fs.WriteByte(65); // A
        Console.WriteLine($"Position: {fs.Position}");
        fs.WriteByte(66); // B
        fs.WriteByte(13); // Enter

        for (byte i = 65; i < 123; i++)
        {
            fs.WriteByte(i);
        }
    }
}

static void Example02()
{
    string path = "C:\\Users\\Youya\\Desktop\\sample.txt";
    using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
    {
        byte[] data = new byte[fs.Length];
        int numBytesToRead = (int)fs.Length;
        int numBytesRead = 0;
        while (numBytesToRead > 0)
        {
            int n = fs.Read(data, numBytesRead, numBytesToRead);

            if (n == 0)
                break;

            numBytesToRead -= n;
            numBytesRead += n;
        }

        foreach (var b in data)
        {
            Console.WriteLine(b);
        }

        var newPath = "C:\\Users\\Youya\\Desktop\\sample1.txt";
        using (var fsw = new FileStream(newPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            fsw.Write(data, 0, data.Length);
        }

    }

}

static void Example03()
{
    string path = "C:\\Users\\Youya\\Desktop\\sample2.txt";
    using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
    {
        fs.Seek(20, SeekOrigin.Begin);
        fs.WriteByte(65);
        fs.Position = 0;
        for (int i = 0; i < fs.Length; i++)
        {
            Console.WriteLine(fs.ReadByte());
        }
    }
}

static void Example04()
{
    string path = "C:\\Users\\Youya\\Desktop\\sample3.txt";
    using (var sw = new StreamWriter(path))
    {
        sw.WriteLine("This");
        sw.WriteLine("Is");
        sw.WriteLine("C#");

    }
}

static void Example05()
{
    string path = "C:\\Users\\Youya\\Desktop\\sample3.txt";
    using (var sr = new StreamReader(path))
    {
        while (sr.Peek() > 0)
        {
            Console.Write((char)sr.Read());
        }
    }
}
static void Example06()
{
    string path = "C:\\Users\\Youya\\Desktop\\sample3.txt";
    using (var sr = new StreamReader(path))
    {
        string line;
        while ((line = sr.ReadLine()) is not null) // != null
        {
            Console.WriteLine(line);
        }
    }
}
static void Example07()
{
    string path = "C:\\Users\\Youya\\Desktop\\sample4.txt";

    string[] lines =
    {
                "C#",
                "Is",
                "Amazing",
                "Language"
            };

    File.WriteAllLines(path, lines);

}

static void Example08()
{
    string path = "C:\\Users\\Youya\\Desktop\\sample5.txt";

    string text = "C# Is Amazing Language";

    File.WriteAllText(path, text);

}

static void Example09()
{
    string path = "C:\\Users\\Youya\\Desktop\\sample5.txt";

    var result = File.ReadAllText(path);

    Console.WriteLine(result);
}

static void Example10()
{
    string path = "C:\\Users\\Youya\\Desktop\\sample4.txt";

    var lines = File.ReadAllLines(path);

    foreach (var line in lines)
    {
        Console.WriteLine(line);
    }
}
//===========================================================================
//===========================================================================
//===========================================================================


