using System;
using System.Collections.Generic;

namespace KitchenManagement.Employees
{
    /// <summary>
    ///     A kitchen helper is an employee with a stock of ingredients
    ///     At any given moment, a helper has [0-3] of any ingredient
    /// </summary>
    public class KitchenHelper : Employee
    {
        private const int MaxNumberOfIngredients = 3;
        private readonly Dictionary<Ingredient, int> _ingredients = new Dictionary<Ingredient, int>();

        /// <summary>
        ///     Creates a kitchen helpers with no ingredients
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="salary"></param>
        public KitchenHelper(string name, DateTime birthDate, int salary) : base(name, birthDate, salary)
        {
            foreach (var ingredient in Utilities.GetEnumValues<Ingredient>())
            {
                _ingredients.Add(ingredient, 0);
            }
        }

        /// <summary>
        ///     Refills the ingredients held by this kitchen helper
        ///     Each kind of ingredient is refilled to a maximum of 3
        ///     and a minimum of the former value
        /// </summary>
        public void RefillIngredients()
        {
            foreach (var ingredient in Utilities.GetEnumValues<Ingredient>())
            {
                int amount = Utilities.Random.Next(MaxNumberOfIngredients + 1);
                int currentAmount = _ingredients[ingredient];

                _ingredients[ingredient] = Math.Max(amount, currentAmount);
            }
        }

        /// <summary>
        ///     Give up an ingredient if the helper possesses it
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public Ingredient? GiveUpIngredient(Ingredient ingredient)
        {
            if (HasIngredient(ingredient))
            {
                DecreaseIngredient(ingredient);
                return ingredient;
            }
            else return null;
        }

        /// <summary>
        ///     Yells about running out of ingredients
        /// </summary>
        public void Yell()
        {
            Console.WriteLine("We're all out!");
        }

        private bool HasIngredient(Ingredient ingredient)
        {
            return _ingredients[ingredient] > 0;
        }

        private void DecreaseIngredient(Ingredient ingredient)
        {
            if (_ingredients[ingredient] == 0)
                throw new ArgumentOutOfRangeException(nameof(ingredient), "Tried to decrease an empty ingredient stock!");

            _ingredients[ingredient]--;
        }
        
    }
}