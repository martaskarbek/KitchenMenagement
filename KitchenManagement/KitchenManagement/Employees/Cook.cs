using System;

namespace KitchenManagement.Employees
{
    public class Cook : CookerEmployee
    {
        public Cook(string name, DateTime birthDate, int salary) : base(name, birthDate, salary)
        {
        }

        protected override void CookWithKnives()
        {
            Console.WriteLine("I'm cooking");
        }
    }
}