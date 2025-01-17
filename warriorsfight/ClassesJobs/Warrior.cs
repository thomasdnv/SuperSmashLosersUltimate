using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SuperSmashLosersUltimate.ClassesJobs
{
    /* this entire section hasn't changed since my 1.0, but a lot is going to change here (stats from "attack" to "speed" don't have any effect for now) */
    internal class Warrior
    {
        private string _name;
        private int _defaultHealthPoints;
        private int _currentHealthPoints;
        private int _currentMagicPoints;
        private int _attack;
        private int _intelligence;
        private int _physicalDefense;
        private int _magicDefense;
        private int _accuracy;
        private int _charism;
        private int _speed;

        private bool throwAtkDie = false;
        private bool throwHealDie = false;

        public Warrior(string name, int defaultHealthPoints, int currentHealthPoints, int currentMagicPoints, int attack, int intelligence, int physicalDefense, int magicDefense, int accuracy, int charism, int speed)
        {
            _name = name;
            _defaultHealthPoints = defaultHealthPoints;
            _currentHealthPoints = currentHealthPoints;
            _currentMagicPoints = currentMagicPoints;
            _attack = attack;
            _intelligence = intelligence;
            _physicalDefense = physicalDefense;
            _magicDefense = magicDefense;
            _accuracy = accuracy;
            _charism = charism;
            _speed = speed;
        }

        public override string ToString() /* allows the warriors' names to be displayed properly with Program.cs when you start the console */
        {
            return Name;
        }

        public string Name { get { return _name; } set { _name = value; } }

        public int DefaultHealthPoints { get { return _defaultHealthPoints; } set { _defaultHealthPoints = value; } }

        public int CurrentHealthPoints { get { return _currentHealthPoints; } set { _currentHealthPoints = value; } }

        public int CurrentMagicPoints { get { return _currentMagicPoints; } set { _currentMagicPoints = value; } }

        public int AttackValue { get { return _attack; } set { _attack = value; } }

        public int IntelligenceValue { get { return _intelligence; } set { _intelligence = value; } }

        public int DefenseValue { get { return _physicalDefense; } set { _physicalDefense = value; } }

        public int MagicDefenseValue { get { return _magicDefense; } set { _magicDefense = value; } }

        public int AccuracyValue { get { return _accuracy; } set { _accuracy = value; } }

        public int CharismValue { get { return _charism; } set { _charism = value; } }

        public int SpeedValue { get { return _speed; } set { _speed = value; } }

        public string WarriorName()
        {
            Console.WriteLine($"Our warriors for the next fight are {Name} and {Name} ! ");
            return Name;
        }

        public virtual int Attack(Warrior opponent)
        {
            Random atkChance = new Random();
            if (atkChance.Next(1, 2) == 1)
            {
                int damageDone = atkChance.Next(300, 901); /* minDmg 300 and maxDmg 900, since my test characters have a average of 7k HP, it's fair using this range so the fight doesn't long too much (as well as not making my pc suffer for free) */
                Console.WriteLine($"{Name} managed to success his attack and did {damageDone} ! ");
                opponent.DamageInflicted(damageDone);
            }
            else
            {
                Console.WriteLine($"{Name} missed his attack ! ");
            }
            return CurrentHealthPoints;
        }

        public virtual void DamageInflicted(int damageDone)
        {
            CurrentHealthPoints -= damageDone;
            if (CurrentHealthPoints < 0)
            {
                CurrentHealthPoints = 0;
            }

            Console.WriteLine($"{Name} now has {CurrentHealthPoints}HP ! ");
        }

        public virtual int Healing()
        {
            Random healChance = new Random();
            if (healChance.Next(1, 2) == 1)
            {
                int healReceived = healChance.Next(1, 9); /* same as damage but for the heal */

                CurrentHealthPoints += healReceived;

                Console.WriteLine($"The heal cast succeed and {Name} got {healReceived}HP, getting back to {CurrentHealthPoints} ! ");
            }
            else
            {
                Console.Write($"{Name} couldn't cast the heal ! ");
            }
            return CurrentHealthPoints;
        }

        public int HealthPoints()
        {
            Console.WriteLine($"{Name} is currently at {CurrentHealthPoints}HP ! ");
            return CurrentHealthPoints;
        }

        public bool Alive()
        {
            return CurrentHealthPoints > 0;
        }

        public static void WarriorsFight(Warrior warrior1, Warrior warrior2)
        {
            Random fighter = new Random();
            while (warrior1.Alive() && warrior2.Alive())
            {
                Console.WriteLine($"\n{warrior1.Name}'s turn ! ");
                warrior1.Attack(warrior2);

                if (fighter.Next(0, 2) == 1)
                {
                    if (!warrior2.Alive()) break; /* automatically end the fight if warrior 2 dies */
                }

                Console.WriteLine($"\n{warrior2.Name}'s turn ! ");
                warrior2.Attack(warrior1);

                if (fighter.Next(1, 2) == 1)
                {
                    if (!warrior1.Alive()) break;
                }
            }

            if (warrior1.Alive())
            {
                Console.WriteLine($"\n{warrior1.Name} wins the fight ! Shame to {warrior2.Name} for being so miserable! ");
            }
            else
            {
                Console.WriteLine($"\n{warrior2.Name} wins the fight ! How can you bear the name {warrior1} and lose against that.. what a loser.");
            }

        }
    }
}
