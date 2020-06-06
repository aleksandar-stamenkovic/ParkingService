using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class UlicnoMestoView
    {
        public int Id { get; set; }
        public string Zauzetost { get; set; }
        public int Zona { get; set; }
        public string NazivUlice { get; set; }
        public virtual IList<ZakupView> ZakupVozila { get; set; }

        public UlicnoMestoView(UlicnoMesto u)
        {
            Id = u.Id;
            Zauzetost = u.Zauzetost;
            Zona = u.Zona;
            NazivUlice = u.NazivUlice;
        }

        public UlicnoMestoView()
        {
            ZakupVozila = new List<ZakupView>();
        }
    }
}
