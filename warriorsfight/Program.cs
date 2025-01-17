/* BRIEF#3 = WARRIORS' FIGHT */

/* Sources used:

- https://learn.microsoft.com/en-us/dotnet/ -> notes, examples, and got explanations for the Dictionary system in CharactersList.cs
- https://stackoverflow.com/ -> character unlock system in my corrupted version (I took notes but it will still take time to make an update on this actual version), got help for the blinking message in the title screen, and the "Press B to return to the main menu" feature
- https://chatgpt.com (DISCLAIMER: NOT used to make the program!) -> used for Thread system, correct few errors I couldn't understand properly (notably about the "Press B to return to the main menu" feature, I struggled to make it work properly, it was always redirecting me on the title screen)
- an amazing friend who saved me helping rebuild my program after my previous version got corrupted and I couldn't get anything back from it (had to redo most of the program from scratch in 1 day, that's why it got sent so late, my apologies!) 

[DISCLAIMER] ANY RESEMBLANCE TO ACTUAL VIDEOGAME CHARACTER, LIVING OR DEAD, IS PURELY COINCIDENTAL AND WAS NOT INTENTIONAL! (ok, mayyyyybe a bit intentional, but french laws allow it as soon as it's a parody so please Nintendo don't sue me!)

 */

using SuperSmashLosersUltimate.Menuing;
using SuperSmashLosersUltimate.Characters;
using SuperSmashLosersUltimate.ClassesJobs;

public class Program
{
    private static string previousGameMode = string.Empty;  /* a variable that stores the previous selected game mode */

    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.MainMenu(); /* start the program in the title screen */
    }

    public static void SetPreviousGameMode(string gameMode)
    {
        previousGameMode = gameMode;
    }

    public static void StartCPUvsCPUFight(string cpu1, string cpu2, Menu menu)
    {
        CharactersList characterList = new CharactersList();
        Warrior warrior1 = characterList.GetWarriorByName(cpu1);
        Warrior warrior2 = characterList.GetWarriorByName(cpu2);

        Console.Clear();
        Console.WriteLine($"CPU 1: {warrior1.Name} vs CPU 2: {warrior2.Name}");
        Warrior.WarriorsFight(warrior1, warrior2);

        /* this prompt method is what's gonna allows the user to choose either to go back to the main menu or start another fight */
        PromptForNextAction("CPUvsCPU", menu);
    }

    public static void StartPlayerVsPlayerFight(string player1, string player2, Menu menu)
    {
        CharactersList characterList = new CharactersList();
        Warrior warrior1 = characterList.GetWarriorByName(player1);
        Warrior warrior2 = characterList.GetWarriorByName(player2);

        Console.Clear();
        Console.WriteLine($"Player 1: {warrior1.Name} vs Player 2: {warrior2.Name}");
        Warrior.WarriorsFight(warrior1, warrior2);

        PromptForNextAction("PlayerVsPlayer", menu);
    }

    /* Method to prompt the user after a fight ends */
    private static void PromptForNextAction(string gameMode, Menu menu)
    {
        bool validChoice = false;
        while (!validChoice)
        {
            Console.WriteLine("\nStart another fight or return to main menu?");
            Console.WriteLine("\nPress A to return to the game mode or B to go back to the main menu."); /* here "A" and "B" are just a ref to Nintendo's controller layout (A = accept, B = return) */

            string userChoice = Console.ReadLine()?.ToLower();
            if (userChoice == "a")
            {
                validChoice = true;
                if (gameMode == "CPUvsCPU")
                {
                    menu.CPUvsCPU(); /* restart a fight in the actual game mode */
                }
                else if (gameMode == "PlayerVsPlayer")
                {
                    menu.PlayerVsPlayer();
                }
            }
            else if (userChoice == "b")
            {
                validChoice = true;
                menu.MainMenu(); /* go back to the main menu */
            }
            else
            {
                Console.WriteLine("\nPlease press A to return to the game mode or B to go back to the main menu!");
            }
        }
    }
}

/* Program made by THOMAS Donovan (with the help of my amazing friend L. for the rushed rebuild, thanks again!), Github: https://github.com/thomasdnv */