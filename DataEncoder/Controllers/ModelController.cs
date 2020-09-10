using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
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
            Encrypt(model);
            return Redirect("/Home");
        }

        public IActionResult EditModel(int id)
        {
            var model = _modelService.Get(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditModel(ModelDTO model)
        {
            _modelService.Update(model);
            return Redirect("/Home");
        }

        private void Encrypt(ModelDTO model)
        {
            model.Name = Encryptor.EncodeOrDecrypt(model.Name);
            model.Desc = Encryptor.EncodeOrDecrypt(model.Desc);
        }
    }
}