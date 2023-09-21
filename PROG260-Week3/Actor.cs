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

        public Actor()
        {

        }

        public Actor(string name, int hP, int mP, int aP, int dEF)
        {
            Name = name;
            HP = hP;
            MP = mP;
            AP = aP;
            DEF = dEF;
        }

        public override string ToString()
        {
            return $"{Name} {HP} {MP} {AP} {DEF}";
        }
    }
}
