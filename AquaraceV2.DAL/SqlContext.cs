using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AquaraceV2.DAL
{
    public class SqlContext
    {
        protected string connectionString = @"Data Source=mssql.fhict.local;Initial Catalog=dbi395898;Persist Security Info=True;User ID=dbi395898;Password=aquadis";

        public bool ExecuteInsertProcedure(string procedure_name, List<SqlParameter> parameters)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(procedure_name, conn) { CommandType = CommandType.StoredProcedure })
                {
                    try
                    {
                        conn.Open();

                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        command.ExecuteNonQuery();
                       

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public List<object> ExecuteSelectProcedure(string procedure_name, List<SqlParameter> parameters, int object_amount, string[] return_columns)
        {
            List<object> returnobject = new List<object>();
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(procedure_name, conn) { CommandType = CommandType.StoredProcedure })
                {
                    try
                    {
                        conn.Open();
                        if (parameters != null)
                        {
                            foreach (SqlParameter parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        SqlDataReader reader = command.ExecuteReader();
                    
                        while (reader.Read())
                        {
                            for (int x = 0; x < object_amount; x++)
                            {
                                returnobject.Add(reader[return_columns[x]]);
                            }                                                                              
                        }                        

                        conn.Close();
                    }
                    catch (Exception e) { Console.Write(e); }
                }
            }
            return returnobject;
        }
    }
}
