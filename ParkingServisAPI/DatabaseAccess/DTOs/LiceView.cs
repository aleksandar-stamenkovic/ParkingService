using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class LiceView
    {
        public int Id { get; set; }
        public string Adresa { get; set; }
        public string BrTelefona { get; set; }
        public virtual IList<VoziloView> Vozila { get; set; }

        public LiceView(Lice l)
        {
            Id = l.Id;
            Adresa = l.Adresa;
            BrTelefona = l.BrTelefona;
        }

        public LiceView()
        {
            Vozila = new List<VoziloView>();
        }
    }
}
