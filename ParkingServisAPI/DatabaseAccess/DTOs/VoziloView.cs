using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class VoziloView
    {
        public int Id { get; set; }
        public string Registarcija { get; set; }
        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public string BrSaobracajne { get; set; }
        public int FizPravnoFleg { get; set; }

        public FizickoLiceView FizickoLice { get; set; }
        public PravnoLiceView PravnoLice { get; set; }
        public virtual IList<ZakupView> ZakupMesta { get; set; }

        public VoziloView(Vozilo v)
        {
            Id = v.Id;
            Registarcija = v.Registarcija;
            Proizvodjac = v.Proizvodjac;
            Model = v.Model;
            BrSaobracajne = v.BrSaobracajne;
            FizPravnoFleg = v.FizPravnoFleg;
        }

        public VoziloView()
        {
            ZakupMesta = new List<ZakupView>();
        }
    }
}
