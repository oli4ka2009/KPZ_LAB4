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
    [Route("api/Policies")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository _dbPolicies;
        private readonly IMapper _mapper;

        public PolicyController(IPolicyRepository dbPolicies, IMapper mapper)
        {
            _dbPolicies = dbPolicies;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all Policies.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyDTO>>> GetPolicies()
        {
            if (!_dbPolicies.Exist())
            {
                return NotFound();
            }

            var policies = await _dbPolicies.GetPolicies();

            return _mapper.Map<List<PolicyDTO>>(policies);
        }

        /// <summary>
        /// Gets a specific Policy.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyDTO>> GetClient(int id)
        {
            if (!_dbPolicies.Exist())
            {
                return NotFound();
            }
            var policy = await _dbPolicies.GetPolicyById(id);

            if (policy == null)
            {
                return NotFound();
            }

            return _mapper.Map<PolicyDTO>(policy);
        }

        /// <summary>
        /// Updates a specific Policy.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicy(int id, PolicyUpdateDTO policyDTO)
        {
            var policy = _mapper.Map<Policy>(policyDTO);

            if (id != policy.Id)
            {
                return BadRequest();
            }

            _dbPolicies.UpdatePolicy(policy);

            try
            {
                await _dbPolicies.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
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
        /// Adds a specific Policy.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(PolicyCreateDTO policyDTO)
        {
            if (!_dbPolicies.Exist())
            {
                return Problem("Entity set 'ApplicationDbContext.Policies'  is null.");
            }
            var policy = _mapper.Map<Policy>(policyDTO);
            _dbPolicies.CreatePolicy(policy);
            await _dbPolicies.SaveAsync();

            var createdPolicyDto = _mapper.Map<PolicyDTO>(policy);

            return CreatedAtAction("GetPolicy", new { id = createdPolicyDto.Id }, createdPolicyDto);
        }

        /// <summary>
        /// Deletes a specific Policy.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            if (!_dbPolicies.Exist())
            {
                return NotFound();
            }
            var policy = await _dbPolicies.GetPolicyById(id);
            if (policy == null)
            {
                return NotFound();
            }

            _dbPolicies.DeletePolicy(id);
            await _dbPolicies.SaveAsync();

            return NoContent();
        }

        private bool PolicyExists(int id)
        {
            return _dbPolicies.PolicyExist(id);
        }
    }
}
