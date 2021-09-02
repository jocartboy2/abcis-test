using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/abcis")]
    [ApiController]
    public class AbcisController : ControllerBase
    {
        private readonly IAbcisRepo _repository;
        private readonly IMapper _mapper;

        public AbcisController(IAbcisRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/abcis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbcisReadDto>>> GetAllCommands()
        {
            await Task.Delay(3000);
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<AbcisReadDto>>(commandItems));
        }

        // GET api/abcis/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public async Task<ActionResult<AbcisReadDto>> GetCommandById(int id)
        {
            await Task.Delay(2000);
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<AbcisReadDto>(commandItem));
            }
            return NotFound();
        }

        // POST api/abcis
        [HttpPost]
        public async Task<ActionResult<AbcisReadDto>> CreateCommand(AbcisCreateDto commandCreateDto)
        {
            await Task.Delay(2000);
            var commandModel = _mapper.Map<AbcisCommand>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<AbcisReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDto.Id }, commandReadDto);
        }

        // PUT api/abcis/2
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand(int id, AbcisUpdateDto commandUpdateDto)
        {
            await Task.Delay(3000);
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/abcis/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialCommandUpate(int id, JsonPatchDocument<AbcisUpdateDto> patchDoc)
        {
            await Task.Delay(3000);
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<AbcisUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/abcis/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommand(int id)
        {
            await Task.Delay(3000);
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}