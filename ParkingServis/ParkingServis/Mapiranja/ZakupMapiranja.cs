using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Mapiranja
{
    public class ZakupMapiranja : ClassMap<Zakup>
    {
        public ZakupMapiranja()
        {
            Table("ZAKUP");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Vreme, "VREME");
            Map(x => x.PeriodZakupa, "PERIOD_ZAKUPA");
            Map(x => x.UlJavnoFleg , "UL_JAVNO_FLEG");

            References(x => x.UlicnoMesto).Column("ID_ULICNOG_MESTA").LazyLoad();
            References(x => x.JavnoMesto).Column("ID_JAVNOG_MESTA").LazyLoad();
            References(x => x.Vozilo).Column("ID_VOZILA").LazyLoad();
        }
    }
}
