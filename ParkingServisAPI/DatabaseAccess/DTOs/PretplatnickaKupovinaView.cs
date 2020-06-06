using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class PretplatnickaKupovinaView : KupovinaView
    {
        public int Zona { get; set; }
        public int PeriodVazenja { get; set; }

        public PretplatnickaKupovinaView(PretplatnickaKupovina p) : base(p)
        {
            Zona = p.Zona;
            PeriodVazenja = p.PeriodVazenja;
        }

        public PretplatnickaKupovinaView() : base()
        {

        }
    }
}
