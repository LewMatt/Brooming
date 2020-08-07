using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;


namespace Brooming_pl.DBClasses
{
    
    public class Orders {
        public Orders() {
			HistoryOfOrders = new List<HistoryOfOrders>();
			OrderElements = new List<OrderElements>();
        }
        public virtual double OrderId { get; set; }
        public virtual Offers Offers { get; set; }
        public virtual Users Users { get; set; }
        public virtual Company Company { get; set; }
        public virtual double? CarId { get; set; }
        public virtual DateTime? DateOfOrder { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual string OrderDetails { get; set; }
        public virtual float? Price { get; set; }
        public virtual string AdditionalInfo { get; set; }
        public virtual int? StateOfOrder { get; set; }
        public virtual IList<HistoryOfOrders> HistoryOfOrders { get; set; }
        public virtual IList<OrderElements> OrderElements { get; set; }
    }
}
