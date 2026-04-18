using JabilMoviesAPI.Models.DTOs;
using JabilMoviesAPI.Services;
using JabilMoviesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JabilMoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class MoviesController : ControllerBase
    {
        private readonly IService<MoviesDTO, MoviesInsertDTO, MoviesUpdateDTO> _moviesService;
        public MoviesController(IService<MoviesDTO, MoviesInsertDTO, MoviesUpdateDTO> service)
        {
            // Aquí puedes inyectar servicios o realizar cualquier inicialización necesaria para el controlador.
            _moviesService = service;
        }

        [HttpGet]
        public async Task<ActionResult<MoviesDTO>> Get()
        {
            var moviesDTO = await _moviesService.GetAll(); 
            return Ok(moviesDTO);
        }

        [HttpGet]
        [Route("{id}")] 
        public async Task<ActionResult<MoviesDTO>> GetById(int id)
        {
            var moviesDTO = await _moviesService.GetById(id); 
            if (moviesDTO == null)
            {
                return NotFound(); 
            }
            return Ok(moviesDTO); 
        }

        [HttpPost]
        public async Task<ActionResult<MoviesDTO>> Create(MoviesInsertDTO moviesDTO)
        {
            var createdMoviesDTO = await _moviesService.Create(moviesDTO); 
            return CreatedAtAction(nameof(GetById), new { id = createdMoviesDTO.Id }, createdMoviesDTO); 
        }

        [HttpPut]
        [Route("{id}")] 
        public async Task<ActionResult<MoviesDTO>> Update(int id, MoviesUpdateDTO moviesDTO)
        {
            var updatedMoviesDTO = await _moviesService.Update(id, moviesDTO); 
            if (updatedMoviesDTO == null)
            {
                return NotFound(); 
            }
            return Ok(updatedMoviesDTO); 
        }

        [HttpDelete]
        [Route("{id}")] 
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _moviesService.Delete(id); 
            if (!deleted)
            {
                return NotFound(); 
            }
            return NoContent(); 
        }
    }
}
