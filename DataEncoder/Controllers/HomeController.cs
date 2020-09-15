using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
