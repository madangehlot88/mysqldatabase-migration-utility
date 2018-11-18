using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Source Database Connection Class
/// </summary>
public class ClassConSource
{

    public static string ConString = "";

    MySqlConnection conn = new MySqlConnection(ConString);
    public int ExecuteQuery(string query)
    {
        try
        {
            

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            else
            {
                conn.Close();
                conn.Open();
            }


            MySqlCommand cmd = new MySqlCommand(query, conn);
            int status = cmd.ExecuteNonQuery();
            conn.Close();

            return status;
        }
        catch (Exception exc)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            return -1;

        }


    }

    public int SelectScaler(string query)
    {
        try
        {
            conn = new MySqlConnection(ConString);

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            else
            {
                conn.Close();
                conn.Open();
            }


            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            conn.Close();
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                return -1;
            }

        }
        catch (Exception exc)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }


            return -1;
        }


    }

    public object SelectScalerObj(string query)
    {
        try
        {
            conn = new MySqlConnection(ConString);

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            else
            {
                conn.Close();
                conn.Open();
            }


            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            conn.Close();
            if (result != null)
            {
                return result;
            }
            else
            {
                return -1;
            }

        }
        catch (Exception exc)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }


            return -1;
        }


    }


    public object SelectScalerBool(string query)
    {
        try
        {
            conn = new MySqlConnection(ConString);

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            else
            {
                conn.Close();
                conn.Open();
            }


            MySqlCommand cmd = new MySqlCommand(query, conn);
            object result = cmd.ExecuteScalar();
            conn.Close();
            if (result != null)
            {
                return result;
            }
            else
            {
                return false;
            }

        }
        catch (Exception exc)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }


            return false;
        }


    }


    public DataSet SelectDS(string query)
    {
        DataSet ds = new DataSet();
        try
        {

            conn = new MySqlConnection(ConString);

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            else
            {
                conn.Close();
                conn.Open();
            }


            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(ds);
            conn.Close();
            return ds;

        }
        catch (Exception exc)
        {
            conn.Close();
        }

        return ds;
    }


    public DataTable SelectDT(string query)
    {
        DataTable dt = new DataTable();
        try
        {

            conn = new MySqlConnection(ConString);

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            else
            {
                conn.Close();
                conn.Open();
            }


            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            conn.Close();
            return dt;

        }
        catch (Exception exc)
        {
            conn.Close();
        }

        return dt;
    }


  



}


