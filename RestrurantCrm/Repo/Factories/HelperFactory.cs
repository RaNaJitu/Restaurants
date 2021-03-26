using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Factories
{
    public class HelperFactory
    {
        string dbcs = ConfigurationManager.ConnectionStrings["RestrurantCrmConStr"].ConnectionString;
        public bool LogtoSQL(Exception ex, string source = "", string TxnID = "")
        {
            bool status = false;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(string.Concat("******************** Error Log - ", DateTime.Now, "*********************"));
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append(string.Concat("Exception Type : ", ex.GetType().Name));
                sb.Append(Environment.NewLine);
                sb.Append(string.Concat("Error Message : ", ex.Message));
                sb.Append(Environment.NewLine);
                sb.Append(string.Concat("Error Source : ", ex.Source));
                sb.Append(Environment.NewLine);
                if (ex.StackTrace != null)
                {
                    sb.Append(string.Concat("Error Trace : ", ex.StackTrace));
                }
                for (Exception innerEx = ex.InnerException; innerEx != null; innerEx = innerEx.InnerException)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append(string.Concat("Exception Type : ", innerEx.GetType().Name));
                    sb.Append(Environment.NewLine);
                    sb.Append(string.Concat("Error Message : ", innerEx.Message));
                    sb.Append(Environment.NewLine);
                    sb.Append(string.Concat("Error Source : ", innerEx.Source));
                    sb.Append(Environment.NewLine);
                    if (ex.StackTrace != null)
                    {
                        sb.Append(string.Concat("Error Trace : ", innerEx.StackTrace));
                    }
                }
                using (SqlConnection con = new SqlConnection(dbcs))
                {
                    using (SqlCommand cmd = new SqlCommand("spXpayLogging", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure; cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@TxnID", TxnID);
                        cmd.Parameters.AddWithValue("@Message", sb.ToString());
                        cmd.Parameters.AddWithValue("@Method", source);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                }
            }
            catch (StackOverflowException)
            {
                status = false;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool LogtoSQL2(Exception ex, string source, string data, string TxnID = "")
        {
            bool status = false;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(string.Concat("******************** Error Log - ", DateTime.Now, "*********************"));
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append(string.Concat("Exception Type : ", ex.GetType().Name));
                sb.Append(Environment.NewLine);
                sb.Append(string.Concat("Error Message : ", ex.Message));
                sb.Append(Environment.NewLine);
                sb.Append(string.Concat("Error Source : ", ex.Source));
                sb.Append(Environment.NewLine);
                if (ex.StackTrace != null)
                {
                    sb.Append(string.Concat("Error Trace : ", ex.StackTrace));
                }
                for (Exception innerEx = ex.InnerException; innerEx != null; innerEx = innerEx.InnerException)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append(string.Concat("Exception Type : ", innerEx.GetType().Name));
                    sb.Append(Environment.NewLine);
                    sb.Append(string.Concat("Error Message : ", innerEx.Message));
                    sb.Append(Environment.NewLine);
                    sb.Append(string.Concat("Error Source : ", innerEx.Source));
                    sb.Append(Environment.NewLine);
                    if (ex.StackTrace != null)
                    {
                        sb.Append(string.Concat("Error Trace : ", innerEx.StackTrace));
                    }
                }
                using (SqlConnection con = new SqlConnection(dbcs))
                {
                    using (SqlCommand cmd = new SqlCommand("spLoggingException2x", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure; cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@TxnID", TxnID);
                        cmd.Parameters.AddWithValue("@exceptions", sb.ToString());
                        cmd.Parameters.AddWithValue("@data", data);
                        cmd.Parameters.AddWithValue("@source", source);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            status = true;
                        }
                        else
                        {

                            status = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return status;
        }
        public bool LogtoSQL(string LogMessage = "", string source = "", string TxnID = "")
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(dbcs))
                {
                    using (SqlCommand cmd = new SqlCommand("spXpayLogging", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure; cmd.CommandTimeout = 600;
                        cmd.Parameters.AddWithValue("@TxnID", TxnID);
                        cmd.Parameters.AddWithValue("@Message", LogMessage);
                        cmd.Parameters.AddWithValue("@Method", source);
                        status = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {

            }
            return status;
        }
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
