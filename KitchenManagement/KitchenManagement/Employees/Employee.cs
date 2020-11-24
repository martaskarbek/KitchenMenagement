using System;

namespace KitchenManagement.Employees
{
    public abstract class Employee
    {
        public string Name { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public int Salary { get; protected set; }

        protected Employee(string name, DateTime birthDate, int salary)
        {
            Name = name;
            BirthDate = birthDate;
            Salary = salary;
        }

        public int Tax => (int) (Salary * 0.99);

        public override string ToString()
        {
            return $"Employee {Name}, Year of Birth: {BirthDate.Year}";
        }
    }
}