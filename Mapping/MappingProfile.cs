using AutoMapper;
using ProjectManagementApp.Controllers.Resources;
using ProjectManagementApp.Core.Models;

namespace ProjectManagementApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBoardResource,Board>();
            CreateMap<Board, BoardResource>();

            CreateMap<CreateColumnResource, Column>();
            CreateMap<Column, ColumnResource>();
        }
    }
}