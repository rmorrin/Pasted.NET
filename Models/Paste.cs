using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasted.Models
{
    public class Paste : IdentityBase
    {
        public Paste()
        {
            CreatedDate = DateTime.Now;
            ExpiryDate = DateTime.Now.AddDays(3);
        }

        public string Title { get;set;}
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Private { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
