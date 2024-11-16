using AutoMapper;
using LAB4.Models;
using LAB4.Models.DTO;
using LAB4.Models.DTO.Create;
using LAB4.Models.DTO.Update;
using LAB4.Repository.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB4.Controllers
{
    [EnableCors("AllowLocalhost")]
    [Route("api/Clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _dbClients;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository dbClients, IMapper mapper)
        {
            _dbClients = dbClients;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all Clients.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClients()
        {
            if (!_dbClients.Exist())
            {
                return NotFound();
            }

            var clients = await _dbClients.GetClients();

            return _mapper.Map<List<ClientDTO>>(clients);
        }

        /// <summary>
        /// Gets a specific Client.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(int id)
        {
            if (!_dbClients.Exist())
            {
                return NotFound();
            }
            var client = await _dbClients.GetClientById(id);

            if (client == null)
            {
                return NotFound();
            }

            return _mapper.Map<ClientDTO>(client);
        }

        /// <summary>
        /// Updates a specific Client.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientUpdateDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);

            if (id != client.Id)
            {
                return BadRequest();
            }

            _dbClients.UpdateClient(client);

            try
            {
                await _dbClients.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Adds a specific Client.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Client>> PostClients(ClientCreateDTO clientDto)
        {
            if (!_dbClients.Exist())
            {
                return Problem("Entity set 'ApplicationDbContext.Clients'  is null.");
            }
            var client = _mapper.Map<Client>(clientDto);
            _dbClients.CreateClient(client);
            await _dbClients.SaveAsync();

            var createdClientDto = _mapper.Map<ClientDTO>(client);

            return CreatedAtAction("GetClient", new { id = createdClientDto.Id }, createdClientDto);
        }

        /// <summary>
        /// Deletes a specific Client.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (!_dbClients.Exist())
            {
                return NotFound();
            }
            var client = await _dbClients.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            _dbClients.DeleteClient(id);
            await _dbClients.SaveAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _dbClients.ClientExist(id);
        }
    }
}
