using tdd.task.manager.Models;

namespace tdd.task.manager.Repository;
public interface ITaskRepository
{
    Task<TaskItemModel> CreateTaskAsync(TaskItemModel task);
    Task<List<TaskItemModel>> GetAllTasksAsync();
    Task<TaskItemModel?> GetTaskByIdAsync(int id);
    Task<TaskItemModel> UpdateTaskAsync(TaskItemModel task);
    Task<TaskItemModel> DeleteTaskAsync(int id);
}