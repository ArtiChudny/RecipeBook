using System;
using System.Web.Mvc;
using log4net;
using RecipeBook.Business;
using RecipeBookMVC.Models;
using System.Net;

namespace RecipeBookMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog log = LogManager.GetLogger("Logger");
        private readonly IProvider provider;

        public HomeController(IProvider _provider)
        {
            provider = _provider;
        }

        // GET: Home
        public ActionResult Index()
        {
           
            try
            {
                HomeViewModel model= new HomeViewModel();
                model.Message = provider.GetMessage();
                return View(model);

            }
            catch (ArgumentNullException ex)
            {

                log.Error(ex.Message);
                return View("Error");


            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return View("Error");

            }
           
           
        }
    }
}