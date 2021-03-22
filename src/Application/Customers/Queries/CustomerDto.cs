using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using ContactInterview.Application.Common.Mappings;
using ContactInterview.Domain.Entities;

namespace ContactInterview.Application.Customers.Queries
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public int Id { get; set; }
        
        public string Prefix { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string SecondLastName { get; set; }

        public string Suffix { get; set; }

        public string IdNumber { get; set; }

        public int GenderId { get; set; }

        public int MaritalStatusId { get; set; }

        public int IdentificationTypeId { get; set; }

        [NotMapped]
        public string FullName => string.Format("{0} {1} {2} {3} {4} {5}",
                       Prefix, FirstName, SecondName, LastName, SecondLastName, Suffix);

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDto>()
                .ForMember(d => d.GenderId, opt => opt.MapFrom(s => (int)s.Gender))
                .ForMember(d => d.IdentificationTypeId, opt => opt.MapFrom(s => (int)s.IdentificationType))
                .ForMember(d => d.MaritalStatusId, opt => opt.MapFrom(s => (int)s.MaritalStatus));
        }
    }
}