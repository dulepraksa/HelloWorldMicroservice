using HelloWorldMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using HelloWorldMicroservice.DTO;

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
                        p.Editing = reader.GetBoolean(reader.GetOrdinal("editing"));

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
                        phrase.Editing = reader.GetBoolean(reader.GetOrdinal("editing"));
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
        public static bool Delete(int id)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connnectionString))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "DELETE FROM HelloWorldSchema.phrases WHERE id = @Id";

                    //konverzija tipova iz inta u string
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = id;
                    cmd.Connection = sqlCon;

                    sqlCon.Open();

                    var rows = Convert.ToInt32(cmd.ExecuteNonQuery());

                    sqlCon.Close();

                    if (rows >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static Phrase Store(Phrase p)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connnectionString))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "INSERT INTO HelloWorldSchema.phrases (body) VALUES(@Body);SELECT SCOPE_IDENTITY()";
                    cmd.Parameters.Add("@Body", SqlDbType.VarChar);
                    cmd.Parameters["@Body"].Value = p.Body;
                    cmd.Connection = sqlCon;

                    sqlCon.Open();
                        var row = Convert.ToInt32(cmd.ExecuteScalar());
                    sqlCon.Close();
                    if(row > 0)
                    {
                        Phrase retP = new Phrase();
                        retP.Id = row;
                        retP.Body = p.Body;

                        return retP;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static Phrase Put(Phrase p)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connnectionString))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "UPDATE HelloWorldSchema.phrases SET body = @Body editing = @Editing WHERE id=@Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = p.Id;
                    cmd.Parameters.Add("@Body", SqlDbType.VarChar);
                    cmd.Parameters["@Body"].Value = p.Body;
                    cmd.Parameters["@Editing"].Value = p.Editing;
                    cmd.Connection = sqlCon;

                    sqlCon.Open();
                    var rows = Convert.ToInt32(cmd.ExecuteNonQuery());
                    sqlCon.Close();
                    if (rows > 0)
                    {
                        Phrase retP = new Phrase();
                        retP.Id = p.Id;
                        retP.Body = p.Body;
                        retP.Editing = p.Editing;

                        return retP;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}