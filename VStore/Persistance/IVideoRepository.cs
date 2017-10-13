using System.Collections.Generic;
using System.Threading.Tasks;
using VStore.Controllers.Resources;
using VStore.Models;

namespace VStore.Persistance
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetVideos(VideoResource videoResource);
        void Add(Video video);
        void Remove(Video video);
        Task<Video> GetVideo(int id, bool includeRelated = true);
    }
}