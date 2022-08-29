using System.ComponentModel.DataAnnotations;

namespace PhoneManager.Models.Entities
{
    public class PhoneNumber : BaseEntity<Guid>
    {
        [Required]
        public string Number { get; set; }
    }
}
