using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;

namespace ParkingServis.Mapiranja
{
    public class JednokratnaKupovinaMapiranja : ClassMap<JednokratnaKupovina>
    {
        public JednokratnaKupovinaMapiranja()
        {
            // Mapiranje tabele
            Table("JEDNOKRATNA_KUPOVINA");

            // Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            // Mapiranje svojstava
            Map(x => x.DatumProdaje, "DATUM_PRODAJE");
            Map(x => x.Iskoriscenost, "ISKORISCENOST");

            References(x => x.PripadaVozilu).Column("ID_VOZILA").LazyLoad();
        }
    }
}
