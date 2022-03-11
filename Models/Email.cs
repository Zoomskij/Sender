using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SenderApp.Models
{
    public class Email : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsSended { get; set; } 

    }
}
