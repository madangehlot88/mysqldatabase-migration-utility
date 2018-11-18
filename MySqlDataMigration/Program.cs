using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MySqlDataMigration
{

    /// <summary>
    /// Program to truncate and copy data from source to destination. Make sure connection strings are using root user
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            //Init source database connection
            ClassConSource conSource = new ClassConSource();

            //Init destination database connection
            ClassConDestination conDestination = new ClassConDestination();

            //fetch all tables from source database
            DataTable dtSource = conSource.SelectDT("SHOW TABLES");


            //loop through all table (source database)
            foreach(DataRow dataRow in dtSource.Rows)
            {


                //first truncate destination table
                string truncateDestination = "truncate table " + dataRow[0] + "";
                conDestination.ExecuteQuery(truncateDestination);

                //fetch source table columns table

                var columns = conSource.SelectScalerObj("SELECT GROUP_CONCAT(concat('`',column_name,'`')) FROM information_schema.columns WHERE table_schema = 'tefsalapp1' AND table_name = '" + dataRow[0] + "' GROUP BY table_schema,table_name");

                //insert into destination table (which are availble in source only, for correct mapping). bulk copy rows from source table to destination table.
                // make sure both databases have root access (given in connection string)
                string insertDestination = "insert into " + dataRow[0] + "("+ columns + ") select * from tefsalapp1." + dataRow[0] + "";
                conDestination.ExecuteQuery(insertDestination);


            }




        }
    }
}
