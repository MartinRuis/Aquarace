using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AquaraceV2.ViewModel
{
    public class CreateGroupViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public bool IsPrivate { get; set; }
    }
}