using ContactInterview.Domain.Common;
using ContactInterview.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactInterview.Domain.Entities
{
    public class ContactType : AuditableEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? SortOrder { get; set; }

        public virtual ContactInformation ContactInformation { get; set; }
    }
}
