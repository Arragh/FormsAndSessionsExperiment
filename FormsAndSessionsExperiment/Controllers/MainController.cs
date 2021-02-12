using FormsAndSessionsExperiment.Models.ContextModels;
using FormsAndSessionsExperiment.ViewModels.Main;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.Controllers
{
    public class MainController : Controller
    {
        private ITestRepository repository;
        public MainController(ITestRepository repository) => this.repository = repository;

        public ViewResult Index(string categoryName) => View(new IndexViewModel {
            Messages = repository.Messages.Include(m => m.Category).Where(m => categoryName == null || m.Category.Name == categoryName),
            Categories = repository.Categories
        });
    }
}
