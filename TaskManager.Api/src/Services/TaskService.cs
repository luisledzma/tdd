using tdd.task.manager.Models;
using tdd.task.manager.Repository;

namespace tdd.task.manager.Services;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo;
    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

    public Task<TaskItemModel> CreateTaskAsync(TaskItemModel task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
            throw new ArgumentException("Title is required");

        if (string.IsNullOrWhiteSpace(task.Description))
            throw new ArgumentException("Description is required");

        return _repo.CreateTaskAsync(task);
    }

    public Task<TaskItemModel> UpdateTaskAsync(TaskItemModel task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
            throw new ArgumentException("Title is required");

        if (string.IsNullOrWhiteSpace(task.Description))
            throw new ArgumentException("Description is required");

        return _repo.UpdateTaskAsync(task);
    }

    public Task<TaskItemModel> DeleteTaskAsync(TaskItemModel task)
    {
        if (task.Id == 0)
            throw new ArgumentException("Id is required");

        return _repo.DeleteTaskAsync(task.Id);
    }

    public Task<TaskItemModel?> GetTaskByIdAsync(int id)
    {
        if (id == 0)
            throw new ArgumentException("Id is required");

        return _repo.GetTaskByIdAsync(id);
    }

    public Task<List<TaskItemModel>> GetAllTasksAsync()
    {
        return _repo.GetAllTasksAsync();
    }
}