using AutoMapper;
using BusinessObject.Dtos;
using DataAccess.EntitySet;

namespace BusinessObject.Helpers;

public class TaskProfile: Profile
{
    public TaskProfile()
    {
        //Source - Target
        CreateMap<TaskEntity, TaskDetailDto>();
            //.ForCtorParam(nameof(TaskEntity.Id), options => options.MapFrom(source => source.Id))
            //.ForCtorParam(nameof(TaskEntity.Title), options => options.MapFrom(source => source.Title))
            //.ForCtorParam(nameof(TaskEntity.Description), options => options.MapFrom(source => source.Description))
            //.ForCtorParam(nameof(TaskEntity.Status), options => options.MapFrom(source => source.Status))
            //.ForCtorParam(nameof(TaskEntity.DueDate), options => options.MapFrom(source => source.DueDate))
            //.ForAllMembers(options => options.Ignore())
            //.DisableCtorValidation();

        CreateMap<TaskDetailDto, TaskEntity>();
            //.ForCtorParam(nameof(TaskEntity.Id), options => options.MapFrom(source => source.id))
            //.ForCtorParam(nameof(TaskEntity.Title), options => options.MapFrom(source => source.title))
            //.ForCtorParam(nameof(TaskEntity.Description), options => options.MapFrom(source => source.description))
            //.ForCtorParam(nameof(TaskEntity.Status), options => options.MapFrom(source => source.status))
            //.ForCtorParam(nameof(TaskEntity.DueDate), options => options.MapFrom(source => source.dueDate))
            //.ForAllMembers(options => options.Ignore());
    }
}
