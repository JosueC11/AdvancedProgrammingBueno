using AdvancedProgramming.Data;
using System.Data.Entity;

namespace AdvancedProgramming.Repository
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
    }

    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser() : base()
        {
        }

        // Implement any specific methods for Product if needed
        public bool LoginUser(User user)
        {
            var result = GetById(user.UserID);
            return true;
        }
    }

}
