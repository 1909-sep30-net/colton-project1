using System;
using System.Collections.Generic;

namespace WebApplication.Data.Entitis
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public double Total { get; set; }
        public int LocationId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
