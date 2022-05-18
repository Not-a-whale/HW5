// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassHierarchy_hw
{
    using System;
    using ClassHierarchy_hw.Classes;

    internal class Program
    {
        private static Salad salad;

        public static void Main(string[] args)
        {
            // filling all the ingredient types
            IngredientType[] ingredientTypes = new IngredientType[0];
            CreateIngredientTypes(ref ingredientTypes, new IngredientType("greens", 3));
            CreateIngredientTypes(ref ingredientTypes, new IngredientType("vegetables", 6));
            CreateIngredientTypes(ref ingredientTypes, new IngredientType("fruit", 2));
            CreateIngredientTypes(ref ingredientTypes, new IngredientType("protein", 2));
            CreateIngredientTypes(ref ingredientTypes, new IngredientType("grains", 1));
            CreateIngredientTypes(ref ingredientTypes, new IngredientType("dressing", 1));
            CreateIngredientTypes(ref ingredientTypes, new IngredientType("yum-ify!", 3));

            // filling all the ingredients
            Ingredient[] ingredients = new Ingredient[0];
            CreateIngredients(ref ingredients, new Ingredient("Green leaf lettuce", 15.0, 100, "gramm", "greens"));
            CreateIngredients(ref ingredients, new Ingredient("Kale", 49.0, 100, "gramm", "greens"));
            CreateIngredients(ref ingredients, new Ingredient("Bok Choy", 17.0, 100, "gramm", "greens"));
            CreateIngredients(ref ingredients, new Ingredient("Carrots", 41.0, 100, "gramm", "vegetables"));
            CreateIngredients(ref ingredients, new Ingredient("Tomatoes", 33.0, 100, "gramm", "vegetables"));
            CreateIngredients(ref ingredients, new Ingredient("Cucumbers", 30.0, 100, "gramm", "vegetables"));
            CreateIngredients(ref ingredients, new Ingredient("Apples", 52.0, 100, "gramm", "fruit"));
            CreateIngredients(ref ingredients, new Ingredient("Kiwi", 61.0, 100, "gramm", "fruit"));
            CreateIngredients(ref ingredients, new Ingredient("Pears", 57.0, 100, "gramm", "fruit"));
            CreateIngredients(ref ingredients, new Ingredient("Pinaple", 50.0, 100, "gramm", "fruit"));
            CreateIngredients(ref ingredients, new Ingredient("Sour Cherry", 77.0, 100, "gramm", "fruit"));
            CreateIngredients(ref ingredients, new Ingredient("Brown Rice", 111.0, 100, "gramm", "grains"));
            CreateIngredients(ref ingredients, new Ingredient("Corn", 90.0, 100, "gramm", "grains"));
            CreateIngredients(ref ingredients, new Ingredient("Chiken", 192.0, 100, "gramm", "protein"));
            CreateIngredients(ref ingredients, new Ingredient("Fish (salmon)", 252.0, 100, "gramm", "protein"));
            CreateIngredients(ref ingredients, new Ingredient("Eggs", 155.0, 100, "gramm", "protein"));
            CreateIngredients(ref ingredients, new Ingredient("Shrimp", 99.0, 100, "gramm", "protein"));
            CreateIngredients(ref ingredients, new Ingredient("Salsa", 36.0, 100, "gramm", "dressing"));
            CreateIngredients(ref ingredients, new Ingredient("Chutney", 25.0, 100, "gramm", "dressing"));
            CreateIngredients(ref ingredients, new Ingredient("Guacamole", 45.0, 100, "gramm", "dressing"));
            CreateIngredients(ref ingredients, new Ingredient("Macadamia Nuts", 718.0, 100, "gramm", "yum-ify!"));
            CreateIngredients(ref ingredients, new Ingredient("Goat Cheese", 364.0, 100, "gramm", "yum-ify!"));
            CreateIngredients(ref ingredients, new Ingredient("Cashews", 553.0, 100, "gramm", "yum-ify!"));
            CreateIngredients(ref ingredients, new Ingredient("Croutons", 407.0, 100, "gramm", "yum-ify!"));

            // Calling the interface
            SaladBuilderInterface(ingredientTypes, ingredients);
        }

        // A method that creates categories
        public static void CreateIngredientTypes(ref IngredientType[] ingredientTypes, IngredientType ingredientType)
        {
            ArrayPush(ref ingredientTypes, ingredientType);
        }

        // A method that creates ingredients
        public static void CreateIngredients(ref Ingredient[] ingredientTypes, Ingredient ingredientType)
        {
            ArrayPush(ref ingredientTypes, ingredientType);
        }

        // Interface method to ask a person about what ingredients to add and returns a salad
        public static void SaladBuilderInterface(IngredientType[] ingredientTypes, Ingredient[] ingredients)
        {
            int optionCounter = 0;
            Console.WriteLine(" Hi this is a SALAD BUILDER NIKITA 3000");
            Console.WriteLine("///////////");
            Console.WriteLine(" Let's build our own salad!");
            Console.WriteLine("///////////");
            Console.WriteLine(" Please choose your own content of the salad");
            Console.WriteLine(" You can choose from: ");
            Console.WriteLine("//////////");
            foreach (IngredientType ingredientType in ingredientTypes)
            {
                Console.WriteLine($"{ingredientType.Name} - Max {ingredientType.MaxQuantity}");
                for (int i = 0; i < ingredients.Length; i++)
                {
                    Ingredient ingred = ingredients[i];
                    if (ingred.Type == ingredientType.Name)
                    {
                        optionCounter++;
                        Console.WriteLine($" {optionCounter} - {ingred.Name}");
                    }
                }
            }

            Console.WriteLine("Please enter your choice.");
            string ingredientNumInput = Console.ReadLine();
            int n;
            bool isNumeric = int.TryParse(ingredientNumInput, out n);

            if (isNumeric && n <= optionCounter && n != 0 && ingredientNumInput != null)
            {
                Ingredient ing = ingredients[n - 1];
                Console.WriteLine("Provide us with some measurements");
                string measurement = Console.ReadLine();
                if (measurement != "oz" && measurement != "gramm" && measurement != "cup")
                {
                    WrongInput(ingredientTypes, ingredients);
                }
                else
                {
                    ing.Measurement = measurement;
                }

                CreateSalad(ingredientTypes, ingredients, ing);
            }
            else
            {
                WrongInput(ingredientTypes, ingredients);
            }
        }

        public static void WrongInput(IngredientType[] ingredientTypes, Ingredient[] ingredients)
        {
            Console.WriteLine("You've made a wrong input. Please try again.");
            SaladBuilderInterface(ingredientTypes, ingredients);
        }

        // Creating the fucking salad, finally
        public static void CreateSalad(IngredientType[] ingredientTypes, Ingredient[] ingredients, Ingredient ingredient)
        {
            Console.WriteLine($"You've added some {ingredient.Name}. Let's Continue;");
            Console.WriteLine("\n");
            if (salad == null)
            {
                salad = new Salad();
                salad.AddIngredient(ingredient);
            }
            else
            {
                salad.AddIngredient(ingredient);
            }

            Console.WriteLine("Contents of the salad are: ");
            foreach (Ingredient ingredientElem in salad.Ingredients)
            {
                Console.WriteLine($"- {ingredientElem.Name}, 1 {ingredientElem.Measurement}");
            }

            Console.WriteLine("Would you like to count calories or sort ingredients by the type: ");
            Console.WriteLine("Count Calories - 1");
            Console.WriteLine("Sort By Type: - 2");
            string optionNumInput = Console.ReadLine();
            int n;
            bool isNumeric = int.TryParse(optionNumInput, out n);

            if (n != 1 && n != 2 && isNumeric)
            {
                WrongInput(ingredientTypes, ingredients);
            }
            else
            {
                if (n == 1)
                {
                    Console.WriteLine($"{salad.CountCalories()} cal");
                    Console.WriteLine("\n");
                }
                else if (n == 2)
                {
                    Console.WriteLine("By which parameters should would you like to sort: ");
                    Console.WriteLine("By name - 1");
                    Console.WriteLine("By calories uptake: - 2");
                    Console.WriteLine("\n");
                    string optionSortInput = Console.ReadLine();
                    int optionSortInputNum;
                    bool isNum = int.TryParse(optionSortInput, out optionSortInputNum);
                    if (optionSortInputNum != 1 && optionSortInputNum != 2 && !isNum)
                    {
                        WrongInput(ingredientTypes, ingredients);
                    }
                    else
                    {
                        if (optionSortInputNum == 1)
                        {
                            salad.SortByType("name");
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            salad.SortByType("cal");
                            Console.WriteLine("\n");
                        }
                    }
                }
            }

            SaladBuilderInterface(ingredientTypes, ingredients);
        }

        public static void ArrayPush<T>(ref T[] table, object value)
        {
            Array.Resize(ref table, table.Length + 1); // Resizing the array for the cloned length (+-) (+1)
            table.SetValue(value, table.Length - 1); // Setting the value for the new element
        }
    }
}