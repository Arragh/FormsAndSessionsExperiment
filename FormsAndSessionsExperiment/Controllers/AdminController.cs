using FormsAndSessionsExperiment.Models;
using FormsAndSessionsExperiment.Models.ContextModels;
using FormsAndSessionsExperiment.ViewModels.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

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
            // Переназначение категорий
            model.Categories = new SelectList(repository.Categories, "CategoryId", "Name");
            return View("CreateMessage", model);
        }

        [HttpGet]
        public ViewResult CreateCategory()
        {
            ViewBag.SessionData = HttpContext.Session.GetString("Test");
            return View();
        }

        [HttpPost]
        public IActionResult ProcessCategory(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Test", $"Была создана категория {model.Name}");
                Category newCategory = new Category
                {
                    CategoryId = Guid.NewGuid(),
                    Name = model.Name
                };
                repository.AddCategory(newCategory);
                TempData["SuccessMessage"] = $"Категория {newCategory.Name} успешно создана";
                return RedirectToAction("Index", "Main");
            }
            return View("CreateCategory");
        }
    }
}
