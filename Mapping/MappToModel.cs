using AutoMapper;
using Twitter.Domain.Models;
using Twitter.Resources;

namespace Twitter.Mapping
{
    public class MappToModel : Profile
    {
        public MappToModel()
        {
            CreateMap<UserResource, User>();
        }
    }
}