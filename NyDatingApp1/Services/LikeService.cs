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
        private readonly datingdatabase _dbContext;

        public LikeService(datingdatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Like>> GetReceivedLikesAsync(int profileId)
        {
            // Hent alle likes, hvor den angivne profil er receiver
            return await _dbContext.Likes
                                  .Include(l => l.SenderProfile)
                                  .Where(l => l.ReceiverId == profileId)
                                  .ToListAsync();
        }

        public async Task<bool> IsProfileLikedByUserAsync(int senderId, int receiverId)
        {
            // Implementer logik til at checke om en profil er liket af en bruger
            // Dette kan være en simpel check eller mere kompleks afhængigt af dine behov
            return await _dbContext.Likes
                                  .AnyAsync(l => l.SenderId == senderId && l.ReceiverId == receiverId);
        }

        public async Task AddLikeAsync(int senderId, int receiverId)
        {
            // Implementer logik til at tilføje en like
            // Dette kunne være at oprette en ny Like-entré i din database
            var like = new Like
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Status = 1 // Eksempel på status (kan være hvad som helst afhængigt af din logik)
            };

            _dbContext.Likes.Add(like);
            await _dbContext.SaveChangesAsync();
        }
    }
}
