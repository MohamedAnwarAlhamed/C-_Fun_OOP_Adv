/*
- WHAT, WHY
- WHAT IS XML, JSON
- BINARY SERIALIZATION
- XML SERIALIZATION
- JSON SERIALIZATION
- JSON AND HTTPCLIENT
*/
var e1 = new Employee
{
    Id = 1001,
    Fname = "Issam",
    Lname = "A.",
    Benefits = { "Pension", "Health Insurance" }
};

var xmlContent = SerializeToXmlString(e1);
Console.WriteLine(xmlContent);
File.WriteAllText("xmlDocument.xml", xmlContent);

var xmlContent2 = File.ReadAllText("xmlDocument.xml");
Employee e2 = DeserializeFromXmlString(xmlContent2);

Console.ReadKey();


private static Employee DeserializeFromXmlString(string xmlContent)
{
    Employee employee = null;
    var xmlSerializer = new XmlSerializer(typeof(Employee));
    using (TextReader reader = new StringReader(xmlContent))
    {
        employee = xmlSerializer.Deserialize(reader) as Employee;
    }
    return employee;
}

private static string SerializeToXmlString(Employee e1)
{
    var result = "";
    var xmlSerializer = new XmlSerializer(e1.GetType());
    using (var sw = new StringWriter())
    {
        using (var writer = XmlWriter.Create(sw, new XmlWriterSettings { Indent = false }))
        {
            xmlSerializer.Serialize(writer, e1);
            result = sw.ToString();
        }
    }
    return result;
}


public class Employee
{
    public int Id { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public List<string> Benefits { get; set; } = new List<string>();
}
//===========================================================================
//===========================================================================
//===========================================================================
var e1 = new Employee
{
    Id = 1001,
    Fname = "Issam",
    Lname = "A.",
    Benefits = { "Pension", "Health Insurance" }
};

string binaryContent = NonSerializeToBinaryString(e1);
Console.WriteLine(binaryContent);

Employee e2 = DeserializeFromBinaryContent(binaryContent);
Console.ReadKey();


private static Employee DeserializeFromBinaryContent(string binaryContent)
{
    byte[] bytes = Convert.FromBase64String(binaryContent);
    using (var stream = new MemoryStream(bytes))
    {
        var binaryFormatter = new BinaryFormatter();
        stream.Seek(0, SeekOrigin.Begin);
        return binaryFormatter.Deserialize(stream) as Employee;

    }
}

private static string NonSerializeToBinaryString(Employee employee)
{
    using (var stream = new MemoryStream())
    {
        var binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(stream, employee);
        stream.Flush();
        stream.Position = 0;
        return Convert.ToBase64String(stream.ToArray());
    }
}

[Serializable]
public class Employee
{
    public int Id { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public List<string> Benefits { get; set; } = new List<string>();
}
//===========================================================================
//===========================================================================
//===========================================================================

var e1 = new Employee
{
    Id = 1001,
    Fname = "Issam",
    Lname = "A.",
    Benefits = { "Pension", "Health Insurance" }
};
var jsonContent = SerializeToJsonStringUsingNewSoftJson(e1);
Console.WriteLine("content json using newtonsoft");
Console.WriteLine("-----------------------------");
Console.WriteLine(jsonContent);

var e2 = DeserializeToJsonStringNewSoftJson(jsonContent);
Console.WriteLine("content json using Json.Net");
Console.WriteLine("-----------------------------");
var jsonContent2 = SerializeToJsonStringUsingJSONNET(e1);
Console.WriteLine(jsonContent2);

var e3 = DeserializeToJsonStringJSONNET(jsonContent2);
Console.ReadKey();


static string SerializeToJsonStringUsingNewSoftJson(Employee employee)
{
    var result = "";
    result = JsonConvert.SerializeObject(employee, Formatting.Indented);

    return result;

}
static Employee DeserializeToJsonStringNewSoftJson(string jsonContent)
{
    Employee employee = null;
    employee = JsonConvert.DeserializeObject<Employee>(jsonContent);
    return employee;
}

static string SerializeToJsonStringUsingJSONNET(Employee employee)
{
    var result = "";
    result = System.Text.Json.JsonSerializer.Serialize(employee,
        new JsonSerializerOptions { WriteIndented = true });

    return result;

}
static Employee DeserializeToJsonStringJSONNET(string jsonContent)
{
    Employee employee = null;
    employee = JsonConvert.DeserializeObject<Employee>(jsonContent);
    return employee;
}


public class Employee
{
    public int Id { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public List<string> Benefits { get; set; } = new List<string>();
}
//===========================================================================
//===========================================================================
//===========================================================================
private readonly static HttpClient httpClient = new HttpClient();
static async Task Main(string[] args)
{
    var todoesJsonContent = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos");

    var todoes = JsonSerializer.Deserialize<List<Todo>>(todoesJsonContent
        , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    foreach (var item in todoes)
        Console.WriteLine(item);
    Console.ReadKey();
}

public class Todo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }


    public override string ToString()
    {
        return $"\n [{Id} - UserId: {UserId}] -  {Title} {(Completed ? "completed" : "not completed")}";
    }
}
