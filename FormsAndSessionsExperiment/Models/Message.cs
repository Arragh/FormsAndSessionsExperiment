using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAndSessionsExperiment.Models
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
