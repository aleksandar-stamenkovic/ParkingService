﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using ParkingServis.Entiteti;

namespace ParkingServis
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void cmdUcitavanjeVozila_Click(object sender, EventArgs e)
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
    }
}
