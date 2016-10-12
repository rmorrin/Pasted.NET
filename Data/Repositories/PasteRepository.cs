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
        public PasteRepository (ApplicationDbContext context) : base (context) { }

        protected override IQueryable<Paste> AddIncludes(IQueryable<Paste> queryable)
        {
            return queryable.Include(p => p.Language);
        }
    }
}