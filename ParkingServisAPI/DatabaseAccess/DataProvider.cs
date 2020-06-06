using DatabaseAccess.DTOs;
using NHibernate;
using NHibernate.Hql.Ast.ANTLR.Tree;
using ParkingServis;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess
{
    public class DataProvider
    {
        public static List<ParkingView> VratiSveParkinge()
        {
            List<ParkingView> parkinzi = new List<ParkingView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<Parking> sviParkinzi = s.QueryOver<Parking>().List<Parking>();

                foreach (Parking p in sviParkinzi)
                {
                    parkinzi.Add(new ParkingView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return parkinzi;
        }
    }
}
