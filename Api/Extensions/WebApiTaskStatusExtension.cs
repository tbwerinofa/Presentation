using BusinessObject.Dtos;
using QueryService;
using Serilog;

namespace Presentation.Extensions;
public static class WebApiTaskStatusExtension
{
    public static void MapTaskStatusEntityEndPoints(this WebApplication app)
    {
        app.MapGet("/taskstatus", (IQueryTaskStatusRepository repo) => {
            try
            {
                Log.Information("Tasks processing has started");

                return repo.GetAll();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Unable to get tasks status");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        })
           .Produces<TaskDto[]>(StatusCodes.Status200OK);
    }
}

