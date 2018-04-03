using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PizzaStore.Library;
using PizzaStore.Data;

namespace PizzaStore.MVC.Models
{
    public class PizzaViewModel
    {

        public int CrustID { get; set; }
        public Dictionary<int, string> Crusts { get; set; }

        public int SauceID { get; set; }
        public Dictionary<int, string> Sauces { get; set; }


        public IList<string> SelectedCheeses { get; set; }
        public IList<SelectListItem> AvailableCheeses { get; set; }


        public IList<string> SelectedToppings { get; set; }
        public IList<SelectListItem> AvailableToppings { get; set; }

        [Required]
        public string PizzaQuantity { get; set; }

        public PizzaViewModel()
        {
            Crusts = GetCrusts();
            Sauces = GetSauces();

            SelectedCheeses = new List<string>();
            AvailableCheeses = GetCheeses();

            SelectedToppings = new List<string>();
            AvailableToppings = GetToppings();
        }

        private Dictionary<int, string> GetCrusts()
        {
            EfData ef = new EfData();
            List<Crust> crusts = ef.ReadCrusts();
            Dictionary<int, string> crustDict = new Dictionary<int, string>();
            foreach(var crust in crusts)
                crustDict[crust.CrustId] = crust.Crust1;
            return crustDict;
        }

        private Dictionary<int, string> GetSauces()
        {
            EfData ef = new EfData();
            List<Sauce> sauces = ef.ReadSauces();
            Dictionary<int, string> sauceDict = new Dictionary<int, string>();
            foreach (var sauce in sauces)
                sauceDict[sauce.SauceId] = sauce.Sauce1;
            return sauceDict;
        }


        private IList<SelectListItem> GetCheeses()
        {
            EfData ef = new EfData();
            List<Cheese> cheeseList = ef.ReadCheeses();

            List<SelectListItem> cheeseSelectList = new List<SelectListItem>();

            foreach(var cheese in cheeseList)
            {
                cheeseSelectList.Add(new SelectListItem { Text = cheese.Cheese1, Value = cheese.CheeseId.ToString() });
            }

            return cheeseSelectList;
        }

        public Pizza2 MakePizza()
        {
            Pizza2 pizza = new Pizza2();
            pizza.CrustId = CrustID;
            pizza.SauceId = SauceID;
            List<int> cheeseIDs = GetCheeseIDs();
            List<int> toppingIDs = GetToppingIDs();

            // Set Cheese1 and Cheese2
            if (cheeseIDs.Count == 0)
            {
                pizza.Cheese1 = null;
                pizza.Cheese2 = null;
            }
            else if (cheeseIDs.Count == 1)
            {
                pizza.Cheese1 = cheeseIDs[0];
                pizza.Cheese2 = null;
            }
            else if (cheeseIDs.Count == 2)
            {
                pizza.Cheese1 = cheeseIDs[0];
                pizza.Cheese2 = cheeseIDs[1];
            }

            // Set Topping1, Topping2, and Topping3
            if (toppingIDs.Count == 0)
            {
                pizza.Topping1 = null;
                pizza.Topping2 = null;
                pizza.Topping3 = null;
            }
            else if (toppingIDs.Count == 1)
            {
                pizza.Topping1 = toppingIDs[0];
                pizza.Topping2 = null;
                pizza.Topping3 = null;
            }
            else if (toppingIDs.Count == 2)
            {
                pizza.Topping1 = toppingIDs[0];
                pizza.Topping2 = toppingIDs[1];
                pizza.Topping3 = null;
            }
            else if (toppingIDs.Count == 3)
            {
                pizza.Topping1 = toppingIDs[0];
                pizza.Topping2 = toppingIDs[1];
                pizza.Topping3 = toppingIDs[2];
            }

            int q = 0;
            Int32.TryParse(PizzaQuantity, out q);
            pizza.Quantity = q;

            var ef = new EfData();
            pizza.TotalPizzaCost = 0;
            pizza.TotalPizzaCost += ef.GetCrustCost(pizza.CrustId);
            if(pizza.SauceId != null)
                pizza.TotalPizzaCost += ef.GetSauceCost(pizza.SauceId.Value);
            if (pizza.Cheese1 != null)
                pizza.TotalPizzaCost += ef.GetCheeseCost(pizza.Cheese1.Value);
            if (pizza.Cheese2 != null)
                pizza.TotalPizzaCost += ef.GetCheeseCost(pizza.Cheese2.Value);
            if (pizza.Topping1 != null)
                pizza.TotalPizzaCost += ef.GetToppingCost(pizza.Topping1.Value);
            if (pizza.Topping2 != null)
                pizza.TotalPizzaCost += ef.GetToppingCost(pizza.Topping2.Value);
            if (pizza.Topping3 != null)
                pizza.TotalPizzaCost += ef.GetToppingCost(pizza.Topping3.Value);

            pizza.ModifiedDate = DateTime.Now;

            return pizza;
        }

        public List<int> GetCheeseIDs()
        {
            List<int> cheeseIDs = new List<int>();
            foreach(var selectItem in SelectedCheeses)
                cheeseIDs.Add(Convert.ToInt32(selectItem));
            return cheeseIDs;
        }

        public List<int> GetToppingIDs()
        {
            List<int> toppingIDs = new List<int>();
            foreach (var selectItem in SelectedToppings)
                toppingIDs.Add(Convert.ToInt32(selectItem));
            return toppingIDs;
        }

        private IList<SelectListItem> GetToppings()
        {

            EfData ef = new EfData();
            List<Topping> toppingList = ef.ReadToppings();

            List<SelectListItem> toppingSelectList = new List<SelectListItem>();

            foreach (var topping in toppingList)
            {
                Console.WriteLine("Reading toppings from Efdata");
                toppingSelectList.Add(new SelectListItem { Text = topping.Topping1, Value = topping.ToppingId.ToString() });
            }

            return toppingSelectList;
        }
    }
}
