using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataEncryptor.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }
        public IActionResult AddModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddModel(ModelDTO model)
        {
            _modelService.Create(model);
            return Redirect("/Home");
        }
    }
}
