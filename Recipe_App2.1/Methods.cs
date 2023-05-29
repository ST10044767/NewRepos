using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // Delegate to calculate the total calories of a recipe
    delegate float CalculateTotalCaloriesDelegate();
	
    class Ingredient
    {
        public string Name { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    class Recipe  // Constuctor
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();  // List to store all the recipes

            Steps = new List<string>();  // List to store all the recipe
        }

        public void EnterRecipe()  // Method to enter recipe details
        {
            Console.Write("Enter the recipe name: ");
            Name = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter ingredient {i + 1} name: ");
                string ingredientName = Console.ReadLine();

                Console.Write($"Enter quantity for {ingredientName}: ");
                float quantity = float.Parse(Console.ReadLine());

                Console.Write($"Enter unit of measurement for {ingredientName}: ");
                string unit = Console.ReadLine();

                Console.Write($"Enter calories for {ingredientName}: ");
                int calories = int.Parse(Console.ReadLine());

                Console.Write($"Enter food group for {ingredientName}: ");
                string foodGroup = Console.ReadLine();

                Ingredient ingredient =
                    new Ingredient
                    {
                        Name = ingredientName,
                        Quantity = quantity,
                        Unit = unit,
                        Calories = calories,
                        FoodGroup = foodGroup
                    };

                Ingredients.Add(ingredient);
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                Steps.Add(step);
            }
        }
        // Method to display a specific recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine(
                    $"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            Console.WriteLine("Steps:");
            foreach (var step in Steps)
            {
                Console.WriteLine(step);
            }
        }

        // Method to calculate the total calories of a recipe
        public int CalculateTotalCalories()
        {
            int totalCalories = Ingredients.Sum(i => i.Calories);
            return totalCalories;
        }

        public void CheckCalorieLimit()
        {
            int totalCalories = CalculateTotalCalories();
            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: Total calories of the recipe exceed 300!");
            }
        }

        // Method to scale the recipes
        public void ScaleRecipe(float factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }
        // Method to reset a recipe
        public void ResetRecipe()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = 0;
            }
        }
        // Method to clear a recipe
        public void ClearRecipe()
        {
            Ingredients.Clear();
            Steps.Clear();
        }
    }
}
