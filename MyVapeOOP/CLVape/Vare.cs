using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CLVape.Repository;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Controls;

namespace CLVape
{
    public class Vare : EntityBase
    {
        public int vareID { get; private set; }
        public string navn { get; set; }
        public double prise { get; set; }
        public int antal { get; set; }
        public int firmaID { get; set; }

        public Vare() : this(0)
        {
        }
        public Vare(int varID)
        {
            this.vareID = varID;
        }


        public List<Vare> getVare() // here vil vi tag alle customer fra databasen og load dem ind i det her program
        {
            try
            {
                List<Vare> vares = new List<Vare>();

                VareRepository vareRepository = new VareRepository();

                vares = vareRepository.GetVareFraDB();

                return vares;
            }
            catch (Exception)
            {

                throw;
            }
        }








        public DataView GuiGetVare()
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM dbo.VVareMedFirmaInfo";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;

            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
            SqlConn.dt = new DataTable();
            SqlConn.da.Fill(SqlConn.dt);

            

            return SqlConn.dt.DefaultView;

        }


        public DataView GuiGetVareFromID(int VareID)
        {
            SqlConn.openConnection();
            SqlConn.sql = "SELECT * FROM Vare WHERE VareID = '" + VareID + "'";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;

            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
            SqlConn.dt = new DataTable();
            SqlConn.da.Fill(SqlConn.dt);



            return SqlConn.dt.DefaultView;

        }

        public static List<ComboBoxChange> GuiGetVareID()
        {
            List<ComboBoxChange> icb = new List<ComboBoxChange>();


            SqlConn.openConnection();

            SqlConn.sql = "SELECT VareID, Navn FROM Vare";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;

            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
            SqlConn.dt = new DataTable();
            SqlConn.da.Fill(SqlConn.dt);


            using (SqlDataReader sdr = SqlConn.cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    icb.Add(new ComboBoxChange(sdr["VareID"].ToString() + " - " + sdr["Navn"].ToString(), Convert.ToInt32(sdr["VareID"])));
                }

                return icb;

            }
        }

        public static void InestVare(string VareNavn = null, float price = 0, int antal = 0, int firmaID = 0)
        {
            SqlConn.openConnection();

            SqlConn.sql = "INSERT INTO Vare (Navn, Prise, Antal, FirmaID) VALUES (@Navn, @VarePrice, @itemAntal, @itemFirmaID)";
            SqlConn.cmd.CommandType = CommandType.Text;
            SqlConn.cmd.CommandText = SqlConn.sql;


            SqlConn.cmd.Parameters.Add("@Navn", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(VareNavn) ? (object)DBNull.Value : VareNavn;
            SqlConn.cmd.Parameters.Add("@VarePrice", SqlDbType.Float).Value = Equals(price, 0) ? (object)DBNull.Value : price;
            SqlConn.cmd.Parameters.Add("@itemAntal", SqlDbType.Int).Value = Equals(antal, 0) ? (object)DBNull.Value : antal;
            SqlConn.cmd.Parameters.Add("@itemFirmaID", SqlDbType.Int).Value = Equals(firmaID, 0) ? (object)DBNull.Value : firmaID;

            SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
            SqlConn.dt = new DataTable();
            SqlConn.da.Fill(SqlConn.dt);
            SqlConn.cmd.Parameters.Clear();
            //Console.WriteLine("Jeg er Sej!!");

            SqlConn.closeConnection();
        }
        public static void ChangeVarePriseAntalGui(float VarePrise, int VareAntal, int VareID)
        {
            try
            {
                SqlConn.openConnection();

                SqlConn.sql = "UPDATE Vare SET Prise = @Prise, Antal = @Antal WHERE VareID = '" + VareID + "'";
                SqlConn.cmd.CommandType = CommandType.Text;
                SqlConn.cmd.CommandText = SqlConn.sql;

                SqlConn.cmd.Parameters.AddWithValue("@Prise", VarePrise);
                SqlConn.cmd.Parameters.AddWithValue("@Antal", VareAntal);
                SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
                SqlConn.dt = new DataTable();
                SqlConn.da.Fill(SqlConn.dt);

                SqlConn.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void ChangeVareGui(string VareNavn, float VarePrise, int VareAntal, int VareID)
        {
            try
            {
                SqlConn.openConnection();

                SqlConn.sql = "UPDATE Vare SET Navn = @Navn, Prise = @Prise, Antal = @Antal WHERE VareID = '" + VareID + "'";
                SqlConn.cmd.CommandType = CommandType.Text;
                SqlConn.cmd.CommandText = SqlConn.sql;

                SqlConn.cmd.Parameters.AddWithValue("@Navn", VareNavn);
                SqlConn.cmd.Parameters.AddWithValue("@Prise", VarePrise);
                SqlConn.cmd.Parameters.AddWithValue("@Antal", VareAntal);
                SqlConn.da = new SqlDataAdapter(SqlConn.cmd);
                SqlConn.dt = new DataTable();
                SqlConn.da.Fill(SqlConn.dt);

                SqlConn.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override string ToString()
        {
            return "ID: " + vareID + " Navn: " + navn + " Prise: " + prise + " Antal: " + antal + "\n";
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
