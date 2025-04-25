

using tdd.task.manager.Data;
using tdd.task.manager.Models;
using tdd.task.manager.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<TaskItemModel> CreateTaskAsync(TaskItemModel task)
    {
        throw new NotImplementedException();
    }

    public Task<TaskItemModel> DeleteTaskAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TaskItemModel>> GetAllTasksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TaskItemModel?> GetTaskByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TaskItemModel> UpdateTaskAsync(TaskItemModel task)
    {
        throw new NotImplementedException();
    }
}