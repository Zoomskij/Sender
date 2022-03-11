using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SenderApp.Models
{
    public class Config : BaseEntity
    {
        public bool IsStarted { get; set; }

    }
}
