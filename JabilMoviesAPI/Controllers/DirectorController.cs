using JabilMoviesAPI.Models.DTOs;
using JabilMoviesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JabilMoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class DirectorController : ControllerBase
    {
        private readonly IService<DirectorDTO, DirectorInsertDTO, DirectorUpdateDTO> _directorService;

        public DirectorController(IService<DirectorDTO, DirectorInsertDTO, DirectorUpdateDTO> directorService)
        {
            // Aquí puedes inyectar servicios o realizar cualquier inicialización necesaria para el controlador.
            _directorService = directorService;
        }
        [HttpGet]
        [Route("{id}")] 
        public async Task<ActionResult<DirectorDTO>> GetById(int id)
        {
            var directorDTO = await _directorService.GetById(id); 
            if (directorDTO == null)
            {
                return NotFound(); 
            }
            return Ok(directorDTO); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDTO>>> GetAll()
        {
            var directorDTO = await _directorService.GetAll(); 
            return Ok(directorDTO);
        }

        [HttpPost]
        public async Task<ActionResult<DirectorDTO>> Create(DirectorInsertDTO directorInsertDTO)
        {
            var createdDirectorDTO = await _directorService.Create(directorInsertDTO); 
            return CreatedAtAction(nameof(GetById), new { id = createdDirectorDTO.Id }, createdDirectorDTO); 
        }

        [HttpPut]
        [Route("{id}")] 
        public async Task<ActionResult<DirectorDTO>> Update(int id, DirectorUpdateDTO directorUpdateDTO)
        {
            var updatedDirectorDTO = await _directorService.Update(id, directorUpdateDTO); 
            if (updatedDirectorDTO == null)
            {
                return NotFound(); 
            }
            return Ok(updatedDirectorDTO); 
        }

        [HttpDelete]
        [Route("{id}")] 
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _directorService.Delete(id); 
            if (!deleted)
            {
                return NotFound(); 
            }
            return NoContent(); 
        }
    }
}
