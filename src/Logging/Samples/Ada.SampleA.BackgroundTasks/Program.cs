using System;

namespace Ada.SampleA.BackgroundTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo { Id = 1, Name = "jinyi" };
            Console.WriteLine(foo.ToString());
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
