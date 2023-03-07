
using AutoMapper;
using TP3.Application.ViewModels;
using TP3.Domain;

namespace TP3.Data.Profiles
{
    public class FriendProfile : Profile
    {
        public FriendProfile()
        {
            CreateMap<FriendViewModel, Friend>();
            CreateMap<Friend, FriendViewModel>();

        }
    }
}
