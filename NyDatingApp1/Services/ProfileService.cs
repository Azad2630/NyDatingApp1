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
            // Implementér logikken til at tjekke om brugeren har sendt en like til receiverId
            // Dette kan involvere at hente likes fra databasen og tjekke modtageren
            // Her er et eksempel, du skal muligvis justere dette efter din databasestruktur
            var sentLikes = await _context.Likes
                .AnyAsync(l => l.SenderId == senderId && l.ReceiverId == receiverId);

            return sentLikes; // Returner sandt, hvis der er mindst én matchende like
        }
    }
}
