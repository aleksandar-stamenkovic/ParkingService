using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public class PretplatnickaKupovina : Kupovina
    {
        //public virtual int Id { get; set; }
        public virtual int Zona { get; set; }
        //public virtual DateTime DatumProdaje { get; set; }
        public virtual int PeriodVazenja { get; set; }
        //public virtual bool Iskoriscenost { get; set; }

        //public virtual Vozilo PripadaVozilu { get; set; }

        public PretplatnickaKupovina()
        {

        }
    }
}
