using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PhoneManager.Models.Entities
{
    public class Contact : BaseEntity<Guid>
    {
        public Guid? PhoneNumberId { get; set; }

        public PhoneNumber PhoneNumber { get; set; }

        [Required]
        public string FIO { get; set; }

        public string Address { get; set; }
    }
}
