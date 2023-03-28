using AutoMapper;
using Familia.Ead.Application.Requests.Authentication.CreateUser;

namespace Familia.Ead.Api.Controllers.Authentication.Inputs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserInput, CreateUserRequest>();

        }
    }
}
