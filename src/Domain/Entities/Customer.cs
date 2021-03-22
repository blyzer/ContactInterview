using ContactInterview.Domain.Common;
using ContactInterview.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactInterview.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        public string Prefix { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string SecondLastName { get; set; }

        public string Suffix { get; set; }

        [Required]
        public string IdNumber { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual IdentificationType IdentificationType { get; set; }

        public virtual IEnumerable<ContactInformation> ContactInformations { get; set; }

        public virtual IEnumerable<Address> Addresses { get; set; }
        
        [NotMapped]
        public string FullName => string.Format("{0} {1} {2} {3} {4} {5}",
                       Prefix, FirstName, SecondName, LastName, SecondLastName, Suffix);
    }
}
