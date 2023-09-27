using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROG260_Week3.Utility;

namespace PROG260_Week3
{
    public class Level
    {
        public string Name { get; protected set; }

        public Actor Monster { get; protected set; }

        public bool Completed { get; protected set; }

        int Round { get; set; }

        Game Host;

        public Level(string name, Actor monster, Game host) 
        {
            Name = name;
            Monster = monster;
            Host = host;
        }

        public void Start()
        {
            ClearConsole();

            ConsoleSpacer();
            Print($"Welcome to {Name}");
            ConsoleSpacer();

            if(BoolQuestion($"Would you like to challenge the {Monster.Name}?", "y", "n"))
            {
                Round = 1;
                Loop();
            }
            else
            {
                Host.Loop();
            }
        }

        void Loop()
        {
            ClearConsole();

            DisplayStats();

            string RoundCont = "Start the challenge? or admit defeat?";
            if (Round > 1) RoundCont = "Continue the challenge? or admit defeat?";

            if (BoolQuestion(RoundCont, "y", "n") == false) Stop();

            ClearConsole();

            DisplayStats();

            int initiative = BoolRand();

            switch(initiative)
            {
                case 0:
                    Print($"{Host.Player.Name} acts first!");
                    PlayerAction();
                    break;
                case 1:
                    Print($"{Monster.Name} acts first!");
                    MonsterActon();
                    break;
            }


            if(Host.Player.Alive == false || Monster.Alive == false)
            {
                Stop();
            }
            else
            {
                Round++;
                Loop();
            }

        }

        void Stop()
        {
            ClearConsole();
            
            ConsoleSpacer();

            /*
            bool[] status = new bool[] { Host.Player.Alive, Monster.Alive};

            switch(BoolArrayToNumSeq(status))
            {
                case 11: Print($"{Host.Player.Name} submitted to the {Monster.Name}!"); break;
                case 10:
                    Completed = true;
                    Print($"{Host.Player.Name} defeated the {Monster.Name}!");
                    break;
                case 01: Print($"{Host.Player.Name} was slain by the {Monster.Name}!");  break;

            }
            */

            if(Host.Player.Alive == true && Monster.Alive == true) Print($"{Host.Player.Name} submitted to the {Monster.Name}!");

            if (Monster.Alive == false)
            {
                Completed = true;
                Print($"{Host.Player.Name} defeated the {Monster.Name}!");
            }

            if(Host.Player.Alive == false) Print($"{Host.Player.Name} was slain by the {Monster.Name}!");

            ConsoleSpacer();

            if(BoolQuestion("Continue back to the main menu?", "y", "n"))
            {
                Host.Player.ResetStatus();
                Host.Loop();
            }
            else
            {
                Host.Stop();
            }
        }

        void DisplayStats()
        {
            ConsoleSpacer();
            Print("| Name HP MP AP DEF |");
            ConsoleSpacer();
            Print($"| {Host.Player} |");
            Print($"| {Monster} |");
            ConsoleSpacer();
            Print($"Round: #{Round}");
            ConsoleSpacer();
        }

        void PlayerAction()
        {
            ConsoleSpacer();

            int AttackChoice = Question("What attack will you use?", new string[] { $"Melee : {Host.Player.MlATK}", $"Magic : {Host.Player.MgATK}" });

            switch(AttackChoice)
            {
                case 0: Host.Player.MeleeAttack(Monster); break;
                case 1: Host.Player.MagicAttack(Monster); break;
            }
        }

        void MonsterActon()
        {
            ConsoleSpacer();

            int AttackChoice = Rand.Next(0, 1);

            switch(AttackChoice)
            {
                case 0:
                    Print($"{Monster.Name} used a melee attack!");
                    Monster.MeleeAttack(Host.Player); 
                    break;
                case 1:
                    Print($"{Monster.Name} used a magic attack!");
                    Monster.MagicAttack(Host.Player); 
                    break;
            }
        }
    }
}
