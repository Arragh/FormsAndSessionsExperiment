using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.Models.ContextModels
{
    public class EFTestRepository : ITestRepository
    {
        private TestDbContext context;
        public EFTestRepository(TestDbContext context) => this.context = context;

        public IQueryable<Category> Categories => context.Categories;
        public IQueryable<Message> Messages => context.Messages;

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void AddMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }
    }
}
