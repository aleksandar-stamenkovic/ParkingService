using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class VoziloPravnogView : VoziloView
    {
        public VoziloPravnogView()
        {

        }

        public VoziloPravnogView(Vozilo v) : base(v)
        {

        }
    }
}
