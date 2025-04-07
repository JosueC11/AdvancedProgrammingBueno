using AdvancedProgramming.Data;
using System.Data.Entity;

namespace AdvancedProgramming.Repository
{
    public interface IRepositoryUserRole : IRepositoryBase<UserRole>
    {
    }

    public class RepositoryUserRole : RepositoryBase<UserRole>, IRepositoryUserRole
    {
        public RepositoryUserRole() : base()
        {
        }

        // Implement any specific methods for Product if needed
    }

}
