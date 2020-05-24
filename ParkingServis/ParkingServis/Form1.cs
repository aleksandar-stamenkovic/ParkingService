using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using ParkingServis.Entiteti;

namespace ParkingServis
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void cmdUcitavanjeParkinga_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Parking p = s.Load<Parking>(3);

                MessageBox.Show(p.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdDodavanjeParkinga_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Parking p = new Parking()
                {
                    Naziv = "Novi PArking",
                    Adresa = "Cara LAzara 76",
                    Zona = 3,
                    BrMesta = 90,
                    RadnoVreme = "24h",
                    GarazaFleg = false,
                    PodNadTip = "Nad",
                    Montazna = true,
                    BrNivoa = 4
                };


                s.Save(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdVezaManyToOne_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o parkingu za zadatim brojem
                JavnoMesto jm = s.Load<JavnoMesto>(5);

                MessageBox.Show(jm.Sprat.ToString());
                MessageBox.Show(jm.PripadaParkingu.Naziv);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUcitavanjePravnogLica_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravnoLice p = s.Load<PravnoLice>(3);

                MessageBox.Show(p.Pib + " " + p.Naziv + " " + p.ImeOvlascenog);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdUcitavanjeUlicnogMesta_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UlicnoMesto p = s.Load<UlicnoMesto>(3);

                MessageBox.Show(p.Zauzetost + " " + p.Zona + " " + p.NazivUlice);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitavanjeVozilaFizickog_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo v = s.Load<Vozilo>(2);

                MessageBox.Show($"Model: {v.Model}, Registracija: {v.Registarcija}");

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodajJavnoMesto_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Parking p = new Parking();

                p = s.Load<Parking>(8);

                JavnoMesto jm = new JavnoMesto()
                {
                    Zauzetost = "Ne",
                    RedBrMesta = 14,
                    GarazaFleg = true,
                    Sprat = 7,
                };

                jm.PripadaParkingu = p;

                p.JavnaMesta.Add(jm);
                
                s.Save(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitavanjeZakupa_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo v = s.Load<Vozilo>(2);

                foreach (var m in v.ZakupMesta)
                {
                    MessageBox.Show(m.Vreme.ToString());
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeZakupa_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            Vozilo v = s.Load<Vozilo>(3);
            JavnoMesto jm = s.Load<JavnoMesto>(4);

            Zakup z = new Zakup()
            {
                Vreme = DateTime.Now,
                PeriodZakupa = 36,
                UlJavnoFleg = true
            };

            z.JavnoMesto = jm;
            z.Vozilo = v;

            s.Save(z);
            s.Flush();

            s.Close();
        }

        private void cmdDodavanjeUlicnogMesta_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                UlicnoMesto um = new UlicnoMesto()
                {
                    Zauzetost = "Ne",
                    Zona = 2,
                    NazivUlice = "Cara Lazara"
                };

                s.Save(um);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitavanjeFizickogLica_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice p = s.Load<FizickoLice>(3);

                MessageBox.Show(p.Jmbg + " " + p.Ime + " " + p.ImeRoditelja);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjePravnogLica_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                PravnoLice p = new PravnoLice()
                {
                    Pib = "1222544",
                    Naziv = "KomTrade",
                    Adresa = "Nikole Pasica Beograd",
                    BrTelefona = "0800250255",
                    ImeOvlascenog = "Jovan Stamenkovic"

                };


                s.Save(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeFizickogLica_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                FizickoLice p = new FizickoLice()
                {
                    Jmbg = 1112223334446,
                    Ime = "Petar",
                    ImeRoditelja = "Milovan",
                    Prezime = "Petrovic",
                    BrTelefona = "0655355454",
                    Adresa = "Stanoja Glavasa Beograd",
                    BrLicne = "222331257",
                    MestoIzdavanja = "Beograd",
                    BrVozacke = "225646654",
                    ZonaBoravka = "2"

                };

                s.Save(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitavanjeJednokratneKupovine_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                JednokratnaKupovina p = s.Load<JednokratnaKupovina>(2);

                MessageBox.Show(p.DatumProdaje + " " + p.Iskoriscenost);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeJednokratneKupovine_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo p = new VoziloPravnog();

                p = s.Load<Vozilo>(8);

                JednokratnaKupovina jm = new JednokratnaKupovina()
                {
                    DatumProdaje = DateTime.Now,
                    Iskoriscenost = true
                };

                jm.PripadaVozilu = p;

                s.Save(jm);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitavanjePretplatnickeKupovine_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PretplatnickaKupovina p = s.Load<PretplatnickaKupovina>(2);

                MessageBox.Show(p.Zona + " " + p.DatumProdaje + " " + p.PeriodVazenja + " " + p.Iskoriscenost);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjePretplatnickeKupovine_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo p = new VoziloFizickog();

                p = s.Load<Vozilo>(4);

                PretplatnickaKupovina jm = new PretplatnickaKupovina()
                {
                    Zona = 3,
                    DatumProdaje = DateTime.Now,
                    PeriodVazenja = 25,
                    Iskoriscenost = true

                };

                jm.PripadaVozilu = p;

                s.Save(jm);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeVozilaFizickog_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                FizickoLice fl = s.Load<FizickoLice>(4);

                VoziloFizickog vf = new VoziloFizickog()
                {
                    BrSaobracajne = "15453",
                    FizickoLice = fl,
                    Model = "Punto",
                    Proizvodjac = "Fiat",
                    Registarcija = "lk456",
                };

                s.Save(vf);

                s.Flush();
                s.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUcitavanjeVozilaPravnog_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo v = s.Load<Vozilo>(7);

                MessageBox.Show($"Model: {v.Model}, Registracija: {v.Registarcija}");

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodavanjeVozilaPravnog_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravnoLice pl = s.Load<PravnoLice>(4);

                Vozilo vp = new VoziloPravnog()
                {
                    BrSaobracajne = "53435",
                    PravnoLice = pl,
                    Model = "Punto",
                    Proizvodjac = "Fiat",
                    Registarcija = "lk406",
                };

                s.Save(vp);

                s.Flush();
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdQueryOver_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<FizickoLice> fizLica = s.QueryOver<FizickoLice>()
                                              .List<FizickoLice>();

                string prikaz = "";
                foreach (var lice in fizLica)
                {
                    prikaz += $"{lice.Id}\t{lice.Ime}\t{lice.Prezime}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdCreateQuery_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Parking");

                IList<Parking> parkinzi = q.List<Parking>();

                string prikaz = "";
                foreach (var parking in parkinzi)
                {
                    prikaz += $"{parking.Id}\t{parking.Naziv}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdCreateQuery1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                // Svi parkinzi sa garazom
                IQuery q = s.CreateQuery("from Parking as p where p.GarazaFleg = true");

                IList<Parking> parkinzi = q.List<Parking>();

                string prikaz = "";
                foreach (var parking in parkinzi)
                {
                    prikaz += $"{parking.Id}\t{parking.Naziv}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUpitSaParametrima_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from JavnoMesto as j where j.Zauzetost = ? and j.Sprat >= ?");

                q.SetParameter(0, "Ne");
                q.SetInt32(1, 5);

                IList<JavnoMesto> javnaMesta = q.List<JavnoMesto>();

                string prikaz = "";
                foreach (var mesto in javnaMesta)
                {
                    prikaz += $"{mesto.Id}\t{mesto.PripadaParkingu.Naziv}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUpitSaParametrima1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select j.PripadaParkingu from JavnoMesto as j "+
                                         "where j.Zauzetost = :zauzetost and j.Sprat < :sprat");
                q.SetString("zauzetost", "Da");
                q.SetInt32("sprat", 5);

                IList<Parking> parkinzi = q.List<Parking>();

                string prikaz = "";
                foreach (var parking in parkinzi)
                {
                    prikaz += $"{parking.Id}\t{parking.Naziv}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdEnumerable_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Parking");

                IEnumerable<Parking> parkinzi = q.Enumerable<Parking>();

                string prikaz = "";
                foreach (var parking in parkinzi)
                {
                    prikaz += $"{parking.Id}\t{parking.Naziv}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdScalar_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select count(*) from JavnoMesto as j where j.Zauzetost = 'Ne'");

                Int64 broj = q.UniqueResult<Int64>();

                MessageBox.Show($"Broj slobodnih javnih mesta: {broj}");

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdUniqueResult_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select p from Parking p where p.Id = 7");

                Parking p = q.UniqueResult<Parking>();

                MessageBox.Show(p.Naziv);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdMultipleResult_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select m.Zona, count(m) from UlicnoMesto m "+
                                         "group by m.Zona");

                IList<object[]> result = q.List<object[]>();

                string prikaz = "";
                foreach (object[] r in result)
                {
                    prikaz += $"Zona: {r[0]}\tBroj: {r[1]}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdPaging_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Parking");
                q.SetFirstResult(2);
                q.SetMaxResults(5);

                IList<Parking> parkinzi = q.List<Parking>();

                string prikaz = "";
                foreach (var p in parkinzi)
                {
                    prikaz += $"{p.Naziv}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ICriteria c = s.CreateCriteria<Parking>();

                c.Add(Expression.Ge("Zona", 2));
                c.Add(Expression.Eq("PodNadTip", "Nad"));

                IList<Parking> parkinzi = c.List<Parking>();

                string prikaz = "";
                foreach (var p in parkinzi)
                {
                    prikaz += $"{p.Naziv}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdSQLNative_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ISQLQuery q = s.CreateSQLQuery("SELECT P.* FROM PARKING P");
                q.AddEntity(typeof(Parking));


                IList<Parking> parkinzi = q.List<Parking>();

                string prikaz = "";
                foreach (var p in parkinzi)
                {
                    prikaz += $"{p.Naziv}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdFluentAPI_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Parking> parkinzi = s.QueryOver<Parking>()
                                           .Where(x => x.Zona > 2)
                                           .List<Parking>();

                string prikaz = "";
                foreach (var p in parkinzi)
                {
                    prikaz += $"{p.Naziv}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdLINQ_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Parking> parkinzi = (from p in s.Query<Parking>()
                                           where (p.Zona >= 1 && p.PodNadTip == "Pod")
                                           select p).ToList<Parking>();

                string prikaz = "";
                foreach (var p in parkinzi)
                {
                    prikaz += $"{p.Naziv}\n";
                }
                MessageBox.Show(prikaz);


                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdLINQ1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Parking> parkinzi = from p in s.Query<Parking>()
                                                 where (p.Montazna == true || p.PodNadTip == "Nad")
                                                 orderby p.Zona
                                                 select p;

                string prikaz = "";
                foreach (var p in parkinzi)
                {
                    prikaz += $"{p.Naziv}\n";
                }
                MessageBox.Show(prikaz);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
