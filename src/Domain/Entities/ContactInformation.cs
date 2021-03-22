using ContactInterview.Domain.Common;
using ContactInterview.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactInterview.Domain.Entities
{
    public class ContactInformation :AuditableEntity
    {
        [Required]
        public int ContactTypeId { get; set; }

        [Required]
        public Guid PersonId { get; set; }

        public int? PhoneNumberTypeId { get; set; }

        [Required]
        public string Information { get; set; }

        public virtual Customer Person { get; set; }

        public virtual IEnumerable<ContactType> ContactType { get; set; }
    }
}
