using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrintLayer.Models
{
    public class News : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
