using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Brooming_pl.DBClasses;


namespace Brooming_pl.Mapping
{
    
    
    public class SysdiagramsMap : ClassMapping<Sysdiagrams> {
        
        public SysdiagramsMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.DiagramId, map => { map.Column("diagram_id"); map.Generator(Generators.Identity); });
			Property(x => x.Name, map => { map.NotNullable(true); map.Unique(true); });
			Property(x => x.PrincipalId, map => 
			{
				map.Column("principal_id");
				map.NotNullable(true);
				map.Unique(true);
			});
			Property(x => x.Version);
			Property(x => x.Definition);
        }
    }
}
