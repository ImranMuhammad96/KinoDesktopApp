using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace KinoAPBD.DAL
{
    public class SQLServerCdb : CennikDb
    {
        public IList<Cennik> getCen()
        {
            var result = new List<Cennik>();
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                var sqlCommand = new SqlCommand("SELECT IDM, Nr_sali, Nr_miejsca, Cena FROM Miejsce", sqlCon);
                sqlCon.Open();

                var dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    var newCennik = new Cennik
                    {
                        IDM = (int)dr["IDM"],
                        Nr_sali = (int)dr["Nr_sali"],
                        Nr_miejsca = (int)dr["Nr_miejsca"],
                        Cena= (decimal)dr["Cena"]
                    };
                    result.Add(newCennik);
                }
                dr.Dispose();
                sqlCon.Dispose();
            }
            return result;
        }
    }
}
