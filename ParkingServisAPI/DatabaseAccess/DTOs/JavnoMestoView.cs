using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class JavnoMestoView
    {
        public int Id { get; set; }
        public string Zauzetost { get; set; }
        public int RedBrMesta { get; set; }
        public bool GarazaFleg { get; set; }
        public int Sprat { get; set; }

        public ParkingView PripadaParkingu { get; set; }
        public virtual IList<ZakupView> ZakupVozila { get; set; }

        public JavnoMestoView()
        {
            ZakupVozila = new List<ZakupView>();
        }

        public JavnoMestoView(JavnoMesto j)
        {
            Id = j.Id;
            Zauzetost = j.Zauzetost;
            RedBrMesta = j.RedBrMesta;
            GarazaFleg = j.GarazaFleg;
            Sprat = j.Sprat;
        }
    }
}
