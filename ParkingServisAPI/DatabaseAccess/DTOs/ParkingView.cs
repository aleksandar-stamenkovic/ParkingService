using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class ParkingView
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int Zona { get; set; }
        public int BrMesta { get; set; }
        public string RadnoVreme { get; set; }
        public bool GarazaFleg { get; set; }
        public string PodNadTip { get; set; }
        public bool Montazna { get; set; }
        public int BrNivoa { get; set; }

        public virtual IList<JavnoMestoView> JavnaMesta { get; set; }

        public ParkingView()
        {
            JavnaMesta = new List<JavnoMestoView>();
        }

        public ParkingView(Parking p)
        {
            Id = p.Id;
            Naziv = p.Naziv;
            Adresa = p.Adresa;
            Zona = p.Zona;
            BrMesta = p.BrMesta;
            RadnoVreme = p.RadnoVreme;
            GarazaFleg = p.GarazaFleg;
            PodNadTip = p.PodNadTip;
            Montazna = p.Montazna;
            BrNivoa = p.BrNivoa;
        }
    }
}
