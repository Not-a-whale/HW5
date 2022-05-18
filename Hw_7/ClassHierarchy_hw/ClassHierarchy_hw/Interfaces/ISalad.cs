// <copyright file="ISalad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassHierarchy_hw.Interfaces
{
    using ClassHierarchy_hw.Classes;

    internal interface ISalad
    {
        public Ingredient[] Ingredients { get; set; }

        // public Ingredient[] Salad();
        public double CountCalories();

        public void AddIngredient(Ingredient ingredient);
    }
}
