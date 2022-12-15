using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebToDo21.Models;
using WebToDo21.DAL;

namespace WebToDo21.Controllers
{
    public class UserController : Controller
    {
        public JsonResult ReturnAllUsers()
        {
            return Json(TodoUserDal.ReturnAllUsers());
        }
    }
}