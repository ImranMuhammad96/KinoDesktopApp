using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace KinoAPBD.DAL
{
    public class SQLServerRdb : RepertuarDb
    {
        public IList<Repertuar> getRep()
        {
            var result = new List<Repertuar>();
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                var sqlCommand = new SqlCommand("SELECT s.IDS, f.IDF, f.Tytul, f.Rezyser, f.Dlugosc, s.Termin, s.Nr_sali FROM Seans s INNER JOIN Film f ON s.IDF = f.IDF", sqlCon);
                sqlCon.Open();

                var dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    var newRepertuar = new Repertuar
                    {
                        IDS = (int)dr["IDS"],
                        IDF = (int)dr["IDF"],
                        Tytul = dr["Tytul"].ToString(),
                        Rezyser = dr["Rezyser"].ToString(),
                        Dlugosc = (int)dr["Dlugosc"],
                        Termin = (DateTime)dr["Termin"],
                        Nr_sali = (int)dr["Nr_sali"]
                    };
                    result.Add(newRepertuar);
                }
                dr.Dispose();
                sqlCon.Dispose();
            }
            return result;
        }
    }
}
