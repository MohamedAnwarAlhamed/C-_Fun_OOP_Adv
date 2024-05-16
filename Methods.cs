
/*
- INSTANCE VS. STATIC MEMBER
- METHOD SIGNITURES
- EXPRESSION BODIED METHOD
- METHOD OVERLOAD
- PASS PARAMETER VALUE / REF.
- LOCAL METHOD
*/
var age = 18;
d1.DoSomething(ref age);
Console.WriteLine(age); // 18
Console.ReadKey();

public void DoSomething(ref int age) { age = age + 3; }
//================================//======================
var age;
d1.DoSomething(out age);
Console.WriteLine(age); // 18
Console.ReadKey();

public void DoSomething(out int age)
{
    age = 18;
    age = age + 3;
}
//================================//======================
var numString = "123456";
int number;
if (lint.TryParse(numString, out number))
{
    Console.WriteLine("invalid number");
}
else
{
    Console.WriteLine($"you provided a valid number {number}");
}
Console.ReadKey();
//================================//======================
// Method Signiture (Name + Param type + param order)

public void DoSomething(int x, double y)
{
}
public void DoSomething(double x, int y)
{
}

//================================//======================

// Method Overloading (Af common way of implementing Polymorphism)

public void Promote(double amount)
{
    Console.WriteLine($"You've got a promotion of ${amount}");
}

public void Promote(double amount, string trip)
{
    Console.WriteLine($"You've got a promotion of ${amount} and a trip {trip}");
}

public void Promote(double amount, string trip, string hotel)
{
    Console.WriteLine($"You've got a promotion of ${amount} and a trip {trip} with {hotel}");
}

//================================//======================

var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
Demo.PrintEvens(numbers);
Console.ReadKey();

public class Demo
{

    public static void PrintEvens(int[] original)
    {
        foreach (var n in original)
        {
            if (IsEven(n))
            {
                Console.Write(n + " ");
            }
        }
        bool IsEven(int number) => number % 2 == 0;
        // public bool IsEven(int number) => number % 2 == 0;
    }
}
