using Moq;
using tdd.task.manager.Models;
using tdd.task.manager.Repository;
using tdd.task.manager.Services;

public class TaskServiceTests
{
    [Fact]
    public async Task CreateTaskAsync_ShouldReturnCreatedTask()
    {
        // Arrange
        var mockRepo = new Mock<ITaskRepository>();
        var taskService = new TaskService(mockRepo.Object);
        var task = new TaskItemModel { Title = "Test", Description = "Testing", IsCompleted = false };

        mockRepo.Setup(r => r.CreateTaskAsync(task)).ReturnsAsync(task);

        // Act
        var result = await taskService.CreateTaskAsync(task);

        // Assert
        Assert.Equal("Test", result.Title);
        Assert.Equal("Testing", result.Description);
        Assert.False(result.IsCompleted);
    }

    [Fact]
    public async Task UpdateTaskAsync_ShouldReturnUpdatedTask()
    {
        // Arrange
        var mockRepo = new Mock<ITaskRepository>();
        var taskService = new TaskService(mockRepo.Object);
        var task = new TaskItemModel { Title = "Updated Test", Description = "Updated Testing", IsCompleted = true };

        mockRepo.Setup(r => r.UpdateTaskAsync(task)).ReturnsAsync(task);

        var result = await taskService.UpdateTaskAsync(task);

        // Assert
        Assert.Equal("Updated Test", result.Title);
        Assert.Equal("Updated Testing", result.Description);
        Assert.True(result.IsCompleted);
    }

    [Fact]
    public async Task DeleteTaskAsync_ShouldReturnDeletedTask()
    {
        // Arrange
        var mockRepo = new Mock<ITaskRepository>();
        var taskService = new TaskService(mockRepo.Object);
        var task = new TaskItemModel { Id = 1, Title = "Deleted Test", Description = "Deleted Testing", IsCompleted = true };

        mockRepo.Setup(r => r.DeleteTaskAsync(task.Id)).ReturnsAsync(task);

        var result = await taskService.DeleteTaskAsync(task);

        // Assert
        Assert.Equal(1, result.Id);
        Assert.Equal("Deleted Test", result.Title);
        Assert.Equal("Deleted Testing", result.Description);
        Assert.True(result.IsCompleted);
    }

    [Fact]
    public async Task GetTaskByIdAsync_ShouldReturnTask()
    {
        // Arrange
        var mockRepo = new Mock<ITaskRepository>();
        var taskService = new TaskService(mockRepo.Object);
        var task = new TaskItemModel { Id = 2, Title = "Get Test", Description = "Get Testing", IsCompleted = true };

        mockRepo.Setup(r => r.GetTaskByIdAsync(task.Id)).ReturnsAsync(task);

        var result = await taskService.GetTaskByIdAsync(task.Id);

        // Assert
        Assert.Equal(2, result?.Id);
        Assert.Equal("Get Test", result?.Title);
        Assert.Equal("Get Testing", result?.Description);
        Assert.True(result?.IsCompleted);
    }

    [Fact]
    public async Task GetAllTasksAsync_ShouldReturnTask()
    {
        // Arrange
        var mockRepo = new Mock<ITaskRepository>();
        var taskService = new TaskService(mockRepo.Object);
        var task = new TaskItemModel { Id = 1, Title = "Get Test", Description = "Get Testing", IsCompleted = true };
        var task2 = new TaskItemModel { Id = 2, Title = "Get Test2", Description = "Get Testing2", IsCompleted = false };
        var tasks = new List<TaskItemModel> { task, task2 };

        mockRepo.Setup(r => r.GetAllTasksAsync()).ReturnsAsync(tasks);

        var result = await taskService.GetAllTasksAsync();

        // Assert
        Assert.Collection(result,
            t =>
            {
                Assert.Equal(1, t.Id);
                Assert.Equal("Get Test", t.Title);
                Assert.Equal("Get Testing", t.Description);
                Assert.True(t.IsCompleted);
            },
            t =>
            {
                Assert.Equal(2, t.Id);
                Assert.Equal("Get Test2", t.Title);
                Assert.Equal("Get Testing2", t.Description);
                Assert.False(t.IsCompleted);
            });
    }
}