for (byte c = 0; c < 255; ++c)
{
    char ch = (char)c;
    string dec = c.ToString().PadLeft(3, '0');
    string hex = c.ToString("X");
    string binary = Convert.ToString(c, 2).PadLeft(8, '0');
    Console.WriteLine($"{dec,-12} {binary,-12} {hex,-12} {ch,-12}");
}

Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Encoding chinese = Encoding.GetEncoding("GB18030");
Console.WriteLine("大");

Task.Run(() => GetDataUTF8Format());
Console.ReadKey();


static async Task GetDataAssciFormat()
{
    var path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
    var filePath = $"{path}\\asciiNewsContent.txt";

    using (var client = new HttpClient())
    {
        Uri uri = new Uri("https://aljazeera.net/search/feed");
        using (HttpResponseMessage response = await client.GetAsync(uri))
        {
            var byteArray = await response.Content.ReadAsByteArrayAsync();
            string result = Encoding.ASCII.GetString(byteArray);
            File.WriteAllText(filePath, result);
        }
    }
}

static async Task GetDataUTF8Format()
{
    var path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
    var filePath = $"{path}\\utf8NewsContent.txt";

    using (var client = new HttpClient())
    {
        Uri uri = new Uri("https://aljazeera.net/search/feed");
        using (HttpResponseMessage response = await client.GetAsync(uri))
        {
            var byteArray = await response.Content.ReadAsByteArrayAsync();
            string result = Encoding.UTF8.GetString(byteArray);
            File.WriteAllText(filePath, result);
        }
    }
}
//===========================================================================
//===========================================================================
//===========================================================================

//UsingQuotedStringLiterals();

//UsingStringConstructor();

//UsingRepeatingCharacter();

//UsingPointerToSignedByte();

//UsingAPointerToCharacterArray();

//UsingConcatenation();

//UsingCallingMethodThatReturnsString();

//UsingFormattedString();

//UsingVerbatimWithStringInterpolation();

//UsingRawString();

Console.ReadKey();




private static void UsingQuotedStringLiterals()
{
    // Suited for strings that fit on a single line

    string str = "Metigator";
    Console.WriteLine(str);
}

private static void UsingStringConstructor()
{
    // [2] using String Constructor (array of characters)
    char[] letters = { 'M', 'e', 't', 'i', 'g', 'a', 't', 'o', 'r' };
    string str = new string(letters);
    Console.WriteLine(str);
}

private static void UsingRepeatingCharacter()
{
    // [3] // Create a string that consists of a character repeated 8 times.
    string str = new string('M', 8);
    Console.WriteLine(str);
}

private static void UsingPointerToSignedByte()
{
    // [4] Create a string from a pointer to a signed byte array.
    //                'M'   'e'   't'   'i'   'g'   'a',  't',  'o'   'r'
    sbyte[] bytes = { 0x4D, 0x65, 0x74, 0x69, 0x67, 0x61, 0x74, 0x6F, 0x72 };
    string str = null;
    // safe context (use pointer, allocation memory block,
    // call method using function pointer
    unsafe
    {
        // Pin the buffer to a fixed location in memory.
        fixed (sbyte* ptr = bytes)
        {
            str = new string(ptr);
            Console.WriteLine(str);

        }
    }
}

private static void UsingAPointerToCharacterArray()
{
    // [5] Create a string from a pointer to a character array.
    char[] letters = { 'M', 'e', 't', 'i', 'g', 'a', 't', 'o', 'r' };

    string str = null;
    unsafe
    {
        fixed (char* pchars = letters)
        {
            // Create a string from a pointer to a character array.
            str = new string(pchars);
            Console.WriteLine(str);
        }
    }
}

private static void UsingConcatenation()
{
    // [5] Using concatenation
    string str1 = "Meti" + "gator";
    string str2 = $"{"Meti"}{"gator"}"; // string interpolation

    Console.WriteLine($"str1 = {str1}");
    Console.WriteLine($"str2 = {str2}");
}

private static void UsingCallingMethodThatReturnsString()
{

    string sentence = "I Love Metigator channel.";

    int startPos = sentence.IndexOf("Metigator"); // 7

    string str = sentence.Substring(startPos, 9); // string from 7, 

    Console.WriteLine(str);

}

private static void UsingFormattedString()
{
    // using formatted string will convert any object to string representation
    string customer = "Issam A";
    DateTime shippingDate = DateTime.Now; // yyyy-MM-dd hh:mm
    DateTime expectedDelivery = shippingDate.AddDays(7); // yyyy-MM-dd hh:mm
    decimal shippingCost = 29.99m;

    string str = String.Format(
        "\nDear {0}.," +
        "\n\nAt {1:t} on {1:D}, the order is on its way to you" +
        "\nIt's expected to be delivered at {2:t} on {2:D}, the order is on its way to you" +
        "\nShipping cost {3:c}." +
        "\n\t\t\tThanks for shopping with us!",

        customer, shippingDate, expectedDelivery, shippingCost);
    //   0           1              2                3
    Console.WriteLine(str);
}

private static void UsingVerbatimWithStringInterpolation()
{
    string customer = "Issam A";
    DateTime shippingDate = DateTime.Now;
    DateTime expectedDelivery = shippingDate.AddDays(7);
    decimal shippingCost = 29.99m;

    string str = $@"Dear {customer},

At {shippingDate:t} on {shippingDate:D}, the order is on its way to you
It's expected to be delivered at {expectedDelivery:t} on {expectedDelivery:D}, the order is on its way to you
Shipping cost {shippingCost:c}.
                        Thanks for shopping with us!";
    Console.WriteLine(str);
}

private static void UsingRawString()
{
    // Raw string starting from C# 11.0 
    string str = """
                    <nav class="box">
                        <ul>
                            <a href="javascript:void(0)">"Home"</a>
                        <li>
                        <ul>
                            <a href="javascript:void(0)">About us</a>
                        <li>
                    </nav>
                """;

    string str2 = """ this is a single line raw string""";
    Console.WriteLine(str);
    Console.WriteLine(str2);

}
//===========================================================================
//===========================================================================
//===========================================================================
// Unicode character -> code point 
// Code point a = "\u0061";
// graphemes: multiple char object (base, combine) : a  ̈
// Also we have single chars that represent the graphems ä

StreamWriter sw = new StreamWriter(@".\output.txt");
string char1 = "\u0061"; // a
string char2 = "\u0308"; // ̈

sw.WriteLine(char1); // a
sw.WriteLine(char2); // ̈


string grapheme = "\u0061\u0308";
sw.WriteLine(grapheme); // ä


string singleChar = "\u00e4";
sw.WriteLine(singleChar); // ä

// representation are equal
sw.WriteLine("{0} = {1} (Culture-sensitive): {2}", grapheme, singleChar,
             String.Equals(grapheme, singleChar,
                           StringComparison.CurrentCulture)); // true

sw.WriteLine("{0} = {1} (Ordinal): {2}", grapheme, singleChar,
             String.Equals(grapheme, singleChar,
                           StringComparison.Ordinal)); // False

sw.WriteLine("{0} = {1} (Normalized Ordinal): {2}", grapheme, singleChar,
             String.Equals(grapheme.Normalize(),
                           singleChar.Normalize(),
                           StringComparison.Ordinal)); // True
sw.Close();
//===========================================================================
//===========================================================================
//===========================================================================

// RunStringLiteralVsObject();
// RunStringLiteralKey();
// RunStringLiteralWithStringObjectComparison();
RunStringIntern();

Console.ReadKey();

public static void RunStringLiteralVsObject()
{
    string s1 = "metigator"; // string literal
    string s2 = new string("metigator"); // string object


    Console.WriteLine(s1 == s2);                   // true same content (string override equality value based)
    Console.WriteLine(s1.Equals(s2));              // true same content

    Console.WriteLine((Object)s1 == (Object)s2);   // false two different reference
    Console.WriteLine(ReferenceEquals(s1, s2));    // false two different reference

}

public static void RunStringLiteralKey()
{
    string s1 = "metigator"; // string literal
    string s2 = "aspnet"; // string literal 
    string s3 = "meti" + "gator"; // string literal



    Console.WriteLine(s1 == s2);                   // false  different content
    Console.WriteLine(ReferenceEquals(s1, s2));    // false two different reference


    Console.WriteLine(s1 == s3);   // true same content
    Console.WriteLine(ReferenceEquals(s1, s3));   // true same reference
}

public static void RunStringLiteralWithStringObjectComparison()
{
    string s1 = "metigator"; // string literal
                             //string s11 = "metigator";
    string s2 = new string("metigator");                  // string object

    Console.WriteLine(s1 == s2);                   // true, same content

    Console.WriteLine(ReferenceEquals(s1, s2));   // false different reference

}

public static void RunStringIntern()
{
    string s1 = "metigator";                       // string literal

    string s2 = new string("metigator");   // string object

    string s3 = String.Intern(s2);                  // string literal

    Console.WriteLine(s1 == s2);                   // true, same content 
    Console.WriteLine(ReferenceEquals(s1, s2));   // false different reference

    Console.WriteLine(s2 == s3);                   // true, same content 
    Console.WriteLine(ReferenceEquals(s2, s3));   // false different reference

    Console.WriteLine(s1 == s3);                   // true, same content 
    Console.WriteLine(ReferenceEquals(s1, s3));   // true, same reference


    string str = "xyz";

    Console.WriteLine(str);

}
//===========================================================================
//===========================================================================
//===========================================================================

//RunCopyTo();
// RunCompare();
// RunStringFound();
// RunStringFormat();
// RunStringIsNullOrEmpty();
// RunStringIsNullOrWhiteSpace();
// RunStringModify();
// RunToCase();
// RunTrim();
//  RunToCharacterArray();
// RunSplit();
RunStringJoin();
Console.ReadKey();


static void RunCopyTo()
{
    string s1 = "metigator";
    char[] characters = { 'f', 'u', 'l', 'l', ' ', 's', 't', 'a', 'c', 'k', ' ',
                '?', '?', '?', '?', '?', '?', '?', '?', '?'};

    Console.WriteLine(characters);

    // copies count characters from the sourceIndex position of this instance
    // to the destinationIndex position of destination character array.

    s1.CopyTo(0, characters, 11, s1.Length);

    Console.WriteLine(characters);
}

static void RunCompare()
{
    // ascii sort order (integer, capital, small)
    // a12Bc = 12Bac

    string s1 = "metigator";
    string s2 = "Metigator";

    // Compares two specified String objects and returns an integer
    // that indicates their relative position in the sort order.
    Console.WriteLine(string.Compare(s1, s2, true));  // 0
    Console.WriteLine(string.Compare(s1, s2, false)); // -1
    Console.WriteLine(string.Compare(s2, s1, false)); // 1
}

static void RunStringFound()
{
    // ascii sort order (integer, capital, small)
    string s1 = "metigator";

    // Returns whether a specified character occurs within this string.
    Console.WriteLine(s1.Contains("gato")); // true

    // starts with the specified character.
    Console.WriteLine(s1.StartsWith("meti")); // true

    // ends with the specified character.
    Console.WriteLine(s1.EndsWith("torx")); // false

    // Reports the zero-based index of the first occurrence
    Console.WriteLine(s1.IndexOf("tig")); //2
}

static void RunStringFormat()
{
    var users = new List<dynamic>
            {
                new { Username =  "user1",  Since = new DateTime(2022, 7, 7) , Followers = 15053 },
                new { Username =  "user2",  Since = new DateTime(2021, 5, 9) , Followers = 12046 },
                new { Username =  "user3",  Since = new DateTime(2022, 11, 10) , Followers = 14027 }
            };

    // Converts the value of objects to strings based on the
    // formats specified and inserts them into another string.
    var header = String.Format("{0,-12}{1,8}{2,12}\n",
                      "Username", "Created At", "Followers");

    Console.WriteLine(header);

    foreach (var user in users)
        Console.WriteLine(String.Format("{0,-12}{1,8:yyyy}{2,12:N0}\n",
                      user.Username, user.Since, user.Followers));

}

static void RunStringIsNullOrEmpty()
{
    string s1 = "metigator";
    string s2 = "";
    string s3 = "   ";
    string s4 = null;
    string s5 = String.Empty;

    // null or empty
    Console.WriteLine(String.IsNullOrEmpty(s1)); // false

    Console.WriteLine(String.IsNullOrEmpty(s2)); // true

    Console.WriteLine(String.IsNullOrEmpty(s3)); // false

    Console.WriteLine(String.IsNullOrEmpty(s4)); // true

    Console.WriteLine(String.IsNullOrEmpty(s5)); // true
}

static void RunStringIsNullOrWhiteSpace()
{
    string s1 = "metigator";
    string s2 = "";
    string s3 = "   ";
    string s4 = null;
    string s5 = String.Empty;

    // null or white spaces
    Console.WriteLine(String.IsNullOrWhiteSpace(s1)); // false

    Console.WriteLine(String.IsNullOrWhiteSpace(s2)); // true

    Console.WriteLine(String.IsNullOrWhiteSpace(s3)); // true

    Console.WriteLine(String.IsNullOrWhiteSpace(s4)); // true

    Console.WriteLine(String.IsNullOrWhiteSpace(s5)); // true
}

static void RunStringModify()
{
    string s1 = "metior";
    string s2 = "metizanor";
    string s3 = "metixyzgator";

    //Returns a new string in which a specified string is inserted at a
    //specified index position in this instance.
    s1 = s1.Insert(4, "gat");
    Console.WriteLine(s1); // metigator

    // all occurrences the current string are replaced with
    // another specified Unicode character or String.
    s2 = s2.Replace("zan", "gat");
    Console.WriteLine(s2); // metigator

    //Returns a new string in which a specified number of characters
    //from the current string are deleted.
    s3 = s3.Remove(4, 3);
    Console.WriteLine(s3); // metigator
}

static void RunToCase()
{
    string s1 = "Metigator";

    // Returns a copy of this string converted to uppercase 
    // might produce culture specific output,
    // use it when user input string in their own language
    Console.WriteLine(s1.ToUpper());

    // Returns a copy of this string converted to lowercase.
    // might produce culture specific output,
    // use it when user input string in their own language
    Console.WriteLine(s1.ToLower());

    // Returns a copy of this string converted to lowercase.
    // use for non language specific data
    Console.WriteLine(s1.ToLowerInvariant());

    // Returns a copy of this string converted to uppercase.
    // use for non language specific data
    Console.WriteLine(s1.ToUpperInvariant());
}

static void RunTrim()
{
    string s1 = "   Metigator   ";
    string s2 = "...Metigator....";

    //Removes all leading and trailing occurrences
    Console.WriteLine("Trim(), Trim(char)");
    Console.WriteLine(s1.Trim());    // "Metigator"
    Console.WriteLine(s2.Trim('.')); // "Metigator"

    //Removes all leading  occurrences
    Console.WriteLine("TrimStart(), TrimStart(char)");
    Console.WriteLine(s1.TrimStart()); // "Metigator   "
    Console.WriteLine(s2.TrimStart('.'));// "Metigator...."

    //Removes all trailing  occurrences
    Console.WriteLine("TrimEnd(), TrimEnd(char)");
    Console.WriteLine(s1.TrimEnd());//  "   Metigator"
    Console.WriteLine(s2.TrimEnd('.')); // "...Metigator"
}

static void RunToCharacterArray()
{
    string s1 = "metigator";
    char[] characters;

    //Copies the characters in this instance to a Unicode character array.
    characters = s1.ToCharArray();

    foreach (char ch in characters)
        Console.Write($" {ch}");
}

static void RunSplit()
{
    string s1 = "This is metigator channel";

    // Returns a string array that contains the substrings
    // in this instance that are delimited by elements of
    // a specified string or Unicode character array.
    string[] words = s1.Split(" ");

    foreach (var word in words)
        Console.WriteLine(word);
}

static void RunStringJoin()
{
    string[] values = { "Los Angeles", "1st Jan 1940", "15M" };

    //Concatenates the elements of a specified array or the members
    //of a collection, using the specified separator between each
    //element or member.
    string commaSeparated = string.Join(',', values);

    Console.WriteLine(commaSeparated); // Los Angeles,1st Jan 1940,15M
}













