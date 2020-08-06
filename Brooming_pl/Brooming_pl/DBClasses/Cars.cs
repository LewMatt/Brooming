using System;


namespace Brooming_pl.DBClasses
{
    public class Cars
    {
        public virtual int Id { get; set; }
        public virtual int User_id { get; set; }
        public virtual int Company_id { get; set; }
        public virtual int Type_id { get; set; }
        public virtual string Registration_number { get; set; }
        public virtual int Year_of_production { get; set; }
        public virtual string Description { get; set; }
        public virtual string Link_to_photo { get; set; }
        public virtual int Availability { get; set; }

        public virtual Users User { get; set; }
        public virtual Car_type CarType { get; set; }
    }
}