﻿using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using log4net;
using RecipeBook.Business.Providers;
using RecipeBook.Common.Models;
using RecipeBook.Web.Models;

namespace RecipeBook.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private IUserProvider userProvider;

        public AdminController(IUserProvider _userProvider)
        {
            userProvider = _userProvider;
        }
        [HttpGet]
        public ActionResult UserList()
        {
            try
            {
                return View(userProvider.GetUsers());
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public ActionResult DeleteUser(int id)
        {
            try
            {
                userProvider.DeleteUser(id);
                return RedirectToAction("UserList");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(string login)
        {
            try
            {
                IEnumerable<Role> roles = userProvider.GetRoles().ToArray();
                ViewBag.roles = roles;
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
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            try
            {
                if (model.Roles == null)
                {
                    ModelState.AddModelError("", "Select at least one role");
                }
                if (ModelState.IsValid)
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
                else
                {
                    return View();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            try
            {
                IEnumerable<Role> roles = userProvider.GetRoles().ToArray();
                ViewBag.roles = roles;
                return View();
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult CreateUser(RegistrationViewModel model)
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
                        Login = model.Login,
                        Password = model.Password,
                        Email = model.Email,
                        Roles = userRoles.ToArray()
                    };

                    userProvider.AddUser(user);
                    return RedirectToAction("UserList");
                }
                catch (System.Exception)
                {
                    throw;
                }

            }
            else
            {
                return View("CreateUser", model);
            }

        }
    }
}