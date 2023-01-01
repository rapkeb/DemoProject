using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UserDemo.Models;

namespace UserDemo.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Register()
        {
            List<User> users = new List<User>();
            using (var db = new DemoContext())
            {
                users = db.Users.ToList();
            }
            ViewBag.users = users;
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                    List<User> users = db.Users.Where(n => n.UserName.Equals(user.UserName)).ToList();
                    if(users.Count() == 0)
                    {
                        TempData["message"] = user.UserName + " has been successfully registered";
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        TempData["message"] = user.UserName + " is catched, try another one";
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult SearchUser(string searchTerm)
        {
            List<User> users = new List<User>();
            using (var db = new DemoContext())
            {
                users = db.Users.Where(n => n.Name.Equals(searchTerm)).ToList();
            }
            ViewBag.users = users;
            return View("Register");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DemoContext())
                {
                    List<User> users = db.Users.Where(n => n.UserName.Equals(user.UserName) && n.Email.Equals(user.Email)).ToList();
                    if (users.Count() == 1)
                    {
                        TempData["message"] = user.UserName + " has been successfully login";
                        TempData["name"] = user.Email;
                    }
                    else
                    {
                        TempData["message"] = user.UserName + " login failed";
                    }
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            TempData.Remove("name");
            return View("Login");
        }
    }
}