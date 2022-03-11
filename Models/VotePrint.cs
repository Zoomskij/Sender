using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PrintLayer.Models
{
    [Serializable]
    public class VotePrint : BaseEntity
    {
        public Guid ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image Image { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int Votes { get; set; }
    }
}
