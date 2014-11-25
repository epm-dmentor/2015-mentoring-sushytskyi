using System;

namespace Unmanaged
{
    class Program
    {
        public static void Main()
        {
            using (var console = new ApplicationConsole())
            {
                console.WriteLine("Line number: {0}", 0);
            }            
            Console.ReadKey();
        }

    }
}
