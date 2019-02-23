using Minesweeper.Models;

namespace Minesweeper.Services
{
    /// <summary>
    /// IDatabase Interface
    /// </summary>
    /// 
    /// <remarks>
    /// Descr.:     This interface sets the contracts for the Database Service.
    /// 
    /// Authors:    Jay Wilson
    ///             Chase Hausman
    ///             Jacki Adair
    ///             Nathan Ford
    ///             Richard Boyd
    ///             
    /// Date:       02/21/19
    /// Version:    1.0.0
    /// </remarks>
    interface IDatabase
    {
        // Create Methods
        bool AddNewUser(UserModel user);

        // Read methods
        UserModel RetrieveUser(string username);

        // Update Methods
        bool UpdateUser(UserModel user);

        // Delete Methods
        bool DeleteUser(string username);
    }
}
