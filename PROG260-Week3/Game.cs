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

        public List<DoublyNode<CombatResults>> GameResults = new List<DoublyNode<CombatResults>>();
        public int ResultsIndex { get; protected set;}

        public int MaxNodeIndex { get; protected set;}

        public Actor Player { get; protected set; }

        public Game() 
        {
            Levels = LoadLevels();
            LevelIndex = 0;

            ResultsIndex = 0;
            MaxNodeIndex = Levels.Count() - 1;
        }

        public List<Level> LoadLevels()
        {
            List<Actor> actors = LoadActorsFromFile("Stats.txt");

            List<Level> levels = new List<Level>();

            actors.ForEach(actor => levels.Add(new Level($"{actor.Name}'s Lair", actor, this)));

            return levels;

        }

        public void IncrementResultsIndex() => ResultsIndex++;

        public void Start()
        {
            ClearConsole();

            ConsoleSpacer();
            Print("Welcome to IO Dungeon Crawler!");
            ConsoleSpacer();
            
            if(BoolQuestion("Want to play?","y", "n"))
            {
                ClearConsole();

                ConsoleSpacer();
                Print("Enter your player's name: ", false);
                string name = Console.ReadLine();

                ConsoleSpacer();
                int choice = Question("What is your class?", new string[] {"Knight", "Mage", "Rogue"});

                switch (choice)
                {
                    case 0: Player = new Actor(name, 170, 20, 45, 20); break;
                    case 1: Player = new Actor(name, 120, 80, 25, 10); break;
                    case 2: Player = new Actor(name, 45, 30, 50, 15); break;
                }

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

            List<Level> UncompletedLevels = Levels.FindAll(level => level.Completed == false);

            List<string> answers = new List<string>();
            UncompletedLevels.ForEach(level => answers.Add(level.Name));

            LevelIndex = Question("Which level will you Challenge?: ", answers.ToArray());

            UncompletedLevels[LevelIndex].Start();
        }

        public void Stop()
        {
            ClearConsole();

            ConsoleSpacer();
            Print("Congradulation!!! You beat I/O Dungeon!!!");
            ConsoleSpacer();
            WriteGameResultsToFile(GameResults, "Output.txt");
            Print("Your results have been saved!!!");
            ConsoleSpacer();

            
            {
                ClearConsole();

                List<string> Results = ReadGameResultsFromFile("Output.txt");

                Results.ForEach(result => 
                {
                    ConsoleSpacer();
                    Print(result);
                });
                ConsoleSpacer();

                Console.ReadLine();

            }
            else{ Exit(); }

        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
