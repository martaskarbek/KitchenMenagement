using System;

namespace KitchenManagement.Employees
{
    public abstract class CookerEmployee : Employee
    {
        public bool HasKnife { get; private set; }

        protected CookerEmployee(string name, DateTime birthDate, int salary) : base(name, birthDate, salary)
        {
        }

        public void ReceiveKnife()
        {
            HasKnife = true;
        }

        public void Cook()
        {
            if (!HasKnife)
                throw new NullReferenceException($"Can't cook: employee {ToString()} hasn't receive a knife!");
        }

        protected abstract void CookWithKnives();
    }
}