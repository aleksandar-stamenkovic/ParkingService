using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public class PravnoLice
    {
        public virtual int Id { get; set; }
        public virtual string Pib { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string BrTelefona { get; set; }
        public virtual string ImeOvlascenog { get; set; }

        public PravnoLice()
        {

        }
    }
}
