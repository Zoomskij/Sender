using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintLayer.Models
{
    [Serializable]
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
