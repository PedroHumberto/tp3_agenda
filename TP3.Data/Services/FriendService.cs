using AutoMapper;
using TP3.Application.Interfaces;
using TP3.Application.ViewModels;
using TP3.Domain;

namespace TP3.Data.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _repository;

        public FriendService(IFriendRepository repository)
        {
            _repository = repository;
        }

        public async Task<FriendViewModel> AddFriendAsync(FriendViewModel model)
        {
            await _repository.AddFriendAsync(model);

            return model;
        }

        public void DeleteFriendAsync(Guid id)
        {
            var delete = _repository.GetAllFriendAsync().Result.FirstOrDefault(friend => friend.Id == id);

            _repository.DeleteFriendAsync(delete);
        }

        public async Task<List<FriendViewModel>> GetAllFriendAsync()
        {
            var friendList = await _repository.GetAllFriendAsync();

            return friendList;
        }

        public async Task<FriendViewModel> GetFriendBydId(Guid Id)
        {
            var friendModel = await _repository.GetFriendById(Id);

            return friendModel;
        }


        //REFAZER O MAP NO REPOSITORY, TROCAR ALGUNS DADOS
        public async Task<FriendViewModel> UpdateFriendAsync(FriendViewModel updatedFriend)
        {
            _repository.UpdateFriendAsync(updatedFriend);

            return updatedFriend;
        }
    }
}
