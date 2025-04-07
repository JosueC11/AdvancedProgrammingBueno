using AdvancedProgramming.Data;
using System.Data.Entity;

namespace AdvancedProgramming.Repository
{
    public interface IRepositoryRole : IRepositoryBase<Role>
    {
    }

    public class RepositoryRole : RepositoryBase<Role>, IRepositoryRole
    {
        public RepositoryRole() : base()
        {
        }

        // Implement any specific methods for Product if needed
    }

}
