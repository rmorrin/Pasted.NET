using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pasted.ViewModels.ManageViewModels
{
    public class CreatePasteViewModel
    {
        public int Language { get; set; }

        [Required]
        [MinLength(3)]
        public string Content { get; set; }
    }
}
