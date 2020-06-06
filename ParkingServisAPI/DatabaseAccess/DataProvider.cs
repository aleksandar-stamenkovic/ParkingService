using DatabaseAccess.DTOs;
using NHibernate;
using NHibernate.Hql.Ast.ANTLR.Tree;
using ParkingServis;
using ParkingServis.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DatabaseAccess
{
    public class DataProvider
    {
        #region Parking
        public static List<ParkingView> VratiSveParkinge()
        {
            List<ParkingView> parkinzi = new List<ParkingView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<Parking> sviParkinzi = s.QueryOver<Parking>().List<Parking>();

                foreach (Parking p in sviParkinzi)
                {
                    var parking = new ParkingView(p);
                    parking.JavnaMesta = p.JavnaMesta.Select(p => new JavnoMestoView(p)).ToList();
                    parkinzi.Add(parking);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return parkinzi;
        }

        public static void DodajParking(ParkingView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Parking o = new Parking
                {
                    Naziv = p.Naziv,
                    Adresa = p.Adresa,
                    Zona = p.Zona,
                    BrMesta = p.BrMesta,
                    RadnoVreme = p.RadnoVreme,
                    GarazaFleg = p.GarazaFleg,
                    PodNadTip = p.PodNadTip,
                    Montazna = p.Montazna,
                    BrNivoa = p.BrNivoa
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static ParkingView AzurirajParking(ParkingView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Parking o = s.Load<Parking>(p.Id);
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.Zona = p.Zona;
                o.BrMesta = p.BrMesta;
                o.RadnoVreme = p.RadnoVreme;
                o.GarazaFleg = p.GarazaFleg;
                o.PodNadTip = p.PodNadTip;
                o.Montazna = p.Montazna;
                o.BrNivoa = p.BrNivoa;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }

        public static void ObrisiParking(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Parking o = s.Load<Parking>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region JavnoMesto
        public static List<JavnoMestoView> VratiSvaJavnaMesta()
        {
            List<JavnoMestoView> javnaMesta = new List<JavnoMestoView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<JavnoMesto> svaJavnaMesta = s.QueryOver<JavnoMesto>().List<JavnoMesto>();

                foreach (JavnoMesto o in svaJavnaMesta)
                {
                    var javnoMesto = new JavnoMestoView(o);
                    javnoMesto.ZakupVozila = o.ZakupVozila.Select(p => new ZakupView(p)).ToList();
                    javnoMesto.PripadaParkingu = new ParkingView(o.PripadaParkingu);
                    javnaMesta.Add(javnoMesto);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return javnaMesta;
        }

        public static void DodajJavnoMesto(JavnoMestoView j)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Parking p = s.Load<Parking>(j.PripadaParkingu.Id);

                JavnoMesto o = new JavnoMesto
                {
                    GarazaFleg = j.GarazaFleg,
                    PripadaParkingu = p,
                    RedBrMesta = j.RedBrMesta,
                    Sprat = j.Sprat,
                    Zauzetost = j.Zauzetost
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static JavnoMestoView AzurirajJavnoMesto(JavnoMestoView j)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Parking p = s.Load<Parking>(j.PripadaParkingu.Id);

                JavnoMesto o = s.Load<JavnoMesto>(j.Id);
                o.GarazaFleg = j.GarazaFleg;
                o.RedBrMesta = j.RedBrMesta;
                o.Sprat = j.Sprat;
                o.Zauzetost = j.Zauzetost;
                o.PripadaParkingu = p;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return j;
        }

        public static void ObrisiJavnoMesto(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                JavnoMesto o = s.Load<JavnoMesto>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region FizickaLica
        public static List<FizickoLiceView> VratiFizickaLica()
        {
            List<FizickoLiceView> Lica = new List<FizickoLiceView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<FizickoLice> svaLica = s.QueryOver<FizickoLice>().List<FizickoLice>();

                foreach (FizickoLice p in svaLica)
                {
                    var fizickoLice = new FizickoLiceView(p);
                    fizickoLice.Vozila = p.Vozila.Select(p => new VoziloView(p)).ToList();
                    Lica.Add(fizickoLice);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Lica;
        }


        public static void DodajFizickoLice(FizickoLiceView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice o = new FizickoLice
                {
                    Jmbg = p.Jmbg,
                    Ime = p.Ime,
                    ImeRoditelja = p.ImeRoditelja,
                    Prezime = p.Prezime,
                    BrTelefona = p.BrTelefona,
                    Adresa = p.Adresa,
                    BrLicne = p.BrLicne,
                    MestoIzdavanja = p.MestoIzdavanja,
                    BrVozacke = p.BrVozacke,
                    ZonaBoravka = p.ZonaBoravka
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static FizickoLiceView AzurirajFizickoLice(FizickoLiceView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice o = s.Load<FizickoLice>(p.Id);
                o.Jmbg = p.Jmbg;
                o.Ime = p.Ime;
                o.ImeRoditelja = p.ImeRoditelja;
                o.Prezime = p.Prezime;
                o.BrTelefona = p.BrTelefona;
                o.Adresa = p.Adresa;
                o.BrLicne = p.BrLicne;
                o.MestoIzdavanja = p.MestoIzdavanja;
                o.BrVozacke = p.BrVozacke;
                o.ZonaBoravka = p.ZonaBoravka;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }


        public static void obrisiFizickoLice(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice o = s.Load<FizickoLice>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region JednokratnaKupovina

        public static List<JednokratnaKupovinaView> VratiSveJednokratneKupovine()
        {
            List<JednokratnaKupovinaView> jednokratneKupovine = new List<JednokratnaKupovinaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<JednokratnaKupovina> sve = s.QueryOver<JednokratnaKupovina>().List<JednokratnaKupovina>();

                foreach (JednokratnaKupovina p in sve)
                {
                    var kupovina = new JednokratnaKupovinaView(p);
                    kupovina.PripadaVozilu = new VoziloView(p.PripadaVozilu);
                    jednokratneKupovine.Add(kupovina);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return jednokratneKupovine;
        }

        public static void DodajJednokratnuKupovinu(JednokratnaKupovinaView j)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo v = s.Load<Vozilo>(j.PripadaVozilu.Id);

                JednokratnaKupovina o = new JednokratnaKupovina
                {
                    DatumProdaje = j.DatumProdaje,
                    Iskoriscenost = j.Iskoriscenost,
                    PripadaVozilu = v
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static JednokratnaKupovinaView AzurirajJednokratnuKupovinu(JednokratnaKupovinaView j)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo v = s.Load<Vozilo>(j.PripadaVozilu.Id);

                JednokratnaKupovina o = s.Load<JednokratnaKupovina>(j.Id);
                o.DatumProdaje = j.DatumProdaje;
                o.Iskoriscenost = j.Iskoriscenost;
                o.PripadaVozilu = v;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return j;
        }

        public static void ObrisiJednokratnuKupovinu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                JednokratnaKupovina o = s.Load<JednokratnaKupovina>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region PretplatnickaKupovina

        public static List<PretplatnickaKupovinaView> VratiSvePretplatnickeKupovine()
        {
            List<PretplatnickaKupovinaView> kupovine = new List<PretplatnickaKupovinaView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<PretplatnickaKupovina> sveKupovine = s.QueryOver<PretplatnickaKupovina>().List<PretplatnickaKupovina>();

                foreach (PretplatnickaKupovina p in sveKupovine)
                {
                    var kupovina = new PretplatnickaKupovinaView(p);
                    kupovina.PripadaVozilu = new VoziloView(p.PripadaVozilu);
                    kupovine.Add(kupovina);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return kupovine;
        }

        public static void DodajPretplatnickuKupovinu(PretplatnickaKupovinaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo v = s.Load<Vozilo>(p.PripadaVozilu.Id);

                PretplatnickaKupovina o = new PretplatnickaKupovina
                {
                    DatumProdaje = p.DatumProdaje,
                    Iskoriscenost = p.Iskoriscenost,
                    PeriodVazenja = p.PeriodVazenja,
                    Zona = p.Zona,
                    PripadaVozilu = v
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static PretplatnickaKupovinaView AzurirajPretplatnickuKupovinu(PretplatnickaKupovinaView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo v = s.Load<Vozilo>(p.PripadaVozilu.Id);

                PretplatnickaKupovina o = s.Load<PretplatnickaKupovina>(p.Id);
                o.DatumProdaje = p.DatumProdaje;
                o.Iskoriscenost = p.Iskoriscenost;
                o.PeriodVazenja = p.PeriodVazenja;
                o.Zona = p.Zona;
                o.PripadaVozilu = v;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }

        public static void ObrisiPretplatnickuKupovinu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PretplatnickaKupovina o = s.Load<PretplatnickaKupovina>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region PravnaLica
        public static List<PravnoLiceView> VratiPravnaLica()
        {
            List<PravnoLiceView> Lica = new List<PravnoLiceView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<PravnoLice> svaLica = s.QueryOver<PravnoLice>().List<PravnoLice>();

                foreach (PravnoLice p in svaLica)
                {
                    var pravnoLice = new PravnoLiceView(p);
                    pravnoLice.Vozila = p.Vozila.Select(p => new VoziloView(p)).ToList();
                    Lica.Add(pravnoLice);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return Lica;
        }


        public static void DodajPravnoLice(PravnoLiceView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravnoLice o = new PravnoLice
                {
                    Pib = p.Pib,
                    Naziv = p.Naziv,
                    Adresa = p.Adresa,
                    BrTelefona = p.BrTelefona,
                    ImeOvlascenog = p.ImeOvlascenog
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static PravnoLiceView AzurirajPravnoLice(PravnoLiceView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravnoLice o = s.Load<PravnoLice>(p.Id);
                o.Pib = p.Pib;
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.BrTelefona = p.BrTelefona;
                o.ImeOvlascenog = p.ImeOvlascenog;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }


        public static void obrisiPravnoLice(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravnoLice o = s.Load<PravnoLice>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region UlicnoMesto

        public static List<UlicnoMestoView> VratiSvaUlicnaMesta()
        {
            List<UlicnoMestoView> mesta = new List<UlicnoMestoView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<UlicnoMesto> svaMesta = s.QueryOver<UlicnoMesto>().List<UlicnoMesto>();

                foreach (UlicnoMesto m in svaMesta)
                {
                    var mesto = new UlicnoMestoView(m);
                    mesto.ZakupVozila = m.ZakupVozila.Select(p => new ZakupView(p)).ToList();
                    mesta.Add(mesto);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return mesta;
        }

        public static void DodajUlicnoMesto(UlicnoMestoView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UlicnoMesto o = new UlicnoMesto
                {
                    NazivUlice = p.NazivUlice,
                    Zauzetost = p.Zauzetost,
                    Zona = p.Zona
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static UlicnoMestoView AzurirajUlicnoMesto(UlicnoMestoView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UlicnoMesto o = s.Load<UlicnoMesto>(p.Id);
                o.NazivUlice = p.NazivUlice;
                o.Zauzetost = p.Zauzetost;
                o.Zona = p.Zona;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }

        public static void ObrisiUlicnoMesto(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UlicnoMesto o = s.Load<UlicnoMesto>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        #region Vozilo
        public static List<VoziloView> VratiVozila()
        {
            List<VoziloView> vozila = new List<VoziloView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<VoziloFizickog> svaVozilaFizickog = s.QueryOver<VoziloFizickog>().List<VoziloFizickog>();
                IList<VoziloPravnog> svaVozilaPravnog = s.QueryOver<VoziloPravnog>().List<VoziloPravnog>();

                foreach (VoziloFizickog p in svaVozilaFizickog)
                {
                    var vozilo = new VoziloFizickogView(p);
                    vozilo.FizickoLice = new FizickoLiceView(p.FizickoLice);                      
                    vozilo.PravnoLice = null;
                    
                    vozilo.ZakupMesta = p.ZakupMesta.Select(x => new ZakupView(x)).ToList();
                    vozila.Add(vozilo);
                }

                foreach (VoziloPravnog p in svaVozilaPravnog)
                {
                    var vozilo = new VoziloPravnogView(p);
                    vozilo.PravnoLice = new PravnoLiceView(p.PravnoLice);
                    vozilo.FizickoLice = null;

                    vozilo.ZakupMesta = p.ZakupMesta.Select(x => new ZakupView(x)).ToList();
                    vozila.Add(vozilo);
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return vozila;
        }


        public static void DodajVozilo(VoziloView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice fl = s.Load<FizickoLice>(p.FizickoLice.Id);
                PravnoLice pl = s.Load<PravnoLice>(p.PravnoLice.Id);
                Vozilo o;
                if(fl != null)
                {
                    o = new VoziloFizickog
                    {
                        Registarcija = p.Registarcija,
                        Proizvodjac = p.Proizvodjac,
                        Model = p.Model,
                        BrSaobracajne = p.BrSaobracajne,
                        FizPravnoFleg = p.FizPravnoFleg,
                        FizickoLice = fl,
                        PravnoLice = null
                    };
                }
                else
                {
                    o = new VoziloPravnog
                    {
                        Registarcija = p.Registarcija,
                        Proizvodjac = p.Proizvodjac,
                        Model = p.Model,
                        BrSaobracajne = p.BrSaobracajne,
                        FizPravnoFleg = p.FizPravnoFleg,
                        FizickoLice = null,
                        PravnoLice = pl
                    };
                }

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static VoziloView AzurirajVozilo(VoziloView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice fl = s.Load<FizickoLice>(p.FizickoLice.Id);
                PravnoLice pl = s.Load<PravnoLice>(p.PravnoLice.Id);

                Vozilo o = s.Load<Vozilo>(p.Id);
                o.Registarcija = p.Registarcija;
                o.Proizvodjac = p.Proizvodjac;
                o.Model = p.Model;
                o.BrSaobracajne = p.BrSaobracajne;
                o.FizPravnoFleg = p.FizPravnoFleg;
                o.FizickoLice = fl;
                o.PravnoLice = pl;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }


        public static void obrisiVozilo(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo o = s.Load<Vozilo>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion

        #region Zakup
        public static List<ZakupView> VratiZakup()
        {
            List<ZakupView> zakupi = new List<ZakupView>();

            try
            {
                ISession s = DataLayer.GetSession();

                IList<Zakup> sviZakupi = s.QueryOver<Zakup>().List<Zakup>();

                foreach (Zakup p in sviZakupi)
                {
                    var zakup = new ZakupView(p);
                    if(p.UlicnoMesto != null)
                        zakup.UlicnoMesto = new UlicnoMestoView(p.UlicnoMesto);
                    else
                        zakup.JavnoMesto = new JavnoMestoView(p.JavnoMesto);
                    zakup.Vozilo = new VoziloView(p.Vozilo);
                    zakupi.Add(zakup);
                }

                s.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return zakupi;
        }


        public static void DodajZakup(ZakupView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UlicnoMesto um = s.Load<UlicnoMesto>(p.UlicnoMesto.Id);
                JavnoMesto jm = s.Load<JavnoMesto>(p.JavnoMesto.Id);
                Vozilo vz = s.Load<Vozilo>(p.Vozilo.Id);

                Zakup o = new Zakup
                {
                    Vreme = p.Vreme,
                    PeriodZakupa = p.PeriodZakupa,
                    UlJavnoFleg = p.UlJavnoFleg,
                    UlicnoMesto = um,
                    JavnoMesto = jm,
                    Vozilo = vz
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static ZakupView AzurirajZakup(ZakupView p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UlicnoMesto um = s.Load<UlicnoMesto>(p.UlicnoMesto.Id);
                JavnoMesto jm = s.Load<JavnoMesto>(p.JavnoMesto.Id);
                Vozilo vz = s.Load<Vozilo>(p.Vozilo.Id);

                Zakup o = s.Load<Zakup>(p.Id);
                o.Vreme = p.Vreme;
                o.PeriodZakupa = p.PeriodZakupa;
                o.UlJavnoFleg = p.UlJavnoFleg;
                o.UlicnoMesto = um;
                o.JavnoMesto = jm;
                o.Vozilo = vz;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }


        public static void obrisiZakup(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Zakup o = s.Load<Zakup>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        #endregion
    }
}
