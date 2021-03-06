using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Entiteti
{
    public abstract class Vozilo
    {
        public virtual int Id { get; set; }
        public virtual string Registarcija { get; set; }
        public virtual string Proizvodjac { get; set; }
        public virtual string Model { get; set; }
        public virtual string BrSaobracajne { get; set; }
        public virtual int FizPravnoFleg { get; set; }

        public virtual FizickoLice FizickoLice { get; set; }
        public virtual PravnoLice PravnoLice { get; set; }
        public virtual IList<Zakup> ZakupMesta { get; set; }

        public Vozilo()
        {
            ZakupMesta = new List<Zakup>();
        }
    }

    public class VoziloPravnog : Vozilo
    {

    }

    public class VoziloFizickog : Vozilo
    {

    }
}
