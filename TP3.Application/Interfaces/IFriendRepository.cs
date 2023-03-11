using System.ComponentModel.DataAnnotations;
using TP3.Application.ViewModels;
using TP3.Domain;

namespace TP3.Application.Interfaces
{
    public interface IFriendRepository
    {
        Task<List<FriendViewModel>> GetAllFriendAsync();
        Task<FriendViewModel> GetFriendById(Guid Id);
        Task AddFriendAsync(FriendViewModel model);
        Task DeleteFriendAsync(FriendViewModel id);
        Task<FriendViewModel> UpdateFriendAsync(FriendViewModel updatedFriend);
    }

}

