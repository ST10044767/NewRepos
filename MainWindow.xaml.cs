using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    // Delegate to calculate the total calories of a recipe
    delegate float CalculateTotalCaloriesDelegate();

    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>(); // List to store all the recipes

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();

            // Prompt for recipe details and add them to the recipe object

            // Example code for adding a recipe using MessageBox prompts:
            recipe.Name = PromptInput("Enter recipe name:");
            int numIngredients = int.Parse(PromptInput("Enter the number of ingredients:"));

            for (int i = 0; i < numIngredients; i++)
            {
                Ingredient ingredient = new Ingredient();

                ingredient.Name = PromptInput($"Enter ingredient {i + 1} name:");
                ingredient.Quantity = float.Parse(PromptInput($"Enter quantity for {ingredient.Name}:"));
                ingredient.Unit = PromptInput($"Enter unit of measurement for {ingredient.Name}:");
                ingredient.Calories = int.Parse(PromptInput($"Enter calories for {ingredient.Name}:"));
                ingredient.FoodGroup = PromptInput($"Enter food group for {ingredient.Name}:");

                recipe.Ingredients.Add(ingredient);
            }

            int numSteps = int.Parse(PromptInput("Enter the number of steps:"));

            for (int i = 0; i < numSteps; i++)
            {
                recipe.Steps.Add(PromptInput($"Enter step {i + 1}:"));
            }

            recipes.Add(recipe);
            MessageBox.Show("Recipe added successfully!");
        }

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            recipeListBox.Items.Clear();

            recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name));

            foreach (Recipe recipe in recipes)
            {
                recipeListBox.Items.Add(recipe.Name);
            }
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (recipeListBox.SelectedItem != null)
            {
                int recipeIndex = recipeListBox.SelectedIndex;

                Recipe recipe = recipes[recipeIndex];

                // Display recipe details in detailsTextBox
                detailsTextBox.Document.Blocks.Clear();
                detailsTextBox.AppendText($"Recipe Details:\nName: {recipe.Name}\n\nIngredients:\n");
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    detailsTextBox.AppendText($"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit}\n");
                }

                detailsTextBox.AppendText("\nSteps:\n");
                foreach (string step in recipe.Steps)
                {
                    detailsTextBox.AppendText($"{step}\n");
                }

                detailsTextBox.AppendText($"\nTotal Calories: {recipe.CalculateTotalCalories()}");

                if (recipe.CalculateTotalCalories() > 300)
                {
                    detailsTextBox.AppendText("\nWarning: The total calories of this recipe exceed 300.");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe.");
            }
        }

        private string PromptInput(string message)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Recipe App");
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (recipeListBox.SelectedItem != null)
            {
                selectButton.IsEnabled = true;
            }
            else
            {
                selectButton.IsEnabled = false;
            }
        }
    }

    class Ingredient
    {
        public string Name { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        // Method to calculate the total calories of a recipe
        public float CalculateTotalCalories()
        {
            float totalCalories = 0;

            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories * ingredient.Quantity;
            }

            return totalCalories;
        }
    }
}
