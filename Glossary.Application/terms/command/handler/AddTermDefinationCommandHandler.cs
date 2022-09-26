using Glossary.Core.entities;
using Glossary.Infrastructure.dataAccess;
using Glossary.Infrastructure.steple.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glossary.Application.terms.command.handler
{
    public class AddTermDefinationCommandHandler : ICommandHandler<AddTermDefinationCommand>
    {
        private readonly GlossaryDbContext _context;
        public AddTermDefinationCommandHandler(GlossaryDbContext context)
        {
            _context = context;
        }
        public async Task Handle(AddTermDefinationCommand command)
        {
            var term = new Term
            {
                WordOrPPhrase = command.WordOrPhrase,
                Definition = new List<Definition> {
                    new Definition {Description = command.Defination}
                }
            };

            _context.Terms.Add(term);
             await _context.SaveChangesAsync();

        }
    }
}
