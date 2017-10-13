using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VStore.Controllers.Resources;
using VStore.Models;

namespace VStore.Persistance
{
    public class VideoRepository : IVideoRepository
    {
        private readonly StoreDbContext _dbContext;

        public VideoRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Video>> GetVideos(VideoResource videoResource)
        {
            var videos = _dbContext.Videos.AsQueryable();
            return await videos.ToListAsync();
        }

        public void Add(Video video)
        {
            _dbContext.Add(video);
        }
        public void Remove(Video video)
        {
            _dbContext.Remove(video);
        }

        public async Task<Video> GetVideo(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await _dbContext.Videos.FindAsync(id);

            return await _dbContext.Videos.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
