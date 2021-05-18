using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Exceptions;

namespace WebAppCB.DataAccess.Connections
{
    public class MySQLConnection : IConnection
    {
        string servidor { get { return "localhost"; } }
        string puerto { get { return "3306"; } } //SHOW GLOBAL VARIABLES LIKE 'PORT';
        string usuario { get { return "root"; } }
        string password { get { return ""; } }
        string database { get { return "cb"; } }
        string ConnectionString { get { return string.Format("server={0};port={1};user id={2};password={3};database={4}", servidor, puerto, usuario, password, database); } }

        public IList<string[]> ExecuteQuery(string query)
        {
            IList<string[]> list = new List<string[]>();

            MySqlConnection conn = new MySqlConnection(ConnectionString);

            try
            {
                conn.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                
                int visFC = reader.VisibleFieldCount;


                while (reader.Read())
                {
                    string[] row = new string[visFC];
                    for (int i = 0; i < visFC; i++)
                    {
                        string val = string.Empty;

                        try
                        {
                            if (!reader.IsDBNull(i))
                                val = reader.GetValue(i).ToString();
                        }
                        catch (Exception e)
                        {
                            val = "DATA ERROR";
                        }

                        row[i] = val;
                    }

                    list.Add(row);
                }

                reader.Dispose();
                cmd.Dispose();

                conn.Close();
            }
            catch(Exception ex)
            {
                string[] row = new string[1];
                row[0] = ex.Message;

                list.Add(row);

                throw new DatabaseException(ex.Message);
            }

            return list;
        }


        public int ExecuteNonQuery(string nonQuery)
        {
            int result = 0;

            MySqlConnection conn = new MySqlConnection(ConnectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(nonQuery, conn);
                result = cmd.ExecuteNonQuery();

                cmd.Dispose();

                conn.Close();
            }
            catch (Exception ex)
            {

                string[] row = new string[1];
                row[0] = ex.Message;

                result = ex.HResult;

                throw new DatabaseException(ex.Message);
            }

            return result;
        }

        public string CleanValue(string val)
        {
            if (string.IsNullOrEmpty(val))
                return val;

            string valClean = val.Replace("\"", "&amp;");
            valClean = valClean.Replace("'", "&#39;");

            return valClean;
        }
    }
}
