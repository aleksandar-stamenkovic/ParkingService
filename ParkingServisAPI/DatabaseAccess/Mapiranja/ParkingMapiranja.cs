using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;

namespace ParkingServis.Mapiranja
{
    public class ParkingMapiranja : ClassMap<Parking>
    {
        public ParkingMapiranja()
        {
            // Mapiranje tabele
            Table("PARKING");

            // Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.Zona, "ZONA");
            Map(x => x.BrMesta, "BR_MESTA");
            Map(x => x.RadnoVreme, "RADNO_VREME");
            Map(x => x.GarazaFleg, "GARAZA_FLEG");
            Map(x => x.PodNadTip, "POD_NAD_TIP");
            Map(x => x.Montazna, "MONTAZNA");
            Map(x => x.BrNivoa, "BR_NIVOA");

            HasMany(x => x.JavnaMesta).KeyColumn("ID_PARKINGA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
