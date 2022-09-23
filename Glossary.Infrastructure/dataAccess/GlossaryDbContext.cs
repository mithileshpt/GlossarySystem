using Glossary.Core.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glossary.Infrastructure.dataAccess
{
    public class GlossaryDbContext : DbContext
    {
               public GlossaryDbContext(DbContextOptions<GlossaryDbContext> options) : base(options)
        {
        }

        public DbSet<Term> Terms { get; set; }
        public DbSet<Definition> Definitions { get; set; }
      
    }
}
