
namespace Tsubaki.Test.Console
{
    using System;

    partial class Program
    {
        static Program()
        {
            Console.WriteLine("Start");
        }
        ~Program()
        {
            Console.WriteLine("End");
        }
        static void Main(string[] args)
        {
            main();
            Console.ReadKey();
        }
    }
}
