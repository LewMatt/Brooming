using System;
using System.Text;
using System.Collections.Generic;
using Brooming_pl.DBClasses;


namespace Brooming_pl.DBClasses
{
    
    public class Ratings {
        public virtual double CommentId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Users Users { get; set; }
        public virtual int? Rating { get; set; }
        public virtual string Comment { get; set; }
    }
}
