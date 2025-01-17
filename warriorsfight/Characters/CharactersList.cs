using System;
using System.Collections.Generic;
using SuperSmashLosersUltimate.ClassesJobs;

namespace SuperSmashLosersUltimate.Characters
{
    internal class CharactersList
    {
        private Dictionary<string, Warrior> warriors = new Dictionary<string, Warrior> /* Dictionary allows to create a list with keys and values linked to the keys (for ex: string, int = (string) Dono (for my name), (int) 28 (for my age), or it could be used for software usage with: string, string = (string) notepad.exe, (string) .txt [here you have a value (.txt) that uses the key (notepad.exe) to open] */
        {
            { "Pario", new Warrior("Pario", 7500, 7500, 700, 220, 160, 180, 210, 150, 190, 230) },
            { "Monkey Bonk", new Warrior("Monkey Bonk", 6800, 6800, 600, 200, 140, 210, 240, 160, 180, 180) },
            { "Dink", new Warrior("Dink", 6500, 6500, 650, 160, 140, 170, 200, 130, 150, 140) },
            { "Mess", new Warrior("Mess", 8000, 8000, 800, 200, 150, 180, 230, 150, 200, 170) },
            { "Pelda", new Warrior("Pelda", 7000, 7000, 700, 180, 160, 200, 210, 140, 180, 150) },
            { "Lowser", new Warrior("Lowser", 7500, 7500, 750, 190, 170, 210, 220, 160, 190, 160) }
        };
        /* for now, since it's only for a testing purpose, the stats are already defined, but a character creator menu will be added in the future (alongside a save/load system) */

        public List<string> PlayableCharacters()
        {
            return new List<string>(warriors.Keys);  /* returns the list of available character */
        }

        public Warrior GetWarriorByName(string name)
        {
            if (warriors.ContainsKey(name))
            {
                return warriors[name]; /* used to get characters for the fight in Program.cs */
            }
            else
            {
                throw new Exception("Character not found!"); /* used when in a previous version of my program you needed to actually write the name of the character, now I'm not sure if I have to keep or replace it (I would like to add more characters in the future so keeping a feature allowing you to search a character would be interesting, especially since my character list could be up to 28) */
            }
        }
    }
}
