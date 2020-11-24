using System;

namespace KitchenManagement.Employees
{
    public class Chef : CookerEmployee
    {
        private IIngredientStore _store;

        public Chef(string name, DateTime birthDate, int salary) : base(name, birthDate, salary)
        {
        }

        /// <summary>
        ///     Set the ingredient store of this chef
        /// </summary>
        /// <param name="store"></param>
        public void SetStore(IIngredientStore store)
        {
            _store = store;
        }

        /// <summary>
        ///     In some cases the chef asks for an ingredient from the kitchen helper
        /// </summary>
        protected override void CookWithKnives()
        {
            // not specified when, so going 50-50
            var shouldAskForIngredient = Utilities.RandomBool();

            if (!shouldAskForIngredient || _store == null)
                return;

            var randomIngredient = Utilities.GetEnumValues<Ingredient>().RandomElement();
            
            Console.WriteLine($"I need {randomIngredient}");
            Ingredient? received = _store.RequestIngredient(randomIngredient);
            string ingredientName = received?.ToString() ?? "NOTHING";

            Console.WriteLine($"I got {ingredientName}");
        }
    }
}