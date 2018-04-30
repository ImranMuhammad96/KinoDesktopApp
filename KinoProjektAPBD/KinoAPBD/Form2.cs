using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KinoAPBD
{
    public partial class Form2 : Form
    {
        int _IDB;
        internal static int IDK;
        internal static int IDS;
        internal static TextBox imie;
        internal static TextBox nazwisko;
        internal static decimal cena;
        internal static string tytul;
        internal static int[] tab;
        internal static List<Button> butt;
        internal static Button reset;
        internal static Button book;

        public Form2()
        {
            InitializeComponent();
        }

        private void GenerateIDB()
        {
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                var sqlCommand = new SqlCommand("SELECT COUNT(ID_BILETU) FROM Bilet", sqlCon);
                sqlCon.Open();
                _IDB = (int)sqlCommand.ExecuteScalar();
                sqlCon.Dispose();
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            GenerateIDB();
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                SqlCommand sqlCommand;
                sqlCon.Open();
                for (int i = 0; i < tab.Length; i++)
                {
                    _IDB++;
                    sqlCommand = new SqlCommand("INSERT INTO Bilet VALUES ('" + _IDB + "','" + tab[i] + "','" + IDK + "','" + IDS + "')", sqlCon);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlCon.Dispose();
            }
            Environment.Exit(0);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                butt[i].Enabled = true;
            }
            reset.Enabled = true;
            book.Enabled = true;
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                var sqlCommand = new SqlCommand("DELETE FROM Klient WHERE IDK="+IDK, sqlCon);
                sqlCon.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCon.Dispose();
            }
            imie.Enabled = true;
            nazwisko.Enabled = true;
            Close();
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            InfoTextBox.Text += "Cena: " + cena.ToString() + "\r\n";
            
            InfoTextBox.Text += "Imie: " + imie.Text + "\r\n" +
                                "Nazwisko: " + nazwisko.Text + "\r\n";
            
            InfoTextBox.Text += "Tytul: " + tytul + "\r\n";
            
            InfoTextBox.Text += "Miejsca: ";
            for (int i=0; i<tab.Length; i++)
            {
                InfoTextBox.Text += tab[i].ToString() + " ";
            }
            InfoTextBox.Text += "\r\n";
            
        }
    }
}
