using Minesweeper.Models;

namespace Minesweeper.Services
{
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
