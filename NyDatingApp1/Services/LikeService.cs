using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NyDatingApp1.Data;
using NyDatingApp1.Models;

namespace NyDatingApp1.Services
{
    public class LikeService
    {
        private readonly datingdatabase _context;

        public LikeService(datingdatabase context)
        {
            _context = context;
        }

        public async Task AddLikeAsync(int senderId, int receiverId)
        {
            try
            {
                // Check if the like already exists
                var existingLike = await _context.Likes
                    .FirstOrDefaultAsync(l => l.SenderId == senderId && l.ReceiverId == receiverId);

                if (existingLike != null)
                {
                    // Update existing like count
                    existingLike.Status++;
                    _context.Likes.Update(existingLike);
                }
                else
                {
                    // Create new like entry
                    var newLike = new Like
                    {
                        SenderId = senderId,
                        ReceiverId = receiverId,
                        Status = 1 // Initial like count
                    };
                    _context.Likes.Add(newLike);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException("Error occurred while adding like.", ex);
            }
        }

        public async Task<bool> IsProfileLikedByUserAsync(int senderId, int receiverId)
        {
            return await _context.Likes.AnyAsync(l => l.SenderId == senderId && l.ReceiverId == receiverId);
        }

        public async Task<List<Like>> GetReceivedLikesAsync(int profileId)
        {
            return await _context.Likes.Where(l => l.ReceiverId == profileId).ToListAsync();
        }
    }
}
