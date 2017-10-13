using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VStore.Controllers.Resources;
using VStore.Models;

namespace VStore.Persistance
{
    public class GenreRepository : IGenreRepository
    {
        private readonly StoreDbContext _dbContext;

        public GenreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Genre> GetGenre(int id, bool includeRelated = true)
        {
            return await _dbContext.Genres.Include(v => v.Videos).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Genre>> GetGenres(GenreResource genre)
        {
            var genres = await _dbContext.Genres.Include(v => v.Videos).ToListAsync();

            return genres;
        }

        public void Add(Genre genre)
        {
            _dbContext.Add(genre);
        }

        public void Remove(Genre genre)
        {
            _dbContext.Remove(genre);
        }

    }
}
