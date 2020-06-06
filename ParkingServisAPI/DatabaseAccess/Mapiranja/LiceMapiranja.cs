using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Mapiranja
{
    class LiceMapiranja : ClassMap<Lice>
    {
        public LiceMapiranja()
        {
            // Table Per Concrete Class Inheritance
            UseUnionSubclassForInheritanceMapping();

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Adresa, "ADRESA");
            Map(x => x.BrTelefona, "BR_TELEFONA");
        }
    }
}
