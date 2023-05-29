using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partTwo
{
    internal class Recipe
    {
        //declare variable
        public static int print;
        
        //Text colour
        ConsoleColor red = ConsoleColor.Red;
        ConsoleColor yellow = ConsoleColor.Yellow;
        public string recName  // property
        { get; set; }

        //Method calling
        Ingredient myObje = new Ingredient();
        Step myObject = new Step();

        //generics
        public static List<int> ingNum = new List<int>();

        public static List<string> ingredientName = new List<string>();
        public static List<string> ingredientQuantity = new List<string>();
        public static List<string> ingredientUnit = new List<string>();

        public static List<int> steNum = new List<int>();

        public static List<string> stepDescription = new List<string>();

        public static List<string> ingredientCalories = new List<string>();
        public static List<string> ingredientFoodGroup = new List<string>();

        public static List<string> firstIngredientQuantity = new List<string>();

        public static List<string> recipeName = new List<string>();

        //Initialize 
        int allCalories = 0;
        int dataStorage = 0;
        int count = 0;

        //Introduce delegate
        delegate T calculating<T>(T sum);

        public void enterRecipe()
        {
            //Prompt 
            Console.WriteLine("Enter the name of the recipe ");
            string recipe = Console.ReadLine();
            recipeName.Add(recipe);

            //Prompt
            Console.WriteLine("\n" + "Enter the number of ingredients");
            int ing = Convert.ToInt32(Console.ReadLine());
            ingNum.Add(ing);


            for (int a = 0; a < ing; a++)
            {
                //Prompt
                Console.WriteLine("\n" + "Enter name of the ingredient > " + (a + 1));
                string ingName = Console.ReadLine();

                //Prompt
                Console.WriteLine("\n" + "Enter the quantity of ingredients > " + (a + 1));
                string ingQuantity = Console.ReadLine();

                //Prompt
                Console.WriteLine("\n" + "Enter unit of measurement of the ingredient > " + (a + 1));
                string ingUnit = Console.ReadLine();

                //Prompt
                Console.WriteLine("\n" + "Enter the number of  calories: ");
                string cal = Console.ReadLine();

                //Prompt
                Console.WriteLine("\n" + "Enter the food group :" + "\n"
                                       + "(1) Starchy foods" + "\n"
                                       + "(2) Vegetables and fruits" + "\n"
                                       + "(3) Dry beans, peas, lentils and soya" + "\n"
                                       + "(4) Chicken, fish, meat and eggs" + "\n"
                                       + "(5) Milk and dairy products" + "\n"
                                       + "(6) Fats and oil" + "\n"
                                       + "(7) Water" + "\n");
                string food = Console.ReadLine();

                string foodGroup = "";

                if (food == "1")
                {
                    foodGroup = "Starchy foods";
                }
                else if (food == "2")
                {
                    foodGroup = "Vegetables and fruits";
                }
                else if (food == "3")
                {
                    foodGroup = "Dry beans, peas, lentils and soya";
                }
                else if (food == "4")
                {
                    foodGroup = "Chicken, fish, meat and eggs";
                }
                else if (food == "5")
                {
                    foodGroup = "Milk and dairy products";
                }
                else if (food == "6")
                {
                    foodGroup = "Fats and oil";
                }
                else if (food == "7")
                {
                    foodGroup = "Water";
                }
                else
                {
                    Console.WriteLine("You did not choose any food group");
                }

                calculating<int> return_all = new calculating<int>(calculateAllCalories);

                return_all(int.Parse(cal));

                myObje.Name = ingName;
                myObje.Quantity = ingQuantity;
                myObje.UnitOfMeasurement = ingUnit;

                ingredientName.Add(ingName + recipe);
                ingredientQuantity.Add(ingQuantity + recipe);
                ingredientUnit.Add(ingUnit + recipe);

                ingredientCalories.Add(int.Parse(cal) + recipe);
                ingredientFoodGroup.Add(foodGroup + recipe);

                firstIngredientQuantity.Add(ingQuantity + recipe);
            }
            //Prompt
            Console.WriteLine("\n" + "Enter the number of steps: ");
            int ste = Convert.ToInt32(Console.ReadLine());
            steNum.Add(ste);

            for (int s = 0; s < ste; s++)
            {
                //Prompt
                Console.WriteLine("\n" + "Enter the step description > " + (s + 1));
                string steName = Console.ReadLine();

                myObject.Description = steName;

                stepDescription.Add(steName + recipe);
            }
            //Notification
            Console.WriteLine("\n" + recipe + " successfully saved.");    

        }

        public int calculateAllCalories(int ingredientCalories)
        {

            allCalories += ingredientCalories;

            if (allCalories > 300)
            {
                Console.ForegroundColor = red;
                Console.WriteLine("You have exceeded the maximum number of calories which is 300, " + "\n" + "Currently the total calories of your ingredients is: " + allCalories);
                Console.ResetColor();
            }
            if ((count + 1) == dataStorage)
            {
                Console.ForegroundColor = yellow;
                Console.WriteLine("Total number of calories: " + allCalories);
                Console.ResetColor();
            }

            return allCalories;
        }
        public void display()
        {
            //method that sort the recipe names
            recipeName.Sort();

            Console.WriteLine("list of all your recipes in alphabetical order by name: ");

            for (int b = 0; b < recipeName.Count; b++)
            {
                Console.WriteLine((b + 1) + "." + recipeName[b]);

            }
            Console.WriteLine("\n" + "Write the name of the recipe to display from the list: ");
            string names = Console.ReadLine();

            for (int c = 0; c < recipeName.Count; c++)
            {

                if (recipeName[c].Contains(names))
                {
                    Console.WriteLine("\n" + "Recipe name: " + recipeName[c]);

                }

            }
            for (int d = 0; d < ingredientName.Count; d++)
            {
                if (ingredientName[d].Contains(names) && ingredientQuantity[d].Contains(names) && ingredientUnit[d].Contains(names) && ingredientCalories[d].Contains(names) && ingredientFoodGroup[d].Contains(names))
                {
                    //display
                    Console.WriteLine("\n" + (d + 1) + " - Ingredient        : " + ingredientQuantity[d].Replace(names, "") + " " + ingredientUnit[d].Replace(names, "") + " of " + ingredientName[d].Replace(names, "")
                               + "\n" + "    Number of calories: " + ingredientCalories[d].Replace(names, "")
                               + "\n" + "    Food group        : " + ingredientFoodGroup[d].Replace(names, ""));
                }

            }
            for (int e = 0; e < stepDescription.Count; e++)
            {
                if (stepDescription[e].Contains(names))
                {
                    //display
                    Console.WriteLine("\n" + (e + 1) + " - Step: " + stepDescription[e].Replace(names, ""));
                }

            }
        }
        public void scaleFactor()
        {
            //Prompt
            Console.WriteLine("\n" + "Enter scaling factor" + "\n"
                           + "(1) 0.5 (half)" + "\n"
                           + "(2) 2(double)" + "\n"
                           + "(3) 3(triple)" + "\n");
            print = Convert.ToInt32(Console.ReadLine());

            if (print == 1)
            {
                Console.WriteLine("Choose the recipe to scale");

                for (int f = 0; f < recipeName.Count; f++)
                {
                    Console.WriteLine((f + 1) + ": " + recipeName[f]);

                }
                //Prompt
                Console.WriteLine("\n" + "Write the name of the recipe to scale from the list: ");
                string namess = Console.ReadLine();

                for (int g = 0; g < ingredientName.Count; g++)
                {
                    if (ingredientName[g].Contains(namess))
                    {
                        double mult = double.Parse(ingredientQuantity[g].Replace(namess, ""));

                        double sum = mult * 1/2;
                        ingredientQuantity[g] = "" + sum + namess;
                    }
                }
                Console.WriteLine("The recipe is scaled");
            }
            else if (print == 2)
            {
                Console.WriteLine("Choose the recipe to scale");

                for (int f = 0; f < recipeName.Count; f++)
                {
                    Console.WriteLine((f + 1) + ": " + recipeName[f]);

                }
                //Prompt
                Console.WriteLine("\n" + "Write the name of the recipe to scale from the list: ");
                string namess = Console.ReadLine();

                for (int g = 0; g < ingredientName.Count; g++)
                {

                    if (ingredientName[g].Contains(namess))
                    {

                        double mult = double.Parse(ingredientQuantity[g].Replace(namess,""));

                        double sum = mult * 2;
                        ingredientQuantity[g] =""+ sum+namess;
                    }
                }
                Console.WriteLine("The recipe is scaled");
            }
            else if (print == 3)
            {
                Console.WriteLine("Choose the recipe to scale");
                string namess = Console.ReadLine();

                for (int k = 0; k < ingredientName.Count; k++)
                {
                    if (ingredientName[k].Contains(namess))
                    {
                        double mult = double.Parse(ingredientQuantity[k].Replace(namess, ""));

                        double sum = mult * 3;
                        ingredientQuantity[k] = "" + sum + namess;
                    }
                }
                Console.WriteLine("The recipe is scaled");
            }
            else
            {
                Console.WriteLine("No scaling");
            }
        }
        public void resetValues() 
        {
            Console.WriteLine("Choose the recipe to scale");

            for (int h = 0; h < recipeName.Count; h++)
            {
                Console.WriteLine((h + 1) + ": " + recipeName[h]);

            }
            //Prompt
            Console.WriteLine("\n" + "Write the name of the recipe to reset from the list: ");
            string namesss = Console.ReadLine();

            for (int j = 0; j < ingredientName.Count; j++)
            {

                if (ingredientName[j].Contains(namesss))
                {
                    ingredientQuantity[j] = firstIngredientQuantity[j];
                    // double mult = double.Parse(ingredientQuantity[g].Replace(namesss, ""));

                    //double sum = mult * 2;
                    //ingredientQuantity[g] = "" + sum + namess;
                }
            }
            Console.WriteLine("Reset quantities done");
        }
        public void clearData()
        {
            Console.WriteLine("\n" + "Do you want to clear your data: " + "\n"
                     + "Press (y) for yes" + "\n"
                     + "Press any other key for no" + "\n");
            string clearing = Console.ReadLine();

            if (clearing == "y")
            {
                //Clearing all data
                recipeName.Clear();
                ingNum.Clear();
                ingredientName.Clear();
                ingredientQuantity.Clear();
                ingredientUnit.Clear();
                steNum.Clear();
                stepDescription.Clear();
                ingredientCalories.Clear();
                ingredientFoodGroup.Clear();

                Console.WriteLine("Data was cleared successfully ");
            }
            else if (clearing == "n")
            {
                Console.WriteLine("Data is not cleared ");
            }
            else
            {
                Console.WriteLine("Enter the correct letter (y/n)");
            }
        }
    }
}
