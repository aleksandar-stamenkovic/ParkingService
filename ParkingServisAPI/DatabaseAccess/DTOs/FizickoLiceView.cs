using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class FizickoLiceView : LiceView
    {
        public long Jmbg { get; set; }
        public string Ime { get; set; }
        public string ImeRoditelja { get; set; }
        public string Prezime { get; set; }
        public string BrLicne { get; set; }
        public string MestoIzdavanja { get; set; }
        public string BrVozacke { get; set; }
        public string ZonaBoravka { get; set; }

        public FizickoLiceView() : base()
        {

        }

        public FizickoLiceView(FizickoLice f) : base(f)
        {
            Jmbg = f.Jmbg;
            Ime = f.Ime;
            ImeRoditelja = f.ImeRoditelja;
            Prezime = f.Prezime;
            BrLicne = f.BrLicne;
            MestoIzdavanja = f.MestoIzdavanja;
            BrVozacke = f.BrVozacke;
            ZonaBoravka = f.ZonaBoravka;
        }
    }
}
