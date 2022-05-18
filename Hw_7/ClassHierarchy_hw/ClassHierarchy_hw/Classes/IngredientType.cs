// <copyright file="IngredientType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassHierarchy_hw.Classes
{
    internal class IngredientType
    {
        private string name;
        private int maxQuantity;
        private Ingredient[] selectedIngredients;

        public IngredientType(string name, int maxQuantity = 1)
        {
            this.Name = name;
            this.MaxQuantity = maxQuantity;
            this.SelectedIngredients = new Ingredient[0];
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public virtual int MaxQuantity
        {
            get => this.maxQuantity;
            set => this.maxQuantity = value;
        }

        public virtual Ingredient[] SelectedIngredients
        {
            get => this.selectedIngredients;
            set => this.selectedIngredients = value;
        }

        public string IsMaxAmountReached()
        {
            // Counts number of ingredient of the same type
            return " ";
        }
    }
}
