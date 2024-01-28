using AutoMapper;
using dotnet_7_crud_api.Entitiles;
using dotnet_7_crud_api.Models.Users;

namespace dotnet_7_crud_api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForMember(dest => dest.Guid, opt => opt.Ignore()) // Ignore the Guid property
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

            // Add this line to create a mapping from CreateRequest to User
            CreateMap<CreateRequest, User>();
        }
    }
}