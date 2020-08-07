using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.Mapping
{
    
    
    public class OrdersMap : ClassMapping<Orders> {
        
        public OrdersMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.OrderId, map => { map.Column("order_id"); map.Generator(Generators.Assigned); });
			Property(x => x.CarId, map => map.Column("car_id"));
			Property(x => x.DateOfOrder, map => map.Column("date_of_order"));
			Property(x => x.OrderNumber, map => map.Column("order_number"));
			Property(x => x.OrderDetails, map => map.Column("order_details"));
			Property(x => x.Price);
			Property(x => x.AdditionalInfo, map => map.Column("additional_info"));
			Property(x => x.StateOfOrder, map => map.Column("state_of_order"));
			ManyToOne(x => x.Offers, map => 
			{
				map.Column("offer_id");
				map.PropertyRef("OfferId");
				map.NotNullable(true);
				map.Cascade(Cascade.None);
			});

			ManyToOne(x => x.Users, map => 
			{
				map.Column("user_id");
				map.NotNullable(true);
				map.Cascade(Cascade.None);
			});

			ManyToOne(x => x.Company, map => 
			{
				map.Column("company_id");
				map.PropertyRef("CompanyId");
				map.NotNullable(true);
				map.Cascade(Cascade.None);
			});

			Bag(x => x.HistoryOfOrders, colmap =>  { colmap.Key(x => x.Column("order_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.OrderElements, colmap =>  { colmap.Key(x => x.Column("order_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
