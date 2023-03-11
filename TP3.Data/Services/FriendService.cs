using AutoMapper;
using TP3.Application.Interfaces;
using TP3.Application.ViewModels;
using TP3.Domain;

namespace TP3.Data.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _repository;
        private readonly IMapper _mapper;

        public FriendService(IFriendRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FriendViewModel> AddFriendAsync(FriendViewModel model)
        {
            var friend = _mapper.Map<Friend>(model);

            await _repository.AddFriendAsync(friend);
           
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

            var viewModel = _mapper.Map<List<FriendViewModel>>(friendList);

            return viewModel;
        }

        public async Task<FriendViewModel> GetFriendBydId(Guid Id)
        {

            Friend friend = await _repository.GetFriendById(Id);

            var viewModel = _mapper.Map<FriendViewModel>(friend);

            return viewModel;
        }

        public async Task<FriendViewModel> UpdateFriendAsync(FriendViewModel updatedFriend)
        {
            Friend friend = await _repository.GetFriendById(updatedFriend.Id);
           
            friend = _mapper.Map<Friend>(updatedFriend);

            var teste = await _repository.UpdateFriendAsync(friend);

            return updatedFriend;
        }
    }
}
