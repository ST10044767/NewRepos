
using RecipeApp;
using System.Diagnostics.Metrics;

class Program
{
    static List<Recipe> recipes =
        new List<Recipe>();  // List to store all the recipe

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nRecipe App\n");
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Display all recipes");
            Console.WriteLine("3. Display recipe details");
            Console.WriteLine("4. Quit");

            Console.Write("\nEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EnterNewRecipe();
                    break;
                case 2:
                    DisplayAllRecipes();
                    break;
                case 3:
                    DisplayRecipeDetails();
                    break;
                case 4:
                    running = false;// Exits the program if the option 6 is entered
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void EnterNewRecipe()  // Method to enter a new recipe
    {
        Recipe recipe = new Recipe();
        recipe.EnterRecipe();
        recipe.CheckCalorieLimit();
        recipes.Add(recipe);
    }

    static void DisplayAllRecipes()  // Method to display all recipe
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes found.");
            return;
        }

        Console.WriteLine("Recipes:");                                                                                                                                                                                                                                                                                                                                                                                                      // metja@91
        foreach (var recipe in recipes.OrderBy(r => r.Name))
        {
            Console.WriteLine(recipe.Name);
        }
    }

    static void DisplayRecipeDetails()  // Method to display a recipe
    {
        Console.Write("Enter the recipe name: ");
        string recipeName = Console.ReadLine();

        Recipe recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
        if (recipe != null)
        {
            recipe.DisplayRecipe();
            recipe.CheckCalorieLimit();

            Console.WriteLine("\nRecipe Actions:");
            Console.WriteLine("1. Scale the recipe");
            Console.WriteLine("2. Reset the recipe");
            Console.WriteLine("3. Clear the recipe");

            Console.Write("\nEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the scaling factor: ");
                    float factor = float.Parse(Console.ReadLine());
                    recipe.ScaleRecipe(factor); //Call the method "Scale Recipe" to scale the recipe
                    Console.WriteLine("Recipe scaled successfully.");
                    break;
                case 2:
                    recipe.ResetRecipe();//Call the method "Reset Recipe" to reset the recipe
                    Console.WriteLine("Recipe reset successfully.");
                    break;
                case 3:
                    recipe.ClearRecipe();//Call the method "Clear Recipe" to detele the recipe
                    Console.WriteLine("Recipe cleared successfully.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            recipe.DisplayRecipe();
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }
}
