using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public abstract class Kupovina
    {
        public virtual int Id { get; set; }
        public virtual DateTime DatumProdaje { get; set; }
        public virtual bool Iskoriscenost { get; set; }
        public virtual Vozilo PripadaVozilu { get; set; }
    }
}
