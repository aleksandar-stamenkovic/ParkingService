using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public class UlicnoMesto
    {
        public virtual int Id { get; set; }
        public virtual string Zauzetost { get; set; }
        public virtual int Zona { get; set; }
        public virtual string NazivUlice { get; set; }

        public UlicnoMesto()
        {

        }
    }
}
