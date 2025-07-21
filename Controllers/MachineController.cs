using MachinesAPI.Models;
using MachinesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MachinesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachinesController : ControllerBase
    {
        private readonly MachineRepository _repo;

        public MachinesController(MachineRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Registers a new machine with name and location
        /// </summary>
        [HttpPost]
        public ActionResult<Machine> RegisterMachine([FromBody] Machine machine)
        {   //Need to add validation for machine
            //Need to add try catch for error handling
            var created = _repo.AddMachine(machine);
            return CreatedAtAction(nameof(GetMachineDetail), new { id = created.Id }, created);
        }

        /// <summary>
        /// Retrieves detailed information about a specific machine.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult GetMachineDetail(Guid id)
        {
            var machine = _repo.GetById(id);
            if (machine == null) return NotFound();

            var last5Logs = machine.StatusLogs
                .OrderByDescending(s => s.Timestamp)
                .Take(5);

            return Ok(new
            {
                machine.Id,
                machine.Name,
                machine.Location,
                LatestStatus = machine.StatusLogs.LastOrDefault(),
                Last5Logs = last5Logs
            });
        }

        /// <summary>
        /// Logs a status update for a specific machine.
        /// </summary>
        [HttpPost("{id}/status")]
        public IActionResult LogStatus(Guid id, [FromBody] MachineStatus status)
        {
            try
            {
                if (status == null) return BadRequest("Status cannot be null.");
                //if (status.Timestamp == default) status.Timestamp = DateTime.UtcNow;
                status.Timestamp = DateTime.UtcNow;
                var machine = _repo.GetById(id);
                if (machine == null) return NotFound();
                _repo.AddStatus(id, status);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error logging status: {ex.Message}");
            }
            

        }
        /// <summary>
        /// Retrieves a summary of all registered machines with their latest status.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<object>> GetSummary()
        {
            var summary = _repo.GetAll().Select(m => new
            {
                m.Id,
                m.Name,
                m.Location,
                LatestStatus = m.StatusLogs.OrderByDescending(s => s.Timestamp).FirstOrDefault()
            });

            return Ok(summary);
        }
     

    }
}
