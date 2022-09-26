using Glossary.Infrastructure.dataAccess;
using Glossary.Infrastructure.steple.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glossary.Application.terms.command.handler
{
    public class DeleteTermDefinationCommandHandler : ICommandHandler<DeleteTermDefinationCommand>
    {
        private readonly GlossaryDbContext _context;
        public DeleteTermDefinationCommandHandler(GlossaryDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteTermDefinationCommand command)
        {
            var term = await _context.Terms.FindAsync(command.Id);
            if (term == null)
            {
                return;
            }

            _context.Terms.Remove(term);
            await _context.SaveChangesAsync();
        }
    }
}
