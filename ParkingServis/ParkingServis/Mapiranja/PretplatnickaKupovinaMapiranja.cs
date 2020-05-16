using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;

namespace ParkingServis.Mapiranja
{
    public class PretplatnickaKupovinaMapiranja : ClassMap<PretplatnickaKupovina>
    {
        public PretplatnickaKupovinaMapiranja()
        {
            // Mapiranje tabele
            Table("PRETPLATNICKA_KUPOVINA");

            // Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            // Mapiranje svojstava
            Map(x => x.Zona, "ZONA");
            Map(x => x.DatumProdaje, "DATUM_PRODAJE");
            Map(x => x.PeriodVazenja, "PERIOD_VAZENJA");
            Map(x => x.Iskoriscenost, "ISKORISCENOST");

            References(x => x.PripadaVozilu).Column("ID_VOZILA").LazyLoad();
        }
    }
}
