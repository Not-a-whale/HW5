// <copyright file="Salad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassHierarchy_hw.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ClassHierarchy_hw.Interfaces;

    internal class Salad : ISalad
    {
        public Salad()
        {
            this.Ingredients = new Ingredient[0];
        }

        public Ingredient[] Ingredients { get; set; }

        public double CountCalories()
        {
            double sum = 0;

            // adds all the calories in all the ingredients
            foreach (var ingredient in this.Ingredients)
            {
                if (ingredient.Measurement == "gramm")
                {
                    sum += ingredient.Calories;
                }
                else if (ingredient.Measurement == "cup")
                {
                    sum += ingredient.Calories * 2;
                }
                else if (ingredient.Measurement == "oz")
                {
                    sum += ingredient.Calories / 28.3495;
                }
            }

            return sum;
        }

        public void SortByType(string nameOfType)
        {
            if (nameOfType == "name")
            {
                IEnumerable<Ingredient> ingredient = this.Ingredients.OrderBy(ingredient => ingredient.Name);
                foreach (var ingred in ingredient)
                {
                    Console.WriteLine($"- {ingred.Name}, 1 {ingred.Measurement}");
                }
            }
            else
            {
                IEnumerable<Ingredient> ingredient = this.Ingredients.OrderBy(ingredient => ingredient.Calories);
                foreach (var ingred in ingredient)
                {
                    Console.WriteLine($"- {ingred.Name}, 1 {ingred.Measurement}");
                }
            }
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredient[] ingredientsArr = this.Ingredients;
            this.ArrayPush(ref ingredientsArr, ingredient);
            this.Ingredients = ingredientsArr;
        }

        public void ArrayPush<T>(ref T[] table, object value)
        {
            Array.Resize(ref table, table.Length + 1); // Resizing the array for the cloned length (+-) (+1)
            table.SetValue(value, table.Length - 1); // Setting the value for the new element
        }
    }
}
