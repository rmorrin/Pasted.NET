using Pasted.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasted.Services
{
    public interface IPasteService
    {
        void AddOrUpdate(Paste paste);

        IEnumerable<Paste> GetAll();

        Paste GetById(int id);
    }
}
