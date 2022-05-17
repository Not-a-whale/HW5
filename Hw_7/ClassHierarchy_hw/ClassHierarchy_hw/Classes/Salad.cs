// <copyright file="Salad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassHierarchy_hw.Classes
{
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
            throw new System.NotImplementedException();
        }

        public string MakeSalad()
        {
            throw new System.NotImplementedException();
        }
    }
}
