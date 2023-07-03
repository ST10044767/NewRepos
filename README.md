# RecipeApp is a update to command-line application written in C# that allows users to enter and display recipe details.
The application also allows users to scale the recipe quantities, reset the quantities to their original 
values, and clear the recipe data to start over.The updated app and has a GUI for a more user-friendly program

Getting Started
These instructions will guide you through compiling and running the application on your local machine.

Prerequisites and Reqiurements
To run the application, you will need to have the following installed on your machine:

.NET Core 3.1 or later
Visual Studio Code or Visual Studio
Installing
Clone this repository to your local machine using git clone.
bash
Copy code
git clone https://github.com/your_username/RecipeApp.git
Open the RecipeApp folder in your preferred code editor.
Running the application
To run the application, open a terminal in your code editor and navigate to the RecipeApp directory.

Type the following command to build the application:

Copy code
dotnet build
Type the following command to run the application:
arduino
Copy code
dotnet run

Follow the prompts to enter recipe details and perform various actions on the recipe.

Usage:
Upon running the application, you will be prompted to enter the details of your recipe, 
including the number of ingredients, the name, quantity, and unit of measurement for each ingredient,
the number of steps, and a description of each step.

Once you have entered your recipe details, the application will display the recipe in a neat format.
You can then choose to scale the recipe quantities by a factor of 0.5, 2, or 3, reset the quantities
to their original values, or clear the recipe data to start over.

License
This project is licensed under the MIT License - see the LICENSE.md file for details.



GitHub repository
https://github.com/ST10044767/RecipeApp.git


//Changes based on feedback

I changed the structure of the menu and put the clear recipe,scale recipe and reset recipe in a sub menu under displayRecipe.
I changed number of elements of the arrays depents on nuIngredients and numStep.Created a new method for clearRecipe.
The application now supports an unlimited number of recipes by using a List to store Recipe objects. Each Recipe object contains a name, a List of ingredients (with additional properties for calories and food group), and a List of steps.
The user can enter multiple recipes, and the application displays a sorted list of all recipes in alphabetical order. The user can select a recipe to display its details, including ingredients, steps, total calories (calculated using a delegate), and a warning if the total calories exceed 300.
Overall, the code has been refactored to use delegates, generic collections, and appropriate data structures to handle the expanded functionality of managing multiple recipes with additional ingredient properties.


