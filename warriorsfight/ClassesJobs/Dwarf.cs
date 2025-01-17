using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSmashLosersUltimate.ClassesJobs
{
    /* in the actual context Dwarf is not used, keeping it for updates/ref */
    internal class Dwarf : Warrior
    {
        bool heavyArmor = false;

        public Dwarf(string name, int defaultHealthPoints, int currentHealthPoints, int currentMagicPoints, int attack, int intelligence, int physicalDefense, int magicDefense, int accuracy, int charism, int speed) :
        base(name, defaultHealthPoints, currentHealthPoints, currentMagicPoints, attack, intelligence, physicalDefense, magicDefense, accuracy, charism, speed)
        {
        }

        public override void DamageInflicted(int damageDone)
        {
            if (heavyArmor == true)
            {
                base.DamageInflicted(damageDone / 2);

                Console.WriteLine($"{Name}'s armor saved his life, and split the damage in two ! ");
            }
            else
            {
                base.DamageInflicted(damageDone);
            }
        }
    }
}
