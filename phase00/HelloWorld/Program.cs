// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
MyFirstNamespace.Program.SayHello();
Program2.SayHello();




public class Program2
{
    public static void SayHello()
    {
        Console.Write("hello again and again...\n");
        return; 
    }
    
}

namespace MyFirstNamespace
{
    class Program
    {
        public static void SayHello()
        {
            Console.Write("hello again...\n");
            return;
        }
        
    }
    
}



