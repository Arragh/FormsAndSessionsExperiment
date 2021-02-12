using FormsAndSessionsExperiment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.ViewModels.Main
{
    public class IndexViewModel
    {
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
