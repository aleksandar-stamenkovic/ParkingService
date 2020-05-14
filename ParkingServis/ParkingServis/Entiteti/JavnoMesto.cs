using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public class JavnoMesto
    {
        public virtual int Id { get; set; }
        public virtual string Zauzetost { get; set; }
        public virtual int RedBrMesta { get; set; }
        public virtual bool GarazaFleg { get; set; }
        public virtual int Sprat { get; set; }

        public virtual Parking PripadaParkingu { get; set; }
    }
}
