using FormsAndSessionsExperiment.Models;
using FormsAndSessionsExperiment.Models.ContextModels;
using FormsAndSessionsExperiment.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.Controllers
{
    public class AdminController : Controller
    {
        private ITestRepository repository;
        public AdminController(ITestRepository repository) => this.repository = repository;

        public ViewResult TestMessage() => View();

        [HttpGet]
        public ViewResult CreateMessage() => View(new CreateMessageViewModel { Categories = new SelectList(repository.Categories, "CategoryId", "Name") });

        [HttpPost]
        public IActionResult ProcessMessage(CreateMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                Message newMessage = new Message
                {
                    MessageId = Guid.NewGuid(),
                    Title = model.Title,
                    Body = model.Body,
                    CategoryId = model.CategoryId
                };
                repository.AddMessage(newMessage);
                TempData["SuccessMessage"] = $"Сообщение {newMessage.Title} успешно создано";
                return RedirectToAction("Index", "Main");
            }
            model.Categories = new SelectList(repository.Categories, "CategoryId", "Name");
            return View("CreateMessage", model);
        }

        [HttpGet]
        public ViewResult CreateCategory() => View();

        [HttpPost]
        public RedirectToActionResult ProcessCategory()
        {
            Category newCategory = new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = Request.Form["Name"]
            };
            repository.AddCategory(newCategory);
            TempData["SuccessMessage"] = $"Категория {newCategory.Name} успешно создана";
            return RedirectToAction("Index", "Main");
        }
    }
}
