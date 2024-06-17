using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NyDatingApp1.Data;
using NyDatingApp1.Models;

namespace NyDatingApp1.Services
{
    public class ProfileService
    {
        private readonly datingdatabase _context;

        public ProfileService(datingdatabase context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task<bool> HasSentLikeAsync(int senderId, int receiverId)
        {
            if (senderId <= 0 || receiverId <= 0)
            {
                throw new ArgumentException("SenderId and ReceiverId must be greater than zero.");
            }

            try
            {
                var sentLikes = await _context.Likes
                    .AnyAsync(l => l.SenderId == senderId && l.ReceiverId == receiverId);

                return sentLikes;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw new ApplicationException("Error checking if like was sent.", ex);
            }
        }
    }
}
