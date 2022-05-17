// <copyright file="IngredientType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ClassHierarchy_hw.Classes
{
    internal class IngredientType
    {
        private string name;
        private double maxQuantity;

        public IngredientType(string name)
        {
            this.name = name;
        }

        public IngredientType(string name, double maxQuantity = 1)
        {
            this.Name = name;
            this.MaxQuantity = maxQuantity;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public virtual double MaxQuantity
        {
            get => this.maxQuantity;
            set => this.maxQuantity = value;
        }
    }
}
