using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;

namespace ParkingServis.Mapiranja
{
    class UlicnoMestoMapiranja : ClassMap<UlicnoMesto>
    {
        public UlicnoMestoMapiranja()
        {
            // Mapiranje tabele
            Table("ULICNO_MESTO");

            // Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Zauzetost, "ZAUZETOST");
            Map(x => x.Zona, "ZONA");
            Map(x => x.NazivUlice, "NAZIV_ULICE");

            HasMany(x => x.ZakupVozila).KeyColumn("ID_ULICNOG_MESTA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
