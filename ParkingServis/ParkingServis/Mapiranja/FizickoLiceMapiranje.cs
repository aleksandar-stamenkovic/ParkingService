using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;

namespace ParkingServis.Mapiranja
{
    public class FizickoLiceMapiranje : ClassMap<FizickoLice>
    {
        public FizickoLiceMapiranje()
        {
            // Mapiranje tabele
            Table("FIZICKO_LICE");

            // Mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje svojstava
            Map(x => x.Jmbg, "JMBG");
            Map(x => x.Ime, "IME");
            Map(x => x.ImeRoditelja, "IME_RODITELJA");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.BrTelefona, "BR_TELEFONA");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.BrLicne, "BR_LICNE");
            Map(x => x.MestoIzdavanja, "MESTO_IZDAVANJA");
            Map(x => x.BrVozacke, "BR_VOZACKE");
            Map(x => x.ZonaBoravka, "ZONA_BORAVKA");

            HasMany(x => x.Vozila).KeyColumn("ID_FIZICKOG").LazyLoad().Cascade.All().Inverse();
        }
    }
}
