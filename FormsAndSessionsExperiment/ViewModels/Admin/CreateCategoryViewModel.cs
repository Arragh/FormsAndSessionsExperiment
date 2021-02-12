using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.ViewModels.Admin
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Название категории не может быть пустым")]
        [Display(Name = "Введите название категории")]
        public string Name { get; set; }
    }
}
