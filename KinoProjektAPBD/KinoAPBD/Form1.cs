using KinoAPBD.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace KinoAPBD
{
    public partial class Form1 : Form
    {
        public int[] tabIDM;
        public int _IDK;
        public int _IDS;
        public int _IDF;
        public TextBox imie;
        public TextBox nazwisko;
        public decimal cena;
        public string tytul;
        private RepertuarDb _rdb;
        private CennikDb _cdb;
        public List<Button> butt = new List<Button>();
        int licz;
        public Form1()
        {
            InitializeComponent();
            ConfigureControls();
            _rdb = new SQLServerRdb();
            _cdb = new SQLServerCdb();
            LoadData();
            butt.Add(Miejsce1);
            butt.Add(Miejsce2);
            butt.Add(Miejsce3);
            butt.Add(Miejsce4);
            butt.Add(Miejsce5);
            butt.Add(Miejsce6);
            butt.Add(Miejsce7);
            butt.Add(Miejsce8);
            butt.Add(Miejsce9);
            butt.Add(Miejsce10);
            butt.Add(Miejsce11);
            butt.Add(Miejsce12);
            butt.Add(Miejsce13);
            butt.Add(Miejsce14);
            butt.Add(Miejsce15);
            butt.Add(Miejsce16);
            butt.Add(Miejsce17);
            butt.Add(Miejsce18);
            butt.Add(Miejsce19);
            butt.Add(Miejsce20);
            butt.Add(Miejsce21);
            butt.Add(Miejsce22);
            butt.Add(Miejsce23);
            butt.Add(Miejsce24);
            butt.Add(Miejsce25);
            butt.Add(Miejsce26);
            butt.Add(Miejsce27);
            butt.Add(Miejsce28);
            butt.Add(Miejsce29);
            butt.Add(Miejsce30);
            butt.Add(Miejsce31);
            butt.Add(Miejsce32);
            butt.Add(Miejsce33);
            butt.Add(Miejsce34);
            butt.Add(Miejsce35);
            butt.Add(Miejsce36);
            butt.Add(Miejsce37);
            butt.Add(Miejsce38);
            butt.Add(Miejsce39);
            butt.Add(Miejsce40);
            butt.Add(Miejsce41);
            butt.Add(Miejsce42);
            butt.Add(Miejsce43);
            butt.Add(Miejsce44);
            butt.Add(Miejsce45);
            butt.Add(Miejsce46);
            butt.Add(Miejsce47);
            butt.Add(Miejsce48);
            butt.Add(Miejsce49);
            butt.Add(Miejsce50);
            butt.Add(Miejsce51);
            butt.Add(Miejsce52);
            butt.Add(Miejsce53);
            butt.Add(Miejsce54);
            butt.Add(Miejsce55);
            butt.Add(Miejsce56);
            butt.Add(Miejsce57);
            butt.Add(Miejsce58);
            butt.Add(Miejsce59);
            butt.Add(Miejsce60);
            cena = 0;
            licz = 0;

            _IDS = 1;
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                var sqlCommand = new SqlCommand("SELECT IDF FROM Seans WHERE IDS = 1", sqlCon);
                sqlCon.Open();
                var dr = sqlCommand.ExecuteReader();
                if (dr.Read())
                {
                    _IDF = (int)dr["IDF"];
                }
                dr.Dispose();
                sqlCommand = new SqlCommand("SELECT Tytul FROM Film WHERE IDF =" + _IDF, sqlCon);
                dr = sqlCommand.ExecuteReader();
                if (dr.Read())
                {
                    tytul = dr["Tytul"].ToString();
                }
                dr.Dispose();
                sqlCon.Dispose();
            }
        }

        private void ConfigureControls()
        {
            RepertuarDataGridView.AutoGenerateColumns = false;
            CennikDataGridView.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            RepertuarDataGridView.DataSource = _rdb.getRep();
            CennikDataGridView.DataSource = _cdb.getCen();
        }

        private void ExtractPrice(int x)
        {
            decimal c;
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                var sqlCommand = new SqlCommand("SELECT Cena FROM Miejsce WHERE IDM =" + x, sqlCon);
                sqlCon.Open();
                var dr = sqlCommand.ExecuteReader();
                if (dr.Read())
                {
                    c = decimal.Parse(dr["Cena"].ToString());

                    if (butt[x - 1].BackColor == Color.Red)
                        cena = cena + c;
                    else
                        cena = cena - c;
                }
                RezerwacjaCenaTextBox.Text = cena.ToString();

                dr.Dispose();
                sqlCon.Dispose();
            }
        }

        private void GenerateIDK()
        {
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                var sqlCommand = new SqlCommand("SELECT COUNT(IDK) FROM Klient", sqlCon);
                sqlCon.Open();
                _IDK = (int)sqlCommand.ExecuteScalar();
                sqlCon.Dispose();
            }
        }

        private void FillTabIDM()
        {
            int k = 0;
            for (int i = 0; i < butt.Count; i++)
            {
                if (butt[i].BackColor == Color.Red)
                {
                    tabIDM[k] = i+1;
                    k++;
                }
            }
        }

        private void Miejsce1_Click(object sender, EventArgs e)
        {
            if (Miejsce1.BackColor != Color.Red)
            {
                Miejsce1.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce1.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(1);
        }

        private void Miejsce2_Click(object sender, EventArgs e)
        {
            if (Miejsce2.BackColor != Color.Red)
            {
                Miejsce2.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce2.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(2);
        }

        private void Miejsce3_Click(object sender, EventArgs e)
        {
            if (Miejsce3.BackColor != Color.Red)
            {
                Miejsce3.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce3.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(3);
        }

        private void Miejsce4_Click(object sender, EventArgs e)
        {
            if (Miejsce4.BackColor != Color.Red)
            {
                Miejsce4.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce4.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(4);
        }

        private void Miejsce5_Click(object sender, EventArgs e)
        {
            if (Miejsce5.BackColor != Color.Red)
            {
                Miejsce5.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce5.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(5);
        }

        private void Miejsce6_Click(object sender, EventArgs e)
        {
            if (Miejsce6.BackColor != Color.Red)
            {
                Miejsce6.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce6.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(6);
        }

        private void Miejsce7_Click(object sender, EventArgs e)
        {
            if (Miejsce7.BackColor != Color.Red)
            {
                Miejsce7.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce7.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(7);
        }

        private void Miejsce8_Click(object sender, EventArgs e)
        {
            if (Miejsce8.BackColor != Color.Red)
            {
                Miejsce8.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce8.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(8);
        }

        private void Miejsce9_Click(object sender, EventArgs e)
        {
            if (Miejsce9.BackColor != Color.Red)
            {
                Miejsce9.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce9.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(9);
        }

        private void Miejsce10_Click(object sender, EventArgs e)
        {
            if (Miejsce10.BackColor != Color.Red)
            {
                Miejsce10.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce10.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(10);
        }

        private void Miejsce11_Click(object sender, EventArgs e)
        {
            if (Miejsce11.BackColor != Color.Red)
            {
                Miejsce11.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce11.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(11);
        }

        private void Miejsce12_Click(object sender, EventArgs e)
        {
            if (Miejsce12.BackColor != Color.Red)
            {
                Miejsce12.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce12.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(12);
        }

        private void Miejsce13_Click(object sender, EventArgs e)
        {
            if (Miejsce13.BackColor != Color.Red)
            {
                Miejsce13.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce13.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(13);
        }

        private void Miejsce14_Click(object sender, EventArgs e)
        {
            if (Miejsce14.BackColor != Color.Red)
            {
                Miejsce14.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce14.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(14);
        }

        private void Miejsce15_Click(object sender, EventArgs e)
        {
            if (Miejsce15.BackColor != Color.Red)
            {
                Miejsce15.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce15.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(15);
        }

        private void Miejsce16_Click(object sender, EventArgs e)
        {
            if (Miejsce16.BackColor != Color.Red)
            {
                Miejsce16.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce16.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(16);
        }

        private void Miejsce17_Click(object sender, EventArgs e)
        {
            if (Miejsce17.BackColor != Color.Red)
            {
                Miejsce17.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce17.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(17);
        }

        private void Miejsce18_Click(object sender, EventArgs e)
        {
            if (Miejsce18.BackColor != Color.Red)
            {
                Miejsce18.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce18.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(18);
        }

        private void Miejsce19_Click(object sender, EventArgs e)
        {
            if (Miejsce19.BackColor != Color.Red)
            {
                Miejsce19.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce19.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(19);
        }

        private void Miejsce20_Click(object sender, EventArgs e)
        {
            if (Miejsce20.BackColor != Color.Red)
            {
                Miejsce20.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce20.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(20);
        }

        private void Miejsce21_Click(object sender, EventArgs e)
        {
            if (Miejsce21.BackColor != Color.Red)
            {
                Miejsce21.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce21.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(21);
        }

        private void Miejsce22_Click(object sender, EventArgs e)
        {
            if (Miejsce22.BackColor != Color.Red)
            {
                Miejsce22.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce22.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(22);
        }

        private void Miejsce23_Click(object sender, EventArgs e)
        {
            if (Miejsce23.BackColor != Color.Red)
            {
                Miejsce23.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce23.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(23);
        }

        private void Miejsce24_Click(object sender, EventArgs e)
        {
            if (Miejsce24.BackColor != Color.Red)
            {
                Miejsce24.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce24.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(24);
        }

        private void Miejsce25_Click(object sender, EventArgs e)
        {
            if (Miejsce25.BackColor != Color.Red)
            {
                Miejsce25.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce25.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(25);
        }

        private void Miejsce26_Click(object sender, EventArgs e)
        {
            if (Miejsce26.BackColor != Color.Red)
            {
                Miejsce26.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce26.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(26);
        }

        private void Miejsce27_Click(object sender, EventArgs e)
        {
            if (Miejsce27.BackColor != Color.Red)
            {
                Miejsce27.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce27.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(27);
        }

        private void Miejsce28_Click(object sender, EventArgs e)
        {
            if (Miejsce28.BackColor != Color.Red)
            {
                Miejsce28.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce28.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(28);
        }

        private void Miejsce29_Click(object sender, EventArgs e)
        {
            if (Miejsce29.BackColor != Color.Red)
            {
                Miejsce29.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce29.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(29);
        }

        private void Miejsce30_Click(object sender, EventArgs e)
        {
            if (Miejsce30.BackColor != Color.Red)
            {
                Miejsce30.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce30.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(30);
        }

        private void Miejsce31_Click(object sender, EventArgs e)
        {
            if (Miejsce31.BackColor != Color.Red)
            {
                Miejsce31.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce31.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(31);
        }

        private void Miejsce32_Click(object sender, EventArgs e)
        {
            if (Miejsce32.BackColor != Color.Red)
            {
                Miejsce32.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce32.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(32);
        }

        private void Miejsce33_Click(object sender, EventArgs e)
        {
            if (Miejsce33.BackColor != Color.Red)
            {
                Miejsce33.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce33.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(33);
        }

        private void Miejsce34_Click(object sender, EventArgs e)
        {
            if (Miejsce34.BackColor != Color.Red)
            {
                Miejsce34.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce34.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(34);
        }

        private void Miejsce35_Click(object sender, EventArgs e)
        {
            if (Miejsce35.BackColor != Color.Red)
            {
                Miejsce35.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce35.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(35);
        }

        private void Miejsce36_Click(object sender, EventArgs e)
        {
            if (Miejsce36.BackColor != Color.Red)
            {
                Miejsce36.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce36.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(36);
        }

        private void Miejsce37_Click(object sender, EventArgs e)
        {
            if (Miejsce37.BackColor != Color.Red)
            {
                Miejsce37.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce37.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(37);
        }

        private void Miejsce38_Click(object sender, EventArgs e)
        {
            if (Miejsce38.BackColor != Color.Red)
            {
                Miejsce38.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce38.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(38);
        }

        private void Miejsce39_Click(object sender, EventArgs e)
        {
            if (Miejsce39.BackColor != Color.Red)
            {
                Miejsce39.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce39.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(39);
        }

        private void Miejsce40_Click(object sender, EventArgs e)
        {
            if (Miejsce40.BackColor != Color.Red)
            {
                Miejsce40.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce40.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(40);
        }

        private void Miejsce41_Click(object sender, EventArgs e)
        {
            if (Miejsce41.BackColor != Color.Red)
            {
                Miejsce41.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce41.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(41);
        }

        private void Miejsce42_Click(object sender, EventArgs e)
        {
            if (Miejsce42.BackColor != Color.Red)
            {
                Miejsce42.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce42.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(42);
        }

        private void Miejsce43_Click(object sender, EventArgs e)
        {
            if (Miejsce43.BackColor != Color.Red)
            {
                Miejsce43.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce43.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(43);
        }

        private void Miejsce44_Click(object sender, EventArgs e)
        {
            if (Miejsce44.BackColor != Color.Red)
            {
                Miejsce44.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce44.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(44);
        }

        private void Miejsce45_Click(object sender, EventArgs e)
        {
            if (Miejsce45.BackColor != Color.Red)
            {
                Miejsce45.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce45.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(45);
        }

        private void Miejsce46_Click(object sender, EventArgs e)
        {
            if (Miejsce46.BackColor != Color.Red)
            {
                Miejsce46.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce46.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(46);
        }

        private void Miejsce47_Click(object sender, EventArgs e)
        {
            if (Miejsce47.BackColor != Color.Red)
            {
                Miejsce47.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce47.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(47);
        }

        private void Miejsce48_Click(object sender, EventArgs e)
        {
            if (Miejsce48.BackColor != Color.Red)
            {
                Miejsce48.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce48.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(48);
        }

        private void Miejsce49_Click(object sender, EventArgs e)
        {
            if (Miejsce49.BackColor != Color.Red)
            {
                Miejsce49.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce49.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(49);
        }

        private void Miejsce50_Click(object sender, EventArgs e)
        {
            if (Miejsce50.BackColor != Color.Red)
            {
                Miejsce50.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce50.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(50);
        }

        private void Miejsce51_Click(object sender, EventArgs e)
        {
            if (Miejsce51.BackColor != Color.Red)
            {
                Miejsce51.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce51.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(51);
        }

        private void Miejsce52_Click(object sender, EventArgs e)
        {
            if (Miejsce52.BackColor != Color.Red)
            {
                Miejsce52.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce52.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(52);
        }

        private void Miejsce53_Click(object sender, EventArgs e)
        {
            if (Miejsce53.BackColor != Color.Red)
            {
                Miejsce53.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce53.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(53);
        }

        private void Miejsce54_Click(object sender, EventArgs e)
        {
            if (Miejsce54.BackColor != Color.Red)
            {
                Miejsce54.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce54.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(54);
        }

        private void Miejsce55_Click(object sender, EventArgs e)
        {
            if (Miejsce55.BackColor != Color.Red)
            {
                Miejsce55.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce55.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(55);
        }

        private void Miejsce56_Click(object sender, EventArgs e)
        {
            if (Miejsce56.BackColor != Color.Red)
            {
                Miejsce56.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce56.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(56);
        }

        private void Miejsce57_Click(object sender, EventArgs e)
        {
            if (Miejsce57.BackColor != Color.Red)
            {
                Miejsce57.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce57.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(57);
        }

        private void Miejsce58_Click(object sender, EventArgs e)
        {
            if (Miejsce58.BackColor != Color.Red)
            {
                Miejsce58.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce58.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(58);
        }

        private void Miejsce59_Click(object sender, EventArgs e)
        {
            if (Miejsce59.BackColor != Color.Red)
            {
                Miejsce59.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce59.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(59);
        }

        private void Miejsce60_Click(object sender, EventArgs e)
        {
            if (Miejsce60.BackColor != Color.Red)
            {
                Miejsce60.BackColor = Color.Red;
                licz++;
            }
            else
            {
                Miejsce60.BackColor = Color.Green;
                licz--;
            }
            ExtractPrice(60);
        }

        private void RepertuarNextButton_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void RezerwacjaPreviousButton_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex = 0;
        }

        private void RezerwacjaNextButton_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }

        private void CennikPreviousButton_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void CennikNextButton_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex = 3;
        }

        private void KlientPreviousButton_Click(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }

        private void RezerwacjaBookButton_Click(object sender, EventArgs e)
        {
            GenerateIDK();
            imie = KlientImieTextBox;
            nazwisko = KlientNazwiskoTextBox;
            if (imie.Text == "" && nazwisko.Text == "")
            {
                MessageBox.Show("Prosze podac imie i nazwisko w zakladce 'Klient'.");
            }
            else if (imie.Text == "")
            {
                MessageBox.Show("Prosze podac imie w zakladce 'Klient'.");
            }
            else if (nazwisko.Text == "")
            {
                MessageBox.Show("Prosze podac nazwisko w zakladce 'Klient'.");
            }
            else
            {
                // GENEROWANIE KLUCZA KLIENTA
                _IDK++;
                using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
                {
                    var sqlCommand = new SqlCommand("INSERT INTO Klient VALUES ('" + _IDK + "','" + imie.Text + "','" + nazwisko.Text + "')", sqlCon);
                    sqlCon.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCon.Dispose();
                }
                imie.Enabled = false;
                nazwisko.Enabled = false;

                // POBIERANIE KLUCZY MIEJSC
                tabIDM = new int[licz];
                FillTabIDM();
                var x = new Form2();
                for (int i = 0; i < 60; i++)
                {
                    butt[i].Enabled = false;
                }
                RezerwacjaResetButton.Enabled = false;
                RezerwacjaBookButton.Enabled = false;

                Form2.IDK = _IDK;
                Form2.IDS = _IDS;
                Form2.imie = imie;
                Form2.nazwisko = nazwisko;
                Form2.cena = cena;
                Form2.tytul = tytul;
                Form2.tab = tabIDM;
                Form2.butt = butt;
                Form2.reset = RezerwacjaResetButton;
                Form2.book = RezerwacjaBookButton;

                x.Show();
            }
        }

        private void RezerwacjaResetButton_Click(object sender, EventArgs e)
        {
            for(int i=0; i<60; i++)
            {
                butt[i].BackColor = Color.Green;
            }
            cena = 0;
            RezerwacjaCenaTextBox.Text = cena.ToString();
            KlientImieTextBox.Text = "";
            KlientImieTextBox.Enabled = true;
            KlientNazwiskoTextBox.Text = "";
            KlientNazwiskoTextBox.Enabled = true;
            licz = 0;
        }

        private void RezerwacjaCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RepertuarDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = RepertuarDataGridView.Rows[e.RowIndex].DataBoundItem as Repertuar;
            _IDS = selectedRow.IDS;
            tytul = selectedRow.Tytul;
        }
    }
}
