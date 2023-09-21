using static PROG260_Week3.Utility;

namespace PROG260_Week3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<Actor> Actors = new List<Actor>();

            StreamReader reader = new StreamReader($"{UseableBaseDir}\\Stats.txt");
            string header = "";

            var line = reader.ReadLine();

            if (line[0] == '/')
            {
                header = line;
                line = reader.ReadLine();
            }

            while( line != null )
            {
                var data = line.Split(' ').ToArray();

                Actors.Add(ParseActor(data));

                line = reader.ReadLine();
            }

            reader.Close();
            reader.Dispose();

            StreamWriter writer = new StreamWriter($"{UseableBaseDir}\\Output.txt");

            writer.WriteLine(header);

            foreach( Actor actor in Actors )
            {
                writer.WriteLine(actor.ToString());
            }

        }
    }
}