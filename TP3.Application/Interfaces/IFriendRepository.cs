using TP3.Domain;

namespace TP3.Application.Interfaces
{
    public interface IFriendRepository
    {
        Task<List<Friend>> GetAllFriendAsync();
        Task<Friend> GetFriendById(Guid Id);
        Task<Friend> AddFriendAsync(Friend model);
        Task DeleteFriendAsync(Friend id);
        Task UpdateFriendAsync(Friend updatedFriend);
    }

}

