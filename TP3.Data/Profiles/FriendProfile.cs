
using AutoMapper;
using TP3.Application.ViewModels;
using TP3.Domain;

namespace TP3.Data.Profiles
{
    public class FriendProfile : Profile
    {
        public FriendProfile()
        {
            CreateMap<List<FriendViewModel>, List<Friend>>();
            CreateMap<FriendViewModel, Friend>();
            CreateMap<Friend, FriendViewModel>();
            CreateMap<List<Friend>, List<FriendViewModel>>();

        }
    }
}
