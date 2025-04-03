using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerAPI.Data;
using ServerAPI.Models;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionsController : ControllerBase
    {
        private readonly ApiContext _context;

        public SubmissionsController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] Dictionary<string, object> submissionData)
        {
            var submission = new Submit { Data = submissionData };
            _context.Submits.Add(submission);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Submit>>> GetSubmissions()
        {
            return await _context.Submits.ToListAsync();
        }
    }
}
