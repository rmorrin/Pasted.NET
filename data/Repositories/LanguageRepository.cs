using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pasted.Models;

namespace Pasted.Data.Repositories
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(ApplicationDbContext context) : base(context) { }
    }
}
