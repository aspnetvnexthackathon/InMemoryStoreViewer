using System;

namespace WebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}