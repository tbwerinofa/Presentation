using PresentationTests.Helpers;
using System.Diagnostics;

namespace PresentationTests.Repository;

public class QueryTaskRepositoryTests
{
    private readonly RepositoryHelper helper;
    public QueryTaskRepositoryTests()
    {
        helper = new RepositoryHelper();
        var writeRepo = helper.GetInMemoryWriteRepository();

        var taskList = helper.GetTaskList();

        foreach (var item in taskList)
        {
            if (item != null)
                writeRepo.AddAsync(item).GetAwaiter();
        }
    }
    [Fact]
    public async Task GetAll_Tasks_CountAsync()
    {

        var readyRepo = helper.GetInMemoryReadRepository();


        var result = await readyRepo.GetAll();
        Assert.Equal(6, result.Count);
    }

    [Fact]
    public async Task GetById_Task_CorrectDetailsAsync()
    {

        var readyRepo = helper.GetInMemoryReadRepository();
        var writeRepo = helper.GetInMemoryWriteRepository();


        var result = await readyRepo.Get(2);
        Assert.Equal(2, result.id);
        Assert.Equal("Race Results", result.title);
        Assert.Equal(2, result.taskStatusEntityId);
        Assert.Equal("Results are now available", result.description);
        Assert.Equal(DateTime.Parse("2025-03-16"), result.dueDate);
    }
}

