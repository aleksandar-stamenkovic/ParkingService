using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class PravnoLiceView : LiceView
    {
        public string Pib { get; set; }
        public string Naziv { get; set; }
        public string ImeOvlascenog { get; set; }

        public PravnoLiceView(PravnoLice p) : base(p)
        {
            Pib = p.Pib;
            Naziv = p.Naziv;
            ImeOvlascenog = p.ImeOvlascenog;
        }

        public PravnoLiceView() : base()
        {

        }
    }
}
