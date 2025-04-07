using AdvancedProgramming.Data;
using AdvancedProgramming.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedProgramming.Service
{
    public class NotificationService
    {
        private readonly RepositoryTask _repositoryTask;
        public NotificationService()
        {
            _repositoryTask = new RepositoryTask();
        }

        public IEnumerable<Task> GetAllNotificationTasks()
        {
            var tasks = _repositoryTask.GetAll();
            var filtered = tasks.Where(x => x.Name.ToLower() == "notify");
            return filtered;
        }

        public IEnumerable<Task> MoveToNextStep(int id)
        {
            var task = GetAllNotificationTasks()
                .SingleOrDefault(x => x.Id == id);

            switch (task.Status)
            {
                case "Pending":
                    task.Status = "In Progres";
                    break;
                case "In Progres":
                    task.Status = "Completed";
                    break;
                default:
                    break;
            }

            _repositoryTask.Update(task);
            return GetAllNotificationTasks().Where(x => x.Name.ToLower() == "notify");
        }
    }
}
