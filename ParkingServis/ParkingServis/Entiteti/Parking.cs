using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public class Parking
    {
        public virtual int Id { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Adresa { get; set; }
        public virtual int Zona { get; set; }
        public virtual int BrMesta { get; set; }
        public virtual string RadnoVreme { get; set; }
        public virtual bool GarazaFleg { get; set; }
        public virtual string PodNadTip { get; set; }
        public virtual bool Montazna { get; set; }
        public virtual int BrNivoa { get; set; }

        public Parking()
        {

        }
    }
}
