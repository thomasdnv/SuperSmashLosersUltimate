using System;
using System.Collections.Generic;
using SuperSmashLosersUltimate.Characters;

namespace SuperSmashLosersUltimate.Menuing
{
    public class Menu
    {
        private bool DisplayedWelcomeOnce = false; /* bool that will make display the welcome title only once each time you start the program */

        private static string previousGameMode; /* allows to return to the selected game mode after the end of each fight (by pressing "A") */

        public static void PreviousGameMode(string gameMode)
        {
            previousGameMode = gameMode;
        }

        public void CenterText(string text) /* centers the menus */
        {
            int windowWidth = Console.WindowWidth;
            int paddingLeft = (windowWidth - text.Length) / 2;
            Console.SetCursorPosition(paddingLeft, Console.CursorTop);
            Console.WriteLine(text);
        }

        public void MainMenu()
        {
            bool menu = true;
            int selectionChoice = 0;
            
            if (!DisplayedWelcomeOnce) /* this if is what will display the welcome title only once when you start the program */
            {
                DisplayTitleScreenWithMessage();
                Console.ReadLine();
                Console.Clear();
                DisplayedWelcomeOnce = true; /* it allows to never show the welcome title anymore until you restart the program */
            }

            while (menu)
            {
                DisplayTitleScreenWithMenu(selectionChoice);

                string[] selectionMenu = /* string[] gives a better formatting in the code, and not getting 6 repetitive string commands */
                    {
                        "CPU vs CPU",
                        "Player vs Player",
                        "Bonus",
                        "DLC",
                        "Options",
                        "Credits"
                    };

                /* this if highlights the user selection in the menu (here in cyan) */
                for (int i = 0; i < selectionMenu.Length; i++)
                {
                    if (i == selectionChoice)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    CenterText(selectionMenu[i]);
                    Console.ResetColor();
                }

                /* commands guide to navigate in the selection menu */
                Console.WriteLine();
                Console.SetCursorPosition((Console.WindowWidth - "Enter = enter a menu UP/DOWN = navigate".Length) / 2, Console.CursorTop);
                Console.WriteLine("Enter = enter a menu \tUP/DOWN = navigate");

                /* this consolekey part allows the user to navigate in the menu using the arrows */
                /* SMALL DETAIL HERE: LEFT has the same info as UP and RIGHT the same info as DOWN because there is a convention in videogames with vertical menus since decades where all the
                buttons from the controller cross have to be usable, with LEFT = UP (because LEFT = going back, so you go back to the top) and RIGHT = DOWN (because RIGHT = going forward) */
                /* note that you're not obligatered to do so, but in videogame development we don't usually like having buttons with no assigned action */
                ConsoleKeyInfo keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.UpArrow || keyInput.Key == ConsoleKey.LeftArrow)
                {
                    selectionChoice--;
                    if (selectionChoice < 0)
                    {
                        selectionChoice = selectionMenu.Length - 1;
                    }
                }
                else if (keyInput.Key == ConsoleKey.DownArrow || keyInput.Key == ConsoleKey.RightArrow)
                {
                    selectionChoice++;
                    if (selectionChoice >= selectionMenu.Length)
                    {
                        selectionChoice = 0;
                    }
                }
                else if (keyInput.Key == ConsoleKey.Enter)
                {
                    menu = false;
                }
            }

            MenuSelection(selectionChoice); /* our method that allows us to use the selection menu */
        }

        public void DisplayTitleScreenWithMessage()
        {
            /* the bool and int here are used to make the "Press Enter to continue" blink like in many videogames when you're at the title screen */
            bool showMessage = true;
            int blinkDuration = 500; /* 500ms is pretty common to use */

            while (!Console.KeyAvailable) /* this loop makes the message blink until we push a key */
            {
                /* automically check when to active the blink */
                System.Threading.Thread.Sleep(blinkDuration);
                Console.Clear();

                /* reset the title UI after each blink */
                Console.ForegroundColor = ConsoleColor.Magenta;
                CenterText("+-----------------------------+");
                Console.ResetColor();
                CenterText("  _____ _____ _      _    _ ");
                CenterText(" / ____/ ____| |    | |  | |");
                CenterText("| (___| (___ | |    | |  | |");
                CenterText(" \\___ \\\\___ \\| |    | |  | |");
                CenterText(" ____) |___) | |____| |__| |");
                CenterText("|_____/_____/|______|\\____/ ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                CenterText("  Super Smash Losers Ultimate  ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                CenterText("+-----------------------------+");
                Console.ResetColor();

                /* display the message with the blink effect */
                if (showMessage)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    CenterText("Press Enter to continue");
                }
                showMessage = !showMessage; /* this command makes the message visible 1/2 time (this is what create the blink effect) */
            }
        }

        /* this UI is the one we see after pressing "Enter" during the title screen, I haven't seen any way for now to use it only one time in the code */
        public void DisplayTitleScreenWithMenu(int selectionChoice)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            CenterText("+-----------------------------+");
            Console.ResetColor();
            CenterText("  _____ _____ _      _    _ ");
            CenterText(" / ____/ ____| |    | |  | |");
            CenterText("| (___| (___ | |    | |  | |");
            CenterText(" \\___ \\\\___ \\| |    | |  | |");
            CenterText(" ____) |___) | |____| |__| |");
            CenterText("|_____/_____/|______|\\____/ ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            CenterText("  Super Smash Losers Ultimate  ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            CenterText("+-----------------------------+");
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        /* switch that handle the selection menu */
        private void MenuSelection(int selectionChoice)
        {
            switch (selectionChoice)
            {
                case 0:
                    Console.Clear();
                    Program.SetPreviousGameMode("CPUvsCPU"); /* this method will allow us to go back to the beginning of this selected mode without having to redo everything back from the main menu */
                    CPUvsCPU();
                    break;
                case 1:
                    Console.Clear();
                    Program.SetPreviousGameMode("PlayerVsPlayer");
                    PlayerVsPlayer();
                    break;
                case 2:
                    Console.Clear();
                    Bonus();
                    break;
                case 3:
                    Console.Clear();
                    DLC();
                    break;
                case 4:
                    Console.Clear();
                    Options();
                    break;
                case 5:
                    Console.Clear();
                    Credits();
                    break;
            }
        }
        /* in a previous version of my program (that got corrupted), I made something with PlayerVsPlayer, Bonus and Options, but since I had to redo everything from scratch I will update all of this a bit later */

        /* character selection for the CPUvsCPU mode */
        public void CPUvsCPU()
        {
            CharactersList characterList = new CharactersList();
            List<string> availableCharacters = characterList.PlayableCharacters();

            Console.Clear();
            Console.WriteLine("CPU vs CPU");

            string cpu1 = GetCharacterSelection(availableCharacters, "CPU 1");

            string cpu2 = GetCharacterSelection(availableCharacters, "CPU 2");

            /* this command transmit the action to Program.cs to start/handle the fight */
            Program.StartCPUvsCPUFight(cpu1, cpu2, this); /* "this" is the option that allows us to choose if we want to start another fight or go back to the main menu */
        }
        /* originally, I made a unlocked/locked character system when you had to beat a locked character 5 times to unlock it, but because of the same reason as previously, I have to redo it (the update will come pretty soon) */
        /* where this system is a bit hard is I tried to make something where Players can't use the locked characters, but CPUs can */

        /* because I lost my class with all my attacks/skills, for now the Player vs Player is basically the same thing as the CPU vs CPU, an update will soon be released as soon as everything is setup again */
        public void PlayerVsPlayer()
        {
            //CharactersList characterList = new CharactersList();
            //List<string> availableCharacters = characterList.PlayableCharacters();

            //Console.Clear();
            //Console.WriteLine("Player vs Player");
            //Console.WriteLine("\nSelect characters or random:");

            //string player1 = GetCharacterSelection(availableCharacters, "Player 1");

            //string player2 = GetCharacterSelection(availableCharacters, "Player 2");

            Console.WriteLine("\nSorry! The Player vs Player mode is still in progress. Changes/features will be added in a upcoming update, make sure to follow me on github at https://github.com/thomasdnv to stay informed! \nSorry for the inconveniances and thanks for the support!");
            ReturnToMainMenu();

            //Program.StartCPUvsCPUFight(player1, player2, this);
        }

        private string GetCharacterSelection(List<string> availableCharacters, string player)
        {
            int selectionChoice = 0;
            bool validSelection = false;

            /* loop where you choose your character (your pick is higlighted in yellow) */
            while (!validSelection)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.SetCursorPosition((Console.WindowWidth - $"{player}, select your fighter!".Length) / 2, Console.CursorTop);
                Console.WriteLine($"{player}, select your fighter!");
                Console.WriteLine();
                Console.WriteLine();

                for (int i = 0; i < availableCharacters.Count; i++)
                {
                    if (i == selectionChoice)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    CenterText(availableCharacters[i]);
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.SetCursorPosition((Console.WindowWidth - "Enter = confirm \tUP/Down = select".Length) / 2, Console.CursorTop);
                Console.WriteLine("Enter = confirm \tUP/Down = select");
                Console.SetCursorPosition((Console.WindowWidth - "\"R = random character".Length) / 2, Console.CursorTop);
                Console.WriteLine("R = Pick a random character");

                ConsoleKeyInfo keyInput = Console.ReadKey(true);

                /* if handling the character selection, with the UP/LEFT and DOWN/RIGHT feature, and "R" allowing to pick a random character */
                if (keyInput.Key == ConsoleKey.UpArrow || keyInput.Key == ConsoleKey.LeftArrow)
                {
                    selectionChoice--;
                    if (selectionChoice < 0)
                    {
                        selectionChoice = availableCharacters.Count - 1;
                    }
                }
                else if (keyInput.Key == ConsoleKey.DownArrow || keyInput.Key == ConsoleKey.RightArrow)
                {
                    selectionChoice++;
                    if (selectionChoice >= availableCharacters.Count)
                    {
                        selectionChoice = 0;
                    }
                }
                else if (keyInput.Key == ConsoleKey.Enter)
                {
                    validSelection = true;
                }
                else if (keyInput.Key == ConsoleKey.R) /* R = random key input */
                {
                    Random random = new Random();
                    selectionChoice = random.Next(availableCharacters.Count);
                    validSelection = true;
                }
            }
            return availableCharacters[selectionChoice]; /* allows to pick different characters for another fight */
        }

        public void Bonus()
        {
            Console.WriteLine("Bonus will be available in a future update! Stay tuned by following me on github at https://github.com/thomasdnv ! Cheers mate.");
            ReturnToMainMenu();
        }

        public void DLC()
        {
            Console.WriteLine("DLC will be available in a future update! Stay tuned by following me on github at https://github.com/thomasdnv ! Cheers mate.");
            ReturnToMainMenu();
        }

        public void Options()
        {
            Console.WriteLine("Options will be available in a future update! Stay tuned by following me on github at https://github.com/thomasdnv ! Cheers mate.");
            ReturnToMainMenu();
        }

        public void Credits()
        {
            Console.WriteLine("Credits will be available in a future update! Stay tuned by following me on github at https://github.com/thomasdnv ! Cheers mate.");
            ReturnToMainMenu();
        }

        /* feature to to back directly to the main menu after a fight by pushing "B" */
        private void ReturnToMainMenu()
        {
            Console.WriteLine("\nPress 'B' to return to the main menu");

            ConsoleKeyInfo keyInput = Console.ReadKey(true);
            if (keyInput.Key == ConsoleKey.B)
            {
                MainMenu();
            }
            else
            {
                MainMenu();
            }
        }
    }
}
