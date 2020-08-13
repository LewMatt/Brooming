using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.mapping
{


    public class CarTypeMap : ClassMapping<CarType>
    {

        public CarTypeMap()
        {
            Table("car_type");
            Schema("dbo");
            Lazy(true);
            Id(x => x.TypeId, map => { map.Column("type_id"); map.Generator(Generators.Identity); });
            Property(x => x.Type);
            Property(x => x.Brand);
            Property(x => x.Model);
            Property(x => x.Color);
            Property(x => x.Transmission);
            Property(x => x.Fuel);
            Property(x => x.FuelUsage, map => map.Column("fuel_usage"));
            Property(x => x.Power);
            Property(x => x.Capacity);
            Property(x => x.DoorQuantity, map => map.Column("door_quantity"));
            Property(x => x.SeatQuantity, map => map.Column("seat_quantity"));
            Bag(x => x.Cars, colmap => { colmap.Key(x => x.Column("type_id")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
