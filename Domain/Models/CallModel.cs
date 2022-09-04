using System.ComponentModel.DataAnnotations;

namespace PhoneManager.Domain.Models
{
    /// <summary>
    /// Модель вызова (звонка)
    /// </summary>
    public class CallModel : BaseModel<Guid>
    {
        public CallModel() : base() { }

        public CallModel(Guid id) : this() { Id = id; }

        public ContactModel Caller { get; set; }

        public ContactModel Subscriber { get; set; }

        /// <summary>
        /// Начало звонка
        /// </summary>
        public DateTime CallStart { get; set; }

        /// <summary>
        /// Конец звонка
        /// </summary>
        public DateTime CallEnd { get; set; }
    }
}
