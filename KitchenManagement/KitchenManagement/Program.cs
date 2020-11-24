using System;
using KitchenManagement.Employees;

namespace KitchenManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var kitchen = new Kitchen();

            var oneDate = new DateTime(1990, 1, 1);
            var chef = new Chef("Chef McCheferson", oneDate, 1000);
            var cook1 = new Cook("Cook McCookface", oneDate.AddYears(3), 800);
            var cook2 = new Cook("Pan Fryingkind", oneDate.AddYears(-2), 800);
            var helper1 = new KitchenHelper("Helper Helpowitz", oneDate.AddYears(1), 750);
            var helper2 = new KitchenHelper("Handy Smith", oneDate.AddYears(3), 750);
            var helper3 = new KitchenHelper("Slim Quicktohelp", oneDate.AddMonths(4), 750);
            
            chef.ReceiveKnife();
            cook1.ReceiveKnife();
            cook2.ReceiveKnife();

            var employees = new Employee[] {chef, cook1, cook2, helper1, helper2, helper3};

            foreach (var employee in employees)
                kitchen.HireEmployee(employee);

            kitchen.ConductAShift();
        }
    }
}