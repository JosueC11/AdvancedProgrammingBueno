using AdvancedProgramming.Architecture.Extensions;
using AdvancedProgramming.ViewModels;
using System.Threading.Tasks;
using System.Web.Hosting;
using APD = AdvancedProgramming.Data;

namespace AdvancedProgramming.Helpers
{
	public class TaskConverter
    {
        public static APD.Task ToTask(TaskViewModel viewModel)
        {
            return new APD.Task
			{
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Status = viewModel.Status,
                CreatedAt = viewModel.CreatedAt.ToDateTime(),
                DueDate = viewModel.DueDate.ToDateTime(),
            };
        }

        public static TaskViewModel ToTaskViewModel(APD.Task task)
        {
            return new TaskViewModel
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = task.CreatedAt.ToDateTimeString(),
                DueDate = task.DueDate.ToDateTimeString()
            };
        }
    }
}