using HelloWorldMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace HelloWorldMicroservice.Store
{
    public static class Phrases
    {
        static string connnectionString = ConfigurationManager.ConnectionStrings["HWConnection"].ConnectionString;

        public static List<Phrase> Get()
        {
            List<Phrase> phrases = new List<Phrase>();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connnectionString))
                {
                    SqlDataReader reader = null;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SELECT * FROM HelloWorldSchema.phrases";
                    cmd.Connection = sqlCon;

                    sqlCon.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Phrase p = new Phrase();

                        p.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        p.Body = reader.GetString(reader.GetOrdinal("body"));

                        phrases.Add(p);
                    }

                    sqlCon.Close();

                    return phrases;
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static Phrase Get(int id)
        {
            Phrase phrase = new Phrase();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connnectionString))
                {
                    SqlDataReader reader = null;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SELECT * FROM HelloWorldSchema.phrases WHERE id = @Id";

                    //konverzija tipova iz inta u string
                    cmd.Parameters.Add("@Id",SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = id;
                    cmd.Connection = sqlCon;

                    sqlCon.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        phrase.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        phrase.Body = reader.GetString(reader.GetOrdinal("body"));
                    }

                    sqlCon.Close();

                    return phrase;
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}