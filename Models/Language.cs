using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasted.Models
{
    public class Language : IdentityBase
    {
        public string Name { get; set; }
        public string PrismName { get; set; }
    }
}
