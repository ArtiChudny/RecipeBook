using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using log4net;
using PagedList;
using RecipeBook.Business.Providers;
using RecipeBook.Common.Models;
using RecipeBook.Web.Models;

namespace RecipeBook.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILog log = LogManager.GetLogger("Logger");
        private IUserProvider userProvider;
        int pageSize = 10;

        public AdminController(IUserProvider _userProvider)
        {
            userProvider = _userProvider;
        }
        [HttpGet]
        public ActionResult UserList(int? page)
        {
            try
            {
                int pageNumber = (page ?? 1);
                var users = userProvider.GetUsers();
                return View(users.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }

        }

        public ActionResult DeleteUser(int id)
        {
            try
            {
                userProvider.DeleteUser(id);
                return RedirectToAction("UserList");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }
        }

        [HttpGet]
        public ActionResult Edit(string login)
        {
            try
            {
                ViewBag.roles = userProvider.GetRoles().ToArray();
                User user = userProvider.GetUserByLogin(login);
                UserViewModel model = new UserViewModel()
                {
                    UserId = user.UserId,
                    Login = user.Login,
                    Email = user.Email,
                    Password = user.Password,
                };
                return View(model);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (model.Roles == null)
            {
                ModelState.AddModelError("", "Select at least one role");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    List<Role> userRoles = new List<Role>();
                    foreach (var item in model.Roles)
                    {
                        Role role = new Role()
                        {
                            RoleId = item
                        };
                        userRoles.Add(role);
                    }

                    User user = new User()
                    {
                        UserId = model.UserId,
                        Login = model.Login,
                        Email = model.Email,
                        Password = model.Password,
                        Roles = userRoles.ToArray()
                    };

                    userProvider.UpdateUser(user);
                    return RedirectToAction("UserList");
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return View("Error", (object)"Sorry, something went wrong. Try again later.");
                }
            }
            else
            {
                ViewBag.roles = userProvider.GetRoles();
                return View(model);
            }


        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            try
            {
                ViewBag.roles = userProvider.GetRoles();
                return View();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return View("Error", (object)"Sorry, something went wrong. Try again later.");
            }

        }

        [HttpPost]
        public ActionResult CreateUser(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Role> userRoles = new List<Role>();
                    foreach (var item in model.Roles)
                    {
                        Role role = new Role()
                        {
                            RoleId = item
                        };
                        userRoles.Add(role);
                    }
                    User user = new User()
                    {
                        Login = model.Login,
                        Password = model.Password,
                        Email = model.Email,
                        Roles = userRoles.ToArray()
                    };
                    userProvider.AddUser(user);
                    return RedirectToAction("UserList");
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return View("Error", (object)"Sorry, something went wrong. Try again later.");
                }

            }
            else
            {
                ViewBag.roles = userProvider.GetRoles();
                return View("CreateUser", model);
            }

        }
    }
}