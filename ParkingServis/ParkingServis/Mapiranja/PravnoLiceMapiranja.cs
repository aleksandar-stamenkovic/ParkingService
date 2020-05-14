using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;

namespace ParkingServis.Mapiranja
{
    public class PravnoLiceMapiranja : ClassMap<PravnoLice>
    {
        public PravnoLiceMapiranja()
        {
            // Mapiranje tabele
            Table("PRAVNO_LICE");

            // Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Pib, "PIB");
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.BrTelefona, "BR_TELEFONA");
            Map(x => x.ImeOvlascenog, "IME_OVLASCENOG");
        }
    }
}
