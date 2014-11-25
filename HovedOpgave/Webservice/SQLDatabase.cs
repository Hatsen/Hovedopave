using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace Webservice
{
    public class SQLDatabase
    {
        private string dbNavn = "";
        private string dbServer = "";
        private string dbUsername = "";
        private string dbPassword = "";
        private SqlConnection dbConn;

        /// <param name="dbNavn">The name of the database. E.g. bankDatabase or bankDatabase.mdf.</param>
        /// <param name="dbServer">The name of the server. E.g. Localhost, IP-address or LocalDB.</param>
        /// <param name="dbUsername">The username used for the login.</param>
        /// <param name="dbPassword">The password used for the login.</param>

        public SQLDatabase(string dbNavn, string dbServer, string dbUsername, string dbPassword)
        {
            this.dbNavn = dbNavn;
            this.dbServer = dbServer;
            this.dbUsername = dbUsername;
            this.dbPassword = dbPassword;
        }

        /// <summary>
        /// Opens the connection to the SQL Server
        /// </summary>
        public bool Open()
        {
            try
            {
                this.dbConn = new SqlConnection(@"Data Source=(" + dbServer + @")\v11.0;AttachDbFileName=|DataDirectory|\" + dbNavn + "; Integrated Security=SSPI; Connection Timeout=12000");
                this.dbConn.Open();

                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show("Der kunne ikke oprettes forbindelse til databasen.");

                return false;
            }
        }

        /// <summary>
        /// Sends an SQL command to the SQL Server.
        /// </summary>
        /// <param name="SQLQuery">The SQL Command you want the server to execute.</param>

        public int Exec(string SQLQuery)
        {
            SqlCommand dbCMD = new SqlCommand(SQLQuery, this.dbConn);   //Forbered en ny SQL statement

            try
            {
                int Result = dbCMD.ExecuteNonQuery();   //Eksekvere SQL sætningen og få nummeret på påvirkede rækker
                
                if (Result > 0)         //Hvis nogle rækker blev påvirket
                {
                    return Result;
                }
                else    //Hvis ingen rækker blev påvirket
                {
                    return 0;
                }
            }
            catch
            {
                return -1;      //En fejl opstod
            }
        }

        /// <summary>
        /// Performs a query on the SQL Server.
        /// </summary>
        /// <param name="SQLQuery">The Query Command.</param>
        /// <returns>Returns a jagged array e.g. yourString[column][row] of the table's data.</returns>
        public string[][] Query(string SQLQuery)
        {
            SqlCommand dbCMD = new SqlCommand(SQLQuery, this.dbConn);
            DataSet dataSet = new DataSet();

            try
            {
                SqlDataAdapter DataAdapter = new SqlDataAdapter(dbCMD);
                DataAdapter.Fill(dataSet);
            }
            catch
            {
                return new string[0][];         //retunerer tom array
            }

            DataRowCollection dbRecords = dataSet.Tables[0].Rows;
            int ColumnCount = dataSet.Tables[0].Columns.Count;

            string[][] Result = new string[dbRecords.Count][];  //Opretter hoved-array

            for (int i = 0; i < dbRecords.Count; i++)   //for hver tupel
            {
                Result[i] = new string[ColumnCount];

                for (int i2 = 0; i2 < ColumnCount; i2++)        //for hver tupel i hver kolonne
                {
                    Result[i][i2] = Convert.ToString(dbRecords[i][i2]); //konverterer hver kolonne til en string
                }
            }

            return Result;
        }

        /// <summary>
        /// Closes the SQL connection.
        /// </summary>
        public void Close()
        {
            this.dbConn.Close();
        }



        //lars er inde og lege!


        public int ExecAndGetId(string SQLQuery)
        {
            string finalSQLQuery = "DECLARE @Id INT; ";
            finalSQLQuery += SQLQuery + " SELECT @Id=SCOPE_IDENTITY(); SELECT @Id;";
            
            
            int result = 0;
            SqlCommand dbCMD = new SqlCommand(finalSQLQuery, this.dbConn);   //Forbered en ny SQL statement

            try
            {

                result = (int)dbCMD.ExecuteScalar();
            }
            catch
            {
               
            }

            return result;
        }





    }
}