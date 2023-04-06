using Microsoft.AspNetCore.Mvc;
using Mordor_Backend.Exceptions;
using Mordor_Backend.Models.Dto;
using Mordor_Backend.Service;

namespace Mordor_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrksController : ControllerBase
    {
        private readonly IMordorService _mordorService;

        public OrksController(IMordorService mordorService)
        {
            _mordorService = mordorService;
        }

        // GET: api/Orks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetOrkDto>>> GetOrks()
        {
            IEnumerable<GetOrkDto> getOrkDto = await _mordorService.GetAllOrksAsync();

            if (getOrkDto.Any())
            {
                return Ok(getOrkDto);
            }

            return NoContent();
        }


        // POST: api/Orks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetOrkDto>> PostOrk(CreateOrkDto createOrkDto)
        {
            GetOrkDto getOrkDto = await _mordorService.CreateOrkAsync(createOrkDto);

            return Created("", getOrkDto);
        }

        // DELETE: api/Orks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrk(int id)
        {
            try
            {
                await _mordorService.DeleteOrkByIdAsync(id);
                return Ok();
            }
            catch (OrkNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
