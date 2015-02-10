using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.HashTable
{
    public class RandomWords
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
        private static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
        public static string GetRandomString(int size)
        {
            var rand1 = RandomString(size);
            var rand2 = RandomString(size + 1);
            return rand1 + "-" + rand2;
        }
    }
}
