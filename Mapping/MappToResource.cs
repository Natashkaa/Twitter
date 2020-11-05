using AutoMapper;
using Twitter.Domain.Models;
using Twitter.Resources;

namespace Twitter.Mapping
{
    public class MappToResource : Profile
    {
        public MappToResource()
        {
            CreateMap<User, UserResource>();
        }
    }
}