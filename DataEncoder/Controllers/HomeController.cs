using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DataEncryptor.Controllers
{
    public class HomeController : Controller
    {
        IModelService _modelService;

        public HomeController(IModelService modelService)
        {
            _modelService = modelService;
        }

        public IActionResult Users()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult Index()
        {
            var models = _modelService.GetAll();
            return View(models);
        }


        [Authorize(Roles ="admin, moderator")]
        public IActionResult AddModel()
        {
            return View("/Model/AddModel");
        }
    }
}
