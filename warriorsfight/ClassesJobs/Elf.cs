using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSmashLosersUltimate.ClassesJobs
{
    /* in the actual context Elf is not used, keeping it for updates/ref */
    internal class Elf : Warrior
    {
        public Elf(string name, int defaultHealthPoints, int currentHealthPoints, int currentMagicPoints, int attack, int intelligence, int physicalDefense, int magicDefense, int accuracy, int charism, int speed) :
        base(name, defaultHealthPoints, currentHealthPoints, currentMagicPoints, attack, intelligence, physicalDefense, magicDefense, accuracy, charism, speed)
        {
        }

        public override void DamageInflicted(int damageDone)
        {
            Random accuracyChance = new Random();

            int missChance = accuracyChance.Next(1, 101); /* 1/100 chances to hit the other fighter (in the og exercise there was a condition where the elf could never miss, this is why it's 1 and not 0) */

            if (missChance > AccuracyValue)
            {
                Console.WriteLine($"{Name} missed his attack!");
            }
            else
            {
                CurrentHealthPoints -= damageDone;
                if (CurrentHealthPoints < 0)
                {
                    CurrentHealthPoints = 0;
                }

                Console.WriteLine($"{Name} now has {CurrentHealthPoints} HP remaining!");
            }
        }
    }
}
