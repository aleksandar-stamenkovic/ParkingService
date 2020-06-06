using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class ZakupView
    {
        public int Id { get; set; }
        public DateTime Vreme { get; set; }
        public int PeriodZakupa { get; set; }
        public bool UlJavnoFleg { get; set; }

        public UlicnoMestoView UlicnoMesto { get; set; }
        public JavnoMestoView JavnoMesto { get; set; }
        public VoziloView Vozilo { get; set; }

        public ZakupView(Zakup z)
        {
            Id = z.Id;
            Vreme = z.Vreme;
            PeriodZakupa = z.PeriodZakupa;
            UlJavnoFleg = z.UlJavnoFleg;
        }

        public ZakupView()
        {

        }
    }
}
