﻿using System.Data;
using Minesweeper.Models;
using System.Data.SqlClient;

/// <summary>
/// DatabaseService Class
/// </summary>
/// 
/// <remarks>
/// Descr.:     The DatabaseService Class provides CRUD for registration,
///             login, and future administration.
/// 
/// Author:     Jay Wilson
/// Date:       02/21/19
/// Version:    1.0.0
/// </remarks>
namespace Minesweeper.Services
{
    /// <summary>
    /// Inherit from IDatabase interface.
    /// </summary>
    public class DatabaseService : IDatabase
    {
        /// <summary>
        /// Add a new user to the database.
        /// </summary>
        public bool AddNewUser(UserModel user)
        {
            // Set the connection
            using (ConnectionService service = new ConnectionService())
            {
                try
                {
                    // Open the connection
                    service.Connection.Open();

                    // Set the command text
                    SqlCommand command = new SqlCommand(null, service.Connection)
                    {
                        CommandText =
                        "INSERT INTO users (username, password, firstname, lastname, gender, age, state, email)" +
                        "VALUES (@username, @password, @firstname, @lastname, @gender, @age, @state, @email)"
                    };

                    // Set the parameters
                    command.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = user.Username;
                    command.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = user.Password;
                    command.Parameters.Add("@firstname", SqlDbType.VarChar, 50).Value = user.FirstName;
                    command.Parameters.Add("@lastname", SqlDbType.VarChar, 50).Value = user.LastName;
                    command.Parameters.Add("@gender", SqlDbType.VarChar, 10).Value = user.Gender;
                    command.Parameters.Add("@age", SqlDbType.Int, 0).Value = user.Age;
                    command.Parameters.Add("@state", SqlDbType.VarChar, 20).Value = user.State;
                    command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = user.Email;

                    // Prepate the statement.
                    command.Prepare();

                    // Execute the statement.
                    command.ExecuteNonQuery();
                }
                catch
                {
                    // Return false if any issues.
                    return false;
                }
            }

            // On success, return true.
            return true;
        }

        /// <summary>
        /// Retrieve user from the database.
        /// </summary>
        public UserModel RetrieveUser(string username)
        {
            // Set up and empty user.
            UserModel user = null;

            // Setup service.
            using (ConnectionService service = new ConnectionService())
            {
                try
                {
                    // Open connection to database
                    service.Connection.Open();

                    // SQL statement
                    SqlCommand command = new SqlCommand(null, service.Connection)
                    {
                        CommandText =
                        "SELECT * FROM users WHERE username = @username"
                    };

                    // Setup parameter
                    command.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = username;

                    // Prepare the statement
                    command.Prepare();

                    // Exececute query using reader
                    SqlDataReader reader = command.ExecuteReader();

                    // Iterate through valuse stored in reader
                    while (reader.Read())
                    {
                        // Store value in user object
                        user = new UserModel(
                            reader["firstname"].ToString(),
                            reader["lastname"].ToString(),
                            reader["gender"].ToString(),
                            (int)reader["age"],
                            reader["state"].ToString(),
                            reader["email"].ToString(),
                            reader["username"].ToString(),
                            reader["password"].ToString()
                            );
                    }
                }
                catch
                {
                    // If issues, return null
                    return null;
                }
            }

            // On success, return user object.
            return user;
        }

        /// <summary>
        /// Update user information.
        /// </summary>
        public bool UpdateUser(UserModel user)
        {
            // setup service
            using (ConnectionService service = new ConnectionService())
            {
                try
                {
                    // Open connection to database
                    service.Connection.Open();

                    // Create statement
                    SqlCommand command = new SqlCommand(null, service.Connection)
                    {
                        CommandText =
                        "UPDATE users " +
                        "SET password = @password, " +
                        "firstname = @firstname, " +
                        "lastname = @lastname, " +
                        "gender = @gender, " +
                        "age = @age, " +
                        "state = @state, " +
                        "email = @email " +
                        "WHERE username = @username;"
                    };

                    // Setup parameters
                    command.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = user.Username;
                    command.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = user.Password;
                    command.Parameters.Add("@firstname", SqlDbType.VarChar, 50).Value = user.FirstName;
                    command.Parameters.Add("@lastname", SqlDbType.VarChar, 50).Value = user.LastName;
                    command.Parameters.Add("@gender", SqlDbType.VarChar, 10).Value = user.Gender;
                    command.Parameters.Add("@age", SqlDbType.Int, 0).Value = user.Age;
                    command.Parameters.Add("@state", SqlDbType.VarChar, 20).Value = user.State;
                    command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = user.Email;

                    // Prepare the statement
                    command.Prepare();

                    // Execute statement.
                    command.ExecuteNonQuery();
                }
                catch
                {
                    // If any issues, return false
                    return false;
                }
            }

            // On success, return true
            return true;
        }

        /// <summary>
        /// Delete user from database.
        /// </summary>
        public bool DeleteUser(string username)
        {
            // Setup service
            using (ConnectionService service = new ConnectionService())
            {
                try
                {
                    // Open connection to database
                    service.Connection.Open();

                    // Create statement
                    SqlCommand command = new SqlCommand(null, service.Connection)
                    {
                        CommandText =
                        "DELETE FROM users WHERE username = @username;"
                    };

                    // Setup parameter
                    command.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = username;

                    // Prepare the statement.
                    command.Prepare();

                    // Execute statement.
                    command.ExecuteNonQuery();
                }
                catch
                {
                    // if any issues, return false.
                    return false;
                }
            }

            // On success, return true.
            return true;
        }
    }
}