using System.Collections.Generic;

namespace WebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Order> Orders { get; set; }
    }
}