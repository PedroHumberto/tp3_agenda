
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using TP3.Application.Interfaces;
using TP3.Application.ViewModels;
using TP3.Data.Data;
using TP3.Domain;

namespace TP3.Data.Repository
{
    public class FriendRepository : IFriendRepository
    {
        private readonly FriendsDbContext _context;
        private readonly IMapper _mapper;

        public FriendRepository(FriendsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddFriendAsync(FriendViewModel friendModel)
        {
            Friend friend = _mapper.Map<Friend>(friendModel);

            await _context.Friends.AddAsync(friend);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFriendAsync(FriendViewModel friendModel)
        {
            Friend friend = _mapper.Map<Friend>(friendModel);
            _context.Friends.Remove(friend);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FriendViewModel>> GetAllFriendAsync()
        {
            var allFriends = await _context.Friends.ToListAsync();

            if (allFriends.IsNullOrEmpty()) return new List<FriendViewModel>();

            var modelList = _mapper.Map<List<FriendViewModel>>(allFriends);

            return modelList;
        }

        public async Task<FriendViewModel> GetFriendById(Guid Id)
        {
            var friend = await _context.Friends.FirstOrDefaultAsync(f => f.Id == Id);

            var modelFriend = _mapper.Map<FriendViewModel>(friend);

            if(friend != null) return modelFriend;
            
            return null;
        }

        public async Task<FriendViewModel> UpdateFriendAsync(FriendViewModel updatedFriend)
        {
            var friend = await _context.Friends.FirstOrDefaultAsync(f => f.Id == updatedFriend.Id);

            _mapper.Map<Friend>(updatedFriend);

            await _context.SaveChangesAsync();

            return updatedFriend;
        }
    }
}
