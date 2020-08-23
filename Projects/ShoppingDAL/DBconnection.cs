using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ShoppingDAL
{
    public class DBconnection
    {
        public static string ConnectionString;
        public DBconnection(string ConnString)
        {
            ConnectionString = ConnString;
        }

        public static DataTable FillDataTable(string StoredProcedure,SqlParameter[] sqlParameters)
        {
            DataTable dataTable = new DataTable();
            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            try
            {
                sqlconn.Open();
                SqlCommand command = new SqlCommand(StoredProcedure, sqlconn);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 15;
                command.Parameters.AddRange(sqlParameters);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconn.Close();
            }
            return dataTable;
        } 

        public static bool ExecuteNonQuery(string StoredProcedure, SqlParameter[] sqlParameters)
        {
            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            try
            {
                sqlconn.Open();
                SqlCommand command = new SqlCommand(StoredProcedure, sqlconn);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 15;
                command.Parameters.AddRange(sqlParameters);
                int rowAffected = command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconn.Close();
            }
        }
    }
}
