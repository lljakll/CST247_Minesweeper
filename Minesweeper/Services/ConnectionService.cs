using System;
using System.Data.SqlClient;

namespace Minesweeper.Services
{
    /// <summary>
    /// ConnectionService Class
    /// </summary>
    /// 
    /// <remarks>
    /// Descr.:     The ConnectionService Class provides quick access to the database by creating a service
    ///             upon object initialization.
    /// 
    /// Author:     Jay Wilson
    /// Date:       02/20/19
    /// Version:    1.0.0
    /// </remarks>
    public class ConnectionService
    {
        // Class Properties
        public SqlConnection Connection { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ConnectionService()
        {
            // Connection String to database
            // Note: In most cases, this would not be hardcoded here, but this should
            //       be fine for this project. We can move it later if necessary.
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mrjay\Source\Repos\mrjaywilson\CST247_Minesweeper\Minesweeper\App_Data\minesweeper.mdf;Integrated Security=True";

            try
            {
                // Setup the connection.
                Connection = new SqlConnection(connectionString);
            } catch (SqlException e)
            {
                // Exception Handling
            }
        }
    }
}