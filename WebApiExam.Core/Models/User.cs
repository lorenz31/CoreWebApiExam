using System.Collections.Generic;

namespace WebApiExam.Core.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
