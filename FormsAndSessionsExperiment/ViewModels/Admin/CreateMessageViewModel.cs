using FormsAndSessionsExperiment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.ViewModels.Admin
{
    public class CreateMessageViewModel
    {
        [Required(ErrorMessage = "Введите заголовок сообщения")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите содержание сообщения")]
        [Display(Name = "Содержание")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Выберите категорию")]
        [Display(Name = "Категория")]
        public Guid CategoryId { get; set; }

        public SelectList Categories { get; set; }
    }
}
