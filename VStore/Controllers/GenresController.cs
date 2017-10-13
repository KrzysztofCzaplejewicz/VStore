using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VStore.Controllers.Resources;
using VStore.Models;
using VStore.Persistance;

namespace VStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Genres")]
    public class GenresController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenresController(IMapper mapper, IGenreRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenre(int id)
        {
            var genre = await _repository.GetGenre(id);

            if (genre == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<Genre, GenreResource>(genre);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IEnumerable<GenreResource>> GetGenres(GenreResource genre)
        {
            var genres = await _repository.GetGenres(genre);

            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreResource>>(genres);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] GenreResource resource)
        {
            var genre = _mapper.Map<GenreResource, Genre>(resource);

            _repository.Add(genre);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Genre, GenreResource>(genre);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] GenreResource resource)
        {
            var genre = await _repository.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Genre, GenreResource>(genre);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _repository.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }

            _repository.Remove(genre);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Genre, GenreResource>(genre);
            return Ok(result);
        }
    }
}