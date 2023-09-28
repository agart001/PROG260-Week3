using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG260_Week3
{
    public static class Utility
    {
        #region Rand
        public static Random Rand = new Random();

        public static int BoolRand()
        {
            Random r = new Random();
            return r.Next(0, 1);
        }
        #endregion

        #region I/O
        public static DirectoryInfo UseableBaseDir = new DirectoryInfo(BaseDir());

        public static string BaseDir()
        {
            string str = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

            return str;
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

        public static List<Actor> LoadActorsFromFile(string file)
        {
            List<Actor> Actors = new List<Actor>();

            StreamReader reader = new StreamReader($"{UseableBaseDir}\\{file}");
            string header = "";

            var line = reader.ReadLine();

            if (line[0] == '/')
            {
                header = line;
                line = reader.ReadLine();
            }

            while (line != null)
            {
                var data = line.Split(' ').ToArray();

                Actors.Add(ParseActor(data));

                line = reader.ReadLine();
            }

            reader.Close();
            reader.Dispose();

            return Actors;
        }

        public static void WriteGameResultsToFile<T>(List<DoublyNode<T>> Results, string file)
        {
            //FileStream stream = new FileStream($"{UseableBaseDir}\\{file}", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(stream);

            string header = "/ Head | Node | Tail -- Node Data (Player , Opponent, Total Rounds)";
            writer.WriteLine(header);

            Results.ForEach(result => writer.WriteLine(result));

            writer.Close();
            //stream.Close();
        }

        public static List<string> ReadGameResultsFromFile(string file)
        {
            List<string> Results = new List<string>();

            StreamReader reader = new StreamReader($"{UseableBaseDir}\\{file}");

            var line = reader.ReadLine();

            if (line[0] == '/') line = reader.ReadLine();

            while (line != null)
            {
                Results.Add(reader.ReadLine());
            }

            reader.Close();
            reader.Dispose();

            return Results;
        }

        #endregion

        #region Console
        public static void Print(string input) => Console.WriteLine(input);

        public static void Print(string input, bool newline, ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(input);

            if (newline) Console.WriteLine();
        }

        public static void ClearConsole() => Console.Clear();

        public static void ConsoleSpacer() => Print("-------------------------------------------------", true, ConsoleColor.DarkGray);

        static bool IsDigit(string input)
        {
            char[] char_array = input.ToArray();

            bool digit = false;
            bool[] digits = new bool[char_array.Length];
            int index = 0;

            foreach (char c in char_array)
            {
                if (Char.IsDigit(c)) digits[index] = true;

                index++;
            }

            digit = digits.All(i => i == true);

            return digit;
        }

        static int GetIntInput()
        {
            string input = Console.ReadLine();
            if (IsDigit(input))
            {
                return Convert.ToInt32(input);
            }
            else
            {
                ConsoleSpacer();
                Print("{ ERROR } - input contains non-digit character // re-enter the input: ", false, ConsoleColor.Red);
                return GetIntInput();
            }
        }

        public static bool BoolQuestion(string question, string confirm, string cancel)
        {
            bool result = false;

            Print($"{question} Confirm/Cancel: {confirm}/{cancel} :", false);
            string answer = Console.ReadLine().ToLower();
            if (answer == confirm) result = true;
            if (answer == cancel) result = false;

            return result;
        }

        public static int Question(string question, string[] answers)
        {
            Print(question, true, ConsoleColor.Green);

            ConsoleSpacer();

            int index = 0;
            foreach (string answer in answers)
            {
                index++;
                Print($" {index} ) {answer}", true, ConsoleColor.Yellow);
            }
            ConsoleSpacer();

            Print(" Answer: ", false);

            int input = GetIntInput();

            return input - 1;
        }
        #endregion


        public static int TryParseInt(string input)
        {
            int value = 0;
            if (int.TryParse(input, out value))
            {
                return value;
            }

            return 0;
        }

        public static int BoolArrayToNumSeq(bool[] array)
        {
            string[] asnum = new string[array.Length];
            int index = 0;
            foreach(bool b in array)
            {
                asnum[index] = (b ? 1 : 0).ToString();
                index++;
            }

            string combine = asnum.Aggregate((sum, next) => sum += next);

            return Convert.ToInt32(combine);
        }

    }
}
