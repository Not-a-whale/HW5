// <copyright file="Salad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassHierarchy_hw.Classes
{
    using System;
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
            // adds all the calories in all the ingredients
            return 0.1;
        }

        public void SortByType(string nameOfType)
        {
            Console.WriteLine("Sorted By the type");
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
