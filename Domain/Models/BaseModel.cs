using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhoneManager.Domain.Models
{
    public abstract class BaseModel<TId>
        where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
    }
}
