using FormsAndSessionsExperiment.Models.ContextModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private ITestRepository repository;
        public NavigationViewComponent(ITestRepository repository) => this.repository = repository;

        public IViewComponentResult Invoke()
        {
            ViewBag.CurrentCategory = RouteData?.Values["categoryName"];
            return View(repository.Categories.Select(c => c.Name));
        }
    }
}
