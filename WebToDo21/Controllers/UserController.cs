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

        [HttpPost]
        public int CreateUser(string userName, string userPassword, string userRole)
        {
            TodoUser tdUser = new TodoUser{UserName=userName, UserPassword=userPassword, UserRole=userRole};
            return TodoUserDal.CreateUser(tdUser);
        }

        public int ChangePassword(int userId, string userPassword, string userRole="creator")
        {
            TodoUser tdUser = new TodoUser{UserId=userId, UserPassword=userPassword, UserRole=userRole};
            return TodoUserDal.UpdateUser(tdUser);
        }

        public int DeleteUser(int id)
        {
            TodoUser tdUser = new TodoUser{UserId=id};
            return TodoUserDal.DeleteUser(tdUser);
        }
    }
}