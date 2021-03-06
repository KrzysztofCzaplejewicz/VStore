﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VStore.Controllers.Resources;
using VStore.Models;
using VStore.Persistance;

namespace VStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Videos")]
    public class VideosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVideoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public VideosController(IMapper mapper, IVideoRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        [HttpGet()]
        public async Task<IEnumerable<VideoResource>> GetVideos(VideoResource saveVideoResource)
        {
            var videos = await _repository.GetVideos(saveVideoResource);
            return _mapper.Map<IEnumerable<Video>, IEnumerable<VideoResource>>(videos);

        }
        [HttpPost]
        public async Task<IActionResult> CreateVideo([FromBody] SaveVideoResource saveVideoResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var video = _mapper.Map<SaveVideoResource, Video>(saveVideoResource);
            _repository.Add(video);
            await _unitOfWork.CompleteAsync();
            await _unitOfWork.ChangeVideo(video.Id);
            var result = _mapper.Map<Video, VideoResource>(video);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideo(int id, [FromBody] SaveVideoResource saveVideoResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _unitOfWork.ChangeVideo(id);

            var video = await _repository.GetVideo(id);
            if (video == null)
            {
                return NotFound();
            }
            _mapper.Map(saveVideoResource, video);
            await _unitOfWork.CompleteAsync();
            var result = _mapper.Map<Video, VideoResource>(video);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var video = await _repository.GetVideo(id);
            if (video == null)
            {
                return NotFound();
            }

            _repository.Remove(video);
            await _unitOfWork.CompleteAsync();
            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVideo(int id)
        {
            var video = await _repository.GetVideo(id);
            if (video == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<Video, VideoResource>(video);
            return Ok(result);
        }


    }
}