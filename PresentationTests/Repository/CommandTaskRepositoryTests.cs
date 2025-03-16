using CommandService;
using DataAccess.EntitySet;
using PresentationTests.Helpers;
using System.Diagnostics;

namespace PresentationTests.Repository;

public class CommandTaskRepositoryTests
{
    [Fact]
    public async Task SaveAsync_Task_Ok()
    {
        var helper = new RepositoryHelper();

        var readyRepo = helper.GetInMemoryReadRepository();
        var writeRepo = helper.GetInMemoryWriteRepository();

        var taskEntity = helper.GetTaskList().FirstOrDefault();


            if (taskEntity != null)
                await writeRepo.AddAsync(taskEntity);


        var taskEntityList = await readyRepo.GetAll();
        var saveTaskEntity = taskEntityList.FirstOrDefault();


        if (taskEntity == null)
            throw new ArgumentNullException("Record not saved");

        Assert.NotEqual(0, taskEntity.id);
        Assert.Equal("File Import", taskEntity.title);
        Assert.Equal(1, taskEntity.taskStatusEntityId);
        Assert.Equal("I failed to import file", taskEntity.description);
        Assert.Equal(DateTime.Parse("2025-03-23"), taskEntity.dueDate);
    }

    [Fact]
    public async Task DeleteAsync_Task_Ok()
    {
        var helper = new RepositoryHelper();

        var readyRepo = helper.GetInMemoryReadRepository();
        var writeRepo = helper.GetInMemoryWriteRepository();

        var taskList = helper.GetTaskList();

            foreach (var taskEntity in taskList)
            {
                if (taskEntity != null)
                    await writeRepo.AddAsync(taskEntity);
             }

        var taskEntityList = await readyRepo.GetAll();
        var savedEntity = taskEntityList.FirstOrDefault();
        if (savedEntity != null)
        {
            await writeRepo.DeleteAsync(savedEntity.id);

            var deletedRecord =  await readyRepo.Get(savedEntity.id);
            Assert.Null(deletedRecord);
        }
    }

    [Fact]
    public async Task DeleteAsync_Task_Fail()
    {
        try
        {


            var helper = new RepositoryHelper();

            var readyRepo = helper.GetInMemoryReadRepository();
            var writeRepo = helper.GetInMemoryWriteRepository();

            var taskList = helper.GetTaskList();

            foreach (var taskEntity in taskList)
            {
                if (taskEntity != null)
                    await writeRepo.AddAsync(taskEntity);
            }

            var taskEntityList = await readyRepo.GetAll();
            var savedEntity = taskEntityList.FirstOrDefault();
            if (savedEntity != null)
            {
                await writeRepo.DeleteAsync(0);
            }
        }
        catch (ArgumentException ae)
        {
            Assert.Equal("Error deleting task 0", ae.Message);
        }
        catch (Exception ex)
        {

            Assert.Fail(
             string.Format("Error deleting task 0"));
        }
    }

}

