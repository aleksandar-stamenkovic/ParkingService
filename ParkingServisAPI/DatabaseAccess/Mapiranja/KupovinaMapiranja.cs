using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Mapiranja
{
    class KupovinaMapiranja : ClassMap<Kupovina>
    {
        public KupovinaMapiranja()
        {
            // Table Per Concrete Class Inheritance
            UseUnionSubclassForInheritanceMapping();

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.DatumProdaje, "DATUM_PRODAJE");
            Map(x => x.Iskoriscenost, "ISKORISCENOST");

            References(x => x.PripadaVozilu).Column("ID_VOZILA").LazyLoad();
        }
    }
}
