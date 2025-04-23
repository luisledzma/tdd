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
        return _repo.CreateTaskAsync(task);
    }
}