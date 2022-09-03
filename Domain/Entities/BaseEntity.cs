using System.ComponentModel.DataAnnotations;

namespace PhoneManager.Models.Entities
{
    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        [Required]
        public virtual TId Id { get; set; }
    }
}
