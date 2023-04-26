namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a new recipe object and set a flag for running the program loop
            Recipe recipe = new Recipe();
            bool running = true;

            while (running)
            {
                //Shows the user the switch meun with all the options
                Console.WriteLine("\nRecipe App\n");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset recipe");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("6. Quit");

                //Tells the user to enter their option
                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.EnterRecipe();//Call the method called "EnterRecipe"
                        break;
                    case 2:
                        recipe.DisplayRecipe();//Call the method called "DisplayRecipe
                        break;
                    case 3:
                        Console.Write("Enter scaling factor (0.5, 2, or 3): ");//Tells the user to enter the factor for scaling.                                                                                                                             //metja@91
                        float factor = float.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);//Call the method called "ScaleRecipe"
                        break;
                    case 4:
                        recipe.ResetRecipe();//Call the method called "ResetRecipe"
                        break;
                    case 5:
                        recipe.ClearRecipe();//Call the method called "ClearRecipe"
                        break;
                    case 6:
                        running = false;//Exits the program if the option 6 is entered
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");//Outputs this statement if invalid option is entered
                        break;
                }
            }
        }
    }
    }