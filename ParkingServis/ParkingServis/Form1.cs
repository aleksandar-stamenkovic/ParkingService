using System;
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
    }
}
