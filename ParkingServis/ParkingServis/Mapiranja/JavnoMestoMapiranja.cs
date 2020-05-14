using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Mapiranja
{
    public class JavnoMestoMapiranja : ClassMap<JavnoMesto>
    {
        public JavnoMestoMapiranja()
        {
            // Mapiranje tabele
            Table("JAVNO_MESTO");

            // Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            // Mapiranje svojstava
            Map(x => x.Zauzetost, "ZAUZETOST");
            Map(x => x.RedBrMesta, "RED_BR_MESTA");
            Map(x => x.GarazaFleg, "GARAZA_FLEG");
            Map(x => x.Sprat, "SPRAT");

            References(x => x.PripadaParkingu).Column("ID_PARKINGA").LazyLoad();
        }
    }
}
