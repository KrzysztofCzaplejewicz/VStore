using System.Collections.Generic;
using System.Threading.Tasks;
using VStore.Controllers.Resources;
using VStore.Models;


namespace VStore.Persistance
{
    public interface IGenreRepository
    {
        Task<Genre> GetGenre(int id, bool includeRelated = true);
        Task<IEnumerable<Genre>> GetGenres(GenreResource genre);
        void Add(Genre genre);
        void Remove(Genre genre);
    }
}