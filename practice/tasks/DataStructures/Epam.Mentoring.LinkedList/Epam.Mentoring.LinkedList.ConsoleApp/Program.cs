using System;

namespace Epam.Mentoring.LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();

            list.Add("test");
            list.Add("sdf");
            list.Add("xcvs");

            list.RemoveAt(2);
            var elem = list.FindElementAt(1);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}
