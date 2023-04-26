using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App { }

class Recipe
{
    // Declare private variables for Recipe class
    private string[] ingredients;
    private string[] units;
    private string[] steps;
    private int numSteps;
    private int numIngredients;
    private float[] quantities;


    // Constructor for Recipe class
    public Recipe()
    {
        // Initialize the private variables to default values
        numIngredients = 0;
        numSteps = 0;
        ingredients = new string[1000];
        quantities = new float[1000];
        units = new string[1000];
        steps = new string[1000];
    }


    // Method to enter recipe details from user input
    public void EnterRecipe()
    {
        // Tells the user to enter the number of ingredients
        Console.Write("Enter the number of ingredients: ");
        numIngredients = int.Parse(Console.ReadLine());

                                                                                                                                                                                                                                                               //meja@91
        for (int i = 0; i < numIngredients; i++)// Loop through the number of ingredients and tells the user to enter each ingredient's name, quantity, and unit     
        {
            Console.Write($"Enter ingredient {i + 1}: ");
            ingredients[i] = Console.ReadLine();
            Console.Write($"Enter quantity for {ingredients[i]}: ");
            quantities[i] = float.Parse(Console.ReadLine());
            Console.Write($"Enter unit of measurement for {ingredients[i]}: ");
            units[i] = Console.ReadLine();
        }


        // Tells the user to enter the number of steps
        Console.Write("Enter the number of steps: ");
        numSteps = int.Parse(Console.ReadLine());

        // Loop through the number of steps and prompt the user to enter each step's description
        for (int i = 0; i < numSteps; i++)
        {
            Console.Write($"Enter step {i + 1}: ");
            steps[i] = Console.ReadLine();
        }
    }


    // Method that displays the recipe details to the user
    public void DisplayRecipe()
    {
        // Prints the list of ingredients with their quantities and units
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"{i + 1}. {quantities[i]} {units[i]} {ingredients[i]}");
        }

        // Prints the list of steps
        Console.WriteLine("Steps:");
        for (int i = 0; i < numSteps; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }
    }


    // Method that scales the recipe's ingredient quantities by a given factor
    public void ScaleRecipe(float factor)
    {
        // Loop through each ingredient and multiply its quantity by the scaling factor
        for (int i = 0; i < numIngredients; i++)
        {
            quantities[i] *= factor;
        }
    }



    // Method that resets the recipe's ingredient quantities back to their original values
    public void ResetRecipe()
    {
        // Loop through each ingredient and divide its quantity by 2 to reset to the original value
        for (int i = 0; i < numIngredients; i++)
        {
            quantities[i] /= 2;
        }
    }



    // Method that clears the recipe data and start all over
    public void ClearRecipe()
    {
        numIngredients = 0;
        numSteps = 0;
    }
}


