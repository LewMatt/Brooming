using System;

namespace Brooming_pl.DBClasses
{
	public class Car_type
	{
		public virtual int Type_id { get; set; }
		public virtual string Type { get; set; }
		public virtual string Brand { get; set; }
		public virtual string Model { get; set; }
		public virtual string Color { get; set; }
		public virtual string Transmission { get; set; }
		public virtual string Fuel { get; set; }
		public virtual string Fuel_usage { get; set; }
		public virtual string Power { get; set; }
		public virtual int Capacity { get; set; }
		public virtual int Door_quantity { get; set; }
		public virtual int Seat_quantity { get; set; }
	}
}