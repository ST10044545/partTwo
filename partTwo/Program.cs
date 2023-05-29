using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partTwo
{
    internal class Program
    {
        public static int print, ing, ste;
        public static int menu;
        static void Main(string[] args)
        {
            //calling Recipe method
            Recipe myObj = new Recipe();

            //Text colour
            ConsoleColor green = ConsoleColor.Green; // Green text colour
            ConsoleColor blue = ConsoleColor.Blue; // Blue text colour
            ConsoleColor yellow = ConsoleColor.Yellow;

            //loop
            while (menu < 6)
            {
                Console.ForegroundColor = green;
                Console.WriteLine("\n" + "Select one option at a time: " + "\n"
                                + "(1) Enter recipe: " + "\n"
                                + "(2) Display list of all recipe(s) in alphabetical order by name: " + "\n"
                                + "(3) Enter the scale factor: " + "\n"
                                + "(4) Reset the quantities to the original values: " + "\n"
                                + "(5) Clear all data to enter new recipe: " + "\n"
                                + "(ANY OTHER NUMERIC KEY) Exit Application" + "\n");
                Console.ResetColor();

                menu = Convert.ToInt32(Console.ReadLine());

                // if statements
                if (menu == 1)
                {
                    Console.ForegroundColor = blue;
                    myObj.enterRecipe();
                    Console.ResetColor();
                }
                else if (menu == 2)
                {
                    Console.ForegroundColor = yellow;
                    myObj.display();
                    Console.ResetColor();
                }
                else if (menu == 3)
                {
                    Console.ForegroundColor = blue;
                     myObj.scaleFactor();
                    Console.ResetColor();
                }
                 else if (menu == 4)
                {
                  Console.ForegroundColor = blue;
                myObj.resetValues();
                Console.ResetColor();
                }
                else if (menu == 5)
                {
                    Console.ForegroundColor = blue;
                    myObj.clearData();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = green;
                    Console.WriteLine("APPLICATION EXIT");
                    Console.ReadLine();
                    Console.ResetColor();
                }
            }
        }
    }
}
