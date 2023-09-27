using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROG260_Week3.Utility;

namespace PROG260_Week3
{
    public class Game
    {
        public List<Level> Levels { get; protected set; }

        public int LevelIndex { get; protected set; }

        public Actor Player { get; protected set; }

        public Game() 
        {
            Levels = LoadLevels();

            LevelIndex = 0;
        }

        public List<Level> LoadLevels()
        {
            List<Actor> actors = LoadActorsFromFile("Stats.txt");

            List<Level> levels = new List<Level>();

            actors.ForEach(actor => levels.Add(new Level($"{actor.Name}'s Lair", actor, this)));

            return levels;

        }

        public void Start()
        {
            ConsoleSpacer();
            Print("Welcome to IO Dungeon Crawler!");
            ConsoleSpacer();
            
            if(BoolQuestion("Want to play?","y", "n"))
            {
                ClearConsole();

                ConsoleSpacer();
                Print("Enter your player's name: ", false);
                string name = Console.ReadLine();
                Player = new Actor(name, 90, 30, 40, 25);

                Loop();
            }
            else
            {
                Exit();
            }
        }

        public void Loop()
        {
            ClearConsole();

            if(Levels.All(level => level.Completed == true)) Stop();

            /*
            Levels.ForEach(level =>
            {
                ConsoleSpacer();
                ConsoleSpacer();
                Print($"{level.Name}");
                ConsoleSpacer();
                Print("| Name HP MP AP DEF |");
                Print($"| {level.Monster} |");
                ConsoleSpacer();
                Print($"Completed : {level.Completed}");
                ConsoleSpacer();
                ConsoleSpacer();
                Print(Environment.NewLine, false);
            });
            */

            List<string> answers = new List<string>();
            Levels.ForEach(level =>
            {
                if (level.Completed != true)
                {
                    answers.Add(level.Name);
                }
            });

            LevelIndex = Question("Which level will you Challenge?: ", answers.ToArray());

            Levels[LevelIndex].Start();
        }

        public void Stop()
        {

        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
