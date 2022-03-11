using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SenderApp.Models
{
    public abstract class BaseEntity
    {
        private DateTime _createdDate;
        private DateTime _modifiedDate;
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate
        {
            get => DateTime.SpecifyKind(_createdDate, DateTimeKind.Utc);
            private set => _createdDate = value;
        }
        public DateTime ModifiedDate
        {
            get => DateTime.SpecifyKind(_modifiedDate, DateTimeKind.Utc);
            set => _modifiedDate = value;
        }
    }
}
