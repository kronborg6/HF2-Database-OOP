using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CLVape
{
    public class Kunder : EntityBase
    {
        public int kundeID { get; private set; }
        public string fornavn { get; set; }
        public string efternavn { get; set; }
        public string email { get; set; }
        public int mobil { get; set; }
        public int aktiv { get; set; }
        public DateTime opretDate { get; set; }
        public Kunder()
        {

        }
        public List<Kunder> getKunder() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM Kunder";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;
            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);

            List<Kunder> kunders = new List<Kunder>();

            try
            {
                using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        kunders.Add(new Kunder
                        {
                            kundeID = Convert.ToInt32(sdr["KundeID"]),
                            fornavn = sdr["Fornavn"].ToString(),
                            efternavn = sdr["Efternavn"].ToString(),
                            mobil = Convert.ToInt32(sdr["Mobil"]),
                            email = sdr["Email"].ToString(),
                            aktiv = Convert.ToInt32(sdr["Aktiv"]),
                        });
                        //Console.WriteLine("New Customer Add From DB");
                    }
                }
                SqlConn.cmd.Parameters.Clear();
                SqlConn.cmd.Parameters.Clear();
                SqlConn.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }
            return kunders;
        }

        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(fornavn)) isValid = false;
            if (string.IsNullOrWhiteSpace(efternavn)) isValid = false;

            return isValid;
        }
        public bool Save(Kunder kunder)
        {
            var success = true;

            if (kunder.HasChanges)
            {
                if (kunder.IsValid)
                {
                    if (kunder.IsNew)
                    {
                        Console.WriteLine("Test1");
                    }
                    else
                    {
                        Console.WriteLine("Test2");
                    }
                }
                else
                {
                    Console.WriteLine("Test3");
                    success = false;
                }
            }
            Console.WriteLine("Test4");
            return success;
        }
        public override string ToString()
        {
            return "ID: " + kundeID + " Fornavn: " + fornavn + " Efternavn: " + efternavn + " Mobil: " + mobil + " Email: " + email;
        }
    }
}
