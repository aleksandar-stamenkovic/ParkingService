using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public abstract class Lice
    {
        public virtual int Id { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string BrTelefona { get; set; }
        public virtual IList<Vozilo> Vozila { get; set; }
    }
}
