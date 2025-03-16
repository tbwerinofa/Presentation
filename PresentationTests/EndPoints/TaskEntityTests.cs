using BusinessObject.Dtos;
using DataAccess.EntitySet;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using PresentationTests.Helpers;
using System.Net;
using System.Net.Http.Json;

namespace PresentationTests.EndPointTests;

public class TaskEntityTests
{
    [Fact]
    public async Task Get_AllTask_Ok()
    {
        await using var application = new TestingFactory();
        using var client = application.CreateClient();

        var response = await client.GetFromJsonAsync<List<TaskDto>>("tasks");

        Assert.IsType(typeof(List<TaskDto>), response);

    }

    [Fact]
    public async Task Get_AllTaskResponse_Ok()
    {
        await using var application = new TestingFactory();

        using var client = application.CreateClient();
        using var response = await client.GetAsync("tasks");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
