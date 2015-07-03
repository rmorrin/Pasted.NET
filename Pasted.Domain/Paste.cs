using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasted.Domain
{
    public class Paste : DomainBase
    {
        public Paste()
        {
            CreatedDate = DateTime.Now;
            ExpiryDate = DateTime.Now.AddDays(3);
        }

        public string Title { get;set;}
        public string Content { get; set; }
        public Language Language { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Private { get; set; }
    }
}
