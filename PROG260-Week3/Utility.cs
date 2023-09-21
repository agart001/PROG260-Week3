using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG260_Week3
{
    public static class Utility
    {
        public static DirectoryInfo UseableBaseDir = new DirectoryInfo(BaseDir());

        public static string BaseDir()
        {
            string str = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

            return str;
        }

        public static void Print(string str) => Console.WriteLine(str);


        public static int TryParseInt(string input)
        {
            int value = 0;
            if(int.TryParse(input, out value))
            {
                return value;
            }

            return 0;
        }

        public static Actor ParseActor(string[] data)
        {
            string name = data[0];
            int hp = TryParseInt(data[1]);
            int mp = TryParseInt(data[2]);
            int ap = TryParseInt(data[3]);
            int def = TryParseInt(data[4]);

            return new Actor(name, hp, mp, ap, def);
        }
    }
}
