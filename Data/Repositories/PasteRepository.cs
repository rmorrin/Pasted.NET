using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pasted.Models;

namespace Pasted.Data.Repositories
{
    public class PasteRepository : GenericRepository<Paste>, IPasteRepository
    {
        private readonly ApplicationDbContext _context;

        public PasteRepository (ApplicationDbContext context) : base (context)
        {
          _context = context;
        }

        protected override IQueryable<Paste> GetQuery()
        {
            return _context.Set<Paste>().Include(p => p.Language);
        }
    }
}