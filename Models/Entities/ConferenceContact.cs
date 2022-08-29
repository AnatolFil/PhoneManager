using System.ComponentModel.DataAnnotations;

namespace PhoneManager.Models.Entities
{
    /// <summary>
    /// Связывающий объект (связывает объекты Conference и Contact)
    /// </summary>
    public class ConferenceContact : BaseEntity<Guid>
    {
        [Required]
        public Guid ConferenceId { get; set; }

        [Required]
        public Guid ContactId { get; set; }

        public Conference Conference { get; set; }

        public Contact Contact { get; set; }
    }
}
