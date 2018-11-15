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

        public void ExecuteInsertProcedure(string procedure_name, List<SqlParameter> parameters)
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
                    catch (SqlException) { }
                }
            }
        }

        public ArrayList ExecuteSelectProcedure(string procedure_name, List<SqlParameter> parameters, int object_amount, string[] return_columns)
        {
            ArrayList returnobject = new ArrayList();
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

                        SqlDataReader reader = command.ExecuteReader();


                        int i = 0;
                        while (reader.Read())
                        {
                            returnobject.Add(reader[return_columns[i]]);
                            i++;
                        }
                        

                        conn.Close();
                    }
                    catch (SqlException) { }
                }
            }
            return returnobject;
        }
    }
}
