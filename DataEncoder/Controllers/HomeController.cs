using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataEncryptor.Controllers
{
    public class HomeController : Controller
    {
        private IModelService _modelService;

        public HomeController(IModelService modelService)
        {
            _modelService = modelService;
        }

        public IActionResult Index()
        {
            var models = _modelService.GetAll();
            return View(models);
        }

        public IActionResult AddModel()
        {
            return View("/Model/AddModel");
        }
    }
}