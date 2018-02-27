﻿using Lab20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab20.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult AddUser(string FirstName, string LastName, string Email)
        {
            CoffeeShopEntities Coffee = new CoffeeShopEntities();
            User NewUser = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };
            if (!ModelState.IsValid)
            {
                foreach(ModelState s in ModelState.Values)
                {
                    foreach(ModelError r in s.Errors)
                    {
                        //individual errors for each field

                        //r.ErrorMessage
                    }
                }
            }
            try
            {
                Coffee.Users.Add(NewUser);
                Coffee.SaveChanges();

                ViewBag.CustomerFirstName = NewUser.FirstName;

                return View("About");
            }
            catch(Exception e)
            {
                ModelState.Values.Add(new ModelState());

                
                return View("../Shared/Error");//error page
            }

        }
        public ActionResult Browse()
        {
            CoffeeShopEntities Coffee = new CoffeeShopEntities();
            List<Item> Stock = new List<Item>();
            Stock = Coffee.Items.ToList();
            ViewBag.Item1 = Stock[0].Name + "$ " + Stock[0].Price + "     Qty: " + Stock[0].Quantity;
            ViewBag.Item2 = Stock[1].Name + "$ " + Stock[1].Price + "     Qty: " + Stock[1].Quantity;
            ViewBag.Item3 = Stock[2].Name + "$ " + Stock[2].Price + "     Qty: " + Stock[2].Quantity;
            ViewBag.Item4 = Stock[3].Name + "$ " + Stock[3].Price + "     Qty: " + Stock[3].Quantity;

            ViewBag.Item1Description = Stock[0].Description.ToString();
            ViewBag.Item2Description = Stock[1].Description.ToString();
            ViewBag.Item3Description = Stock[2].Description.ToString();
            ViewBag.Item4Description = Stock[3].Description.ToString();
            return View();
        }

        public ActionResult AdminTool()
        {
            CoffeeShopEntities Coffee = new CoffeeShopEntities();
            ViewBag.StockItems = Coffee.Items.ToList();
            return View();
        }

        public ActionResult EditItem(int ItemID)
        {
            CoffeeShopEntities Coffee = new CoffeeShopEntities();
            ViewBag.ItemInfo = Coffee.Items.Find(ItemID);
            return View("EditItem",ViewBag.ItemInfo);
        }

        public ActionResult EditItemByID(int ItemID, string Name, string Description, int Quantity, decimal Price, bool Visibility)
        {
            CoffeeShopEntities Coffee = new CoffeeShopEntities();
            var MyItem = Coffee.Items.Single(t => t.ItemID == ItemID);
            
            try
            {
                MyItem.Name = Name;
                MyItem.Description = Description;
                MyItem.Quantity = Quantity;
                MyItem.Price = Price;
                MyItem.Visibility = Visibility;

                Coffee.SaveChanges();
                ViewBag.Success = true;
            }
            catch
            {
                ViewBag.Success = false;
            }
            return View("AdminTool");
        }
    }
}