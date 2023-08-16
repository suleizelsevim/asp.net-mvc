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
            var yy = new UserManager();
            var user2 = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth,
                Gender=user.Gender,
                City = user.City,
                Website = user.Website,
                Adress = user.Adress,
                IsSubscribed = user.IsSubscribed

            };

            yy.SetUsers(user2);
            var aa = new UserManager();
            return RedirectToAction("Table", "Home", new { page = page });

        }
        [HttpGet]
        public ActionResult Table(int? page=1)
        {
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            //return View(User.ToPagedList(pageNumber, pageSize));
            var aa = new UserManager();
            
            var dd = aa.GetUsers().ToPagedList(pageNumber, pageSize);
            
            ViewBag.CurrentPage = page;
            if (dd.Count == 0)
            {
                page = page - 1;
                ViewBag.CurrentPage= page;
                pageNumber = pageNumber - 1;
                return View(aa.GetUsers().ToPagedList(pageNumber, pageSize));
            }
            
            return View(dd);
        }
        [HttpGet]
        public JsonResult TableJson()
        {
            var aa = new UserManager();
            return Json(aa.GetUsers(), JsonRequestBehavior.AllowGet);
        }

        //    List<User> userList = yy.GetUsers();
        //    return View(userTbl);
        //}



        [HttpPost]
        public ActionResult Table(User user)
        {
            //users = new User();
            return View(user);


        }

        [HttpGet]
        public ActionResult Update(int id, int page) {
            var user = new User();
            var upd=new UserManager().GetUserById(id);
            var aa=new UserManager();
            ViewBag.CurrentPage = page;
            if (upd == null)
            {
                return View("Table", aa.GetUsers());
            }
            return View(upd);

        }

        [HttpPost]
        public ActionResult Update(User user, int page)
        {
            var yy = new UserManager();
            var updateUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth,
                Gender=user.Gender,
                City = user.City,
                Website = user.Website,
                Adress = user.Adress,
                IsSubscribed = user.IsSubscribed
            };

            yy.UpdateUser(updateUser);
            var aa = new UserManager();
            return RedirectToAction("Table", "Home", new { page = page });

        }
        [HttpGet]
        public ActionResult Delete(int id, int page)
        {
            var user = new User();
            var delete = new UserManager().GetUserById(id);
            var aa = new UserManager();
            ViewBag.CurrentPage = page;

            if (delete == null)
            {
                return View("Table", aa.GetUsers());
            }
            return View(delete);

        }

        [HttpPost]
        public ActionResult Delete(User user, int page)
        {
            var yy = new UserManager();
            var deleteUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                City = user.City,
                Website = user.Website,
                Adress = user.Adress,
                IsSubscribed = user.IsSubscribed
            };
            yy.DeleteUser(deleteUser);
            var aa = new UserManager();
            
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