using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DataEncryptor.Controllers
{
    [Authorize]
    public class ModelController : Controller
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }


        [Authorize(Roles = "admin")]
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



        [Authorize]
        public IActionResult EditModel(int id)
        {
            var model = _modelService.Get(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditModel(ModelDTO model)
        {
            try
            {
                _modelService.Update(model);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return Redirect("/Home");
        }

    }
}
