using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebUI.DatabaseContext;
using WebUI.Managers;
using WebUI.Models;
using PagedList;
using PagedList.Mvc;
using System.Drawing.Printing;
using System.Web.UI;
using System.IO;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult User(int page)
        {
            ViewBag.CurrentPage = page;
            var user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult User(User user, int page)
        {
            var addUser = new UserManager();
            addUser.SetUsers(user);
            return RedirectToAction("Table", "Home", new { page = page });

        }
        [HttpGet]
        public ActionResult Table(int? page=1)
        {
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //return View(User.ToPagedList(pageNumber, pageSize));
            var userList = new UserManager();
            
            var pagedList = userList.GetUsers().ToPagedList(pageNumber, pageSize);
            
            ViewBag.CurrentPage = page;
            if (pagedList.Count == 0)
            {
                page = page - 1;
                ViewBag.CurrentPage= page;
                pageNumber = pageNumber - 1;
                return View(userList.GetUsers().ToPagedList(pageNumber, pageSize));
            }
            
            return View(pagedList);
        }
        [HttpGet]
        public JsonResult TableJson()
        {
            var jsonList = new UserManager();
            return Json(jsonList.GetUsers(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Table(User user)
        {
            return View(user);
        }

        [HttpGet]
        public ActionResult Update(int id, int page) {
            var upd=new UserManager().GetUserById(id);
            var updateUser=new UserManager();
            ViewBag.CurrentPage = page;
            if (upd == null)
            {
                return View("Table", updateUser.GetUsers());
            }
            return View(upd);

        }

        [HttpPost]
        public ActionResult Update(User user, int page)
        {
            var updateUser = new UserManager();
            updateUser.UpdateUser(user);
            return RedirectToAction("Table", "Home", new { page = page });

        }
        [HttpGet]
        public ActionResult Delete(int id, int page)
        {
            var deleteUser = new UserManager().GetUserById(id);
            var aa = new UserManager();
            ViewBag.CurrentPage = page;

            if (deleteUser == null)
            {
                return View("Table", aa.GetUsers());
            }
            return View(deleteUser);

        }

        [HttpPost]
        public ActionResult Delete(User user, int page)
        {
            var deleteUser = new UserManager();
            deleteUser.DeleteUser(user);
            return RedirectToAction("Table", "Home", new { page = page });
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            var aa = new UserManager();
            var users = aa.GetUsers();

            return users;
        }



    }


}