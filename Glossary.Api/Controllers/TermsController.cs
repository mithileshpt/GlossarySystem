using Glossary.Application;
using Glossary.Application.terms.command;
using Glossary.Core.entities;
using Glossary.Infrastructure.dataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glossary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermsController : ControllerBase
    {
        private readonly GlossaryDbContext _context;
        private readonly Messages _message;

        public TermsController(GlossaryDbContext context,
            Messages message)
        {
            _context = context;
            _message = message;
            //_context.Database.EnsureCreated();
        }

        // GET: api/Terms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Term>>> GetTerms()
        {
            return await _context.Terms.ToListAsync();
        }

        // GET: api/Terms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Term>> GetTerm(int id)
        {
            var term = await _context.Terms.FindAsync(id);

            if (term == null)
            {
                return new Term();
            }

            return term;
        }

        // PUT: api/Terms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTerm(int id, UpdateTermDefinationCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await _message.Dispatch(command);
            return Ok();
        }

        // POST: api/Terms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Term>> PostTerm(AddTermDefinationCommand command)
        {
            await _message.Dispatch(command);
            return Ok();
        }

        // DELETE: api/Terms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Term>> DeleteTerm(int id)
        {
            await _message.Dispatch(new DeleteTermDefinationCommand() { Id = id });
            return Ok();
        }


    }
}
