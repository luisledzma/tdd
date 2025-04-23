using tdd.task.manager.Models;
namespace tdd.task.manager.Services;
public interface ITaskService
{
    Task<TaskItemModel> CreateTaskAsync(TaskItemModel task);
}