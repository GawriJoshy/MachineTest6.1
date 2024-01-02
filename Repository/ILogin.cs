using MachineTest6._1.Models;

namespace MachineTest6._1.Repository
{
    public interface ILogin
    {
        public Login ValidateUser(string username, string password);
    }
}
