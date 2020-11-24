using System;
using System.Collections.Generic;
using KitchenManagement.Employees;

namespace KitchenManagement
{
    public class Kitchen : IIngredientStore
    {
          private readonly HashSet<Employee> _employees = new HashSet<Employee>();
        
        private Chef _chef;
        private readonly HashSet<CookerEmployee> _cookers = new HashSet<CookerEmployee>();
        private readonly HashSet<KitchenHelper> _helpers = new HashSet<KitchenHelper>();

        /// <summary>
        ///     Hire an employee
        ///     If the hired employee is a chef then release the former chef (if exists)
        /// </summary>
        /// <param name="employee"></param>
        public void HireEmployee(Employee employee)
        {
            _employees.Add(employee);

            switch (employee)
            {
                case Chef chef:
                    HireChef(chef);
                    _cookers.Add(chef);
                    break;

                case CookerEmployee cooker:
                    _cookers.Add(cooker);
                    break;

                case KitchenHelper kitchenHelper:
                    _helpers.Add(kitchenHelper);
                    break;
            }
        }

        /// <summary>
        ///     Conduct a shift making meals
        /// </summary>
        public void ConductAShift()
        {
            if (_chef == null)
                throw new NullReferenceException("Can't start a shirt without a chef!");

            foreach (var helper in _helpers)
                helper.RefillIngredients();

            foreach (var cooker in _cookers)
            {
                try
                {
                    cooker.Cook();
                }
                catch (NullReferenceException e)
                {
                    // Report error but go on
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        /// <summary>
        ///     Iterate through the kitchen helpers for the requested ingredient.
        ///     If the ingredient is present, then return it.
        ///     In case of a missing ingredient, invokes kitchen helpers' yell method and returns null
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public Ingredient? RequestIngredient(Ingredient ingredient)
        {
            foreach (var helper in _helpers)
            {
                var received = helper.GiveUpIngredient(ingredient);

                if (received.HasValue)
                {
                    return received;
                }
            }

            foreach (var helper in _helpers)
                helper.Yell();

            return null;
        }

        private void HireChef(Chef newChef)
        {
            if (_chef != null)
                FireChef();

            _chef = newChef;
            _chef.SetStore(this);

            Console.WriteLine($"You're hired, chef {_chef.Name}!");
        }

        private void FireChef()
        {
            _chef.SetStore(null);
            _employees.Remove(_chef);

            Console.WriteLine($"You're fired, chef {_chef.Name}!");

            _chef = null;
        }
    }
}