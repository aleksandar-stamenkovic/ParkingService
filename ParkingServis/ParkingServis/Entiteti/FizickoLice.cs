using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public class FizickoLice
    {
        public virtual int Id { get; set; }
        public virtual long Jmbg { get; set; }
        public virtual string Ime { get; set; }
        public virtual string ImeRoditelja { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string BrTelefona { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string BrLicne { get; set; }
        public virtual string MestoIzdavanja { get; set; }
        public virtual string BrVozacke { get; set; }
        public virtual string ZonaBoravka { get; set; }

        public FizickoLice()
        {

        }
    }
}
