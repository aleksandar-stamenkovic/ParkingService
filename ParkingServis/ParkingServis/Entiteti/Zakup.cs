using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public class Zakup
    {
        public virtual int Id { get; set; }
        public virtual DateTime Vreme { get; set; }
        public virtual int PeriodZakupa { get; set; }
        public virtual bool UlJavnoFleg { get; set; }

        public virtual UlicnoMesto UlicnoMesto { get; set; }
        public virtual JavnoMesto JavnoMesto { get; set; }
        public virtual Vozilo Vozilo { get; set; }
    }
}
