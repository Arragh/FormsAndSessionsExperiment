using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.Controllers
{
    public class MainController : Controller
    {
        public ViewResult Index() => View();
    }
}
