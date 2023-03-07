using TP3.Application.ViewModels;

using TP3.Domain;

namespace TP3.Application.Interfaces
{
    public interface IFriendService
    {
        Task<List<FriendViewModel>> GetAllFriendAsync();
        Task<FriendViewModel> GetFriendBydId(Guid Id);
        Task<FriendViewModel> AddFriendAsync(FriendViewModel model);
        void DeleteFriendAsync(Guid id);
    }
}
