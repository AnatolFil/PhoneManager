using System.ComponentModel.DataAnnotations;

namespace PhoneManager.Models.Entities
{
    public class Conference : BaseEntity<Guid>
    {
        [Required]
        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
