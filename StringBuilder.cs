
Console.ReadKey();

static string GenerateWithString()
{
    string str = null;

    str += String.Concat(new char[] { 'E', 'T', 'I' }); // ETI

    str += String.Format("GAT{0}{1}{2}", 'O', 'P', 'S'); // GATOPS

    str = "M" + str; // METIGATOPS

    str = str.Replace('P', 'R'); //METIGATORS

    str = str.Remove(str.Length - 1); // METIGATOR 

    return str;
}
static string GenerateWithStringBuilder()
{
    StringBuilder sb = new StringBuilder();

    sb.Append(new char[] { 'E', 'T', 'I' }); // ETI

    sb.AppendFormat("GAT{0}{1}{2}", 'O', 'P', 'S'); // ETIGATOPS

    sb.Insert(0, "M"); // METIGATOPS

    sb.Replace('P', 'R'); //METIGATORS

    sb.Remove(sb.Length - 1, 1); // METIGATOR 

    return sb.ToString();
}
//===========================================================================
//===========================================================================
//===========================================================================
// RunArrayOfCharacterConcept();
// RunStringBuilderProperties();
RunStringBuilderHowItWorks();

Console.ReadKey();


static void RunArrayOfCharacterConcept()
{
    // char[] characters = new char[9];
    char[] characters;
    // Console.WriteLine(characters.Length);  // use of unassigned error

    characters = new char[9];

    characters[0] = 'M';
    characters[1] = 'e';
    characters[2] = 't';
    characters[3] = 'i';
    characters[4] = 'g';
    characters[5] = 'a';
    characters[6] = 't';
    characters[7] = 'o';
    characters[8] = 'r';



    // or
    characters = new char[9] { 'M', 'e', 't', 'i', 'g', 'a', 't', 'o', 'r' };

    // or
    characters = new char[] { 'M', 'e', 't', 'i', 'g', 'a', 't', 'o', 'r' };

    characters[0] = 'm'; // mutate

    Console.WriteLine(characters);
}

static void RunStringBuilderProperties()
{

    var sb = new StringBuilder("Metigator");

    Console.WriteLine(sb.ToString());              // Metigator

    //the characters the object currently contains
    Console.WriteLine($"Length: {sb.Length}");     // 9  

    //  the number of characters that the object can contain.
    Console.WriteLine($"Capacity: {sb.Capacity}"); // 16 (default)

    // the maximum capacity, if it's reached,  OutOfMemoryException
    Console.WriteLine($"MaxCapacity: {sb.MaxCapacity}"); // 2,147,483,647  (default)

    Console.WriteLine($"First Letter: {sb[0]}");     // M  Index out of range exception 

}

static void RunStringBuilderHowItWorks()
{

    var sb = new StringBuilder();
    // sb is a StringBuilder object
    // string value is empty, length 0, capacity 16, maxcapacity is 2,147,483,647

    sb.Append("I Love Metigator"); // add 16 character

    Console.WriteLine($"Length: {sb.Length}");           // 16
    Console.WriteLine($"Capacity: {sb.Capacity}");       // 16  (default)
    Console.WriteLine($"MaxCapacity: {sb.MaxCapacity}"); // 2,147,483,647 (default)

    sb.Append("Youtube Channel"); // add 15 character

    Console.WriteLine($"Length: {sb.Length}");           // 31
    Console.WriteLine($"Capacity: {sb.Capacity}");       // 32 (size doubled)
    Console.WriteLine($"MaxCapacity: {sb.MaxCapacity}"); // 2,147,483,647 (default)
}
//===========================================================================
//===========================================================================
//===========================================================================

// RunAppend();
// RunAppendJoin();
// RunAppendFormat();
// RunAppendLine();
// RunInsert();
// RunReplace();
// RunRemove();
// RunClear();
// RunGetChuncks();
// RunInsureCapacity();
// RunCopyTo(); 
RunCharAtIndex();
Console.ReadKey();

private static void RunAppend()
{
    var sb = new StringBuilder();
    // Append Return StringBuilder, useful method chaining
    sb.Append("ƒ(x)").Append("=").Append("Σ").Append("x²").Append("±").Append("α");

    Console.WriteLine(sb.ToString());
}

private static void RunAppendJoin()
{
    string[] words = { "I", "Love", "Metigator" };
    var sb = new StringBuilder();
    sb.AppendJoin('°', words);
    Console.WriteLine(sb.ToString());
}

private static void RunAppendFormat()
{
    string customer = "Issam A";
    DateTime shippingDate = DateTime.Now; // yyyy-MM-dd hh:mm
    DateTime expectedDelivery = shippingDate.AddDays(7); // yyyy-MM-dd hh:mm
    decimal shippingCost = 29.99m;

    var sb = new StringBuilder();

    sb.AppendFormat(
        "\nDear {0}.," +
        "\n\nAt {1:t} on {1:D}, the order is on its way to you" +
        "\nIt's expected to be delivered at {2:t} on {2:D}, the order is on its way to you" +
        "\nShipping cost {3:c}." +
        "\n\t\t\tThanks for shopping with us!",

        customer, shippingDate, expectedDelivery, shippingCost);
    //   0           1              2                3
    Console.WriteLine(sb.ToString());
}

private static void RunAppendLine()
{
    var sb = new StringBuilder();

    sb.AppendLine("C# is a modern, object-oriented, type-safe programming language");
    sb.AppendLine("C# enables developers to build secure and robust applications");
    sb.AppendLine("C# has its roots in the C family of languages ");
    Console.WriteLine(sb.ToString());
}

private static void RunInsert()
{
    var sb = new StringBuilder("C# is a modern, object-, type-safe programming language");

    sb.Insert(23, "oriented");

    Console.WriteLine(sb.ToString());
}

private static void RunReplace()
{
    var sb = new StringBuilder();

    // Append Return StringBuilder, useful method chaining
    sb.Append("Fetigator");

    Console.WriteLine("before replace..");
    Console.WriteLine(sb.ToString());

    sb.Replace("Fetigator", "Metigator");

    Console.WriteLine("after replace..");
    Console.WriteLine(sb.ToString());
}

private static void RunRemove()
{
    var sb = new StringBuilder();

    // Append Return StringBuilder, useful method chaining
    sb.Append("Metigator xyx");

    Console.WriteLine("before remove..");
    Console.WriteLine(sb.ToString());

    sb.Remove(9, 4);

    Console.WriteLine("after remove..");
    Console.WriteLine(sb.ToString());
}

private static void RunClear()
{
    var sb = new StringBuilder();

    // Append Return StringBuilder, useful method chaining
    sb.Append("Metigator");

    Console.WriteLine("before clear..");
    Console.WriteLine(sb.ToString());

    sb.Clear();

    Console.WriteLine("after clear..");
    Console.WriteLine(sb.ToString());
}

private static void RunGetChuncks()
{
    var sb = new StringBuilder();

    sb.Append("I Love Metigator");

    sb.Append("Youtube Channel");

    var counter = 1;
    foreach (var chunk in sb.GetChunks())
    {
        Console.WriteLine($"chunck #{counter++}: \"{chunk}\" length: {chunk.Length}");
    }
}

private static void RunInsureCapacity()
{

    var sb = new StringBuilder(10);

    Console.WriteLine("before sb.EnsureCapacity(12)");
    Console.WriteLine(sb.Capacity); // 10

    Console.WriteLine("after ensuring capacity");

    // If the current capacity is less than the capacity
    // parameter, memory for this instance is reallocated
    // to hold at least capacity number of characters; otherwise,
    // no memory is changed.

    sb.EnsureCapacity(8);

    Console.WriteLine("after sb.EnsureCapacity(12)");
    Console.WriteLine(sb.Capacity); // 12



}

private static void RunCopyTo()
{
    var sb = new StringBuilder("Metigator");
    char[] characters = new char[sb.Length];
    sb.CopyTo(0, characters, 0, sb.Length);
    Console.WriteLine(characters);

}
private static void RunCharAtIndex()
{
    var sb = new StringBuilder("Metigator");
    var firstChar = sb[0];
    Console.WriteLine(firstChar);

}











