using AdvancedProgramming.Data;
using System.Data.Entity;

namespace AdvancedProgramming.Repository
{
    public interface IRepositorySupplier : IRepositoryBase<Supplier>
    {
    }

    public class RepositorySupplier : RepositoryBase<Supplier>, IRepositorySupplier
    {
        public RepositorySupplier() : base()
        {
        }

        // Implement any specific methods for Product if needed
    }

}
