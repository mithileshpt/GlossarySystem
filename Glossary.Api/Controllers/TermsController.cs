﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Glossary.Core.entities;
using Glossary.Infrastructure.dataAccess;
using Glossary.Application.terms.command;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Glossary.Application;

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

            var term = new Term
            {
                Id = command.Id,
                WordOrPPhrase = command.WordOrPhrase,
                Definition = new List<Definition>
                {
                    new Definition { Description = command.Defination}
                }
            };
                
            _context.Entry(term).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermExists(id))
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

        // POST: api/Terms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Term>> PostTerm(AddTermDefinationCommand command)
        {
             _message.Dispatch(command);
            return Ok();
        }

        // DELETE: api/Terms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Term>> DeleteTerm(int id)
        {
            var term = await _context.Terms.FindAsync(id);
            if (term == null)
            {
                return NotFound();
            }

            _context.Terms.Remove(term);
            await _context.SaveChangesAsync();

            return term;
        }

        private bool TermExists(int id)
        {
            return _context.Terms.Any(e => e.Id == id);
        }
    }
}
