using System;
using System.Collections.Generic;

namespace EverestEngineering
{
    public static class DisplayMenu 
    {
        // Set the default index of the selected item to be the first
        private static int index = 0;
        // use to print menu list
        public static void Display()
        {
            WriteMenu(IMenuOption.MenuOptions, IMenuOption.MenuOptions[index]);
            HandelKeyInput();
        }
        // Write the menu out
        private static void WriteMenu(IList<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }

        //Handels keybord inputs.
        private static void HandelKeyInput()
        {
            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < IMenuOption.MenuOptions.Count)
                    {
                        index++;
                        WriteMenu(IMenuOption.MenuOptions, IMenuOption.MenuOptions[index]);
                    }
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(IMenuOption.MenuOptions, IMenuOption.MenuOptions[index]);
                    }
                }
                // Handle different action for the option
                else if (keyinfo.Key == ConsoleKey.Enter)
                {
                    IMenuOption.MenuOptions[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
        }

    }

}