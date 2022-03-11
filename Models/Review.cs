using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PrintLayer.Models
{
    [Serializable]
    public class Review : BaseEntity
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public byte Grade { get; set; }
    }
}
