using AdvancedProgramming.Data;

namespace AdvancedProgramming.Repository
{
    public interface IRepositoryTask : IRepositoryBase<Task>
    {

    }

    public class RepositoryTask : RepositoryBase<Task>, IRepositoryTask
    {
        public RepositoryTask() : base()
        {
        }
    }
}
