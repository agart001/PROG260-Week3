using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG260_Week3
{
    public class Actor
    {
        public string Name { get; protected set; }

        public int HP { get; protected set; }
        public int MP { get; protected set; }
        public int AP { get; protected set; }
        public int DEF { get; protected set; }

        int[] Stats;

        public int MgATK { get; protected set; }
        public int MlATK { get; protected set; }

        public bool Alive { get; protected set; }

        public Actor()
        {

        }

        public Actor(string name, int hP, int mP, int aP, int dEF)
        {
            Stats = new int[] { hP, mP, aP, dEF };
            Alive = true;

            Name = name;
            HP = hP;
            MP = mP;
            AP = aP;
            DEF = dEF;

            MgATK = (int)(MP / (float)HP * 100);
            MlATK = (int)(AP / (float)HP * 100);
        }

        public void SetHealth(int value)
        {
            if(value < 0)
            {
                HP = 0;
                Alive = false;
            }
            else { HP = value; }
        }

        public void MeleeAttack(Actor opponent)
        {
            opponent.SetHealth(opponent.HP - (MlATK - opponent.DEF));
        }

        public void MagicAttack(Actor opponent)
        {
            opponent.SetHealth(opponent.HP - (MgATK - opponent.MP));
        }

        public void ResetStatus()
        {
            Alive = true;
            
            HP = Stats[0];
            MP = Stats[1];
            AP = Stats[2];
            DEF = Stats[3];
        }

        public Actor Clone() => (Actor)MemberwiseClone();

        public override string ToString() => $"{Name} {HP} {MP} {AP} {DEF}";
    }
}
