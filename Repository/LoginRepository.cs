using MachineTest6._1.Models;
using System.Linq;

namespace MachineTest6._1.Repository
{
    public class LoginRepository:ILogin
    {
        private readonly MachineTest61Context _dbContext;

        public LoginRepository(MachineTest61Context dbContext)
        {
            _dbContext = dbContext;
        }

        #region Find user by credentials
        public Login ValidateUser(string username, string password)
        {
            if (_dbContext != null)
            {
                Login user = _dbContext.Login.FirstOrDefault(user => user.Username == username && user.Password == password);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        #endregion
    }
}
