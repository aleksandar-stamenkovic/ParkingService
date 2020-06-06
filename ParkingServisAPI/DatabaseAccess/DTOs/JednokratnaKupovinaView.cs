using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class JednokratnaKupovinaView : KupovinaView
    {
        public JednokratnaKupovinaView() : base()
        {

        }

        public JednokratnaKupovinaView(Kupovina k) : base(k)
        {

        }
    }
}
