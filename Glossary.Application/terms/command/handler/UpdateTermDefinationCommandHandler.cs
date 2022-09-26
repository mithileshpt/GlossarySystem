using Glossary.Core.entities;
using Glossary.Infrastructure.dataAccess;
using Glossary.Infrastructure.steple.CQRS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glossary.Application.terms.command.handler
{
    public class UpdateTermDefinationCommandHandler : ICommandHandler<UpdateTermDefinationCommand>
    {
        private readonly GlossaryDbContext _context;
        public UpdateTermDefinationCommandHandler(GlossaryDbContext contex)
        {
            _context = contex;
        }

        public async Task Handle(UpdateTermDefinationCommand command)
        {
           

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
            catch 
            {
                if (!TermExists(command.Id))
                {
                    throw;
                }
            }

        }

        private bool TermExists(int id)
        {
            return _context.Terms.Any(e => e.Id == id);
        }
    }
}
