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
        //[Required(Message = "the message")]
        // [Message="sample message"]
        //[DataType(DataType.int)]
        //[StLength]
        public int CrustID { get; set; }
        public Dictionary<int, string> Crusts { get; set; }

        [Required]
        //[NameValidator(ErrorMessage = "bad name")]
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
            foreach(KeyValuePair<int, string> entry in Crusts)
                Console.WriteLine("Crusts: {0} : {1}", entry.Key, entry.Value);
            foreach (KeyValuePair<int, string> entry in Sauces)
                Console.WriteLine("Sauces: {0} : {1}", entry.Key, entry.Value);

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

        public string GetCheeseIDString()
        {
            string cheeseString = "";
            int count = 0;
            foreach(var cheeseID in GetCheeseIDs())
            {
                if (count == 0)
                    cheeseString += cheeseID.ToString();
                else
                    cheeseString += "," + cheeseID.ToString();
                count += 1;
            }
            Console.WriteLine("CheeseString: :" + cheeseString + ":");
            return cheeseString;
        }

        public string GetToppingIDString()
        {
            string toppingString = "";
            int count = 0;
            foreach (var toppingID in GetToppingIDs())
            {
                if (count == 0)
                    toppingString += toppingID.ToString();
                else
                    toppingString += "," + toppingID.ToString();
                count += 1;
            }
            return toppingString;
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
