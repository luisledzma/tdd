using tdd.task.manager.Models;
namespace tdd.task.manager.Services;
public interface ITaskService
{
    Task<TaskItemModel> CreateTaskAsync(TaskItemModel task);
    Task<TaskItemModel> UpdateTaskAsync(TaskItemModel task);
    Task<TaskItemModel> DeleteTaskAsync(TaskItemModel task);
    Task<TaskItemModel?> GetTaskByIdAsync(int id);
    Task<List<TaskItemModel>> GetAllTasksAsync();
}