
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TP3.Application.Interfaces;
using TP3.Data.Data;
using TP3.Domain;

namespace TP3.Data.Repository
{
    public class FriendRepository : IFriendRepository
    {
        private readonly FriendsDbContext _context;

        public FriendRepository(FriendsDbContext context)
        {
            _context = context;
        }

        public async Task<Friend> AddFriendAsync(Friend friend)
        {
            await _context.Friends.AddAsync(friend);
            await _context.SaveChangesAsync();
            return friend;
        }

        public async Task DeleteFriendAsync(Friend friend)
        {
            _context.Friends.Remove(friend);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Friend>> GetAllFriendAsync()
        {
            var allFriends = await _context.Friends.ToListAsync();
            if (allFriends.IsNullOrEmpty()) return new List<Friend>();

            return await _context.Friends.ToListAsync();
        }

        public async Task<Friend> GetFriendById(Guid Id)
        {
            var friend = await _context.Friends.FirstOrDefaultAsync(f => f.Id == Id);

            if(friend != null) return friend;
            
            return null;
        }

        public async Task UpdateFriendAsync(Friend updatedFriend)
        {
            await _context.SaveChangesAsync();
        }
    }
}
