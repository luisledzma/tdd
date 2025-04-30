

using Microsoft.EntityFrameworkCore;
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

    public async Task<TaskItemModel> CreateTaskAsync(TaskItemModel task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskItemModel> DeleteTaskAsync(int id)
    {
        _context.Tasks.Remove(new TaskItemModel { Id = id });
        await _context.SaveChangesAsync();
        return new TaskItemModel { Id = id };
    }

    public async Task<List<TaskItemModel>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskItemModel?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<TaskItemModel> UpdateTaskAsync(TaskItemModel task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }
}