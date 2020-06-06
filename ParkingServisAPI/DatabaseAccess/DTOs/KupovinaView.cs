using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class KupovinaView
    {
        public int Id { get; set; }
        public DateTime DatumProdaje { get; set; }
        public bool Iskoriscenost { get; set; }
        public VoziloView PripadaVozilu { get; set; }

        public KupovinaView()
        {

        }

        public KupovinaView(Kupovina k)
        {
            Id = k.Id;
            DatumProdaje = k.DatumProdaje;
            Iskoriscenost = k.Iskoriscenost;
        }
    }
}
