using Microsoft.AspNetCore.Mvc;
using WebApplication04G.Data;
using WebApplication04G.Models;

namespace WebApplication04G.Controllers
{
    public class ULoginController1 : Controller
    {
        WebApplication04GContext db;

        public ULoginController1 (WebApplication04GContext dbc)
        {
            db = dbc;
        }

        [HttpGet]
        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserCreate(Login T)
        {
            db.Register.Add(T);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult ULogin() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult ULogin(Login T)
        {
            var x = db.Register.Where(a=> a.Email == T.Email && a.Password == T.Password).FirstOrDefault();
            if (x != null) 
            {
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                ViewBag.m = "Email or Password Wrong";
                return View();
            }
        }
    }
}

