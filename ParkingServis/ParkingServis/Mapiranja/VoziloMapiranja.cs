﻿using FluentNHibernate.Mapping;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingServis.Mapiranja
{
    public class VoziloMapiranja : ClassMap<Vozilo>
    {
        public VoziloMapiranja()
        {
            Table("VOZILO");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Registarcija, "REGISTRACIJA");
            Map(x => x.Proizvodjac, "PROIZVODJAC");
            Map(x => x.Model, "MODEL");
            Map(x => x.BrSaobracajne, "BR_SAOBRACAJNE");
            Map(x => x.FizPravnoFleg, "FIZ_PRAVNO_FLEG");

            References(x => x.FizickoLice).Column("ID_FIZICKOG").LazyLoad();
            References(x => x.PravnoLice).Column("ID_PRAVNOG").LazyLoad();
        }
    }
}
