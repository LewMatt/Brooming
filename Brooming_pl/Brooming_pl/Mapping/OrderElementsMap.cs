using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping
{
    
    
    public class OrderElementsMap : ClassMapping<OrderElements> {
        
        public OrderElementsMap() {
			Table("order_elements");
			Schema("dbo");
			Lazy(true);
			Id(x => x.OrderId, map => { map.Column("order_id"); map.Generator(Generators.Assigned); });
			Property(x => x.DailyPrice, map => map.Column("daily_price"));
			Property(x => x.TakeLocation, map => map.Column("take_location"));
			Property(x => x.ReturnLocation, map => map.Column("return_location"));
			ManyToOne(x => x.Orders, map => 
			{
				map.Column("order_id");
				map.PropertyRef("OrderId");
				map.Cascade(Cascade.None);
			});

			ManyToOne(x => x.Cars, map => 
			{
				map.Column("car_id");
				map.PropertyRef("CarId");
				map.NotNullable(true);
				map.Cascade(Cascade.None);
			});

        }
    }
}
