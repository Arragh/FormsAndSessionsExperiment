using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.Models.ContextModels
{
    public interface ITestRepository
    {
        IQueryable<Category> Categories { get; }
        IQueryable<Message> Messages { get; }
        void AddCategory(Category category);
        void AddMessage(Message message);
    }
}
