using AutoMapper;
using VirtualDeanary.Data.Models;
using VirtualDeanary.Models;

namespace VirtualDeanary.Infrastructure.MapperProfiles
{
    public class GroupProfiles : Profile
    {
        public GroupProfiles()
        {
            CreateMap<AddUserToGroupViewModel, Groups>().
                ForMember(x => x.Id, otp => otp.Ignore()); ;
        }
    }
}
