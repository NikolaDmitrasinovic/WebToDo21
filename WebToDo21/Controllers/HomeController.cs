﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebToDo21.Models;
using WebToDo21.DAL;

namespace WebToDo21.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReturnAllCards()
        {
            return Json(TodoCardDal.ReturnCards());
        }
        public JsonResult CreateNewCard(int userId, string title, string content)
        {
            TodoCard tCard = new TodoCard{UserId =userId, Title=title, Content=content};
            return Json(TodoCardDal.CreateNewCard(tCard));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
